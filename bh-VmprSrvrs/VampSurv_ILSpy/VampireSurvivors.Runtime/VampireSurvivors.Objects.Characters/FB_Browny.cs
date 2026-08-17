using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Browny : CharacterController_FirstBlood
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		base.SetBloodColor(16777147u);
	}

	public override float PArea()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArea_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DEFABh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_00eb;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00eb;
		IL_00eb:
		float num2 = base.PCooldownFinal();
		object obj3 = default(object);
		float num3 = 1f - (float)obj3;
		float num4 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num4 & 0;
		float num5 = num3 + num3;
		bool flag = !(1f > num5);
		float num6 = 1f;
		if (!flag)
		{
			num6 = num5;
		}
		return (float)obj4 + num6;
	}

	public override void AfterFullInitialization()
	{
		//IL_001d: Expected O, but got I4
		//IL_0045: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		base.AfterFullInitialization();
		List<PropType> pROPSTypes = new List<PropType>();
		_PROPSTypes = pROPSTypes;
		object obj = 0;
		do
		{
			List<System.Int32Enum> pROPSTypes2 = (List<System.Int32Enum>)(object)_PROPSTypes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ r8_v5+18]");
			if (num >= 0)
			{
				pROPSTypes2.AddWithResize((System.Int32Enum)102);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = 102;
			}
			obj++;
		}
		while ((nint)obj < 4);
		_spawnExtraProps = true;
	}
}
