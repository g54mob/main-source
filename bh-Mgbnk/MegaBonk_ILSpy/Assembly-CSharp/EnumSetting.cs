using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class EnumSetting : BetterSetting
{
	public TextMeshProUGUI valueText;

	public void UpdateValue(int dir)
	{
		//IL_0041: Expected I, but got O
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected I4, but got Unknown
		//IL_011b: Expected I, but got O
		object settingValue = _settingValue;
		if (_settingValue != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			int num = 0;
			nint num2 = (nint)settingValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v2 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v2 (System.Int32)+40]");
			bool flag = num3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v2 (Il2CppClass<System.Object>)+40]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v2 (System.Int32)+40]");
			if (num4 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj = default(object);
			int num5 = obj + num5;
			if (flag)
			{
				return;
			}
			string[] array = options;
			if (options != null)
			{
				if (num5 < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object settingValue2 = default(object);
					_settingValue = settingValue2;
					nint num6 = (nint)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<EnumSetting>)+1B0]");
					num5 = 0;
					ShowValue();
					Action<string, object, CFSettings> action = base.saveAction;
					bool flag2 = base.saveAction == null;
					settingValue = this;
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ r10_v4 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void ControllerInputDir(int dir, float multiplier)
	{
		//IL_0041: Expected I, but got O
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected I4, but got Unknown
		//IL_011b: Expected I, but got O
		object settingValue = _settingValue;
		if (_settingValue != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			int num = 0;
			nint num2 = (nint)settingValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v2 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v2 (System.Int32)+40]");
			bool flag = num3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ r8_v2 (Il2CppClass<System.Object>)+40]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v2 (System.Int32)+40]");
			if (num4 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			object obj = default(object);
			int num5 = obj + num5;
			if (flag)
			{
				return;
			}
			string[] array = options;
			if (options != null)
			{
				if (num5 < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object settingValue2 = default(object);
					_settingValue = settingValue2;
					nint num6 = (nint)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<EnumSetting>)+1B0]");
					num5 = 0;
					ShowValue();
					Action<string, object, CFSettings> action = base.saveAction;
					bool flag2 = base.saveAction == null;
					settingValue = this;
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v107 @ r10_v4 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void ShowValue()
	{
		//IL_057e: Expected O, but got I
		//IL_0586: Expected I, but got O
		//IL_0064: Expected I, but got O
		//IL_0074: Expected O, but got I
		//IL_0116: Expected I, but got O
		//IL_0126: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_01f4: Expected I, but got O
		//IL_02c8: Expected I, but got O
		//IL_02d8: Expected O, but got I
		//IL_0324: Expected O, but got I
		//IL_03a1: Expected O, but got I
		//IL_03a9: Expected I, but got O
		//IL_042e: Expected I, but got O
		//IL_06f6: Expected I, but got O
		//IL_0706: Expected O, but got I
		//IL_047c: Expected O, but got I4
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Expected O, but got Unknown
		//IL_0504: Expected I, but got O
		//IL_0514: Expected O, but got I
		string[] array = options;
		bool flag = options == null;
		EnumSetting enumSetting = this;
		EnumSetting settingValue2;
		EnumSetting enumSetting2;
		EnumSetting settingValue;
		if (!flag)
		{
			if (array.Length == 0)
			{
				goto IL_0545;
			}
			settingValue = (EnumSetting)_settingValue;
			bool flag2 = _settingValue == null;
			settingValue2 = (EnumSetting)_settingValue;
			enumSetting = this;
			if (!flag2)
			{
				nint num = (nint)settingValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				enumSetting2 = (EnumSetting)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v21 (Il2CppClass<EnumSetting>)+40]");
				bool flag3 = 0 != (nint)((BetterSetting)enumSetting2).settings;
				enumSetting = (EnumSetting)_settingValue;
				if (flag3)
				{
					goto IL_0680;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj = default(object);
				bool flag4 = (nint)obj < 0;
				settingValue2 = (EnumSetting)_settingValue;
				if (flag4)
				{
					goto IL_0545;
				}
				settingValue2 = (EnumSetting)_settingValue;
				bool flag5 = _settingValue == null;
				enumSetting = (EnumSetting)_settingValue;
				if (!flag5)
				{
					nint num2 = (nint)settingValue2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
					enumSetting2 = (EnumSetting)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rcx_v23 (Il2CppClass<EnumSetting>)+40]");
					bool flag6 = 0 != (nint)((BetterSetting)enumSetting2).settings;
					enumSetting = (EnumSetting)_settingValue;
					if (flag6)
					{
						goto IL_0690;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					enumSetting = (EnumSetting)(object)options;
					if (options != null)
					{
						CancellationTokenSource cancellationTokenSource = ((MonoBehaviour)enumSetting).m_CancellationTokenSource;
						object obj2 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource))
						{
							goto IL_0545;
						}
						enumSetting = (EnumSetting)_settingValue;
						if (_settingValue != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							settingValue2 = (EnumSetting)0;
							nint num3 = (nint)enumSetting;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rdx_v21 (Il2CppClass<EnumSetting>)+40]");
							if (0 != (nint)((BetterSetting)settingValue2).settings)
							{
								goto IL_06a8;
							}
							TextMeshProUGUI textMeshProUGUI = valueText;
							string[] array2 = options;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							object obj3 = default(object);
							enumSetting = (EnumSetting)obj3;
							if ((nint)obj3 >= array2.Length)
							{
								throw new IndexOutOfRangeException();
							}
							string settingEnumLocalized = ConfigSettingsUtility.GetSettingEnumLocalized(array2[(object)enumSetting]);
							string text = settingEnumLocalized + "\n<size=45%>";
							bool flag7 = (object)valueText == null;
							settingValue2 = null;
							enumSetting = (EnumSetting)(object)settingEnumLocalized;
							if (!flag7)
							{
								nint num4 = (nint)textMeshProUGUI;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
								EnumSetting enumSetting3 = (EnumSetting)0;
								valueText.text = text;
								string[] array3 = options;
								bool flag8 = options == null;
								EnumSetting enumSetting4 = null;
								EnumSetting enumSetting5 = null;
								nint num5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v10 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
								settingValue2 = (EnumSetting)0;
								enumSetting = null;
								if (!flag8)
								{
									object obj4 = default(object);
									string text4 = default(string);
									while (true)
									{
										if ((nint)enumSetting5 >= array3.Length)
										{
											return;
										}
										enumSetting = (EnumSetting)_settingValue;
										bool flag9 = _settingValue == null;
										num5 = num4;
										settingValue2 = enumSetting3;
										if (flag9)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
										settingValue2 = (EnumSetting)0;
										nint num6 = (nint)enumSetting;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v26 (Il2CppClass<EnumSetting>)+40]");
										bool flag10 = 0 != (nint)((BetterSetting)settingValue2).settings;
										num5 = num4;
										if (!flag10)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
											EnumSetting enumSetting6 = (EnumSetting)(object)valueText;
											bool flag11 = (object)valueText == null;
											num5 = num4;
											if (flag11)
											{
												break;
											}
											bool flag12 = enumSetting4 == obj4;
											nint num7 = (nint)enumSetting6;
											string text2;
											if (!flag12)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v670 @ rax_v42 (Il2CppClass<EnumSetting>)+548] (should have been resolved before IL gen)");
												text2 = "<sprite name=\"CircleHollow\">";
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v670 @ rax_v42 (Il2CppClass<EnumSetting>)+548] (should have been resolved before IL gen)");
												text2 = "<sprite name=\"CircleFilled\">";
											}
											string text3 = text4 + text2;
											nint num8 = (nint)enumSetting6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r9_v11 (Il2CppClass<EnumSetting>)+560]");
											settingValue2 = (EnumSetting)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v68 @ r9_v11 (Il2CppClass<EnumSetting>)+558] (should have been resolved before IL gen)");
											string[] array4 = options;
											bool flag13 = options == null;
											num5 = num8;
											enumSetting = (EnumSetting)(object)valueText;
											if (flag13)
											{
												break;
											}
											object obj5 = array4.Length - 1;
											bool flag14 = enumSetting4 == obj5;
											num5 = num8;
											if (!flag14)
											{
												TextMeshProUGUI textMeshProUGUI2 = valueText;
												bool flag15 = (object)valueText == null;
												num5 = num8;
												enumSetting = (EnumSetting)(object)valueText;
												if (flag15)
												{
													break;
												}
												string text5 = valueText.text;
												string text6 = text5 + "  ";
												num5 = (nint)textMeshProUGUI2;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ r9_v4 (Il2CppClass<TMPro.TextMeshProUGUI>)+560]");
												settingValue2 = (EnumSetting)0;
												valueText.text = text6;
											}
											array3 = options;
											enumSetting4 = (EnumSetting)(enumSetting4 + 1);
											bool flag16 = options == null;
											enumSetting = enumSetting4;
											if (flag16)
											{
												break;
											}
											num4 = num5;
											enumSetting3 = settingValue2;
											enumSetting5 = enumSetting4;
											continue;
										}
										goto IL_06cd;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_078a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0545:
		enumSetting = (EnumSetting)_settingValue;
		if (_settingValue != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			settingValue = (EnumSetting)0;
			nint num9 = (nint)enumSetting;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rdx_v14 (Il2CppClass<EnumSetting>)+40]");
			if (0 != (nint)((BetterSetting)settingValue).settings)
			{
				goto IL_078a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			enumSetting = (EnumSetting)(object)options;
			bool flag17 = options == null;
			settingValue2 = settingValue;
			if (!flag17)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				object arg2 = default(object);
				string message = $"Setting {_settingName} has invalid value. Value: {arg}, options length: {arg2}";
				Debug.LogError(message);
				return;
			}
		}
		throw new NullReferenceException();
		IL_06a8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		enumSetting2 = settingValue2;
		goto IL_0690;
		IL_0690:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		settingValue = settingValue2;
		goto IL_0680;
		IL_06cd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_06a8;
		IL_0680:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_078a;
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
