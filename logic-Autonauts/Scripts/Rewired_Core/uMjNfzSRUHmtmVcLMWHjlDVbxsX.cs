using System;
using Rewired;

internal struct uMjNfzSRUHmtmVcLMWHjlDVbxsX : IEquatable<uMjNfzSRUHmtmVcLMWHjlDVbxsX>
{
	public ModifierKey gWianwYlPTpUyiakpxkqBHyQIsw;

	public ModifierKey DhQEwkTxibArHJgkUgHzhoHRHFXw;

	public ModifierKey dCsxkoqMnFjzELpbGHaMzDGxaiu;

	private ModifierKey this[int index]
	{
		get
		{
			if (index <= 0)
			{
				return gWianwYlPTpUyiakpxkqBHyQIsw;
			}
			if (index == 1)
			{
				return DhQEwkTxibArHJgkUgHzhoHRHFXw;
			}
			if (index >= 2)
			{
				return dCsxkoqMnFjzELpbGHaMzDGxaiu;
			}
			return gWianwYlPTpUyiakpxkqBHyQIsw;
		}
		set
		{
			if (index <= 0)
			{
				gWianwYlPTpUyiakpxkqBHyQIsw = value;
				goto IL_000b;
			}
			goto IL_002d;
			IL_003f:
			int num;
			if (index >= 2)
			{
				dCsxkoqMnFjzELpbGHaMzDGxaiu = value;
				num = -126045864;
				goto IL_0010;
			}
			return;
			IL_000b:
			num = -126045862;
			goto IL_0010;
			IL_0010:
			switch (num ^ -126045861)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_002d;
			case 2:
				goto IL_003f;
			case 3:
				return;
			}
			goto IL_000b;
			IL_002d:
			if (index == 1)
			{
				DhQEwkTxibArHJgkUgHzhoHRHFXw = value;
				num = -126045863;
				goto IL_0010;
			}
			goto IL_003f;
		}
	}

	public uMjNfzSRUHmtmVcLMWHjlDVbxsX(ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		gWianwYlPTpUyiakpxkqBHyQIsw = modifierKey1;
		DhQEwkTxibArHJgkUgHzhoHRHFXw = modifierKey2;
		dCsxkoqMnFjzELpbGHaMzDGxaiu = modifierKey3;
	}

	public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
	{
		if (gWianwYlPTpUyiakpxkqBHyQIsw != ModifierKey.None)
		{
			gWianwYlPTpUyiakpxkqBHyQIsw = ModifierKey.None;
			goto IL_000f;
		}
		goto IL_0035;
		IL_0035:
		int num;
		if (DhQEwkTxibArHJgkUgHzhoHRHFXw != ModifierKey.None)
		{
			DhQEwkTxibArHJgkUgHzhoHRHFXw = ModifierKey.None;
			num = -2075608327;
			goto IL_0014;
		}
		goto IL_0059;
		IL_000f:
		num = -2075608324;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num ^ -2075608323)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0035;
			case 0:
				dCsxkoqMnFjzELpbGHaMzDGxaiu = ModifierKey.None;
				num = -2075608321;
				continue;
			case 4:
				goto IL_0059;
			case 2:
				return;
			}
			break;
		}
		goto IL_000f;
		IL_0059:
		int num2;
		if (dCsxkoqMnFjzELpbGHaMzDGxaiu == ModifierKey.None)
		{
			num = -2075608321;
			num2 = num;
		}
		else
		{
			num = -2075608323;
			num2 = num;
		}
		goto IL_0014;
	}

	public static uMjNfzSRUHmtmVcLMWHjlDVbxsX GfmBBOdBWBAJKCgHamBoQtPqQiti(ModifierKeyFlags P_0)
	{
		uMjNfzSRUHmtmVcLMWHjlDVbxsX result = default(uMjNfzSRUHmtmVcLMWHjlDVbxsX);
		int num = 0;
		while (true)
		{
			int num2 = 1636668438;
			while (true)
			{
				switch (num2 ^ 0x618D9410)
				{
				case 2:
					break;
				case 6:
				{
					int num5;
					if (!Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
					{
						num2 = 1636668433;
						num5 = num2;
					}
					else
					{
						num2 = 1636668439;
						num5 = num2;
					}
					continue;
				}
				case 8:
					result[num++] = ModifierKey.Command;
					num2 = 1636668437;
					continue;
				case 4:
					result[num++] = ModifierKey.Alt;
					num2 = 1636668432;
					continue;
				case 5:
				{
					int num4;
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
					{
						num2 = 1636668436;
						num4 = num2;
					}
					else
					{
						num2 = 1636668432;
						num4 = num2;
					}
					continue;
				}
				case 7:
					result[num++] = ModifierKey.Control;
					num2 = 1636668433;
					continue;
				case 0:
					if (num >= 3)
					{
						return result;
					}
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
					{
						result[num++] = ModifierKey.Shift;
						num2 = 1636668435;
						continue;
					}
					goto default;
				case 1:
				{
					int num3;
					if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
					{
						num2 = 1636668440;
						num3 = num2;
					}
					else
					{
						num2 = 1636668437;
						num3 = num2;
					}
					continue;
				}
				default:
					return result;
				}
				break;
			}
		}
	}

	public bool Equals(uMjNfzSRUHmtmVcLMWHjlDVbxsX other)
	{
		if (gWianwYlPTpUyiakpxkqBHyQIsw == other.gWianwYlPTpUyiakpxkqBHyQIsw && DhQEwkTxibArHJgkUgHzhoHRHFXw == other.DhQEwkTxibArHJgkUgHzhoHRHFXw)
		{
			return dCsxkoqMnFjzELpbGHaMzDGxaiu == other.dCsxkoqMnFjzELpbGHaMzDGxaiu;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			while (true)
			{
				int num = -894293024;
				while (true)
				{
					switch (num ^ -894293022)
					{
					case 0:
						break;
					case 2:
						goto IL_0021;
					default:
						goto end_IL_0003;
					}
					break;
					IL_0021:
					if (!(obj is uMjNfzSRUHmtmVcLMWHjlDVbxsX))
					{
						num = -894293021;
						continue;
					}
					return Equals((uMjNfzSRUHmtmVcLMWHjlDVbxsX)obj);
				}
				continue;
				end_IL_0003:
				break;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 17;
		while (true)
		{
			int num2 = 2117239112;
			while (true)
			{
				switch (num2 ^ 0x7E32814A)
				{
				case 0:
					break;
				case 2:
					goto IL_0021;
				default:
					return num * 29 + dCsxkoqMnFjzELpbGHaMzDGxaiu.GetHashCode();
				}
				break;
				IL_0021:
				num = num * 29 + gWianwYlPTpUyiakpxkqBHyQIsw.GetHashCode();
				num = num * 29 + DhQEwkTxibArHJgkUgHzhoHRHFXw.GetHashCode();
				num2 = 2117239115;
			}
		}
	}

	public static bool operator ==(uMjNfzSRUHmtmVcLMWHjlDVbxsX a, uMjNfzSRUHmtmVcLMWHjlDVbxsX b)
	{
		if (a.gWianwYlPTpUyiakpxkqBHyQIsw == b.gWianwYlPTpUyiakpxkqBHyQIsw && a.DhQEwkTxibArHJgkUgHzhoHRHFXw == b.DhQEwkTxibArHJgkUgHzhoHRHFXw)
		{
			return a.dCsxkoqMnFjzELpbGHaMzDGxaiu == b.dCsxkoqMnFjzELpbGHaMzDGxaiu;
		}
		return false;
	}

	public static bool operator !=(uMjNfzSRUHmtmVcLMWHjlDVbxsX a, uMjNfzSRUHmtmVcLMWHjlDVbxsX b)
	{
		return !(a == b);
	}
}
