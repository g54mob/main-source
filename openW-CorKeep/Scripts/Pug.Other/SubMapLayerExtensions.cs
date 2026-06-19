using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public static class SubMapLayerExtensions
{
	public unsafe static ref ulong Row(this ref SubMapLayer sl, int index)
	{
		return ref UnsafeUtility.AsRef<ulong>((byte*)UnsafeUtility.AddressOf(ref sl.bitfield) + (nint)index * (nint)8);
	}

	public static ulong GetRow(this SubMapLayer sl, int rowIndex)
	{
		return sl.Row(rowIndex);
	}

	public static bool GetByRef(this ref SubMapLayer sl, int2 pos)
	{
		return sl.GetByRef(pos.x, pos.y);
	}

	public static bool GetByRef(this ref SubMapLayer sl, int x, int y)
	{
		return ((sl.Row(y) >> x) & 1) != 0;
	}

	public static bool Get(this SubMapLayer sl, int2 pos)
	{
		return sl.Get(pos.x, pos.y);
	}

	public static bool Get(this SubMapLayer sl, int x, int y)
	{
		return ((sl.Row(y) >> x) & 1) != 0;
	}

	public static void Set(this ref SubMapLayer sl, int2 pos)
	{
		sl.Set(pos.x, pos.y);
	}

	public static void Set(this ref SubMapLayer sl, int x, int y)
	{
		ulong num = sl.Row(y);
		num |= (ulong)(1L << x);
		sl.Row(y) = num;
	}

	public static void Unset(this ref SubMapLayer sl, int2 pos)
	{
		sl.Unset(pos.x, pos.y);
	}

	public static void Unset(this ref SubMapLayer sl, int x, int y)
	{
		ulong num = sl.Row(y);
		num &= (ulong)(~(1L << x));
		sl.Row(y) = num;
	}

	public static void Clear(this ref SubMapLayer sl)
	{
		for (int i = 0; i < 64; i++)
		{
			sl.Row(i) = 0uL;
		}
	}

	public static bool IsAnySet(this ref SubMapLayer sl)
	{
		bool result = false;
		for (int i = 0; i < 64; i++)
		{
			if (sl.Row(i) != 0L)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static bool IsAnyUnset(this ref SubMapLayer sl)
	{
		bool result = false;
		for (int i = 0; i < 64; i++)
		{
			if (sl.Row(i) != ulong.MaxValue)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public static SubMapLayer Invert(this SubMapLayer sl)
	{
		SubMapLayer sl2 = default(SubMapLayer);
		for (int i = 0; i < 64; i++)
		{
			sl2.Row(i) = ~sl.Row(i);
		}
		return sl2;
	}

	public static SubMapLayer Set(this SubMapLayer sl, SubMapLayer other)
	{
		SubMapLayer sl2 = new SubMapLayer
		{
			layer = sl.layer
		};
		for (int i = 0; i < 64; i++)
		{
			sl2.Row(i) = sl.Row(i) | other.Row(i);
		}
		return sl2;
	}

	public static SubMapLayer Subtract(this SubMapLayer sl, SubMapLayer other)
	{
		SubMapLayer sl2 = new SubMapLayer
		{
			layer = sl.layer
		};
		for (int i = 0; i < 64; i++)
		{
			sl2.Row(i) = sl.Row(i) & ~other.Row(i);
		}
		return sl2;
	}

	public static SubMapLayer Merge(this SubMapLayer sl, SubMapLayer other)
	{
		SubMapLayer sl2 = new SubMapLayer
		{
			layer = sl.layer
		};
		for (int i = 0; i < 64; i++)
		{
			sl2.Row(i) = sl.Row(i) | other.Row(i);
		}
		return sl2;
	}

	public static SubMapLayer Intersect(this SubMapLayer sl, SubMapLayer other)
	{
		SubMapLayer sl2 = new SubMapLayer
		{
			layer = sl.layer
		};
		for (int i = 0; i < 64; i++)
		{
			sl2.Row(i) = sl.Row(i) & other.Row(i);
		}
		return sl2;
	}

	public static bool IsEmpty(this SubMapLayer sl)
	{
		ulong num = 0uL;
		for (int i = 0; i < 64; i++)
		{
			num |= sl.Row(i);
		}
		return num == 0;
	}

	public static void Print(this SubMapLayer sl)
	{
		string text = "";
		for (int num = 63; num >= 0; num--)
		{
			for (int i = 0; i < 64; i++)
			{
				text = ((!sl.Get(i, num)) ? (text + "0") : (text + "1"));
			}
			text += "\n";
		}
		Debug.Log(JsonUtility.ToJson(sl.layer, prettyPrint: true));
		Debug.Log(text);
	}

	public unsafe static ref ulong Row(this ref ClientSubMapLayer sl, int index)
	{
		return ref UnsafeUtility.AsRef<ulong>((byte*)UnsafeUtility.AddressOf(ref sl.bitfield) + (nint)index * (nint)8);
	}

	public static bool GetByRef(this ref ClientSubMapLayer sl, int2 pos)
	{
		return sl.GetByRef(pos.x, pos.y);
	}

	public static bool GetByRef(this ref ClientSubMapLayer sl, int x, int y)
	{
		return ((sl.Row(y) >> x) & 1) != 0;
	}

	public static void Set(this ref ClientSubMapLayer sl, int2 pos)
	{
		sl.Set(pos.x, pos.y);
	}

	public static void Set(this ref ClientSubMapLayer sl, int x, int y)
	{
		ulong num = sl.Row(y);
		num |= (ulong)(1L << x);
		sl.Row(y) = num;
	}

	public static void Unset(this ref ClientSubMapLayer sl, int2 pos)
	{
		sl.Unset(pos.x, pos.y);
	}

	public static void Unset(this ref ClientSubMapLayer sl, int x, int y)
	{
		ulong num = sl.Row(y);
		num &= (ulong)(~(1L << x));
		sl.Row(y) = num;
	}

	public static void Clear(this ref ClientSubMapLayer sl)
	{
		for (int i = 0; i < 48; i++)
		{
			sl.Row(i) = 0uL;
		}
	}
}
