using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class LabeledButtonUI : MonoBehaviour, ISelectableUI, IUIObject
{
	private TextMeshProUGUI _Label;

	private TextMeshProUGUI _ButtonLabel;

	private Button _Button;

	public void SetLabel(string text)
	{
		_Label.text = text;
	}

	public void SetButtonLabel(string text)
	{
		_ButtonLabel.text = text;
		((UnityEngine.Object)_Button).SetName(text);
	}

	public void SetButtonCallback(Action cb)
	{
		Button button = _Button;
		UnityAction call = cb.Invoke;
		button.m_OnClick.AddListener(call);
	}

	public Selectable GetSelectable()
	{
		return _Button;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void UpdateNavigation(Selectable up, Selectable down, Selectable left, Selectable right)
	{
	}

	public LabeledButtonUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
