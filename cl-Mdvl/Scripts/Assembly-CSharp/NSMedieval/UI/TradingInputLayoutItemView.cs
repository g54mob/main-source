using System;
using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TradingInputLayoutItemView : LayoutGroupItemView
	{
		private const int InputIndex = 0;

		private const int MinusButtonIndex = 1;

		private const int PlusButtonIndex = 2;

		private SafeTMP_InputField inputField;

		private bool interactable = true;

		private int maxTradeValue;

		private int minTradeValue;

		private int tradeValue;

		public int TradeValue => tradeValue;

		public int MaxTradeValue => maxTradeValue;

		private SoundButton MinusButton => base.GroupItems[1].GetComponent<SoundButton>();

		private SoundButton PlusButton => base.GroupItems[2].GetComponent<SoundButton>();

		public SafeTMP_InputField InputField
		{
			get
			{
				if (inputField == null)
				{
					inputField = base.GroupItems[0].GetComponent<SafeTMP_InputField>();
				}
				return inputField;
			}
		}

		public event Action<int> AmountChangedEvent;

		public event Action<int> PreAmountChangedEvent;

		private void Start()
		{
			PlusButton.onClick.AddListener(delegate
			{
				OnButtonClick(1);
			});
			MinusButton.onClick.AddListener(delegate
			{
				OnButtonClick(-1);
			});
			InputField.onValueChanged.AddListener(OnValueChanged);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.AmountChangedEvent = null;
			this.PreAmountChangedEvent = null;
		}

		public void SetTradeValue(int tradeValue)
		{
			this.tradeValue = tradeValue;
			UpdateInputDisplay();
		}

		public void SetMinMax(int min, int max)
		{
			minTradeValue = min;
			maxTradeValue = max;
			UpdateInputDisplay();
		}

		public void SetInteractable(bool interactable, bool leaveButtonsVisibleIfDisabled = false)
		{
			this.interactable = interactable;
			SetInteractable(interactable, PlusButton, leaveButtonsVisibleIfDisabled);
			SetInteractable(interactable, MinusButton, leaveButtonsVisibleIfDisabled);
			InputField.interactable = interactable;
		}

		private void OnValueChanged(string newValue)
		{
			if (newValue.Equals("-") || newValue.Equals(tradeValue.ToString()))
			{
				return;
			}
			string text = tradeValue.ToString();
			try
			{
				int.TryParse(newValue, out tradeValue);
				ClampValue();
				UpdateInputDisplay();
				TradeValueChanged();
			}
			catch (Exception)
			{
				InputField.text = text;
			}
		}

		private void UpdateInputDisplay()
		{
			InputField.text = tradeValue.ToString();
			SetInteractable(interactable && tradeValue < maxTradeValue, PlusButton);
			SetInteractable(interactable && tradeValue > minTradeValue, MinusButton);
		}

		private void OnButtonClick(int value)
		{
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				value *= 100;
			}
			else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
			{
				value *= 10;
			}
			tradeValue += value;
			ClampValue();
			UpdateInputDisplay();
			TradeValueChanged();
		}

		private void ClampValue()
		{
			tradeValue = Math.Max(Math.Min(tradeValue, maxTradeValue), minTradeValue);
		}

		private void TradeValueChanged()
		{
			this.PreAmountChangedEvent?.Invoke(tradeValue);
			this.AmountChangedEvent?.Invoke(tradeValue);
		}

		private void SetInteractable(bool interactable, SoundButton button, bool leaveVisibleIfDisabled = false)
		{
			CanvasGroup component = button.GetComponent<CanvasGroup>();
			component.alpha = ((interactable || leaveVisibleIfDisabled) ? 1 : 0);
			component.interactable = interactable;
			TooltipViewNew component2 = button.GetComponent<TooltipViewNew>();
			if (!(component2 == null))
			{
				component2.SetEnabled(interactable);
			}
		}
	}
}
