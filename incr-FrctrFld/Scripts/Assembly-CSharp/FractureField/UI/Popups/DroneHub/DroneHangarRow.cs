using FractureField.Drones;
using FractureField.UI.Components;
using FractureField.UI.Components.Buttons;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.DroneHub
{
	public class DroneHangarRow : MonoBehaviour
	{
		[Header("Variables")]
		public DroneType DroneType;

		[Header("References")]
		[SerializeField]
		private RText _descriptionText;

		[SerializeField]
		private TMP_Text _moveSpeedText;

		[SerializeField]
		private TMP_Text _hitSpeedText;

		[SerializeField]
		private TMP_Text _damageText;

		[SerializeField]
		private RText _slotsText;

		[SerializeField]
		private RText _limitText;

		[SerializeField]
		private TMP_InputField _targetInputField;

		[SerializeField]
		private TMP_InputField _maxInputField;

		[SerializeField]
		private RButtonComponent _increasePriorityButton;

		[SerializeField]
		private RButtonComponent _decreasePriorityButton;

		[SerializeField]
		private DroneTargetingDropdown _targetingDropdown;

		[SerializeField]
		private RComponent _upgradesGO;

		[SerializeField]
		private RButtonComponent _hideUpgradesButton;

		[SerializeField]
		private Badge _upgradesBadge;

		[SerializeField]
		private ToggleWithLabel _isEnabledToggle;

		private DroneRuleSettings _droneRule;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void Setup()
		{
		}

		private void OnTargetPercentChanged(string value)
		{
		}

		private void OnTargetPercentChanged(string value, bool triggerUpdate)
		{
		}

		private void OnMaxQuantityChanged(string value)
		{
		}

		private void OnMaxQuantityChanged(string value, bool triggerUpdate)
		{
		}

		private void UpdateDroneRule()
		{
		}

		public void ClickedIncreasePriority()
		{
		}

		public void ClickedDecreasePriority()
		{
		}

		public void ClickedToggleUpgrades()
		{
		}
	}
}
