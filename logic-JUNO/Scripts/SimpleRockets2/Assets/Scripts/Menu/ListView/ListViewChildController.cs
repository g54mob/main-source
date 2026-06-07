using System;
using ModApi.Ui;
using UI.Xml;

namespace Assets.Scripts.Menu.ListView
{
	public class ListViewChildController : XmlLayoutController
	{
		public virtual bool Active
		{
			get
			{
				return base.gameObject.activeInHierarchy;
			}
			set
			{
				if (value != Active)
				{
					XmlElement panelContainer = PanelContainer;
					if (value)
					{
						panelContainer.Show();
					}
					else
					{
						panelContainer.Hide();
					}
					this.ActiveChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		protected XmlElement PanelContainer => base.xmlLayout.XmlElement.parentElement;

		public event EventHandler<EventArgs> ActiveChanged;

		public void Initialize(ListViewModel viewModel, IDialog dialog)
		{
			base.gameObject.AddComponent<ListViewScript>().Initialize(base.xmlLayout, base.xmlLayout.XmlLayoutController, viewModel, null, dialog);
		}
	}
}
