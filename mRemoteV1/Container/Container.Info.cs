using System;
using System.Windows.Forms;
using mRemoteNG.Tools;
using System.ComponentModel;
using mRemoteNG.Connection;


namespace mRemoteNG.Container
{
	[DefaultProperty("Name")]
    public class Info
	{
        #region Properties
        [LocalizedAttributes.LocalizedCategory("strCategoryDisplay", 1), 
            Browsable(true), 
            ReadOnly(false), 
            Bindable(false), 
            DefaultValue(""), 
            DesignOnly(false),
            LocalizedAttributes.LocalizedDisplayName("strPropertyNameName"),
            LocalizedAttributes.LocalizedDescription("strPropertyDescriptionName")]
        public string Name
		{
			get { return ConnectionRecord.Name; }
			set { ConnectionRecord.Name = value; }
		}
			
		private TreeNode _TreeNode;
        [Category(""), 
            Browsable(false), 
            ReadOnly(false), 
            Bindable(false), 
            DefaultValue(""), 
            DesignOnly(false)]
        public TreeNode TreeNode
		{
			get { return this._TreeNode; }
			set { this._TreeNode = value; }
		}
			
		private object _Parent;
        [Category(""), 
            Browsable(false)]
        public object Parent
		{
			get { return this._Parent; }
			set { this._Parent = value; }
		}
			
		//Private _GlobalID As Integer = 0
		//<Category(""), _
		//    Browsable(False)> _
		//Public Property GlobalID() As Integer
		//    Get
		//        Return _GlobalID
		//    End Get
		//    Set(ByVal value As Integer)
		//        _GlobalID = value
		//    End Set
		//End Property
			
		private bool _IsExpanded;
        [Category(""), 
            Browsable(false), 
            ReadOnly(false), 
            Bindable(false), 
            DefaultValue(""), 
            DesignOnly(false)]
        public bool IsExpanded
		{
			get { return this._IsExpanded; }
			set { this._IsExpanded = value; }
		}

        private ConnectionRecord _ConnectionInfo = new ConnectionRecordImp();
        public ConnectionRecord ConnectionRecord
		{
			get { return this._ConnectionInfo; }
			set { this._ConnectionInfo = value; }
		}
        #endregion
			
        #region Methods
		public Container.Info Copy()
		{
			return (Info)this.MemberwiseClone();
		}
			
		public Info()
		{
			this.SetDefaults();
		}
			
		public void SetDefaults()
		{
			if (this.IsExpanded == null)
			{
				this.IsExpanded = true;
			}
		}
        #endregion
	}
}