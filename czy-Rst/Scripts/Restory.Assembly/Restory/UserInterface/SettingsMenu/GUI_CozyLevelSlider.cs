using System;
using System.Collections.Generic;
using Restory.Gameplay.GameSettings;
using Restory.UserInterface.CommonElements;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.SettingsMenu
{
	public class GUI_CozyLevelSlider : SerializedMonoBehaviour
	{
		[Serializable]
		private struct CozyLevelValue
		{
			public Sprite Icon;

			public string NameLocKey;

			public string DescriptionLocKey;
		}

		[SerializeField]
		private Image icon;

		[SerializeField]
		private GUI_LocalisedText nameText;

		[SerializeField]
		private GUI_LocalisedText descriptionText;

		[SerializeField]
		private GUI_ElementDescription elementDescriptionText;

		[SerializeField]
		private GUI_BaseSlider slider;

		[SerializeField]
		private Dictionary<CozyLevel, CozyLevelValue> values = new Dictionary<CozyLevel, CozyLevelValue>();

		public CozyLevel Value
		{
			get
			{
				return (CozyLevel)slider.Value;
			}
			set
			{
				slider.Value = (float)value;
			}
		}

		public event UnityAction<CozyLevel> OnValueChanged;

		private void Awake()
		{
			slider.MinValue = 0f;
			slider.MaxValue = Enum.GetValues(typeof(CozyLevel)).Length - 1;
		}

		private void OnEnable()
		{
			slider.OnValueChanged += Slider_OnValueChanged;
			UpdateView();
		}

		private void OnDisable()
		{
			slider.OnValueChanged -= Slider_OnValueChanged;
		}

		private void Slider_OnValueChanged(float value)
		{
			UpdateView();
			this.OnValueChanged?.Invoke(Value);
		}

		private void UpdateView()
		{
			if (values.TryGetValue(Value, out var value))
			{
				icon.sprite = value.Icon;
				nameText.LocalizationID = value.NameLocKey;
				GUI_LocalisedText gUI_LocalisedText = descriptionText;
				string localizationID = (elementDescriptionText.Description = value.DescriptionLocKey);
				gUI_LocalisedText.LocalizationID = localizationID;
			}
		}

		public void SetValueWithoutNotify(CozyLevel cozyLevel)
		{
			slider.SetValueWithoutNotify((float)cozyLevel);
		}
	}
}
