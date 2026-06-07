using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.FactoryFloor.Toolbar
{
	[CreateAssetMenu(menuName = "UI/GameplayTooltipEventSO", fileName = "GameplayTooltipEventSO", order = 0)]
	public class GameplayTooltipEventSO : ScriptableObject
	{
		public bool IsActive { get; private set; }

		public string LocalizationKey { get; private set; }

		public InputActionReference[] InputActions { get; private set; }

		public event Action<bool> ActiveStateChanged = delegate
		{
		};

		public event Action<string> LocalizationKeyChanged = delegate
		{
		};

		public void SetActiveState(bool isActive)
		{
			IsActive = isActive;
			this.ActiveStateChanged(isActive);
		}

		public void SetLocalizationKey(string localizationKey, InputActionReference[] inputActions = null)
		{
			LocalizationKey = localizationKey;
			InputActions = inputActions;
			this.LocalizationKeyChanged(localizationKey);
		}
	}
}
