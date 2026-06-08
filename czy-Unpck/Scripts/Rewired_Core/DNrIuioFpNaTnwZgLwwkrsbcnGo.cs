using System;
using Rewired;

internal struct DNrIuioFpNaTnwZgLwwkrsbcnGo : IEquatable<DNrIuioFpNaTnwZgLwwkrsbcnGo>
{
	public ModifierKey DzyWReoVEVjkPPRTcIQrFppXvVZ;

	public ModifierKey oCOJeddqDlevYkDxZmzkezmKEfu;

	public ModifierKey MJsYUpMZfJSmNsxSZrkJzHcgopV;

	private ModifierKey this[int index]
	{
		get
		{
			if (index <= 0)
			{
				return DzyWReoVEVjkPPRTcIQrFppXvVZ;
			}
			if (index == 1)
			{
				return oCOJeddqDlevYkDxZmzkezmKEfu;
			}
			if (index >= 2)
			{
				return MJsYUpMZfJSmNsxSZrkJzHcgopV;
			}
			return DzyWReoVEVjkPPRTcIQrFppXvVZ;
		}
		set
		{
			if (index <= 0)
			{
				DzyWReoVEVjkPPRTcIQrFppXvVZ = value;
				goto IL_000b;
			}
			goto IL_0054;
			IL_003f:
			int num;
			int num2;
			if (index >= 2)
			{
				num = -956923755;
				num2 = num;
			}
			else
			{
				num = -956923756;
				num2 = num;
			}
			goto IL_0010;
			IL_000b:
			num = -956923753;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -956923754)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					MJsYUpMZfJSmNsxSZrkJzHcgopV = value;
					num = -956923756;
					continue;
				case 0:
					goto IL_003f;
				case 1:
					goto IL_0054;
				case 2:
					return;
				}
				break;
			}
			goto IL_000b;
			IL_0054:
			if (index == 1)
			{
				oCOJeddqDlevYkDxZmzkezmKEfu = value;
				num = -956923754;
				goto IL_0010;
			}
			goto IL_003f;
		}
	}

	public DNrIuioFpNaTnwZgLwwkrsbcnGo(ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		DzyWReoVEVjkPPRTcIQrFppXvVZ = modifierKey1;
		oCOJeddqDlevYkDxZmzkezmKEfu = modifierKey2;
		MJsYUpMZfJSmNsxSZrkJzHcgopV = modifierKey3;
	}

	public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
	{
		if (DzyWReoVEVjkPPRTcIQrFppXvVZ != ModifierKey.None)
		{
			DzyWReoVEVjkPPRTcIQrFppXvVZ = ModifierKey.None;
			goto IL_000f;
		}
		goto IL_0031;
		IL_0047:
		int num;
		if (MJsYUpMZfJSmNsxSZrkJzHcgopV != ModifierKey.None)
		{
			MJsYUpMZfJSmNsxSZrkJzHcgopV = ModifierKey.None;
			num = 1102983898;
			goto IL_0014;
		}
		return;
		IL_000f:
		num = 1102983896;
		goto IL_0014;
		IL_0014:
		switch (num ^ 0x41BE32DB)
		{
		case 0:
			break;
		default:
			return;
		case 3:
			goto IL_0031;
		case 2:
			goto IL_0047;
		case 1:
			return;
		}
		goto IL_000f;
		IL_0031:
		if (oCOJeddqDlevYkDxZmzkezmKEfu != ModifierKey.None)
		{
			oCOJeddqDlevYkDxZmzkezmKEfu = ModifierKey.None;
			num = 1102983897;
			goto IL_0014;
		}
		goto IL_0047;
	}

	public static DNrIuioFpNaTnwZgLwwkrsbcnGo nyieeJfdwFOPVNcNdshjrFlptsE(ModifierKeyFlags P_0)
	{
		DNrIuioFpNaTnwZgLwwkrsbcnGo result = default(DNrIuioFpNaTnwZgLwwkrsbcnGo);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result[num++] = ModifierKey.Control;
			goto IL_0020;
		}
		goto IL_0046;
		IL_00a3:
		return result;
		IL_0020:
		int num2 = -458730187;
		goto IL_0025;
		IL_0025:
		switch (num2 ^ -458730186)
		{
		case 4:
			break;
		case 3:
			goto IL_0046;
		case 1:
			goto IL_0063;
		case 0:
			goto IL_0086;
		default:
			goto IL_00a3;
		}
		goto IL_0020;
		IL_0046:
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result[num++] = ModifierKey.Command;
			num2 = -458730186;
			goto IL_0025;
		}
		goto IL_0086;
		IL_0086:
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result[num++] = ModifierKey.Alt;
			num2 = -458730185;
			goto IL_0025;
		}
		goto IL_0063;
		IL_0063:
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result[num++] = ModifierKey.Shift;
			num2 = -458730188;
			goto IL_0025;
		}
		goto IL_00a3;
	}

	public bool Equals(DNrIuioFpNaTnwZgLwwkrsbcnGo other)
	{
		if (DzyWReoVEVjkPPRTcIQrFppXvVZ == other.DzyWReoVEVjkPPRTcIQrFppXvVZ && oCOJeddqDlevYkDxZmzkezmKEfu == other.oCOJeddqDlevYkDxZmzkezmKEfu)
		{
			return MJsYUpMZfJSmNsxSZrkJzHcgopV == other.MJsYUpMZfJSmNsxSZrkJzHcgopV;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is DNrIuioFpNaTnwZgLwwkrsbcnGo))
		{
			return false;
		}
		return Equals((DNrIuioFpNaTnwZgLwwkrsbcnGo)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		while (true)
		{
			int num2 = 27424781;
			while (true)
			{
				switch (num2 ^ 0x1A2780E)
				{
				case 2:
					break;
				case 3:
					num = num * 29 + DzyWReoVEVjkPPRTcIQrFppXvVZ.GetHashCode();
					num = num * 29 + oCOJeddqDlevYkDxZmzkezmKEfu.GetHashCode();
					num2 = 27424782;
					continue;
				case 0:
					num = num * 29 + MJsYUpMZfJSmNsxSZrkJzHcgopV.GetHashCode();
					num2 = 27424783;
					continue;
				default:
					return num;
				}
				break;
			}
		}
	}

	public static bool operator ==(DNrIuioFpNaTnwZgLwwkrsbcnGo a, DNrIuioFpNaTnwZgLwwkrsbcnGo b)
	{
		if (a.DzyWReoVEVjkPPRTcIQrFppXvVZ == b.DzyWReoVEVjkPPRTcIQrFppXvVZ && a.oCOJeddqDlevYkDxZmzkezmKEfu == b.oCOJeddqDlevYkDxZmzkezmKEfu)
		{
			return a.MJsYUpMZfJSmNsxSZrkJzHcgopV == b.MJsYUpMZfJSmNsxSZrkJzHcgopV;
		}
		return false;
	}

	public static bool operator !=(DNrIuioFpNaTnwZgLwwkrsbcnGo a, DNrIuioFpNaTnwZgLwwkrsbcnGo b)
	{
		return !(a == b);
	}
}
