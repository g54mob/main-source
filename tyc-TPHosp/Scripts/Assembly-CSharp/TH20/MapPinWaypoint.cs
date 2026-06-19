using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20
{
	internal class MapPinWaypoint : MapPinUnlockMe
	{
		[SerializeField]
		private Material _materialUnlocked;

		[SerializeField]
		private SharedInstance_TH20TH20_LevelConfig[] _levelConfigs;

		public override void OnSelected()
		{
			if (!OSManager.IsDlcInstalled(base.RequiredDLC.AppID))
			{
				base.OnSelected();
				return;
			}
			AudioManager.Instance.Play("PopOut3:UI");
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>();
			if (selectedHospitalMenu != null)
			{
				selectedHospitalMenu.CloseMenu();
			}
			SelectedWaypointMenu selectedWaypointMenu = _hud.FindMenu<SelectedWaypointMenu>();
			if (selectedWaypointMenu == null)
			{
				selectedWaypointMenu = _hud.CreateMenu<SelectedWaypointMenu>();
			}
			selectedWaypointMenu.OpenMenu();
			selectedWaypointMenu.Setup(_levelConfigs, _metagameMap, base.GUIName, base.GUIDescription);
		}

		public override void OnUnselected()
		{
			if (!OSManager.IsDlcInstalled(base.RequiredDLC.AppID))
			{
				base.OnUnselected();
				return;
			}
			SelectedWaypointMenu selectedWaypointMenu = _hud.FindMenu<SelectedWaypointMenu>(includeInactive: false);
			if (selectedWaypointMenu != null)
			{
				selectedWaypointMenu.CloseMenu();
			}
		}
	}
}
