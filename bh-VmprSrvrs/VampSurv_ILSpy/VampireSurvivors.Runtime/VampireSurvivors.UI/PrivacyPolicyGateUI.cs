using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class PrivacyPolicyGateUI : MonoBehaviour, ISelectableUI, IUIObject
{
	private TextMeshProUGUI _WarningMessage;

	private TextMeshProUGUI _CenterButtonLabel;

	private Button _CenterButton;

	public void SetWarningMessage(string text)
	{
		_WarningMessage.text = text;
		((UnityEngine.Object)_WarningMessage).SetName(text);
	}

	public void SetCenterButtonLabel(string text)
	{
		_CenterButtonLabel.text = text;
		((UnityEngine.Object)_CenterButton).SetName(text);
	}

	public void SetCenterButtonCallback(Action cb)
	{
		Button centerButton = _CenterButton;
		UnityAction call = cb.Invoke;
		centerButton.m_OnClick.AddListener(call);
	}

	public Selectable GetSelectable()
	{
		return _CenterButton;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
	}

	public PrivacyPolicyGateUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
