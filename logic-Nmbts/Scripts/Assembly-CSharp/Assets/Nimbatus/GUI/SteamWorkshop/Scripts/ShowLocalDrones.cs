using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class ShowLocalDrones : MonoBehaviour
	{
		[HideInInspector]
		public DroneData SelectedDroneData;

		public LocalDroneList List;

		private DroneUploadPanel _panel;

		public void Init(DroneUploadPanel droneUploadPanel)
		{
			_panel = droneUploadPanel;
			SelectedDroneData = null;
			List.gameObject.SetActive(false);
		}

		public void OnClick()
		{
			List.SelectedDroneChanged += OnDroneSelected;
			List.Init();
			List.gameObject.SetActive(true);
		}

		public void OnDroneSelected()
		{
			SelectedDroneData = List.SelectedDrone;
			List.gameObject.SetActive(false);
			_panel.UpdateFromDrone(List.SelectedDrone);
			List.SelectedDroneChanged -= OnDroneSelected;
		}
	}
}
