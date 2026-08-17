using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine.UI;

public class BetterDropdownSetting : BetterSetting
{
	public TextMeshProUGUI title;

	public MyButton resButton;

	public override void ControllerInputDir(int dir, float multiplier)
	{
		Button button = resButton.GetButton();
		button.m_OnClick.Invoke();
	}

	protected override void OnSetting()
	{
	}

	public void ValueChanged()
	{
		Action<string, object, CFSettings> action = base.saveAction;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ r10_v1 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
	}

	protected override void ShowValue()
	{
		//IL_0049: Expected I, but got O
		//IL_0059: Expected O, but got I
		//IL_02dd: Expected I, but got O
		//IL_00f4: Expected I, but got O
		//IL_0104: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_01e2: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172099]");
		bool flag = (nint)0 != 0;
		BetterDropdownSetting betterDropdownSetting = this;
		if (!flag)
		{
			_ = 1;
			betterDropdownSetting = (BetterDropdownSetting)(object)"?";
		}
		object settingValue = _settingValue;
		bool flag2 = _settingValue == null;
		object settingValue2 = _settingValue;
		string text = (string)(object)betterDropdownSetting;
		if (!flag2)
		{
			nint num = (nint)settingValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v7 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v5 (System.Object)+40]");
			bool flag3 = num2 != 0;
			text = (string)_settingValue;
			if (flag3)
			{
				goto IL_032f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj2 = default(object);
			if ((nint)obj2 < 0)
			{
				goto IL_02a4;
			}
			settingValue2 = _settingValue;
			bool flag4 = _settingValue == null;
			text = (string)_settingValue;
			if (!flag4)
			{
				nint num3 = (nint)settingValue2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v11 (Il2CppClass<System.Object>)+40]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v5 (System.Object)+40]");
				bool flag5 = num4 != 0;
				text = (string)_settingValue;
				if (flag5)
				{
					goto IL_033a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				text = (string)(object)options;
				if (options != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v5 (System.String)+18]");
					object obj3 = default(object);
					bool flag6 = (nint)obj3 >= 0;
					settingValue = _settingValue;
					if (flag6)
					{
						goto IL_02a4;
					}
					text = (string)_settingValue;
					if (_settingValue != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						settingValue2 = 0;
						nint num5 = (nint)text;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdx_v11 (Il2CppClass<System.String>)+40]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ r8_v4 (System.Object)+40]");
						if (num6 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							obj = settingValue2;
							goto IL_033a;
						}
						string[] array = options;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj4 = default(object);
						text = (string)obj4;
						if ((nint)obj4 >= array.Length)
						{
							throw new IndexOutOfRangeException();
						}
						text = array[(object)text];
						string settingEnumLocalized = ConfigSettingsUtility.GetSettingEnumLocalized(array[(object)text]);
						if ((object)title != null)
						{
							title.text = settingEnumLocalized;
							return;
						}
					}
				}
			}
		}
		goto IL_02e8;
		IL_02e8:
		throw new NullReferenceException();
		IL_02a4:
		text = (string)(object)title;
		bool flag7 = (object)title == null;
		settingValue2 = settingValue;
		if (!flag7)
		{
			nint num7 = (nint)text;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v286 @ rax_v15 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
			return;
		}
		goto IL_02e8;
		IL_032f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_033a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		settingValue = settingValue2;
		goto IL_032f;
	}

	private int GetValue()
	{
		//IL_001f: Expected O, but got I
		//IL_0027: Expected I, but got O
		//IL_0065: Expected I4, but got O
		object settingValue = _settingValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
		object obj = 0;
		nint num = (nint)settingValue;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rdx_v3 (Il2CppClass<System.Object>)+40]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v2+40]");
		if (num2 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj2 = default(object);
			return (int)obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		int result = default(int);
		return result;
	}
}
