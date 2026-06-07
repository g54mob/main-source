using FractureField.Drones;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.DroneHub
{
	public class DroneTargetingDropdown : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private TMP_Dropdown _modeDropdown;

		[SerializeField]
		private TMP_Dropdown _layerDropdown;

		[SerializeField]
		private GameObject _layerDropdownContainer;

		private DroneType _droneType;

		private DroneTargetSettings _targetSettings;

		private bool _isUpdating;

		public void Setup(DroneType droneType)
		{
		}

		private void SetupModeDropdown()
		{
		}

		private void SetupLayerDropdown()
		{
		}

		private void UpdateUI()
		{
		}

		private void OnModeChanged(int value)
		{
		}

		private void OnLayerChanged(int value)
		{
		}
	}
}
