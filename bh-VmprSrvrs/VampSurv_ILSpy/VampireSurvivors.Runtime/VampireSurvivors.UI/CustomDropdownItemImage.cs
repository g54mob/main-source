using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class CustomDropdownItemImage : CustomDropdownItem
{
	private Image _Image;

	public unsafe override void Initialize(object option, CustomDropDown dropdown)
	{
		//IL_0013: Expected I, but got O
		//IL_0020: Expected I, but got O
		//IL_005e: Expected O, but got Ref
		base.Initialize(option, dropdown);
		nint num = (nint)typeof(Color);
		nint num2 = (nint)option;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v4 (Il2CppClass<System.Object>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ r8_v4 (Il2CppClass<UnityEngine.Color>)+40]");
		if (num3 == 0)
		{
			object obj = default(object);
			_Image.color = (Color)(&obj);
			return;
		}
		throw new InvalidCastException();
	}

	public CustomDropdownItemImage()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
