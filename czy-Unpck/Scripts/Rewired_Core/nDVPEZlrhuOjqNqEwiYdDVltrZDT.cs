using System;
using Rewired;

internal struct nDVPEZlrhuOjqNqEwiYdDVltrZDT : IEquatable<nDVPEZlrhuOjqNqEwiYdDVltrZDT>
{
	public KeyboardKeyCode eCeckwvNiZdHCzvfwrlBXxhtgZs;

	public ModifierKey DzyWReoVEVjkPPRTcIQrFppXvVZ;

	public ModifierKey oCOJeddqDlevYkDxZmzkezmKEfu;

	public ModifierKey MJsYUpMZfJSmNsxSZrkJzHcgopV;

	public nDVPEZlrhuOjqNqEwiYdDVltrZDT(KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		eCeckwvNiZdHCzvfwrlBXxhtgZs = keyCode;
		DzyWReoVEVjkPPRTcIQrFppXvVZ = modifierKey1;
		oCOJeddqDlevYkDxZmzkezmKEfu = modifierKey2;
		MJsYUpMZfJSmNsxSZrkJzHcgopV = modifierKey3;
	}

	public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
	{
		if (eCeckwvNiZdHCzvfwrlBXxhtgZs != KeyboardKeyCode.None)
		{
			goto IL_0008;
		}
		goto IL_0040;
		IL_0008:
		int num = 370613208;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x16171BDC)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				eCeckwvNiZdHCzvfwrlBXxhtgZs = KeyboardKeyCode.None;
				num = 370613209;
				continue;
			case 5:
				goto IL_0040;
			case 1:
				goto IL_0056;
			case 3:
				goto IL_006c;
			case 2:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0056:
		if (MJsYUpMZfJSmNsxSZrkJzHcgopV != ModifierKey.None)
		{
			MJsYUpMZfJSmNsxSZrkJzHcgopV = ModifierKey.None;
			num = 370613214;
			goto IL_000d;
		}
		return;
		IL_0040:
		if (DzyWReoVEVjkPPRTcIQrFppXvVZ != ModifierKey.None)
		{
			DzyWReoVEVjkPPRTcIQrFppXvVZ = ModifierKey.None;
			num = 370613215;
			goto IL_000d;
		}
		goto IL_006c;
		IL_006c:
		if (oCOJeddqDlevYkDxZmzkezmKEfu != ModifierKey.None)
		{
			oCOJeddqDlevYkDxZmzkezmKEfu = ModifierKey.None;
			num = 370613213;
			goto IL_000d;
		}
		goto IL_0056;
	}

	public bool Equals(nDVPEZlrhuOjqNqEwiYdDVltrZDT other)
	{
		if (eCeckwvNiZdHCzvfwrlBXxhtgZs == other.eCeckwvNiZdHCzvfwrlBXxhtgZs && DzyWReoVEVjkPPRTcIQrFppXvVZ == other.DzyWReoVEVjkPPRTcIQrFppXvVZ && oCOJeddqDlevYkDxZmzkezmKEfu == other.oCOJeddqDlevYkDxZmzkezmKEfu)
		{
			return MJsYUpMZfJSmNsxSZrkJzHcgopV == other.MJsYUpMZfJSmNsxSZrkJzHcgopV;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is nDVPEZlrhuOjqNqEwiYdDVltrZDT))
		{
			return false;
		}
		return Equals((nDVPEZlrhuOjqNqEwiYdDVltrZDT)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + eCeckwvNiZdHCzvfwrlBXxhtgZs.GetHashCode();
		num = num * 29 + DzyWReoVEVjkPPRTcIQrFppXvVZ.GetHashCode();
		num = num * 29 + oCOJeddqDlevYkDxZmzkezmKEfu.GetHashCode();
		return num * 29 + MJsYUpMZfJSmNsxSZrkJzHcgopV.GetHashCode();
	}

	public static bool operator ==(nDVPEZlrhuOjqNqEwiYdDVltrZDT a, nDVPEZlrhuOjqNqEwiYdDVltrZDT b)
	{
		if (a.eCeckwvNiZdHCzvfwrlBXxhtgZs == b.eCeckwvNiZdHCzvfwrlBXxhtgZs && a.DzyWReoVEVjkPPRTcIQrFppXvVZ == b.DzyWReoVEVjkPPRTcIQrFppXvVZ && a.oCOJeddqDlevYkDxZmzkezmKEfu == b.oCOJeddqDlevYkDxZmzkezmKEfu)
		{
			return a.MJsYUpMZfJSmNsxSZrkJzHcgopV == b.MJsYUpMZfJSmNsxSZrkJzHcgopV;
		}
		return false;
	}

	public static bool operator !=(nDVPEZlrhuOjqNqEwiYdDVltrZDT a, nDVPEZlrhuOjqNqEwiYdDVltrZDT b)
	{
		return !(a == b);
	}
}
