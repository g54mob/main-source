using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors;

public class HelpButton : MonoBehaviour
{
	public static HelpButton Instance;

	private Button _button;

	private void Awake()
	{
		Instance = this;
		Button component = GetComponent<Button>();
		_button = component;
		GameObject gameObject = _button.gameObject;
		gameObject.SetActive(value: false);
	}

	public static void AddCallback(Action cb)
	{
		HelpButton instance = Instance;
		Button button = instance._button;
		button.m_OnClick.RemoveAllListeners();
		HelpButton instance2 = Instance;
		Button button2 = instance2._button;
		UnityAction call = cb.Invoke;
		button2.m_OnClick.AddListener(call);
		HelpButton instance3 = Instance;
		GameObject gameObject = instance3._button.gameObject;
		gameObject.SetActive(value: true);
	}

	public static void Clear()
	{
		HelpButton instance = Instance;
		Button button = instance._button;
		button.m_OnClick.RemoveAllListeners();
		HelpButton instance2 = Instance;
		GameObject gameObject = instance2._button.gameObject;
		gameObject.SetActive(value: false);
	}

	public unsafe static void SetNavigation(Selectable left, Selectable right, Selectable up, Selectable down)
	{
		//IL_001c: Expected O, but got Ref
		HelpButton instance = Instance;
		object obj = default(object);
		instance._button.navigation = (Navigation)(&obj);
	}

	public HelpButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
