using System;
using System.Globalization;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public abstract class SettingSlider<TSetting, TType> : SettingHandle<TSetting, TType> where TSetting : NumericSetting<TType>
	{
		protected TType startValue;

		[SerializeField]
		protected SettingSliderReference SettingSliderRef;

		[NonSerialized]
		public bool onlyChangeSettingOnEndDrag;

		private EscapableAction closeEditPanel;

		public Slider slider => SettingSliderRef.slider;

		public SliderDragHandler sliderDragHandler => SettingSliderRef.sliderDragHandler;

		public override void CreateUIElement(GameObject _parent)
		{
			LinkToRef(UnityEngine.Object.Instantiate(UIPrefabsHolder.Instance.SettingSliderPrefab, _parent.transform).GetComponent<SettingSliderReference>());
			InitUIElement();
		}

		public void InitUIElement(SettingSliderReference sliderRef)
		{
			LinkToRef(sliderRef);
			InitUIElement();
		}

		public override void InitUIElement()
		{
			base.InitUIElement();
			if (SettingSliderRef.settingName != null)
			{
				SettingSliderRef.settingName.text = setting.Name;
				TooltipTrigger component = SettingSliderRef.settingName.gameObject.GetComponent<TooltipTrigger>();
				if (!string.IsNullOrEmpty(setting.HelperText))
				{
					component.UpdateText(setting.Name, setting.HelperText);
				}
			}
			if (SettingSliderRef.sliderValue != null)
			{
				SettingSliderRef.sliderValue.InitFromSetting(setting);
			}
			if (SettingSliderRef.editButton != null)
			{
				SettingSliderRef.editButton.onClick.AddListener(OpenEditPanel);
			}
			SettingSliderRef.editField.onSubmit.AddListener(delegate
			{
				CloseEditPanel(submit: true);
			});
			SettingSliderRef.editField.onValueChanged.AddListener(UpdateValueDuringEdit);
			SettingSliderRef.editField.onDeselect.AddListener(delegate
			{
				CloseEditPanel(submit: false);
			});
			SettingSliderRef.editField.onDeselect.AddListener(delegate
			{
				ExitEditField();
			});
			closeEditPanel = new EscapableAction(delegate
			{
				CloseEditPanel(submit: false);
			});
			TypeSpecificUIElementCreation();
			SetMinMax((dynamic)setting.minValue, (dynamic)setting.maxValue, forceInBounds: !setting.canGoOutOfBounds);
			SettingSliderRef.sliderDragHandler.onBeginDrag.AddListener(OnBeginDrag);
			SettingSliderRef.sliderDragHandler.onEndDrag.AddListener(OnEndDrag);
			if (!onlyChangeSettingOnEndDrag)
			{
				SettingSliderRef.slider.onValueChanged.AddListener(SetValueFromSlider);
			}
			else
			{
				SettingSliderRef.slider.onValueChanged.AddListener(UpdateValueText);
			}
			CloseEditPanel(submit: false);
			LayoutRebuilder.ForceRebuildLayoutImmediate(SettingSliderRef.GetComponent<RectTransform>());
			PositionDefaultPointer();
			UpdateUIElement();
			initialized = true;
		}

		public virtual void SetMinMax(float? min = null, float? max = null, bool forceInBounds = false)
		{
			if (!forceInBounds)
			{
				updatedFromSetting = true;
			}
			_ = SettingSliderRef.slider.value;
			SettingSliderRef.slider.minValue = min ?? SettingSliderRef.slider.minValue;
			SettingSliderRef.slider.maxValue = max ?? SettingSliderRef.slider.maxValue;
			if (!forceInBounds)
			{
				updatedFromSetting = false;
			}
		}

		public virtual void SetValueFromSlider(float val)
		{
			TType val2 = SettingValueOfSlider(val);
			SetValue(val2, revertable: false);
			if (!updatedFromSetting)
			{
				onValueChangedByUser.Invoke(val2);
			}
		}

		protected void UpdateValueText(float val)
		{
			if (SettingSliderRef.sliderValue != null)
			{
				SettingSliderRef.sliderValue.SetValue((dynamic)SettingValueOfSlider(val));
			}
		}

		public abstract TType SettingValueOfSlider(float val);

		public void OnBeginDrag(float val)
		{
			startValue = setting.val;
		}

		public void OnEndDrag(float val)
		{
			if (onlyChangeSettingOnEndDrag)
			{
				SetValueFromSlider(val);
			}
			if (changeIsRevertable && initialized)
			{
				UINavigationManager.AddRevertableActionToStack(new ChangeSettingHandleAction<TSetting, TType>(this, startValue, setting.val));
			}
		}

		public void LinkToRef(SettingSliderReference sliderRef)
		{
			SettingSliderRef = sliderRef;
			if (SettingSliderRef.resetButton != null)
			{
				if (simple)
				{
					SettingSliderRef.resetButton.gameObject.SetActive(value: false);
				}
				else
				{
					SettingSliderRef.resetButton.onClick.AddListener(ResetValue);
				}
			}
			SettingSliderRef.OnSizeChange.AddListener(PositionDefaultPointer);
		}

		public override void HideUIElement()
		{
			SettingSliderRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			SettingSliderRef.gameObject.SetActive(value: true);
		}

		public override void UpdateUIElement()
		{
			SettingSliderRef.slider.SetValueWithoutNotify((float)(dynamic)setting.val);
			if (SettingSliderRef.sliderValue != null)
			{
				SettingSliderRef.sliderValue.UpdateValue((float)(dynamic)setting.val, check: false);
			}
		}

		public void UpdateValueDuringEdit(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = "0";
			}
			if (text[0] == '-' || text[0] == '+')
			{
				text = $"{text[0]}0{string.Join(string.Empty, text.Skip(1))}";
			}
			if (text[0] == '.' || text[0] == ',')
			{
				text = "0" + text;
			}
			float num = 0f;
			try
			{
				num = float.Parse(text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return;
			}
			num = (dynamic)num / setting.factor;
			if (!setting.canBeNegative)
			{
				num = Mathf.Max(0f, num);
			}
			if (!setting.canGoOutOfBounds)
			{
				num = Mathf.Clamp(num, (dynamic)setting.minValue, (dynamic)setting.maxValue);
			}
			if (!(SettingSliderRef.sliderValue == null))
			{
				UpdateDisplayedValue(Mathf.Approximately(0f, num) ? 0f : num);
			}
		}

		public void UpdateDisplayedValue(float val)
		{
			SettingSliderRef.sliderValue.UpdateValue(val);
		}

		public virtual void ExitEditField()
		{
			UpdateUIElement();
		}

		public virtual void SubmitEditValue(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = "0";
			}
			if (text[0] == '-' || text[0] == '+')
			{
				text = $"{text[0]}0{string.Join(string.Empty, text.Skip(1))}";
			}
			if (text[0] == '.' || text[0] == ',')
			{
				text = "0" + text;
			}
			float num = 0f;
			try
			{
				num = float.Parse(text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return;
			}
			num = (dynamic)num / setting.factor;
			if (!setting.canBeNegative)
			{
				num = Mathf.Max(0f, num);
			}
			if (!setting.canGoOutOfBounds)
			{
				num = Mathf.Clamp(num, (dynamic)setting.minValue, (dynamic)setting.maxValue);
			}
			SetValue((TType)(dynamic)num, revertable: false);
			onValueChangedByUser.Invoke((TType)(dynamic)num);
		}

		public void OpenEditPanel()
		{
			if (interactable)
			{
				UserControl.SetKeyboardBlockFromSource("SliderEdit", block: true);
				SettingSliderRef.editField.text = ((dynamic)setting.val * setting.factor).ToString();
				SettingSliderRef.editSection.SetActive(value: true);
				SettingSliderRef.normalSection.SetActive(value: false);
				SettingSliderRef.editField.Select();
				UINavigationManager.AddEscapableToStack(closeEditPanel);
			}
		}

		public void CloseEditPanel(bool submit)
		{
			UserControl.SetKeyboardBlockFromSource("SliderEdit", block: false);
			SettingSliderRef.editSection.SetActive(value: false);
			SettingSliderRef.normalSection.SetActive(value: true);
			UINavigationManager.RemoveEscapableFromStack(closeEditPanel);
			if (submit)
			{
				SubmitEditValue(SettingSliderRef.editField.text);
			}
		}

		protected abstract void TypeSpecificUIElementCreation();

		public virtual void PositionDefaultPointer()
		{
			if (setting != null && !(SettingSliderRef.defaultPointer == null))
			{
				float width = SettingSliderRef.defaultPointer.transform.parent.GetComponent<RectTransform>().rect.width;
				Vector2 vector = Vector2.zero + new Vector2(1f, 0f) * width;
				if (!(width < 1f))
				{
					SettingSliderRef.defaultPointer.GetComponent<RectTransform>().localPosition = vector * ((dynamic)setting.DefaultValue - setting.minValue) / ((dynamic)setting.maxValue - setting.minValue) - new Vector2(width / 2f, 0f);
				}
			}
		}

		public override void SetInteractable(bool isInteractable)
		{
			base.SetInteractable(isInteractable);
			SettingSliderRef.slider.interactable = isInteractable;
		}

		protected SettingSlider(TSetting _setting, SettingSliderReference reference)
			: base(_setting, false)
		{
			setting = _setting;
			InitUIElement(reference);
		}

		protected SettingSlider(TSetting _setting, bool simple)
			: base(_setting, simple)
		{
		}

		protected SettingSlider()
		{
		}
	}
}
