using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class AutomationButtonsMainMenu : MonoBehaviour
{
	public enum MainMenuButtons
	{
		Start,
		Bestiary,
		CharacterConfirm,
		CharacterStart,
		StageConfirm,
		StageStart
	}

	private MainMenuButtonsDictionary _buttons;

	private static AutomationButtonsMainMenu _instance;

	private void Awake()
	{
		_instance = this;
	}

	private void OnDestroy()
	{
		//IL_00e7: Expected O, but got I4
		//IL_0101: Expected O, but got I4
		AutomationButtonsMainMenu instance = _instance;
		bool flag = (object)_instance == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)_instance != null)
				{
					object obj3 = (object)_instance - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		_instance = null;
	}

	public static GameObject GetButtonGameObject(MainMenuButtons button)
	{
		AutomationButtonsMainMenu instance = _instance;
		if ((object)_instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			AutomationButtonsMainMenu instance2 = _instance;
			if ((object)_instance != null)
			{
				return (GameObject)CollectionExtensions.GetValueOrDefault((IReadOnlyDictionary<System.Int32Enum, object>)instance2._buttons, (System.Int32Enum)button);
			}
			return (GameObject)(object)new NullReferenceException();
		}
		return null;
	}

	public AutomationButtonsMainMenu()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
