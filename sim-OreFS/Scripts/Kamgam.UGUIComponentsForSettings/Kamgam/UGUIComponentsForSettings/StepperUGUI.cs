using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class StepperUGUI : MonoBehaviour
	{
		public delegate void OnValueChangedDelegate(float value);

		public UnityEvent<float> OnValueChangedEvent;

		public OnValueChangedDelegate OnValueChanged;

		public float MinValue;

		public float MaxValue = 100f;

		public float StepSize = 10f;

		public bool WholeNumbers = true;

		public GameObject StepTemplate;

		public GameObject StepsContainer;

		[NonSerialized]
		protected List<StepperStepConsoleUGUI> _steps = new List<StepperStepConsoleUGUI>();

		public string ValueFormat = "{0:N0} %";

		[Tooltip("Should the buttons be disabled if the limits (min,max) are reached?")]
		public bool DisableButtons = true;

		public Button DecreaseButton;

		public Button IncreaseButton;

		protected AutoNavigationOverrides decreaseButtonNavigationOverrides;

		protected AutoNavigationOverrides increaseButtonNavigationOverrides;

		protected float _value;

		public TextMeshProUGUI TextTf;

		public TextMeshProUGUI ValueTf;

		[SerializeField]
		[Tooltip("If enabled and if this is selected (has focus) then the descrease/increase action will be triggered by keyboard/controller navigation too.\nNOTICE: This also means it will deny left/right selection navigation away from this is object. Useful for console type UIs.")]
		protected bool _enableButtonControls;

		protected AutoNavigationOverrides _autoNavigationOverrides;

		protected Selectable _selectable;

		public bool ShowSteps
		{
			get
			{
				if (StepsContainer != null)
				{
					return StepTemplate != null;
				}
				return false;
			}
		}

		public float StepCountFloat => (MaxValue - MinValue) / StepSize;

		public int StepCount => Mathf.CeilToInt((MaxValue - MinValue - 0.001f) / StepSize);

		public AutoNavigationOverrides DecreaseButtonNavigationOverrides
		{
			get
			{
				if (DecreaseButton == null)
				{
					return null;
				}
				if (decreaseButtonNavigationOverrides == null)
				{
					decreaseButtonNavigationOverrides = DecreaseButton.GetComponent<AutoNavigationOverrides>();
				}
				return decreaseButtonNavigationOverrides;
			}
		}

		public AutoNavigationOverrides IncreaseButtonNavigationOverrides
		{
			get
			{
				if (IncreaseButton == null)
				{
					return null;
				}
				if (increaseButtonNavigationOverrides == null)
				{
					increaseButtonNavigationOverrides = IncreaseButton.GetComponent<AutoNavigationOverrides>();
				}
				return increaseButtonNavigationOverrides;
			}
		}

		public float Value
		{
			get
			{
				if (!WholeNumbers)
				{
					return _value;
				}
				return Mathf.Round(_value);
			}
			set
			{
				if (!(Mathf.Abs(_value - value) <= Mathf.Epsilon))
				{
					updateValue(value);
					updateButtons();
				}
			}
		}

		public int IntValue => Mathf.RoundToInt(_value);

		public string Text
		{
			get
			{
				return TextTf.text;
			}
			set
			{
				if (!(value == Text))
				{
					updateText(value);
					updateButtons();
				}
			}
		}

		public bool EnableButtonControls
		{
			get
			{
				return _enableButtonControls;
			}
			set
			{
				if (AutoNavigationOverrides != null)
				{
					AutoNavigationOverrides.BlockLeft = EnableButtonControls;
					AutoNavigationOverrides.BlockRight = EnableButtonControls;
				}
			}
		}

		public AutoNavigationOverrides AutoNavigationOverrides
		{
			get
			{
				if (_autoNavigationOverrides == null)
				{
					_autoNavigationOverrides = GetComponent<AutoNavigationOverrides>();
				}
				return _autoNavigationOverrides;
			}
		}

		public Selectable Selectable
		{
			get
			{
				if (_selectable == null)
				{
					_selectable = GetComponent<Selectable>();
				}
				return _selectable;
			}
		}

		protected void updateValue(float value)
		{
			float value2 = (WholeNumbers ? Mathf.Round(value) : value);
			value2 = ConvertToStepValue(value2);
			_value = Mathf.Clamp(value2, MinValue, MaxValue);
			ValueTf.text = string.Format(ValueFormat, _value);
			if (ShowSteps)
			{
				if (!hasValidSteps())
				{
					_steps = StepperStepConsoleUGUI.CreateSteps(StepsContainer.transform, StepTemplate, StepCount);
				}
				int stepToDisplay = GetStepToDisplay(Value);
				StepperStepConsoleUGUI.SetActive(_steps, stepToDisplay);
			}
		}

		public void Refresh()
		{
			updateValue(Value);
		}

		protected bool hasValidSteps()
		{
			if (_steps == null || _steps.Count != StepCount)
			{
				return false;
			}
			return true;
		}

		protected void updateText(string text)
		{
			TextTf.text = text;
		}

		public void OnEnable()
		{
			EnableButtonControls = _enableButtonControls;
			updateText(Text);
			updateValue(Value);
			updateButtons();
		}

		public virtual void Update()
		{
			if (EnableButtonControls && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == Selectable.gameObject)
			{
				if (InputUtils.LeftPressed())
				{
					Decrease();
				}
				else if (InputUtils.RightPressed())
				{
					Increase();
				}
			}
		}

		public float ConvertToStepValue(float value)
		{
			float num = float.MaxValue;
			float num2 = value;
			float num3 = MinValue;
			int num4 = Mathf.CeilToInt((MaxValue - MinValue) / StepSize) + 1;
			for (int i = 0; i < num4; i++)
			{
				float num5 = Mathf.Abs(value - num3);
				if (num5 < num)
				{
					num = num5;
					num2 = num3;
				}
				num3 += StepSize;
			}
			if (WholeNumbers)
			{
				num2 = Mathf.Round(num2);
			}
			return num2;
		}

		public int GetStepToDisplay(float value)
		{
			if (value > MaxValue - StepSize * 0.5f)
			{
				return Mathf.CeilToInt((MaxValue - MinValue) / StepSize);
			}
			return Mathf.RoundToInt((value - MinValue + 0.499f * StepSize) / StepSize);
		}

		public void Increase()
		{
			Step(1);
		}

		public void IncreaseLooped()
		{
			if (_value > MaxValue - StepSize * 0.1f)
			{
				Step(-Mathf.CeilToInt(StepCountFloat));
			}
			else
			{
				Increase();
			}
		}

		public void Decrease()
		{
			Step(-1);
		}

		public void Step(int steps)
		{
			Value = Mathf.Clamp(_value + (float)steps * StepSize, MinValue, MaxValue);
			if (steps != 0)
			{
				OnValueChangedEvent?.Invoke(Value);
				OnValueChanged?.Invoke(Value);
			}
		}

		protected void updateButtons()
		{
			if (!DisableButtons)
			{
				if (DecreaseButton != null)
				{
					DecreaseButton.enabled = true;
				}
				if (IncreaseButton != null)
				{
					IncreaseButton.enabled = true;
				}
				return;
			}
			bool interactable = Mathf.Abs(_value - MaxValue) > float.Epsilon;
			if (IncreaseButton != null)
			{
				IncreaseButton.interactable = interactable;
			}
			bool interactable2 = Mathf.Abs(_value - MinValue) > float.Epsilon;
			if (DecreaseButton != null)
			{
				DecreaseButton.interactable = interactable2;
			}
		}

		public void SetSelected()
		{
			if (Selectable != null && EventSystem.current != null)
			{
				EventSystem.current.SetSelectedGameObject(Selectable.gameObject);
			}
		}
	}
}
