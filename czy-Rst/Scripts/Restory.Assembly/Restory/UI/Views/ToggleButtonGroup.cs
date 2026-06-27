using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views
{
	public class ToggleButtonGroup : UIBehaviour
	{
		[SerializeField]
		private RectTransform container;

		[SerializeField]
		private List<ToggleButton> buttons = new List<ToggleButton>();

		private ToggleButtonGroupState value;

		[SerializeField]
		private bool isMultipleSelection;

		[SerializeField]
		private bool allowEmptySelection;

		public ToggleButtonGroupState Value
		{
			get
			{
				return value;
			}
			set
			{
				SetValue(value);
			}
		}

		public bool IsMultipleSelection
		{
			get
			{
				return isMultipleSelection;
			}
			set
			{
				if (isMultipleSelection != value)
				{
					ToggleButtonGroupState valueWithoutNotify = this.value;
					Span<int> activeOptionsIndices = stackalloc int[valueWithoutNotify.Length];
					Span<int> activeOptions = valueWithoutNotify.GetActiveOptions(activeOptionsIndices);
					if (activeOptions.Length > 1 && buttons.Count > 0)
					{
						valueWithoutNotify.ResetAllOptions();
						valueWithoutNotify[activeOptions[0]] = true;
						SetValueWithoutNotify(valueWithoutNotify);
					}
					isMultipleSelection = value;
				}
			}
		}

		public bool AllowEmptySelection
		{
			get
			{
				return allowEmptySelection;
			}
			set
			{
				if (allowEmptySelection == value)
				{
					return;
				}
				if (!value)
				{
					ToggleButtonGroupState valueWithoutNotify = this.value;
					Span<int> activeOptionsIndices = stackalloc int[valueWithoutNotify.Length];
					if (valueWithoutNotify.GetActiveOptions(activeOptionsIndices).Length == 0 && buttons.Count > 0)
					{
						valueWithoutNotify[0] = true;
						SetValueWithoutNotify(valueWithoutNotify);
					}
				}
				allowEmptySelection = value;
			}
		}

		public event Action<ToggleButtonGroupState> ValueChanged;

		protected override void Awake()
		{
			ToggleButtonGroupState newValue = value;
			newValue.Length = buttons.Count;
			if (newValue.Length > 0 && newValue.Data == 0L && !AllowEmptySelection)
			{
				newValue[0] = true;
				SetValue(newValue, sendCallback: false);
			}
		}

		public void SetValueWithoutNotify(ToggleButtonGroupState newValue)
		{
			if (newValue.Length == 0)
			{
				newValue = new ToggleButtonGroupState(0uL, 0);
			}
			SetValue(newValue, sendCallback: false);
		}

		private void SetValue(ToggleButtonGroupState newValue, bool sendCallback = true)
		{
			if (!Application.isPlaying || value != newValue)
			{
				value = newValue;
				UpdateButtonStates();
				if (sendCallback)
				{
					this.ValueChanged?.Invoke(value);
				}
			}
		}

		public void Add(ToggleButton button)
		{
			if (buttons.Count + 1 > 64)
			{
				Debug.LogWarning($"There can't be more than {64} buttons.");
				return;
			}
			buttons.Add(button);
			button.transform.SetParent(container, worldPositionStays: false);
			button.onClick.AddListener(delegate
			{
				OnOptionChange(button);
			});
			bool flag = false;
			ToggleButtonGroupState newValue = value;
			if (buttons.Count >= value.Length && buttons.Count <= 64)
			{
				newValue.Length = buttons.Count;
				flag = true;
			}
			if (value.Data == 0L && !AllowEmptySelection)
			{
				newValue[0] = true;
				flag = true;
			}
			if (flag)
			{
				SetValue(newValue);
			}
		}

		public void Remove(ToggleButton button)
		{
			ToggleButtonGroupState toggleButtonGroupState = value;
			int index = buttons.IndexOf(button);
			Span<int> activeOptionsIndices = stackalloc int[toggleButtonGroupState.Length];
			Span<int> activeOptions = toggleButtonGroupState.GetActiveOptions(activeOptionsIndices);
			bool flag = activeOptions.IndexOf(index) != -1;
			button.onClick.RemoveAllListeners();
			button.transform.SetParent(null);
			buttons.RemoveAt(index);
			toggleButtonGroupState.Length = buttons.Count;
			if (buttons.Count == 0)
			{
				toggleButtonGroupState.ResetAllOptions();
				SetValueWithoutNotify(toggleButtonGroupState);
			}
			else if (flag)
			{
				toggleButtonGroupState[index] = false;
				if (!AllowEmptySelection && activeOptions.Length == 1)
				{
					toggleButtonGroupState[0] = true;
				}
				SetValue(toggleButtonGroupState);
			}
		}

		public void Clear()
		{
			foreach (ToggleButton button in buttons)
			{
				button.onClick.RemoveAllListeners();
				button.transform.SetParent(null);
			}
			buttons.Clear();
			ToggleButtonGroupState newValue = value;
			newValue.Length = buttons.Count;
			newValue.ResetAllOptions();
			SetValue(newValue);
		}

		private void UpdateButtonStates()
		{
			Span<int> activeOptionsIndices = stackalloc int[value.Length];
			Span<int> activeOptions = value.GetActiveOptions(activeOptionsIndices);
			for (int i = 0; i < buttons.Count; i++)
			{
				buttons[i].IsSelected = activeOptions.IndexOf(i) != -1;
			}
		}

		private void OnOptionChange(ToggleButton button)
		{
			int num = buttons.IndexOf(button);
			ToggleButtonGroupState newValue = value;
			Span<int> activeOptionsIndices = stackalloc int[newValue.Length];
			Span<int> activeOptions = newValue.GetActiveOptions(activeOptionsIndices);
			if (IsMultipleSelection)
			{
				if (!AllowEmptySelection && activeOptions.Length == 1 && newValue[num])
				{
					return;
				}
				newValue[num] = !newValue[num];
			}
			else if (AllowEmptySelection && activeOptions.Length == 1 && newValue[activeOptions[0]])
			{
				newValue[activeOptions[0]] = false;
				if (num != activeOptions[0])
				{
					newValue[num] = true;
				}
			}
			else
			{
				newValue.ResetAllOptions();
				newValue[num] = true;
			}
			SetValue(newValue);
		}
	}
}
