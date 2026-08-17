using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Newt : CharacterController_FirstBlood
{
	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		base.SetBloodColor(4500036u);
	}

	public override float PPower()
	{
		//IL_0059: Invalid comparison between I4 and F4
		//IL_006b: Expected F4, but got I4
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		if (_playerStats != null)
		{
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float num = base.PSpeed();
			float num2 = num2 - 1f;
			bool flag = !(0f < num2);
			float num3 = 0f;
			if (!flag)
			{
				num3 = num2;
			}
			bool flag2 = !(10f > num3);
			float num4 = 10f;
			if (!flag2)
			{
				num4 = num3;
			}
			if (playerStats._003CPower_003Ek__BackingField != null)
			{
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + num4;
				if (eggFloat2 != null)
				{
					float num5 = eggFloat2._eggVal + eggFloat2._val;
					object obj = num5 & -2147483649L;
					if ((nint)obj != 2139095040)
					{
						object obj2 = num5 & -2147483649L;
						if ((nint)obj2 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875E064Dh\"");
							if (num5 == -1f / 0f)
							{
								num5 = -3.4028235E+38f;
							}
							return num5;
						}
					}
					return 3.4028235E+38f;
				}
			}
		}
		throw new NullReferenceException();
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
				pROPSTypes2.AddWithResize((System.Int32Enum)103);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj3 = (nint)0 + (nint)1;
				_ = 103;
			}
			obj++;
		}
		while ((nint)obj < 20);
		_spawnExtraProps = true;
	}
}
