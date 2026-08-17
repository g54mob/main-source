using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class SaveSlotContainerUI : MonoBehaviour, IUIObject, ISelectableUI
{
	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _SaveData;

	private TextMeshProUGUI _ButtonLabel;

	private Button _Button;

	public void SetLabel(string title)
	{
		_Title.text = title;
	}

	public void SetSaveData(string text)
	{
		_SaveData.text = text;
	}

	public void RemoveButton()
	{
		GameObject gameObject = _Button.gameObject;
		gameObject.SetActive(value: false);
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

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public Selectable GetSelectable()
	{
		return _Button;
	}

	public unsafe void UpdateNavigation(Selectable above, Selectable below, Selectable left, Selectable right)
	{
		//IL_0014: Expected O, but got Ref
		object obj = default(object);
		_Button.navigation = (Navigation)(&obj);
	}

	public SaveSlotContainerUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
