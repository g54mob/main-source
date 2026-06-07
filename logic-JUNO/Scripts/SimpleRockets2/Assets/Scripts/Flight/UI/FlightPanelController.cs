using System;
using Assets.Scripts.Flight.Sim;
using UI.Xml;

namespace Assets.Scripts.Flight.UI
{
	public class FlightPanelController : XmlLayoutController
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

		public CraftNode CraftNode => FlightSceneUiController.CraftNode;

		protected FlightSceneUiController FlightSceneUiController { get; private set; }

		protected XmlElement PanelContainer => base.xmlLayout.XmlElement.parentElement;

		public event EventHandler<EventArgs> ActiveChanged;

		public virtual void CraftNodeChanged(CraftNode craftNode)
		{
		}

		public virtual void CraftStructureChanged(CraftNode craftNode)
		{
		}

		public virtual void Initialize(FlightSceneUiController flightSceneUiController)
		{
			FlightSceneUiController = flightSceneUiController;
		}

		public virtual void LateUpdatePanel(CraftNode craftNode)
		{
		}

		public virtual void StartPanel()
		{
		}

		public virtual void UpdatePanel(CraftNode craftNode)
		{
		}
	}
}
