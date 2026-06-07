using System;
using Rewired;

internal struct dNIkkpHmbenRXMbwvhZsDaEKwGD : IEquatable<dNIkkpHmbenRXMbwvhZsDaEKwGD>
{
	public ModifierKey dzVdjlEVQwgzvzhVUKnnyxEfDccq;

	public ModifierKey QevfNgMhRGjlsMgBpjDuDOAeljTh;

	public ModifierKey yKFGycBpxalffjUWjPHPvRPQTWmG;

	private ModifierKey this[int index]
	{
		get
		{
			if (index <= 0)
			{
				return dzVdjlEVQwgzvzhVUKnnyxEfDccq;
			}
			if (index == 1)
			{
				return QevfNgMhRGjlsMgBpjDuDOAeljTh;
			}
			if (index >= 2)
			{
				return yKFGycBpxalffjUWjPHPvRPQTWmG;
			}
			return dzVdjlEVQwgzvzhVUKnnyxEfDccq;
		}
		set
		{
			if (index <= 0)
			{
				dzVdjlEVQwgzvzhVUKnnyxEfDccq = value;
			}
			if (index == 1)
			{
				QevfNgMhRGjlsMgBpjDuDOAeljTh = value;
			}
			if (index >= 2)
			{
				yKFGycBpxalffjUWjPHPvRPQTWmG = value;
			}
		}
	}

	public dNIkkpHmbenRXMbwvhZsDaEKwGD(ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
	{
		dzVdjlEVQwgzvzhVUKnnyxEfDccq = modifierKey1;
		QevfNgMhRGjlsMgBpjDuDOAeljTh = modifierKey2;
		yKFGycBpxalffjUWjPHPvRPQTWmG = modifierKey3;
	}

	public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		if (dzVdjlEVQwgzvzhVUKnnyxEfDccq != ModifierKey.None)
		{
			dzVdjlEVQwgzvzhVUKnnyxEfDccq = ModifierKey.None;
		}
		if (QevfNgMhRGjlsMgBpjDuDOAeljTh != ModifierKey.None)
		{
			QevfNgMhRGjlsMgBpjDuDOAeljTh = ModifierKey.None;
		}
		if (yKFGycBpxalffjUWjPHPvRPQTWmG != ModifierKey.None)
		{
			yKFGycBpxalffjUWjPHPvRPQTWmG = ModifierKey.None;
		}
	}

	public static dNIkkpHmbenRXMbwvhZsDaEKwGD NyBUUOCvTkHIxpgoRNwhNoOJOKx(ModifierKeyFlags P_0)
	{
		dNIkkpHmbenRXMbwvhZsDaEKwGD result = default(dNIkkpHmbenRXMbwvhZsDaEKwGD);
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result[num++] = ModifierKey.Control;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result[num++] = ModifierKey.Command;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result[num++] = ModifierKey.Alt;
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result[num++] = ModifierKey.Shift;
		}
		return result;
	}

	public bool Equals(dNIkkpHmbenRXMbwvhZsDaEKwGD other)
	{
		if (dzVdjlEVQwgzvzhVUKnnyxEfDccq == other.dzVdjlEVQwgzvzhVUKnnyxEfDccq && QevfNgMhRGjlsMgBpjDuDOAeljTh == other.QevfNgMhRGjlsMgBpjDuDOAeljTh)
		{
			return yKFGycBpxalffjUWjPHPvRPQTWmG == other.yKFGycBpxalffjUWjPHPvRPQTWmG;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is dNIkkpHmbenRXMbwvhZsDaEKwGD))
		{
			return false;
		}
		return Equals((dNIkkpHmbenRXMbwvhZsDaEKwGD)obj);
	}

	public override int GetHashCode()
	{
		int num = 17;
		num = num * 29 + dzVdjlEVQwgzvzhVUKnnyxEfDccq.GetHashCode();
		num = num * 29 + QevfNgMhRGjlsMgBpjDuDOAeljTh.GetHashCode();
		return num * 29 + yKFGycBpxalffjUWjPHPvRPQTWmG.GetHashCode();
	}

	public static bool operator ==(dNIkkpHmbenRXMbwvhZsDaEKwGD a, dNIkkpHmbenRXMbwvhZsDaEKwGD b)
	{
		if (a.dzVdjlEVQwgzvzhVUKnnyxEfDccq == b.dzVdjlEVQwgzvzhVUKnnyxEfDccq && a.QevfNgMhRGjlsMgBpjDuDOAeljTh == b.QevfNgMhRGjlsMgBpjDuDOAeljTh)
		{
			return a.yKFGycBpxalffjUWjPHPvRPQTWmG == b.yKFGycBpxalffjUWjPHPvRPQTWmG;
		}
		return false;
	}

	public static bool operator !=(dNIkkpHmbenRXMbwvhZsDaEKwGD a, dNIkkpHmbenRXMbwvhZsDaEKwGD b)
	{
		return !(a == b);
	}
}
