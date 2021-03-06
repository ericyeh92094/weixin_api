﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace weixin_bot
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ironmandb")]
	public partial class MessageDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertMessage(Message instance);
    partial void UpdateMessage(Message instance);
    partial void DeleteMessage(Message instance);
    #endregion
		
		public MessageDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ironmandbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MessageDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessageDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessageDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessageDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Message> Messages
		{
			get
			{
				return this.GetTable<Message>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Messages")]
	public partial class Message : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _MessageID;
		
		private string _FromUserName;
		
		private string _CreateTimeWeChat;
		
		private string _MsgType;
		
		private System.Xml.Linq.XElement _ContentWeChat;
		
		private System.Nullable<bool> _Out;
		
		private string _URL;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnMessageIDChanging(string value);
    partial void OnMessageIDChanged();
    partial void OnFromUserNameChanging(string value);
    partial void OnFromUserNameChanged();
    partial void OnCreateTimeWeChatChanging(string value);
    partial void OnCreateTimeWeChatChanged();
    partial void OnMsgTypeChanging(string value);
    partial void OnMsgTypeChanged();
    partial void OnContentWeChatChanging(System.Xml.Linq.XElement value);
    partial void OnContentWeChatChanged();
    partial void OnOutChanging(System.Nullable<bool> value);
    partial void OnOutChanged();
    partial void OnURLChanging(string value);
    partial void OnURLChanged();
    #endregion
		
		public Message()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MessageID", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string MessageID
		{
			get
			{
				return this._MessageID;
			}
			set
			{
				if ((this._MessageID != value))
				{
					this.OnMessageIDChanging(value);
					this.SendPropertyChanging();
					this._MessageID = value;
					this.SendPropertyChanged("MessageID");
					this.OnMessageIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromUserName", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string FromUserName
		{
			get
			{
				return this._FromUserName;
			}
			set
			{
				if ((this._FromUserName != value))
				{
					this.OnFromUserNameChanging(value);
					this.SendPropertyChanging();
					this._FromUserName = value;
					this.SendPropertyChanged("FromUserName");
					this.OnFromUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateTimeWeChat", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string CreateTimeWeChat
		{
			get
			{
				return this._CreateTimeWeChat;
			}
			set
			{
				if ((this._CreateTimeWeChat != value))
				{
					this.OnCreateTimeWeChatChanging(value);
					this.SendPropertyChanging();
					this._CreateTimeWeChat = value;
					this.SendPropertyChanged("CreateTimeWeChat");
					this.OnCreateTimeWeChatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MsgType", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string MsgType
		{
			get
			{
				return this._MsgType;
			}
			set
			{
				if ((this._MsgType != value))
				{
					this.OnMsgTypeChanging(value);
					this.SendPropertyChanging();
					this._MsgType = value;
					this.SendPropertyChanged("MsgType");
					this.OnMsgTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContentWeChat", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
		public System.Xml.Linq.XElement ContentWeChat
		{
			get
			{
				return this._ContentWeChat;
			}
			set
			{
				if ((this._ContentWeChat != value))
				{
					this.OnContentWeChatChanging(value);
					this.SendPropertyChanging();
					this._ContentWeChat = value;
					this.SendPropertyChanged("ContentWeChat");
					this.OnContentWeChatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Out", DbType="Bit")]
		public System.Nullable<bool> Out
		{
			get
			{
				return this._Out;
			}
			set
			{
				if ((this._Out != value))
				{
					this.OnOutChanging(value);
					this.SendPropertyChanging();
					this._Out = value;
					this.SendPropertyChanged("Out");
					this.OnOutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URL", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				if ((this._URL != value))
				{
					this.OnURLChanging(value);
					this.SendPropertyChanging();
					this._URL = value;
					this.SendPropertyChanged("URL");
					this.OnURLChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
