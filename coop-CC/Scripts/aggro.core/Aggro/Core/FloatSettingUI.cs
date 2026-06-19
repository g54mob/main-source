using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Aggro.Core
{
	public class FloatSettingUI : AggroSettingUI
	{
		public GameObject inputContainer;

		public TMP_InputField input;

		public Slider slider;

		public EventReference sliderChangeSfx;

		public EventReference sliderZeroSfx;

		private FloatSetting _setting;

		private bool _ignoreSets;

		private bool _playSfx;

		public override void Set(AggroSettingBase setting)
		{
			if (setting is FloatSetting floatSetting)
			{
				_setting = floatSetting;
				_ignoreSets = true;
				slider.minValue = floatSetting.min;
				slider.maxValue = floatSetting.max;
				slider.SetValueWithoutNotify(floatSetting.value);
				_ignoreSets = false;
				switch (_setting.style)
				{
				case FloatSetting.Style.Number:
					inputContainer.SetActive(value: true);
					input.contentType = TMP_InputField.ContentType.DecimalNumber;
					break;
				case FloatSetting.Style.Percentage:
					inputContainer.SetActive(value: true);
					input.contentType = TMP_InputField.ContentType.Standard;
					break;
				case FloatSetting.Style.NoInputField:
					inputContainer.SetActive(value: false);
					break;
				case FloatSetting.Style.Integer:
					inputContainer.SetActive(value: true);
					input.contentType = TMP_InputField.ContentType.IntegerNumber;
					slider.wholeNumbers = true;
					break;
				default:
					throw new InvalidEnumException();
				}
				SetInputWithoutNotify();
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for FloatSettingUI!");
			}
		}

		public override void Refresh()
		{
			slider.SetValueWithoutNotify(_setting.value);
			SetInputWithoutNotify();
		}

		private void Update()
		{
			if (!_playSfx)
			{
				return;
			}
			if (Mouse.current != null)
			{
				if (!Mouse.current.leftButton.isPressed)
				{
					_playSfx = false;
					PlaySfx();
				}
			}
			else
			{
				_playSfx = false;
			}
		}

		public void OnSliderChanged(float value)
		{
			if (!_ignoreSets)
			{
				_setting.SetValue(value);
				_setting.Save();
				if (_setting.style != FloatSetting.Style.NoInputField)
				{
					SetInputWithoutNotify();
				}
				if (AggroSettings.inputMode == InputMode.Gamepad)
				{
					PlaySfx();
				}
				else
				{
					_playSfx = true;
				}
			}
		}

		public void OnInputSelect(string content)
		{
			if (_setting.style == FloatSetting.Style.Percentage)
			{
				input.SetTextWithoutNotify(GetPercentageValue().ToString());
				input.contentType = TMP_InputField.ContentType.IntegerNumber;
			}
		}

		public void OnInputDeselect(string content)
		{
			SetInputWithoutNotify();
		}

		public void OnInputEndEdit(string content)
		{
			switch (_setting.style)
			{
			case FloatSetting.Style.Number:
			case FloatSetting.Style.Integer:
			{
				if (float.TryParse(content, out var result2))
				{
					_setting.SetValue(result2);
					slider.SetValueWithoutNotify(_setting.value);
				}
				else
				{
					Debug.LogWarning("[Setting] Could not parse input field for Number FloatSetting! " + content, this);
				}
				break;
			}
			case FloatSetting.Style.Percentage:
			{
				if (int.TryParse(content, out var result))
				{
					float value = (float)result / 100f;
					_setting.SetValue(value);
					slider.SetValueWithoutNotify(_setting.value);
				}
				else
				{
					Debug.LogWarning("[Setting] Could not parse input field for Percentage FloatSetting! " + content, this);
				}
				break;
			}
			default:
				throw new InvalidEnumException();
			}
			SetInputWithoutNotify();
			_setting.Save();
			PlaySfx();
		}

		private void PlaySfx()
		{
			EventReference sfx = (_setting.changeSfx.IsNull ? sliderChangeSfx : _setting.changeSfx);
			EventReference sfx2 = (_setting.zeroSfx.IsNull ? sliderZeroSfx : _setting.zeroSfx);
			if (_setting.value == 0f && !sfx2.IsNull)
			{
				AggroUtil.PlaySfxIfValid(sfx2);
			}
			else
			{
				AggroUtil.PlaySfxIfValid(sfx);
			}
		}

		private void SetInputWithoutNotify()
		{
			switch (_setting.style)
			{
			case FloatSetting.Style.Number:
				input.SetTextWithoutNotify(_setting.value.ToString("F2"));
				break;
			case FloatSetting.Style.Integer:
				input.SetTextWithoutNotify(Mathf.RoundToInt(_setting.value).ToString());
				break;
			case FloatSetting.Style.Percentage:
				input.SetTextWithoutNotify($"{GetPercentageValue()}%");
				break;
			default:
				throw new InvalidEnumException();
			}
		}

		private int GetPercentageValue()
		{
			return Mathf.RoundToInt(_setting.value * 100f);
		}
	}
}
