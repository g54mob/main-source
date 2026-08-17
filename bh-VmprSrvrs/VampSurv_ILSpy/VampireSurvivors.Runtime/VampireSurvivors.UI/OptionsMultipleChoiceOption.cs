using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class OptionsMultipleChoiceOption : MonoBehaviour
{
	private Image _Tick;

	private Button _Button;

	private TextMeshProUGUI _Label;

	private OptionsMultipleChoice _owner;

	public void Select()
	{
		OptionsMultipleChoice owner = _owner;
		OptionsMultipleChoiceOption selected = owner._selected;
		if ((object)owner._selected != null)
		{
			GameObject gameObject = selected._Tick.gameObject;
			gameObject.SetActive(value: false);
		}
		owner._selected = this;
		GameObject gameObject2 = _Tick.gameObject;
		gameObject2.SetActive(value: true);
	}

	public void Deselect()
	{
		GameObject gameObject = _Tick.gameObject;
		gameObject.SetActive(value: false);
	}

	public void Initialize(string text, Action cb, OptionsMultipleChoice owner)
	{
		_Label.text = text;
		Button button = _Button;
		UnityAction call = Select;
		button.m_OnClick.AddListener(call);
		Button button2 = _Button;
		UnityAction call2 = cb.Invoke;
		button2.m_OnClick.AddListener(call2);
		_owner = owner;
	}

	public OptionsMultipleChoiceOption()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
