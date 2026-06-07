using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class FlightFlyouts : IFlightFlyouts
	{
		public delegate void FlyoutNotificationDelegate(IFlyout flyout);

		private List<FlightPanelScript> _panels = new List<FlightPanelScript>();

		private IFlyout _selected;

		public IFlyout ActivitySettings { get; private set; }

		public IFlyout ChangeCraft { get; private set; }

		public FlightUIScript FlightUI { get; }

		public IFlyout Menu { get; private set; }

		public IFlyout PlayerList { get; private set; }

		public IFlyout Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					if (_selected != null)
					{
						_selected.Closed -= OnFlyoutClosed;
						_selected.Show(show: false);
						_selected = null;
					}
					_selected = value;
					if (_selected != null)
					{
						_selected.Show(show: true);
						_selected.Closed += OnFlyoutClosed;
					}
					this.SelectedFlyoutChanged?.Invoke(_selected);
				}
			}
		}

		public IFlyout SelectLocation { get; private set; }

		public IFlyout ServerSettings { get; private set; }

		public IFlyout Settings { get; private set; }

		public IFlyout SpawnCraft { get; private set; }

		public event FlyoutNotificationDelegate SelectedFlyoutChanged;

		public FlightFlyouts(FlightUIScript flightUI, Widget root)
		{
			FlightUI = flightUI;
			Menu = RegisterFlyout(root, "flyout-menu");
			Settings = RegisterFlyout(root, "flyout-settings");
			ServerSettings = RegisterFlyout(root, "flyout-server-settings");
			ChangeCraft = RegisterFlyout(root, "flyout-change-craft");
			ActivitySettings = RegisterFlyout(root, "flyout-activity-settings");
			PlayerList = RegisterFlyout(root, "flyout-player-list");
			SelectLocation = RegisterFlyout(root, "flyout-select-location");
			SpawnCraft = RegisterFlyout(root, "flyout-spawn-craft");
		}

		public IFlyout FindById(string id)
		{
			return _panels.Where((FlightPanelScript x) => x.Flyout.Id == id).FirstOrDefault()?.Flyout;
		}

		public void ToggleFlyout(IFlyout flyout)
		{
			if (Selected == flyout)
			{
				Selected = null;
			}
			else
			{
				Selected = flyout;
			}
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			if (_selected == flyout)
			{
				_selected.Closed -= OnFlyoutClosed;
				_selected = null;
				this.SelectedFlyoutChanged?.Invoke(_selected);
			}
		}

		private IFlyout RegisterFlyout(Widget root, string id)
		{
			FlightPanelScript flightPanelScript = root.FindWidget(id)?.gameObject.GetComponentInChildren<FlightPanelScript>();
			if (flightPanelScript != null)
			{
				flightPanelScript.InitializeFlightPanel(FlightUI);
			}
			else
			{
				Debug.LogError("Could not find flight panel " + id);
			}
			_panels.Add(flightPanelScript);
			return flightPanelScript.Flyout;
		}
	}
}
