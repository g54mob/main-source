using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine.UI;

public class SliderSetting : BetterSetting
{
	public TMP_InputField valueText;

	public Slider slider;

	private bool useWholeNumbers;

	public override void SetSetting(Action<string, object, CFSettings> saveAction, string settingName, object currentValue, Settings settings, CFSettings cfSettings)
	{
		Settings settings2 = default(Settings);
		CFSettings cFSettings = default(CFSettings);
		base.SetSetting(saveAction, settingName, currentValue, settings2, cFSettings);
		bool flag = (useWholeNumbers = ConfigSettingsUtility.GetSliderWholeNumbers(settingName));
		slider.wholeNumbers = flag;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb edx,edx\"");
		TMP_InputField.ContentType contentType = (TMP_InputField.ContentType)((flag ? 1 : 0) + 3);
		valueText.contentType = contentType;
		ConfigSettingsUtility.GetSliderRange(settingName, out var min, out var max);
		slider.minValue = min;
		slider.maxValue = max;
		ShowValue();
	}

	public void UpdateValueSlider()
	{
		float num = slider.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object settingValue = default(object);
		_settingValue = settingValue;
		string text = _settingValue.ToString();
		valueText.text = text;
		ShowValue();
		Action<string, object, CFSettings> action = base.saveAction;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ r10_v2 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
	}

	public void UpdateValueInputField()
	{
		//IL_005b: Expected I, but got O
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021b: Expected O, but got I
		//IL_00e7: Expected I, but got O
		//IL_0175: Expected I, but got O
		//IL_017d: Expected F4, but got O
		//IL_018d: Expected O, but got I
		//IL_019c: Expected F4, but got O
		//IL_01a1: Expected I, but got O
		TMP_InputField tMP_InputField = valueText;
		if ((object)valueText != null)
		{
			float num = float.Parse(tMP_InputField.m_Text);
			Slider slider = this.slider;
			bool flag = (object)this.slider == null;
			nint num2 = unchecked((nint)null);
			tMP_InputField = (TMP_InputField)(object)tMP_InputField.m_Text;
			if (!flag)
			{
				float minValue = slider.m_MinValue;
				if (!(slider.m_MinValue > num))
				{
					minValue = slider.m_MaxValue;
					if (!(num > slider.m_MaxValue))
					{
						minValue = num;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				tMP_InputField = (TMP_InputField)(this + 128);
				IntPtr intPtr = default(IntPtr);
				_settingValue = (nint)intPtr;
				TMP_InputField settingValue = (TMP_InputField)_settingValue;
				bool flag2 = _settingValue == null;
				num2 = intPtr;
				if (!flag2)
				{
					nint num3 = (nint)settingValue;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v7 (Il2CppClass<TMPro.TMP_InputField>)+40]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v1 (Il2CppMethodInfo)+40]");
					bool flag3 = num4 != 0;
					tMP_InputField = (TMP_InputField)_settingValue;
					if (flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						return;
					}
					Slider slider2 = this.slider;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					bool flag4 = (object)this.slider == null;
					tMP_InputField = (TMP_InputField)_settingValue;
					if (!flag4)
					{
						nint num5 = (nint)slider2;
						object obj = default(object);
						minValue = (float)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdx_v7 (Il2CppClass<UnityEngine.UI.Slider>)+430]");
						settingValue = (TMP_InputField)0;
						this.slider.value = (float)obj;
						nint num6 = (nint)this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rax_v11 (Il2CppClass<SliderSetting>)+1B0]");
						num2 = 0;
						ShowValue();
						Action<string, object, CFSettings> action = base.saveAction;
						bool flag5 = base.saveAction == null;
						tMP_InputField = (TMP_InputField)(object)this;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v25 @ r10_v3 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
		//IL_024f: Expected I, but got O
		if (disabledOverlay != null && disabledOverlay.activeSelf)
		{
			return;
		}
		Slider slider;
		float num3;
		float sliderIncrement = default(float);
		if (!useWholeNumbers)
		{
			sliderIncrement = ConfigSettingsUtility.GetSliderIncrement(_settingName);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803772C3h\"");
			if (sliderIncrement == -1f)
			{
				slider = this.slider;
				float num = slider.m_MaxValue - slider.m_MinValue;
				float num2 = num / 100f;
				num3 = num2 * multiplier;
				goto IL_0109;
			}
			num3 = sliderIncrement * multiplier;
		}
		else
		{
			num3 = 1f;
		}
		slider = this.slider;
		goto IL_0109;
		IL_0109:
		Slider slider2 = this.slider;
		float num4 = slider.value;
		Slider slider3 = this.slider;
		float num5 = (float)dir * num3;
		float num6 = num5 + sliderIncrement;
		if (!(slider3.m_MinValue > num6))
		{
			sliderIncrement = slider3.m_MaxValue;
			if (num6 > slider3.m_MaxValue)
			{
				num6 = slider3.m_MaxValue;
			}
		}
		else
		{
			num6 = slider3.m_MinValue;
		}
		nint num7 = (nint)slider2;
		slider2.value = num6;
		float num8 = this.slider.value;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object settingValue = default(object);
		_settingValue = settingValue;
		string text = _settingValue.ToString();
		valueText.text = text;
		ShowValue();
		Action<string, object, CFSettings> action = base.saveAction;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ r10_v3 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
	}

	private float GetValue()
	{
		//IL_001f: Expected O, but got I
		//IL_0027: Expected I, but got O
		//IL_0065: Expected F4, but got O
		object settingValue = _settingValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
		object obj = 0;
		nint num = (nint)settingValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rdx_v3 (Il2CppClass<System.Object>)+40]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v2+40]");
		if (num2 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj2 = default(object);
			return (float)obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		float result = default(float);
		return result;
	}

	protected override void ShowValue()
	{
		//IL_0043: Expected O, but got I
		//IL_004b: Expected I, but got O
		//IL_0142: Expected O, but got I4
		//IL_00eb: Expected O, but got I4
		//IL_018c: Expected O, but got I4
		//IL_01a2: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831720CB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object settingValue = _settingValue;
		bool flag = _settingValue == null;
		string settingValue2 = (string)_settingValue;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
			object obj = 0;
			nint num = (nint)settingValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdx_v6 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v3+40]");
			bool flag2 = num2 != 0;
			settingValue2 = (string)_settingValue;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			string textWithoutNotify;
			if (!useWholeNumbers)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				textWithoutNotify = $"{arg:F2}";
				bool flag3 = (object)valueText == null;
				obj = 0;
				settingValue2 = "{0:F2}";
				if (flag3)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg2 = default(object);
				textWithoutNotify = $"{arg2:N0}";
				bool flag4 = (object)valueText == null;
				obj = 0;
				settingValue2 = "{0:N0}";
				if (flag4)
				{
					throw new NullReferenceException();
				}
			}
			valueText.SetTextWithoutNotify(textWithoutNotify);
			settingValue2 = (string)(object)slider;
			bool flag5 = (object)slider == null;
			obj = 0;
			if (!flag5)
			{
				nint num3 = (nint)settingValue2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ rax_v14 (Il2CppClass<System.String>)+438] (should have been resolved before IL gen)");
				return;
			}
		}
		throw new NullReferenceException();
	}
}
