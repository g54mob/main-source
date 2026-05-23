using System;
using UnityEngine;

public class MersenneTwister
{
	private const int N = 624;

	private const int M = 397;

	private const ulong MATRIX_A = 2567483615uL;

	private const ulong UPPER_MASK = 2147483648uL;

	private const ulong LOWER_MASK = 2147483647uL;

	private ulong[] mt = new ulong[624];

	private int mti = 625;

	public float value
	{
		get
		{
			return (float)genrand_real1();
		}
	}

	public Vector2 insideUnitCircle
	{
		get
		{
			float num = (float)genrand_real1();
			float f = (float)Math.PI * 2f * (float)genrand_real1();
			return new Vector2(num * Mathf.Cos(f), num * Mathf.Sin(f));
		}
	}

	public MersenneTwister()
	{
		init_by_array(new ulong[4] { 291uL, 564uL, 837uL, 1110uL });
	}

	public MersenneTwister(ulong s)
	{
		init_genrand(s);
	}

	public MersenneTwister(ulong[] init_key)
	{
		init_by_array(init_key);
	}

	public void init_genrand(ulong s)
	{
		mt[0] = s & 0xFFFFFFFFu;
		for (mti = 1; mti < 624; mti++)
		{
			mt[mti] = 1812433253 * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + (ulong)mti;
			mt[mti] &= 4294967295uL;
		}
	}

	public void init_by_array(ulong[] init_key)
	{
		init_genrand(19650218uL);
		int num = 1;
		int num2 = 0;
		for (int num3 = ((624 <= init_key.Length) ? init_key.Length : 624); num3 != 0; num3--)
		{
			mt[num] = (mt[num] ^ ((mt[num - 1] ^ (mt[num - 1] >> 30)) * 1664525)) + init_key[num2] + (ulong)num2;
			mt[num] &= 4294967295uL;
			num++;
			num2++;
			if (num >= 624)
			{
				mt[0] = mt[623];
				num = 1;
			}
			if (num2 >= init_key.Length)
			{
				num2 = 0;
			}
		}
		for (int num3 = 623; num3 != 0; num3--)
		{
			mt[num] = (mt[num] ^ ((mt[num - 1] ^ (mt[num - 1] >> 30)) * 1566083941)) - (ulong)num;
			mt[num] &= 4294967295uL;
			num++;
			if (num >= 624)
			{
				mt[0] = mt[623];
				num = 1;
			}
		}
		mt[0] = 2147483648uL;
	}

	public ulong genrand_uint32()
	{
		ulong[] array = new ulong[2] { 0uL, 2567483615uL };
		ulong num = 0uL;
		if (mti >= 624)
		{
			if (mti == 625)
			{
				init_genrand(5489uL);
			}
			int i;
			for (i = 0; i < 227; i++)
			{
				num = (mt[i] & 0x80000000u) | (mt[i + 1] & 0x7FFFFFFF);
				mt[i] = mt[i + 397] ^ (num >> 1) ^ array[num & 1];
			}
			for (; i < 623; i++)
			{
				num = (mt[i] & 0x80000000u) | (mt[i + 1] & 0x7FFFFFFF);
				mt[i] = mt[i + -227] ^ (num >> 1) ^ array[num & 1];
			}
			num = (mt[623] & 0x80000000u) | (mt[0] & 0x7FFFFFFF);
			mt[623] = mt[396] ^ (num >> 1) ^ array[num & 1];
			mti = 0;
		}
		num = mt[mti++];
		num ^= num >> 11;
		num ^= (num << 7) & 0x9D2C5680u;
		num ^= (num << 15) & 0xEFC60000u;
		return num ^ (num >> 18);
	}

	public double genrand_real1()
	{
		return (double)genrand_uint32() * 2.3283064370807974E-10;
	}

	public double genrand_real2()
	{
		return (double)genrand_uint32() * 2.3283064365386963E-10;
	}

	public int genrand_N(int iN)
	{
		return (int)((double)genrand_uint32() * ((double)iN / 4294967296.0));
	}

	public float Range(float a, float b)
	{
		return Mathf.Lerp(a, b, (float)genrand_real1());
	}

	public int Range(int a, int b)
	{
		return genrand_N(b - a) + a;
	}
}
