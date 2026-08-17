using System;
using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;

namespace VampireSurvivors.Objects.Characters;

public class FB_Colonel : CharacterController_FirstBlood
{
	public override float PPower()
	{
		//IL_0059: Invalid comparison between I4 and F4
		//IL_006b: Expected F4, but got I4
		//IL_01d8: Invalid comparison between I4 and F4
		//IL_01ea: Expected F4, but got I4
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		float num9;
		if (_playerStats != null)
		{
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float num = base.PGreed();
			float num3 = default(float);
			float num2 = num3 - 1f;
			bool flag = !(0f < num2);
			float num4 = 0f;
			if (!flag)
			{
				num4 = num2;
			}
			float num5 = base.PCurse();
			num3 = num2 - 1f;
			bool flag2 = !(0f < num3);
			float num6 = 0f;
			if (!flag2)
			{
				num6 = num3;
			}
			float num7 = num6 + num4;
			bool flag3 = !(10f > num7);
			float num8 = 10f;
			if (!flag3)
			{
				num8 = num7;
			}
			if (playerStats._003CPower_003Ek__BackingField != null)
			{
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val + num8;
				if (eggFloat2 != null)
				{
					num9 = eggFloat2._eggVal + eggFloat2._val;
					object obj = num9 & -2147483649L;
					if ((nint)obj != 2139095040)
					{
						object obj2 = num9 & -2147483649L;
						if ((nint)obj2 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875DF292h\"");
							if (num9 == -1f / 0f)
							{
								num9 = -3.4028235E+38f;
							}
							goto IL_01fd;
						}
					}
					num9 = 3.4028235E+38f;
					goto IL_01fd;
				}
			}
		}
		throw new NullReferenceException();
		IL_01fd:
		return num9;
	}
}
