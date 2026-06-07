using System;
using Rewired;

internal struct GZVjuIZEQgCufijhxtroNXVwOEy : IEquatable<GZVjuIZEQgCufijhxtroNXVwOEy>
{
	public KeyboardKeyCode VbwqNhPkRZCERMqIhyUQZMHiGtL;

	public ModifierKey gWianwYlPTpUyiakpxkqBHyQIsw;

	public ModifierKey DhQEwkTxibArHJgkUgHzhoHRHFXw;

	public ModifierKey dCsxkoqMnFjzELpbGHaMzDGxaiu;

	public GZVjuIZEQgCufijhxtroNXVwOEy(KeyboardKeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		VbwqNhPkRZCERMqIhyUQZMHiGtL = keyCode;
		gWianwYlPTpUyiakpxkqBHyQIsw = modifierKey1;
		DhQEwkTxibArHJgkUgHzhoHRHFXw = modifierKey2;
		dCsxkoqMnFjzELpbGHaMzDGxaiu = modifierKey3;
	}

	public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
	{
		if (VbwqNhPkRZCERMqIhyUQZMHiGtL != KeyboardKeyCode.None)
		{
			VbwqNhPkRZCERMqIhyUQZMHiGtL = KeyboardKeyCode.None;
			goto IL_000f;
		}
		goto IL_0035;
		IL_004b:
		int num;
		if (DhQEwkTxibArHJgkUgHzhoHRHFXw != ModifierKey.None)
		{
			DhQEwkTxibArHJgkUgHzhoHRHFXw = ModifierKey.None;
			num = 1741257515;
			goto IL_0014;
		}
		goto IL_0061;
		IL_000f:
		num = 1741257513;
		goto IL_0014;
		IL_0014:
		switch (num ^ 0x67C97B28)
		{
		case 2:
			break;
		default:
			return;
		case 1:
			goto IL_0035;
		case 4:
			goto IL_004b;
		case 3:
			goto IL_0061;
		case 0:
			return;
		}
		goto IL_000f;
		IL_0035:
		if (gWianwYlPTpUyiakpxkqBHyQIsw != ModifierKey.None)
		{
			gWianwYlPTpUyiakpxkqBHyQIsw = ModifierKey.None;
			num = 1741257516;
			goto IL_0014;
		}
		goto IL_004b;
		IL_0061:
		if (dCsxkoqMnFjzELpbGHaMzDGxaiu != ModifierKey.None)
		{
			dCsxkoqMnFjzELpbGHaMzDGxaiu = ModifierKey.None;
			num = 1741257512;
			goto IL_0014;
		}
	}

	public bool Equals(GZVjuIZEQgCufijhxtroNXVwOEy other)
	{
		if (VbwqNhPkRZCERMqIhyUQZMHiGtL == other.VbwqNhPkRZCERMqIhyUQZMHiGtL && gWianwYlPTpUyiakpxkqBHyQIsw == other.gWianwYlPTpUyiakpxkqBHyQIsw && DhQEwkTxibArHJgkUgHzhoHRHFXw == other.DhQEwkTxibArHJgkUgHzhoHRHFXw)
		{
			return dCsxkoqMnFjzELpbGHaMzDGxaiu == other.dCsxkoqMnFjzELpbGHaMzDGxaiu;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is GZVjuIZEQgCufijhxtroNXVwOEy))
		{
			return false;
		}
		return Equals((GZVjuIZEQgCufijhxtroNXVwOEy)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + VbwqNhPkRZCERMqIhyUQZMHiGtL.GetHashCode();
		num = num * 29 + gWianwYlPTpUyiakpxkqBHyQIsw.GetHashCode();
		while (true)
		{
			int num2 = 781992365;
			while (true)
			{
				switch (num2 ^ 0x2E9C41AF)
				{
				case 0:
					break;
				case 2:
					goto IL_004d;
				default:
					return num * 29 + dCsxkoqMnFjzELpbGHaMzDGxaiu.GetHashCode();
				}
				break;
				IL_004d:
				num = num * 29 + DhQEwkTxibArHJgkUgHzhoHRHFXw.GetHashCode();
				num2 = 781992366;
			}
		}
	}

	public static bool operator ==(GZVjuIZEQgCufijhxtroNXVwOEy a, GZVjuIZEQgCufijhxtroNXVwOEy b)
	{
		if (a.VbwqNhPkRZCERMqIhyUQZMHiGtL == b.VbwqNhPkRZCERMqIhyUQZMHiGtL && a.gWianwYlPTpUyiakpxkqBHyQIsw == b.gWianwYlPTpUyiakpxkqBHyQIsw && a.DhQEwkTxibArHJgkUgHzhoHRHFXw == b.DhQEwkTxibArHJgkUgHzhoHRHFXw)
		{
			return a.dCsxkoqMnFjzELpbGHaMzDGxaiu == b.dCsxkoqMnFjzELpbGHaMzDGxaiu;
		}
		return false;
	}

	public static bool operator !=(GZVjuIZEQgCufijhxtroNXVwOEy a, GZVjuIZEQgCufijhxtroNXVwOEy b)
	{
		return !(a == b);
	}
}
