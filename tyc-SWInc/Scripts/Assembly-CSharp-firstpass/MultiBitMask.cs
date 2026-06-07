using System;
using System.Collections.Generic;
using System.Text;

public struct MultiBitMask
{
	public readonly uint[] Mask;

	public int Length
	{
		get
		{
			if (!IsNull)
			{
				return Mask.Length;
			}
			return 0;
		}
	}

	public bool Zero
	{
		get
		{
			for (int i = 0; i < Length; i++)
			{
				if (Mask[i] != 0)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool IsNull
	{
		get
		{
			return Mask == null;
		}
	}

	public uint this[int index]
	{
		get
		{
			return Mask[index];
		}
		set
		{
			Mask[index] = value;
		}
	}

	public MultiBitMask(int len)
	{
		Mask = new uint[len];
	}

	public MultiBitMask(uint[] masks)
	{
		Mask = masks;
	}

	public MultiBitMask(MultiBitMask m)
	{
		Mask = new uint[m.Length];
		for (int i = 0; i < Length; i++)
		{
			Mask[i] = m[i];
		}
	}

	public MultiBitMask(int bits, bool zeros)
	{
		Mask = new uint[(int)Math.Ceiling((double)bits / 32.0)];
		if (!zeros)
		{
			for (int i = 0; i < Mask.Length; i++)
			{
				Mask[i] = uint.MaxValue;
			}
		}
	}

	public MultiBitMask SetBit(int bit, bool on)
	{
		int num = 32;
		if (bit >= 0 && bit < Length * num)
		{
			int num2 = 0;
			while (bit >= num)
			{
				bit -= num;
				num2++;
			}
			if (on)
			{
				this[num2] |= (uint)(1 << bit);
			}
			else
			{
				this[num2] &= (uint)(~(1 << bit));
			}
		}
		return this;
	}

	public bool GetBit(int bit)
	{
		int num = 32;
		if (bit >= 0 && bit < Length * num)
		{
			int num2 = 0;
			while (bit >= num)
			{
				bit -= num;
				num2++;
			}
			return (Mask[num2] & (uint)(1 << bit)) != 0;
		}
		return false;
	}

	public IEnumerable<bool> Iterate()
	{
		int s = 32;
		for (int i = 0; i < Length; i++)
		{
			for (int j = 0; j < s; j++)
			{
				yield return (Mask[i] & (uint)(1 << j)) != 0;
			}
		}
	}

	public MultiBitMask And(MultiBitMask b)
	{
		if (Length != b.Length)
		{
			throw new Exception("Tried to and unequal bitmasks");
		}
		MultiBitMask result = new MultiBitMask(Length);
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = this[i] & b[i];
		}
		return result;
	}

	public bool AndTest(MultiBitMask b)
	{
		if (Length != b.Length)
		{
			throw new Exception("Tried to and unequal bitmasks");
		}
		for (int i = 0; i < Length; i++)
		{
			if ((this[i] & b[i]) != this[i])
			{
				return false;
			}
		}
		return true;
	}

	public void OrSelf(MultiBitMask b)
	{
		if (Length != b.Length)
		{
			throw new Exception("Tried to or unequal bitmasks");
		}
		for (int i = 0; i < Length; i++)
		{
			this[i] |= b[i];
		}
	}

	public MultiBitMask Or(MultiBitMask b)
	{
		if (Length != b.Length)
		{
			throw new Exception("Tried to or unequal bitmasks");
		}
		if (Length == 1)
		{
			return new MultiBitMask(new uint[1] { this[0] | b[0] });
		}
		MultiBitMask result = new MultiBitMask(Length);
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = this[i] | b[i];
		}
		return result;
	}

	public static bool operator !=(MultiBitMask a, MultiBitMask b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(MultiBitMask a, MultiBitMask b)
	{
		return a.Equals(b);
	}

	public static MultiBitMask operator <<(MultiBitMask a, int b)
	{
		if (a.Length == 1)
		{
			return new MultiBitMask(new uint[1] { a[0] << b });
		}
		uint[] array = new uint[a.Length];
		for (int num = a.Length - 1; num >= 0; num--)
		{
			uint num2 = ((num != 0) ? (a[num - 1] >> 32 - b) : 0u);
			array[num] = (a[num] << b) | num2;
		}
		return new MultiBitMask(array);
	}

	public static MultiBitMask operator |(MultiBitMask a, MultiBitMask b)
	{
		return a.Or(b);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is MultiBitMask))
		{
			return false;
		}
		return Equals((MultiBitMask)obj);
	}

	public bool Equals(MultiBitMask mask)
	{
		if (mask.Length != Length)
		{
			return false;
		}
		for (int i = 0; i < Length; i++)
		{
			if (mask[i] != Mask[i])
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = Length;
		for (int i = 0; i < Length; i++)
		{
			num = num * 314159 + Mask[i].GetHashCode();
		}
		return num;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = Length - 1; num >= 0; num--)
		{
			if (num < Length - 1)
			{
				stringBuilder.Append(" ");
			}
			for (int num2 = 31; num2 >= 0; num2--)
			{
				stringBuilder.Append((((this[num] >> num2) & 1) != 0) ? "1" : "0");
			}
		}
		return stringBuilder.ToString();
	}
}
