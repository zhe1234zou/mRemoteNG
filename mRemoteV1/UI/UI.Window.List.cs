using System.Collections;
using System.Windows.Forms;



namespace mRemoteNG.UI.Window
{
	public class List : CollectionBase
	{
        #region Public Properties
        public UI.Window.Base this[object Index]
		{
			get
			{
				this.CleanUp();
				if (Index is UI.Window.Base)
				{
					if (Index as UI.Window.Base != null)
					{
                        return (UI.Window.Base)Index;
					}
				}
				else
				{
					if (List.Count - 1 >= (int)Index)
					{
						if (List[System.Convert.ToInt32(Index)] != null)
						{
							return List[System.Convert.ToInt32(Index)] as UI.Window.Base;
						}
					}
				}
						
				return null;
			}
		}
				
        public new int Count
		{
			get
			{
				this.CleanUp();
				return List.Count;
			}
		}
        #endregion
				
        #region Public Methods
		public void Add(UI.Window.Base uiWindow)
		{
			this.List.Add(uiWindow);
			//AddHandler uiWindow.FormClosing, AddressOf uiFormClosing
		}
				
		public void AddRange(UI.Window.Base[] uiWindow)
		{
			foreach (Form uW in uiWindow)
			{
				this.List.Add(uW);
			}
		}
				
		public void Remove(UI.Window.Base uiWindow)
		{
			this.List.Remove(uiWindow);
		}
				
		public UI.Window.Base FromString(string uiWindow)
		{
			this.CleanUp();
					
			for (int i = 0; i <= this.List.Count - 1; i++)
			{
				if (this[i].Text == uiWindow.Replace("&", "&&"))
				{
					return this[i];
				}
			}
					
			return null;
		}
        #endregion
				
        #region Private Methods
		private void CleanUp()
		{
			for (int i = 0; i <= this.List.Count - 1; i++)
			{
				if (i > this.List.Count - 1)
				{
					CleanUp();
					return;
				}
				if ((this.List[i] as UI.Window.Base).IsDisposed)
				{
					this.List.RemoveAt(i);
					CleanUp();
					return;
				}
			}
		}
        #endregion
				
        #region Event Handlers
		private void uiFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			this.List.Remove(sender);
		}
        #endregion
	}
}
