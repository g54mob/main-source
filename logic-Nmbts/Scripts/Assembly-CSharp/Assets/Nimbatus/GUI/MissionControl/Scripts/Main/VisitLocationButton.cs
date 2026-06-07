using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class VisitLocationButton : MonoBehaviour
	{
		private MissionControlUiManager _manager;

		private bool Visitable
		{
			get
			{
				if (_manager != null && _manager.SelectedLocation.Visitable)
				{
					return _manager.SelectedLocation.Sector.Explored;
				}
				return false;
			}
		}

		public void Init(MissionControlUiManager mapManager)
		{
			_manager = mapManager;
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
				_manager.VisitCurrentLocation();
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
