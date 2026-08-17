using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class ToggleLanguage : MonoBehaviour
{
	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA37]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		MonoBehaviour.InvokeDelayed((MonoBehaviour)this, "test", 3f, 0f);
	}

	private void test()
	{
		List<string> allLanguages = LocalizationManager.GetAllLanguages();
		LocalizationManager.InitializeIfNeeded();
		int num = Array.IndexOf((object[])allLanguages._items, (object)LocalizationManager.mCurrentLanguage, 0, allLanguages._size);
		MonoBehaviour.InvokeDelayed((MonoBehaviour)this, "test", 3f, 0f);
	}

	public ToggleLanguage()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
