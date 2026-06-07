using System;
using UnityEngine;

[Serializable]
public struct Index3
{
	public static readonly Index3 Zero;

	public static readonly Index3 Forward;

	public static readonly Index3 Backward;

	public static readonly Index3 Left;

	public static readonly Index3 Right;

	public static readonly Index3 Up;

	public static readonly Index3 Down;

	public int X;

	public int Y;

	public int Z;

	public Index3(int _0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D, int _0023_003DqLkBZJhSJigy4rT8G9XcOpQ_003D_003D, int _0023_003Dqo3WkBn5Cp3RNaUG4ei0wxg_003D_003D)
	{
		if (2u != 0)
		{
			X = _0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D;
		}
		if (5u != 0)
		{
			Y = _0023_003DqLkBZJhSJigy4rT8G9XcOpQ_003D_003D;
		}
		if (7u != 0)
		{
			Z = _0023_003Dqo3WkBn5Cp3RNaUG4ei0wxg_003D_003D;
		}
	}

	static Index3()
	{
		Index3 zero = new Index3(0, 0, 0);
		if (7u != 0)
		{
			Zero = zero;
		}
		Index3 forward = new Index3(0, 0, 1);
		if (0 == 0)
		{
			Forward = forward;
		}
		Index3 backward = new Index3(0, 0, -1);
		if (true)
		{
			Backward = backward;
		}
		Left = new Index3(-1, 0, 0);
		Right = new Index3(1, 0, 0);
		Up = new Index3(0, 1, 0);
		Down = new Index3(0, -1, 0);
	}

	public static Index3 _0023_003DqTzkck15YX2_FWm_WDIfBTg_003D_003D(Vector3 _0023_003DqHrE2WkT9XC3Qntr0Z4Mpcw_003D_003D)
	{
		return new Index3((int)Mathf.Round(_0023_003DqHrE2WkT9XC3Qntr0Z4Mpcw_003D_003D.x), (int)Mathf.Round(_0023_003DqHrE2WkT9XC3Qntr0Z4Mpcw_003D_003D.y), (int)Mathf.Round(_0023_003DqHrE2WkT9XC3Qntr0Z4Mpcw_003D_003D.z));
	}

	public bool _0023_003DqsSacXSUjBd0_ilK3odjUCQ_003D_003D(Index3 _0023_003Dq7ZNloZpwLng9VcafI_l9lQ_003D_003D)
	{
		int num = 2;
		if (-1 == 0)
		{
		}
		int result;
		if (X == _0023_003Dq7ZNloZpwLng9VcafI_l9lQ_003D_003D.X)
		{
			int num2 = 7;
			if (-1 == 0)
			{
			}
			if (Y == _0023_003Dq7ZNloZpwLng9VcafI_l9lQ_003D_003D.Y)
			{
				int num3 = 8;
				if (6 == 0)
				{
				}
				result = ((Z == _0023_003Dq7ZNloZpwLng9VcafI_l9lQ_003D_003D.Z) ? 1 : 0);
				goto IL_004c;
			}
		}
		result = 0;
		goto IL_004c;
		IL_004c:
		return (byte)result != 0;
	}

	public override bool Equals(object _0023_003DqGazUhfA6C0jKspsF9faZXw_003D_003D)
	{
		Index3? obj = _0023_003DqGazUhfA6C0jKspsF9faZXw_003D_003D as Index3?;
		Index3? index;
		if (4u != 0)
		{
			index = obj;
		}
		if (index.HasValue)
		{
			return _0023_003DqsSacXSUjBd0_ilK3odjUCQ_003D_003D(index.Value);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num;
		if (8u != 0)
		{
			num = 17;
		}
		int num2 = num * 23 + X.GetHashCode();
		if (0 == 0)
		{
			num = num2;
		}
		int num3 = num * 23 + Y.GetHashCode();
		if (0 == 0)
		{
			num = num3;
		}
		return num * 23 + Z.GetHashCode();
	}

	public override string ToString()
	{
		string _0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991936);
		object[] array = new object[3];
		int num = 7;
		if (6 == 0)
		{
		}
		array[0] = X;
		int num2 = 8;
		if (-1 == 0)
		{
		}
		array[1] = Y;
		int num3 = 1;
		if (6 == 0)
		{
		}
		array[2] = Z;
		return _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D._0023_003DqMuax2R_00241K_xWFnMjKF4QoVMyLJdbKwr3U7yJtcyjFqw_003D(_0023_003Dq78Mga_VljAVGHCR7GPbPVw_003D_003D, array);
	}

	public Index3 _0023_003Dqwaw14lBB_3juJS_0024XtqpjSQ_003D_003D(int _0023_003DqL4LYIkjLI_0024hcKXofTVcpDA_003D_003D, int _0023_003DqBqR6vt0W_4Eyyu9lElBBDA_003D_003D)
	{
		int num = -1;
		if (5 == 0)
		{
		}
		int x = X;
		int num2 = 0;
		if (3 == 0)
		{
		}
		int num3 = 6;
		if (2 == 0)
		{
		}
		return new Index3(Mathf.Clamp(x, _0023_003DqL4LYIkjLI_0024hcKXofTVcpDA_003D_003D, _0023_003DqBqR6vt0W_4Eyyu9lElBBDA_003D_003D), Mathf.Clamp(Y, _0023_003DqL4LYIkjLI_0024hcKXofTVcpDA_003D_003D, _0023_003DqBqR6vt0W_4Eyyu9lElBBDA_003D_003D), Mathf.Clamp(Z, _0023_003DqL4LYIkjLI_0024hcKXofTVcpDA_003D_003D, _0023_003DqBqR6vt0W_4Eyyu9lElBBDA_003D_003D));
	}

	public Index3 _0023_003DqYjuc_0024Tixoi7s2F9DuK4SRQ_003D_003D(int _0023_003Dqix9ay32NU1sGzGylC_0024erMw_003D_003D)
	{
		int num = 7;
		if (6 == 0)
		{
		}
		int x = X;
		int num2 = 7;
		if (7 == 0)
		{
		}
		int _0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D = Mathf.Min(x, _0023_003Dqix9ay32NU1sGzGylC_0024erMw_003D_003D);
		int num3 = 6;
		if (8 == 0)
		{
		}
		return new Index3(_0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D, Mathf.Min(Y, _0023_003Dqix9ay32NU1sGzGylC_0024erMw_003D_003D), Mathf.Min(Z, _0023_003Dqix9ay32NU1sGzGylC_0024erMw_003D_003D));
	}

	public static Index3 _0023_003DqnTcutxzYbWDXKXCttCaq8g_003D_003D(Index3 _0023_003DqaVK5NsotdyugJEMSx8qUNQ_003D_003D, Index3 _0023_003DqDbSZiktKCibeLgXIMjzp7g_003D_003D)
	{
		return new Index3(Mathf.Min(_0023_003DqaVK5NsotdyugJEMSx8qUNQ_003D_003D.X, _0023_003DqDbSZiktKCibeLgXIMjzp7g_003D_003D.X), Mathf.Min(_0023_003DqaVK5NsotdyugJEMSx8qUNQ_003D_003D.Y, _0023_003DqDbSZiktKCibeLgXIMjzp7g_003D_003D.Y), Mathf.Min(_0023_003DqaVK5NsotdyugJEMSx8qUNQ_003D_003D.Z, _0023_003DqDbSZiktKCibeLgXIMjzp7g_003D_003D.Z));
	}

	public static Index3 _0023_003DqlWnisbPvNb2u4taAiud0UQ_003D_003D(Index3 _0023_003DqTVyfkgQeZgJ7zgYd2dgrxw_003D_003D, Index3 _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D)
	{
		return new Index3(Mathf.Max(_0023_003DqTVyfkgQeZgJ7zgYd2dgrxw_003D_003D.X, _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D.X), Mathf.Max(_0023_003DqTVyfkgQeZgJ7zgYd2dgrxw_003D_003D.Y, _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D.Y), Mathf.Max(_0023_003DqTVyfkgQeZgJ7zgYd2dgrxw_003D_003D.Z, _0023_003Dq58VMtYJLqgteGOaYyGUqxg_003D_003D.Z));
	}

	public int _0023_003DqLck81qcmPLCTJhHZl9NvzyYWC5LO9jon16fJoDKT3QA_003D()
	{
		int num3 = 3;
		if (1 == 0)
		{
		}
		int num = Math.Abs(X);
		int num4 = 5;
		if (8 == 0)
		{
		}
		int num2 = num + Math.Abs(Y);
		int num5 = 1;
		if (6 == 0)
		{
		}
		return num2 + Math.Abs(Z);
	}

	public int _0023_003Dq9n3x4YR3w8yWIu1geY9k77K9o7Ck2TQxJx3fRbYT53Q_003D(Index3 _0023_003DqooiApLjulTG5rStHRyGkfA_003D_003D)
	{
		Index3 index = this - _0023_003DqooiApLjulTG5rStHRyGkfA_003D_003D;
		Index3 index2;
		if (5u != 0)
		{
			index2 = index;
		}
		return index2._0023_003DqLck81qcmPLCTJhHZl9NvzyYWC5LO9jon16fJoDKT3QA_003D();
	}

	public Index3[] _0023_003DqSQVOPmZSveg2BDCGT64FsuQ8PW0ZUQgoj52ER2wrxwg_003D()
	{
		Index3[] array = new Index3[6];
		Index3[] obj = array;
		int num = 0;
		int num4 = 6;
		if (1 == 0)
		{
		}
		obj[num] = this + Forward;
		Index3[] obj2 = array;
		int num2 = 1;
		int num5 = 6;
		if (8 == 0)
		{
		}
		obj2[num2] = this + Backward;
		Index3[] obj3 = array;
		int num3 = 2;
		int num6 = 6;
		if (7 == 0)
		{
		}
		obj3[num3] = this + Left;
		array[3] = this + Right;
		array[4] = this + Up;
		array[5] = this + Down;
		return array;
	}

	public static int _0023_003DqFDvZqjq_Xsi22dJ779pkOA_003D_003D(Index3 _0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D, Index3 _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D)
	{
		if (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.Z != _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.Z)
		{
			return (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.Z >= _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.Z) ? 1 : (-1);
		}
		if (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.Y != _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.Y)
		{
			return (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.Y >= _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.Y) ? 1 : (-1);
		}
		if (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.X != _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.X)
		{
			return (_0023_003DqFGY4_lcp7dl272vmn7gBJg_003D_003D.X >= _0023_003DqANTt8wzwh5OnWdH6Ci5_zw_003D_003D.X) ? 1 : (-1);
		}
		return 0;
	}

	public static explicit operator Vector3(Index3 _0023_003Dqt26Oknra7UJQGGh32DvNUw_003D_003D)
	{
		return new Vector3(_0023_003Dqt26Oknra7UJQGGh32DvNUw_003D_003D.X, _0023_003Dqt26Oknra7UJQGGh32DvNUw_003D_003D.Y, _0023_003Dqt26Oknra7UJQGGh32DvNUw_003D_003D.Z);
	}

	public static Index3 operator +(Index3 _0023_003Dq89OlqLkfoimXue3WdD7gHg_003D_003D, Index3 _0023_003DqBJiXkTj4fLR8Fe7WFjRDRw_003D_003D)
	{
		return new Index3(_0023_003Dq89OlqLkfoimXue3WdD7gHg_003D_003D.X + _0023_003DqBJiXkTj4fLR8Fe7WFjRDRw_003D_003D.X, _0023_003Dq89OlqLkfoimXue3WdD7gHg_003D_003D.Y + _0023_003DqBJiXkTj4fLR8Fe7WFjRDRw_003D_003D.Y, _0023_003Dq89OlqLkfoimXue3WdD7gHg_003D_003D.Z + _0023_003DqBJiXkTj4fLR8Fe7WFjRDRw_003D_003D.Z);
	}

	public static Index3 operator -(Index3 _0023_003DqYN30B7V_0024_002476fgEUv_0024v8M3Q_003D_003D, Index3 _0023_003DqF_p4IMCTAEPLWCkUPtoz_0024w_003D_003D)
	{
		return new Index3(_0023_003DqYN30B7V_0024_002476fgEUv_0024v8M3Q_003D_003D.X - _0023_003DqF_p4IMCTAEPLWCkUPtoz_0024w_003D_003D.X, _0023_003DqYN30B7V_0024_002476fgEUv_0024v8M3Q_003D_003D.Y - _0023_003DqF_p4IMCTAEPLWCkUPtoz_0024w_003D_003D.Y, _0023_003DqYN30B7V_0024_002476fgEUv_0024v8M3Q_003D_003D.Z - _0023_003DqF_p4IMCTAEPLWCkUPtoz_0024w_003D_003D.Z);
	}

	public static Index3 operator -(Index3 _0023_003Dq5S9mTxTlOoTXuBNEFXkHBQ_003D_003D)
	{
		return new Index3(-_0023_003Dq5S9mTxTlOoTXuBNEFXkHBQ_003D_003D.X, -_0023_003Dq5S9mTxTlOoTXuBNEFXkHBQ_003D_003D.Y, -_0023_003Dq5S9mTxTlOoTXuBNEFXkHBQ_003D_003D.Z);
	}

	public static Index3 operator *(int _0023_003Dqv9dKVBMkiTdoGr_00247mySbkw_003D_003D, Index3 _0023_003DqAlZXuFz6Rs6B4kY_0024TcsdKg_003D_003D)
	{
		int num = 6;
		if (4 == 0)
		{
		}
		int _0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D = _0023_003Dqv9dKVBMkiTdoGr_00247mySbkw_003D_003D * _0023_003DqAlZXuFz6Rs6B4kY_0024TcsdKg_003D_003D.X;
		int num2 = 4;
		if (1 == 0)
		{
		}
		int _0023_003DqLkBZJhSJigy4rT8G9XcOpQ_003D_003D = _0023_003Dqv9dKVBMkiTdoGr_00247mySbkw_003D_003D * _0023_003DqAlZXuFz6Rs6B4kY_0024TcsdKg_003D_003D.Y;
		int num3 = 1;
		if (6 == 0)
		{
		}
		return new Index3(_0023_003DqcGHyJJVRBn77gV0pOwV34A_003D_003D, _0023_003DqLkBZJhSJigy4rT8G9XcOpQ_003D_003D, _0023_003Dqv9dKVBMkiTdoGr_00247mySbkw_003D_003D * _0023_003DqAlZXuFz6Rs6B4kY_0024TcsdKg_003D_003D.Z);
	}

	public static bool operator ==(Index3 _0023_003DqW2x0Qq7lqpuRqvC5impgcQ_003D_003D, Index3 _0023_003DqDANbUyaTuKuBJlvWZl1zHw_003D_003D)
	{
		int num = 0;
		if (7 == 0)
		{
		}
		return _0023_003DqW2x0Qq7lqpuRqvC5impgcQ_003D_003D._0023_003DqsSacXSUjBd0_ilK3odjUCQ_003D_003D(_0023_003DqDANbUyaTuKuBJlvWZl1zHw_003D_003D);
	}

	public static bool operator !=(Index3 _0023_003Dq1pnUHvhKtQ98eO_0024_0024afU3Jg_003D_003D, Index3 _0023_003DqzZ3A64_0024BYLDbKLEQpTICqw_003D_003D)
	{
		int num = 7;
		if (false)
		{
		}
		return !_0023_003Dq1pnUHvhKtQ98eO_0024_0024afU3Jg_003D_003D._0023_003DqsSacXSUjBd0_ilK3odjUCQ_003D_003D(_0023_003DqzZ3A64_0024BYLDbKLEQpTICqw_003D_003D);
	}
}
