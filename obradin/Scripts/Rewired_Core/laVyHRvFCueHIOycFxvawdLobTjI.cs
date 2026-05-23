using System;
using Rewired;

internal struct laVyHRvFCueHIOycFxvawdLobTjI : IEquatable<laVyHRvFCueHIOycFxvawdLobTjI>
{
	public KeyboardKeyCode aBmlGepoDHejkomZPBOKauFmINOW;

	public ModifierKey HkyvOsaidNYmdQZrPxleuzBGLMn;

	public ModifierKey ieSOzjvYulYvizEtgeNbBYPVuII;

	public ModifierKey KuyoSjIDOVSRhxVsoVPCAPYbbyt;

	public laVyHRvFCueHIOycFxvawdLobTjI(KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		aBmlGepoDHejkomZPBOKauFmINOW = keyCode;
		HkyvOsaidNYmdQZrPxleuzBGLMn = modifierKey1;
		ieSOzjvYulYvizEtgeNbBYPVuII = modifierKey2;
		KuyoSjIDOVSRhxVsoVPCAPYbbyt = modifierKey3;
	}

	public void nympziBLtYDUiPlWNRoEGqbSPfa()
	{
		if (aBmlGepoDHejkomZPBOKauFmINOW != KeyboardKeyCode.None)
		{
			aBmlGepoDHejkomZPBOKauFmINOW = KeyboardKeyCode.None;
			goto IL_000f;
		}
		goto IL_005d;
		IL_0047:
		int num;
		if (ieSOzjvYulYvizEtgeNbBYPVuII != ModifierKey.None)
		{
			ieSOzjvYulYvizEtgeNbBYPVuII = ModifierKey.None;
			num = -1526358418;
			goto IL_0014;
		}
		goto IL_0073;
		IL_000f:
		num = -1526358420;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ -1526358417)
			{
			case 0:
				break;
			default:
				return;
			case 5:
				KuyoSjIDOVSRhxVsoVPCAPYbbyt = ModifierKey.None;
				num = -1526358419;
				continue;
			case 4:
				goto IL_0047;
			case 3:
				goto IL_005d;
			case 1:
				goto IL_0073;
			case 2:
				return;
			}
			break;
		}
		goto IL_000f;
		IL_005d:
		if (HkyvOsaidNYmdQZrPxleuzBGLMn != ModifierKey.None)
		{
			HkyvOsaidNYmdQZrPxleuzBGLMn = ModifierKey.None;
			num = -1526358421;
			goto IL_0014;
		}
		goto IL_0047;
		IL_0073:
		int num2;
		if (KuyoSjIDOVSRhxVsoVPCAPYbbyt == ModifierKey.None)
		{
			num = -1526358419;
			num2 = num;
		}
		else
		{
			num = -1526358422;
			num2 = num;
		}
		goto IL_0014;
	}

	public bool Equals(laVyHRvFCueHIOycFxvawdLobTjI other)
	{
		if (aBmlGepoDHejkomZPBOKauFmINOW == other.aBmlGepoDHejkomZPBOKauFmINOW)
		{
			while (true)
			{
				int num = -986783582;
				while (true)
				{
					switch (num ^ -986783581)
					{
					case 0:
						break;
					case 1:
						goto IL_002d;
					default:
						goto IL_0043;
					}
					break;
					IL_0043:
					if (ieSOzjvYulYvizEtgeNbBYPVuII != other.ieSOzjvYulYvizEtgeNbBYPVuII)
					{
						goto end_IL_000f;
					}
					return KuyoSjIDOVSRhxVsoVPCAPYbbyt == other.KuyoSjIDOVSRhxVsoVPCAPYbbyt;
					IL_002d:
					if (HkyvOsaidNYmdQZrPxleuzBGLMn != other.HkyvOsaidNYmdQZrPxleuzBGLMn)
					{
						goto end_IL_000f;
					}
					num = -986783583;
				}
				continue;
				end_IL_000f:
				break;
			}
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is laVyHRvFCueHIOycFxvawdLobTjI))
		{
			return false;
		}
		return Equals((laVyHRvFCueHIOycFxvawdLobTjI)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + aBmlGepoDHejkomZPBOKauFmINOW.GetHashCode();
		num = num * 29 + HkyvOsaidNYmdQZrPxleuzBGLMn.GetHashCode();
		num = num * 29 + ieSOzjvYulYvizEtgeNbBYPVuII.GetHashCode();
		return num * 29 + KuyoSjIDOVSRhxVsoVPCAPYbbyt.GetHashCode();
	}

	public static bool operator ==(laVyHRvFCueHIOycFxvawdLobTjI a, laVyHRvFCueHIOycFxvawdLobTjI b)
	{
		if (a.aBmlGepoDHejkomZPBOKauFmINOW == b.aBmlGepoDHejkomZPBOKauFmINOW && a.HkyvOsaidNYmdQZrPxleuzBGLMn == b.HkyvOsaidNYmdQZrPxleuzBGLMn && a.ieSOzjvYulYvizEtgeNbBYPVuII == b.ieSOzjvYulYvizEtgeNbBYPVuII)
		{
			return a.KuyoSjIDOVSRhxVsoVPCAPYbbyt == b.KuyoSjIDOVSRhxVsoVPCAPYbbyt;
		}
		return false;
	}

	public static bool operator !=(laVyHRvFCueHIOycFxvawdLobTjI a, laVyHRvFCueHIOycFxvawdLobTjI b)
	{
		return !(a == b);
	}
}
