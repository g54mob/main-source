using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI;

public class CustomDropdownItemText : CustomDropdownItem
{
	private TextMeshProUGUI _Label;

	public override void Initialize(object option, CustomDropDown dropdown)
	{
		base.Initialize(option, dropdown);
		if ((object)_Label != null)
		{
			bool flag = option == null;
			object obj = null;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				bool flag2 = option != null;
				obj = null;
				if (!flag2)
				{
					obj = option;
				}
				if (obj == null)
				{
					goto IL_00c4;
				}
			}
			_Label.text = (string)obj;
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_00c4;
		IL_00c4:
		throw new InvalidCastException();
	}

	public CustomDropdownItemText()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
