using System;
using System.Collections.Generic;
using Data.FeatureFlags.Validators;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Data.UI.Controls
{
	[Serializable]
	public class SettingsRebindActionData
	{
		[SerializeField]
		[LocaKey]
		private string _locName;

		public bool IsHidden;

		public bool AddUISpaceAbove;

		[Header("Input")]
		public InputActionReference Action;

		public List<InputActionReference> HiddenDuplicateActions;

		public bool IsHoldAction;

		[InputBinding("Action")]
		public string ModifierBindingId;

		[InputBinding("Action")]
		public string BindingId;

		[InputBinding("Action")]
		public string AltModifierBindingId;

		[InputBinding("Action")]
		public string AltBindingId;

		[Space]
		public FeatureFlagValidator FeatureFlagValidator;

		public Action OnChanged = delegate
		{
		};

		public string GetLocalizedName()
		{
			return LocalizationUtility.GetLocalizedText(_locName);
		}

		public bool HasAltBinding()
		{
			return !string.IsNullOrEmpty(AltBindingId);
		}
	}
}
