using System;
using Rewired;

internal struct DPdDgksNILmWTzDYcQDlYsVlndC : IEquatable<DPdDgksNILmWTzDYcQDlYsVlndC>
{
	public ModifierKey HkyvOsaidNYmdQZrPxleuzBGLMn;

	public ModifierKey ieSOzjvYulYvizEtgeNbBYPVuII;

	public ModifierKey KuyoSjIDOVSRhxVsoVPCAPYbbyt;

	private ModifierKey this[int index]
	{
		get
		{
			if (index <= 0)
			{
				return HkyvOsaidNYmdQZrPxleuzBGLMn;
			}
			if (index == 1)
			{
				return ieSOzjvYulYvizEtgeNbBYPVuII;
			}
			if (index >= 2)
			{
				return KuyoSjIDOVSRhxVsoVPCAPYbbyt;
			}
			return HkyvOsaidNYmdQZrPxleuzBGLMn;
		}
		set
		{
			if (index <= 0)
			{
				HkyvOsaidNYmdQZrPxleuzBGLMn = value;
				goto IL_000b;
			}
			goto IL_0031;
			IL_0031:
			int num;
			int num2;
			if (index == 1)
			{
				num = 111652267;
				num2 = num;
			}
			else
			{
				num = 111652265;
				num2 = num;
			}
			goto IL_0010;
			IL_000b:
			num = 111652269;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ 0x6A7ADA9)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					goto IL_0031;
				case 0:
					if (index >= 2)
					{
						KuyoSjIDOVSRhxVsoVPCAPYbbyt = value;
						num = 111652264;
						continue;
					}
					return;
				case 2:
					ieSOzjvYulYvizEtgeNbBYPVuII = value;
					num = 111652265;
					continue;
				case 1:
					return;
				}
				break;
			}
			goto IL_000b;
		}
	}

	public DPdDgksNILmWTzDYcQDlYsVlndC(ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		HkyvOsaidNYmdQZrPxleuzBGLMn = modifierKey1;
		ieSOzjvYulYvizEtgeNbBYPVuII = modifierKey2;
		KuyoSjIDOVSRhxVsoVPCAPYbbyt = modifierKey3;
	}

	public void nympziBLtYDUiPlWNRoEGqbSPfa()
	{
		if (HkyvOsaidNYmdQZrPxleuzBGLMn != ModifierKey.None)
		{
			HkyvOsaidNYmdQZrPxleuzBGLMn = ModifierKey.None;
			goto IL_000f;
		}
		goto IL_0035;
		IL_0059:
		int num;
		int num2;
		if (KuyoSjIDOVSRhxVsoVPCAPYbbyt == ModifierKey.None)
		{
			num = 214843098;
			num2 = num;
		}
		else
		{
			num = 214843102;
			num2 = num;
		}
		goto IL_0014;
		IL_000f:
		num = 214843099;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ 0xCCE3EDA)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0035;
			case 4:
				KuyoSjIDOVSRhxVsoVPCAPYbbyt = ModifierKey.None;
				num = 214843098;
				continue;
			case 3:
				goto IL_0059;
			case 0:
				return;
			}
			break;
		}
		goto IL_000f;
		IL_0035:
		if (ieSOzjvYulYvizEtgeNbBYPVuII != ModifierKey.None)
		{
			ieSOzjvYulYvizEtgeNbBYPVuII = ModifierKey.None;
			num = 214843097;
			goto IL_0014;
		}
		goto IL_0059;
	}

	public static DPdDgksNILmWTzDYcQDlYsVlndC dEcGUDazSBDgjhOEGPZoaCPIgrii(ModifierKeyFlags P_0)
	{
		DPdDgksNILmWTzDYcQDlYsVlndC result = default(DPdDgksNILmWTzDYcQDlYsVlndC);
		int num = 0;
		while (true)
		{
			int num2 = 1734621474;
			while (true)
			{
				switch (num2 ^ 0x67643923)
				{
				case 3:
					break;
				case 1:
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
					{
						result[num++] = ModifierKey.Control;
						num2 = 1734621475;
						continue;
					}
					goto case 0;
				case 0:
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
					{
						result[num++] = ModifierKey.Command;
						num2 = 1734621479;
						continue;
					}
					goto case 4;
				case 2:
					if (num >= 3)
					{
						return result;
					}
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
					{
						result[num++] = ModifierKey.Shift;
						num2 = 1734621477;
						continue;
					}
					goto default;
				case 4:
				{
					int num3;
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
					{
						num2 = 1734621478;
						num3 = num2;
					}
					else
					{
						num2 = 1734621473;
						num3 = num2;
					}
					continue;
				}
				case 5:
					result[num++] = ModifierKey.Alt;
					num2 = 1734621473;
					continue;
				default:
					return result;
				}
				break;
			}
		}
	}

	public bool Equals(DPdDgksNILmWTzDYcQDlYsVlndC other)
	{
		if (HkyvOsaidNYmdQZrPxleuzBGLMn == other.HkyvOsaidNYmdQZrPxleuzBGLMn && ieSOzjvYulYvizEtgeNbBYPVuII == other.ieSOzjvYulYvizEtgeNbBYPVuII)
		{
			return KuyoSjIDOVSRhxVsoVPCAPYbbyt == other.KuyoSjIDOVSRhxVsoVPCAPYbbyt;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is DPdDgksNILmWTzDYcQDlYsVlndC))
		{
			return false;
		}
		return Equals((DPdDgksNILmWTzDYcQDlYsVlndC)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + HkyvOsaidNYmdQZrPxleuzBGLMn.GetHashCode();
		num = num * 29 + ieSOzjvYulYvizEtgeNbBYPVuII.GetHashCode();
		while (true)
		{
			int num2 = -2118200416;
			while (true)
			{
				switch (num2 ^ -2118200414)
				{
				case 0:
					break;
				case 2:
					goto IL_004d;
				default:
					return num;
				}
				break;
				IL_004d:
				num = num * 29 + KuyoSjIDOVSRhxVsoVPCAPYbbyt.GetHashCode();
				num2 = -2118200413;
			}
		}
	}

	public static bool operator ==(DPdDgksNILmWTzDYcQDlYsVlndC a, DPdDgksNILmWTzDYcQDlYsVlndC b)
	{
		if (a.HkyvOsaidNYmdQZrPxleuzBGLMn == b.HkyvOsaidNYmdQZrPxleuzBGLMn && a.ieSOzjvYulYvizEtgeNbBYPVuII == b.ieSOzjvYulYvizEtgeNbBYPVuII)
		{
			return a.KuyoSjIDOVSRhxVsoVPCAPYbbyt == b.KuyoSjIDOVSRhxVsoVPCAPYbbyt;
		}
		return false;
	}

	public static bool operator !=(DPdDgksNILmWTzDYcQDlYsVlndC a, DPdDgksNILmWTzDYcQDlYsVlndC b)
	{
		return !(a == b);
	}
}
