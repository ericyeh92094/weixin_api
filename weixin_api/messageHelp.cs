﻿using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;

namespace weixin_api
{
    /// <summary>
    /// 接受/发送消息帮助类
    /// </summary>
    public class messageHelp
    {
        //返回消息
        public async Task<string> ReturnMessage(string postStr)
        {
            string responseContent = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(postStr)));
            XmlNode MsgType = xmldoc.SelectSingleNode("/xml/MsgType");
            if (MsgType != null)
            {
                switch (MsgType.InnerText)
                {
                    case "event":
                        responseContent = EventHandle(xmldoc);//事件处理
                        break;
                    case "text":
                        responseContent = await TextHandle(xmldoc);//接受文本消息处理
                        break;
                    default:
                        break;
                }
            }
            return responseContent;
        }
        //事件
        public string EventHandle(XmlDocument xmldoc)
        {
            string responseContent = "";
            XmlNode Event = xmldoc.SelectSingleNode("/xml/Event");
            XmlNode EventKey = xmldoc.SelectSingleNode("/xml/EventKey");
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            if (Event!=null)
            {
                //菜单单击事件
                if (Event.InnerText.Equals("CLICK"))
                {
                    if (EventKey.InnerText.Equals("click_one"))//click_one
                    {
                        responseContent = string.Format(ReplyType.Message_Text,
                            FromUserName.InnerText,
                            ToUserName.InnerText, 
                            DateTime.Now.Ticks, 
                            "你点击的是click_one");
                    }
                    else if (EventKey.InnerText.Equals("click_two"))//click_two
                    {
                        responseContent = string.Format(ReplyType.Message_News_Main, 
                            FromUserName.InnerText, 
                            ToUserName.InnerText, 
                            DateTime.Now.Ticks, 
                            "2",
                             string.Format(ReplyType.Message_News_Item,"我要寄件","",
                             "http://www.soso.com/orderPlace.jpg",
                             "http://www.soso.com/")+
                             string.Format(ReplyType.Message_News_Item, "订单管理", "",
                             "http://www.soso.com/orderManage.jpg",
                             "http://www.soso.com/"));
                    }
                    else if (EventKey.InnerText.Equals("click_three"))//click_three
                    {
                        responseContent = string.Format(ReplyType.Message_News_Main,
                            FromUserName.InnerText,
                            ToUserName.InnerText,
                            DateTime.Now.Ticks,
                            "1",
                             string.Format(ReplyType.Message_News_Item, "标题", "摘要",
                             "http://www.soso.com/jieshao.jpg",
                             "http://www.soso.com/"));
                    }
                }
            }
            return responseContent;
        }
        //接受文本消息
        public async Task<string> TextHandle(XmlDocument xmldoc)
        {
            string responseContent = "";
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            XmlNode Content = xmldoc.SelectSingleNode("/xml/Content");
            if (Content != null)
            {

                LuisHelp cognitive = new weixin_api.LuisHelp();
                string CarCaringString;
                CarCaringLUIS carLUIS = await LuisHelp.GetEntityFromLUIS(Content.InnerText);
                if (carLUIS.intents.Count() > 0)
                {
                    Intent maxscore_intent = carLUIS.intents.Max();

                    switch (maxscore_intent.intent)
                    {
                        case "StoreLocation":
                            CarCaringString = cognitive.GetStoreLocation(carLUIS);
                            break;
                        case "CheckPrice":
                            CarCaringString = cognitive.GetPrice(carLUIS);
                            break;
                        case "CheckItem":
                            CarCaringString = cognitive.GetItem(carLUIS);
                            break;
                        case "News":
                            CarCaringString = cognitive.GetNews(carLUIS);
                            break;
                        case "Tips":
                            CarCaringString = cognitive.GetTips(carLUIS);
                            break;
                        default:
                            CarCaringString = "您可以到网站去查询我门的最新讯息。";

                            responseContent = string.Format(ReplyType.Message_News_Main,
                                FromUserName.InnerText,
                                ToUserName.InnerText,
                                DateTime.Now.Ticks,
                                "1",
                                string.Format(ReplyType.Message_News_Item, "佳通新闻", "您可以询问附近的保修站，轮胎商品或是保养知识；或到网站去查询我门的最新讯息。",
                                "http://www.giti.com/Content/cn/Images/288-15day.png",
                                "http://www.giti.com/"));

                            return responseContent;
                            break;
                    }
                }
                else
                {
                    CarCaringString = "您可以到网站去查询我门的最新讯息。";
                }
                responseContent = string.Format(ReplyType.Message_Text, 
                    FromUserName.InnerText, 
                    ToUserName.InnerText, 
                    DateTime.Now.Ticks, CarCaringString);
            }
            return responseContent;
        }

        //写入日志
        public void WriteLog(string text)
        {
            StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(".") + "\\log.txt", true);
            sw.WriteLine(text);
            sw.Close();//写入
        }
    }

    //回复类型
    public class ReplyType
    {
        /// <summary>
        /// 普通文本消息
        /// </summary>
        public static string Message_Text
        {
            get { return @"<xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[text]]></MsgType>
                            <Content><![CDATA[{3}]]></Content>
                            </xml>"; }
        }
        /// <summary>
        /// 图文消息主体
        /// </summary>
        public static string Message_News_Main
        {
            get
            {
                return @"<xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[news]]></MsgType>
                            <ArticleCount>{3}</ArticleCount>
                            <Articles>
                            {4}
                            </Articles>
                            </xml> ";
            }
        }
        /// <summary>
        /// 图文消息项
        /// </summary>
        public static string Message_News_Item
        {
            get
            {
                return @"<item>
                            <Title><![CDATA[{0}]]></Title> 
                            <Description><![CDATA[{1}]]></Description>
                            <PicUrl><![CDATA[{2}]]></PicUrl>
                            <Url><![CDATA[{3}]]></Url>
                            </item>";
            }
        }
    }
}