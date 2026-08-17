using System;
using Cpp2ILInjected;
using VampireSurvivors.Data;

namespace VampireSurvivors;

public class TreasurePrizeTypePair
{
	public PrizeType prizeType;

	public ItemType prizeItem;

	public WeaponType prizeWeapon;

	public int Level;

	public unsafe override string ToString()
	{
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0056: Expected O, but got Ref
		//IL_007c: Expected O, but got Ref
		//IL_00a7: Expected O, but got Ref
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected I4, but got Unknown
		string[] array = new string[9];
		object obj = this + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj2 = default(object);
		if (obj2 != null)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v60 @ rdx_v3+168] (should have been resolved before IL gen)");
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				IntPtr intPtr = default(IntPtr);
				string text = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text2 = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				IntPtr intPtr2 = default(IntPtr);
				string text3 = ((Enum)(&intPtr2)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int num = this + 28;
				string text4 = ((int*)num)->ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				return string.Concat(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
