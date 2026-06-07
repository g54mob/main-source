using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class TravelButton : MonoBehaviour
	{
		public UILabel ThreatLabel;

		private MissionControlUiManager _manager;

		private bool Reachable
		{
			get
			{
				if (_manager != null)
				{
					return _manager.GalaxyMap.SelectedLocationReachable;
				}
				return false;
			}
		}

		private bool Visitable
		{
			get
			{
				if (Reachable && _manager.SelectedLocation.Visitable)
				{
					return _manager.SelectedLocation.Sector.Explored;
				}
				return false;
			}
		}

		public void Init(MissionControlUiManager mapManager)
		{
			_manager = mapManager;
			float selectedLocationThreatIncrease = _manager.GalaxyMap.SelectedLocationThreatIncrease;
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat && Visitable)
			{
				ThreatLabel.text = LabelHelper.DarkOrange + selectedLocationThreatIncrease.ToString("F2") + "% " + LocalizationManager.GetTermTranslation("CampaignMode/Threat");
			}
			else
			{
				ThreatLabel.text = "";
			}
			if (Visitable)
			{
				GetComponent<UIButton>().SetState(UIButtonColor.State.Normal, true);
			}
		}

		public void Update()
		{
			if (!Visitable && _manager != null)
			{
				GetComponent<UIButton>().SetState(UIButtonColor.State.Disabled, true);
				base.gameObject.SetActive(!(_manager.SelectedLocation is WormHoleLocationData) || !_manager.SelectedLocation.Sector.Explored);
			}
		}

		public void OnClick()
		{
			if (Visitable)
			{
				_manager.TravelToSelectedLocation();
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (!Visitable)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneHangar/NotVisitable"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
