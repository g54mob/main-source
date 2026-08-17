using System;
using System.Globalization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class SliderUI : MonoBehaviour, ISelectableUI, IUIObject
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public SliderUI _003C_003E4__this;

		public Action<int> cb;

		internal void _003CAddOnValueChange_003Eb__0(float v)
		{
			//IL_011d: Expected I, but got O
			//IL_00bd: Expected O, but got I
			//IL_00cd: Expected O, but got I
			//IL_00dd: Expected O, but got I
			//IL_0048: Expected I, but got O
			//IL_0072: Expected I, but got O
			//IL_0096: Expected O, but got I
			while (true)
			{
				SliderUI sliderUI = _003C_003E4__this;
				TextMeshProUGUI optionalValueLabel = sliderUI._optionalValueLabel;
				bool flag = (object)sliderUI._optionalValueLabel == null;
				nint num = (nint)typeof(UnityEngine.Object);
				if (!flag)
				{
					bool flag2 = ((UnityEngine.Object)optionalValueLabel).m_CachedPtr == (IntPtr)0;
					num = (nint)typeof(UnityEngine.Object);
					if (!flag2)
					{
						SliderUI sliderUI2 = _003C_003E4__this;
						nint num2 = (nint)sliderUI2._optionalValueLabel;
						NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
						string text = System.Number.FormatSingle(v, null, currentInfo);
						object obj = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v70 @ r9_v2+558] (should have been resolved before IL gen)");
						num = num2;
					}
				}
				Action<int> action = cb;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Action`1<System.Int32>)+28]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Action`1<System.Int32>)+40]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Action`1<System.Int32>)+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v184 @ rax_v11 (should have been resolved before IL gen)");
			}
		}
	}

	private Slider _slider;

	private TextMeshProUGUI _label;

	private TextMeshProUGUI _optionalValueLabel;

	public void SetLabel(string text)
	{
		_label.text = text;
	}

	public void AddOnValueChange(Action<float> cb)
	{
		Slider slider = _slider;
		UnityAction<float> unityAction = null;
		float obj = default(float);
		unityAction(obj);
		slider.m_OnValueChanged.AddListener(unityAction);
	}

	public void AddOnValueChange(Action<int> cb)
	{
		_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
		obj._003C_003E4__this = this;
		obj.cb = cb;
		Slider slider = _slider;
		UnityAction<float> unityAction = null;
		float v = default(float);
		((_003C_003Ec__DisplayClass5_0)(object)unityAction)._003CAddOnValueChange_003Eb__0(v);
		slider.m_OnValueChanged.AddListener(unityAction);
	}

	public void InitialSet(float f, float minValue = 0f, float maxValue = 1f)
	{
		_slider.wholeNumbers = false;
		_slider.minValue = minValue;
		_slider.maxValue = maxValue;
		_slider.value = f;
	}

	public void InitialSet(int v, int minValue = 0, int maxValue = 100)
	{
		//IL_0029: Expected F4, but got I4
		//IL_003d: Expected F4, but got I4
		//IL_0051: Expected F4, but got I4
		_slider.wholeNumbers = true;
		_slider.minValue = minValue;
		_slider.maxValue = maxValue;
		_slider.value = v;
		Slider slider = _slider;
		Transform parent = ((Selectable)slider).m_TargetGraphic.transform;
		TextMeshProUGUI optionalValueLabel = UnityEngine.Object.Instantiate(_label, parent);
		_optionalValueLabel = optionalValueLabel;
		RectTransform rectTransform = _optionalValueLabel.rectTransform;
		Vector2 vector = default(Vector2);
		rectTransform.anchorMin = vector;
		RectTransform rectTransform2 = _optionalValueLabel.rectTransform;
		rectTransform2.anchorMax = vector;
		RectTransform rectTransform3 = _optionalValueLabel.rectTransform;
		rectTransform3.sizeDelta = vector;
		RectTransform rectTransform4 = _optionalValueLabel.rectTransform;
		rectTransform4.anchoredPosition = vector;
		TextMeshProUGUI optionalValueLabel2 = _optionalValueLabel;
		if (((TMP_Text)optionalValueLabel2).m_HorizontalAlignment != HorizontalAlignmentOptions.Center || ((TMP_Text)optionalValueLabel2).m_VerticalAlignment != VerticalAlignmentOptions.Geometry)
		{
			((TMP_Text)optionalValueLabel2).m_HorizontalAlignment = HorizontalAlignmentOptions.Center;
			((TMP_Text)optionalValueLabel2).m_VerticalAlignment = VerticalAlignmentOptions.Geometry;
			((TMP_Text)optionalValueLabel2).m_havePropertiesChanged = true;
			optionalValueLabel2.SetVerticesDirty();
		}
		TextMeshProUGUI optionalValueLabel3 = _optionalValueLabel;
		if (((TMP_Text)optionalValueLabel3).m_TextWrappingMode != TextWrappingModes.NoWrap)
		{
			((TMP_Text)optionalValueLabel3).m_havePropertiesChanged = true;
			((TMP_Text)optionalValueLabel3).m_TextWrappingMode = TextWrappingModes.NoWrap;
			optionalValueLabel3.SetVerticesDirty();
			optionalValueLabel3.SetLayoutDirty();
		}
		int num = default(int);
		string text = num.ToString();
		_optionalValueLabel.text = text;
		_optionalValueLabel.raycastTarget = false;
	}

	public Selectable GetSelectable()
	{
		return _slider;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public unsafe void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_slider.navigation = (Navigation)(&obj);
	}

	public SliderUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
