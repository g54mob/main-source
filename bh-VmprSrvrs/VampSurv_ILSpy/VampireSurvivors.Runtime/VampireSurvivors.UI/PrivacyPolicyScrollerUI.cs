using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.UI;

namespace VampireSurvivors.UI;

public class PrivacyPolicyScrollerUI : MonoBehaviour, ISelectableUI, IUIObject
{
	private TextMeshProUGUI _Text;

	private TextMeshProUGUI _LeftButtonLabel;

	private TextMeshProUGUI _RightButtonLabel;

	private Button _LeftButton;

	private Button _RightButton;

	private FakeSliderHandleController _SliderHandle;

	public void SetLeftButtonLabel(string text)
	{
		_LeftButtonLabel.text = text;
		((UnityEngine.Object)_LeftButton).SetName(text);
	}

	public void SetLeftButtonCallback(Action cb)
	{
		Button leftButton = _LeftButton;
		UnityAction call = cb.Invoke;
		leftButton.m_OnClick.AddListener(call);
	}

	public void SetRightButtonLabel(string text)
	{
		_RightButtonLabel.text = text;
		((UnityEngine.Object)_RightButton).SetName(text);
	}

	public void SetRightButtonCallback(Action cb)
	{
		Button rightButton = _RightButton;
		UnityAction call = cb.Invoke;
		rightButton.m_OnClick.AddListener(call);
	}

	public Selectable GetSelectable()
	{
		ProgrammaticUI componentInParent = GetComponentInParent<ProgrammaticUI>(includeInactive: true);
		if ((object)componentInParent != null)
		{
			FakeSliderHandleController componentInChildren = componentInParent.GetComponentInChildren<FakeSliderHandleController>(includeInactive: true);
			Slider componentInChildren2 = componentInParent.GetComponentInChildren<Slider>(includeInactive: true);
			if ((object)componentInChildren2 != null)
			{
				return componentInChildren2.GetComponentInChildren<FakeSliderHandleController>(includeInactive: true);
			}
		}
		return (Selectable)(object)new NullReferenceException();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public unsafe void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00e9: Expected O, but got Ref
		//IL_0165: Expected O, but got Ref
		//IL_01ee: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ProgrammaticUI componentInParent = GetComponentInParent<ProgrammaticUI>(includeInactive: true);
		FakeSliderHandleController componentInChildren = componentInParent.GetComponentInChildren<FakeSliderHandleController>(includeInactive: true);
		Slider componentInChildren2 = componentInParent.GetComponentInChildren<Slider>(includeInactive: true);
		FakeSliderHandleController componentInChildren3 = componentInChildren2.GetComponentInChildren<FakeSliderHandleController>(includeInactive: true);
		componentInChildren2.value = 0f;
		componentInChildren3.Select();
		FakeSliderHandleController sliderHandle = _SliderHandle;
		Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
		sliderHandle._OnUp = component;
		FakeSliderHandleController sliderHandle2 = _SliderHandle;
		sliderHandle2._OnDown = _LeftButton;
		FakeSliderHandleController sliderHandle3 = _SliderHandle;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v17 (VampireSurvivors.UI.FakeSliderHandleController)+48]");
		_ = 0;
		_ = ((Selectable)sliderHandle3).m_Navigation;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v17 (VampireSurvivors.UI.FakeSliderHandleController)+38]");
		_ = 0;
		Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v17 (VampireSurvivors.UI.FakeSliderHandleController)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rax_v17 (VampireSurvivors.UI.FakeSliderHandleController)+48]");
		_ = 0;
		_SliderHandle.navigation = navigation;
		Button leftButton = _LeftButton;
		_ = _RightButton;
		_ = ((Selectable)leftButton).m_Navigation;
		_ = 4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v20 (UnityEngine.UI.Button)+38]");
		_ = 0;
		Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		_LeftButton.navigation = navigation2;
		Button rightButton = _RightButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v26 (UnityEngine.UI.Button)+38]");
		_ = 0;
		_ = _LeftButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v26 (UnityEngine.UI.Button)+48]");
		_ = 0;
		_ = ((Selectable)rightButton).m_Navigation;
		_ = 4;
		Navigation navigation3 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-1]");
		_ = 0;
		_RightButton.navigation = navigation3;
	}

	public PrivacyPolicyScrollerUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
