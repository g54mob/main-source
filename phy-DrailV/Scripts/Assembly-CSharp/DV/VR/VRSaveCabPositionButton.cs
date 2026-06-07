using UnityEngine;
using UnityEngine.UI;

namespace DV.VR
{
	public class VRSaveCabPositionButton : MonoBehaviour
	{
		public Button savePositionButton;

		public Button resetPositionButton;

		private void Awake()
		{
			if (!VRManager.IsVREnabled())
			{
				savePositionButton.gameObject.SetActive(value: false);
				resetPositionButton.gameObject.SetActive(value: false);
				return;
			}
			PlayerManager.CarChanged += OnCarChanged;
			OnCarChanged(PlayerManager.Car);
			savePositionButton.onClick.AddListener(Save);
			resetPositionButton.onClick.AddListener(Reset);
		}

		private void Save()
		{
			PlayerCabPositionManager.SavePosition();
			CheckResetState();
		}

		private void Reset()
		{
			PlayerCabPositionManager.ClearPosition(PlayerManager.Car.carLivery.parentType, isVR: true);
			CheckResetState();
		}

		private void CheckSaveState()
		{
			savePositionButton.gameObject.SetActive((bool)PlayerManager.Car && (bool)PlayerManager.Car.cabTeleportDestination);
		}

		private void CheckResetState()
		{
			resetPositionButton.gameObject.SetActive((bool)PlayerManager.Car && (bool)PlayerManager.Car.cabTeleportDestination && PlayerCabPositionManager.TryLoadPosition(PlayerManager.Car.carLivery.parentType, isVR: true, out var _));
		}

		private void OnCarChanged(TrainCar car)
		{
			CheckSaveState();
			CheckResetState();
		}

		private void OnDestroy()
		{
			PlayerManager.CarChanged -= OnCarChanged;
			if ((bool)savePositionButton)
			{
				savePositionButton.onClick.RemoveListener(Save);
			}
			if ((bool)resetPositionButton)
			{
				resetPositionButton.onClick.RemoveListener(Reset);
			}
		}
	}
}
