using System;
using FractureField.Shared.Enums;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace FractureField.UI.Components.Buttons
{
	[ExecuteInEditMode]
	public class RButtonComponent : RButton
	{
		[Header("Button Variables")]
		public ButtonType Type;

		[SerializeField]
		private ButtonColor _color;

		[SerializeField]
		private Color _customColor;

		[SerializeField]
		private string _text;

		[SerializeField]
		private int _textSize;

		[Header("Button References")]
		public RText Text;

		public IconWithText IconWithText;

		public CurrencyCost CurrencyCost;

		[Header("Optional References")]
		[SerializeField]
		private LayoutElement _layoutElement;

		[SerializeField]
		private Image _lightContainer;

		[SerializeField]
		private Image _darkContainer;

		[SerializeField]
		private LocalizeStringEvent _locStringEvent;

		private Color Color => default(Color);

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}

		public void SetType(ButtonType type)
		{
		}

		private void OnTypeChanged()
		{
		}

		private void OnBackgroundColorChanged()
		{
		}

		protected override void OnIsDisabledChanged()
		{
		}

		public void SetDisabled(bool isDisabled)
		{
		}

		public void SetDisabled(Func<bool> getter)
		{
		}

		public void SetClickDisabled(bool isClickDisabled)
		{
		}

		public void SetClickDisabled(Func<bool> getter)
		{
		}

		public void SetText(string text, bool logWarning = true)
		{
		}

		public void SetText(Func<string> getter, bool logWarning = true)
		{
		}

		public void SetFontSize(float fontSize, bool logWarning = true)
		{
		}

		public void SetFontSize(Func<float> getter, bool logWarning = true)
		{
		}

		public void SetTextColor(Color color, bool logWarning = true)
		{
		}

		public void SetTextColor(Func<Color> getter, bool logWarning = true)
		{
		}

		public void SetIcon(Sprite sprite, bool logWarning = true)
		{
		}

		public void SetIcon(Func<Sprite> getter, bool logWarning = true)
		{
		}

		public void SetCurrency(CurrencyType currencyType, bool logWarning = true)
		{
		}

		public void SetCost(string cost, bool logWarning = true)
		{
		}

		public void SetCost(Func<string> getter, bool logWarning = true)
		{
		}

		public void SetColor(ButtonColor color)
		{
		}

		public void SetColor(string hex)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void SetColor(Func<Color> getter)
		{
		}

		public void SetMinimumWidth(float width)
		{
		}

		public void SetMinimumHeight(float height)
		{
		}

		public void SetPreferredWidth(float width)
		{
		}

		public void SetPreferredHeight(float height)
		{
		}

		public void SetImage(Sprite sprite, bool isSliced = true)
		{
		}

		private void OnValidate()
		{
		}
	}
}
