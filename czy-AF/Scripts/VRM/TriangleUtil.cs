using System;
using System.Collections.Generic;
using System.Linq;

public static class TriangleUtil
{
	public static IEnumerable<int> FlipTriangle(IEnumerable<byte> src)
	{
		return FlipTriangle(src.Select((Func<byte, int>)((byte x) => x)));
	}

	public static IEnumerable<int> FlipTriangle(IEnumerable<ushort> src)
	{
		return FlipTriangle(src.Select((Func<ushort, int>)((ushort x) => x)));
	}

	public static IEnumerable<int> FlipTriangle(IEnumerable<uint> src)
	{
		return FlipTriangle(src.Select((uint x) => (int)x));
	}

	public static IEnumerable<int> FlipTriangle(IEnumerable<int> src)
	{
		IEnumerator<int> it = src.GetEnumerator();
		while (it.MoveNext())
		{
			int i0 = it.Current;
			if (!it.MoveNext())
			{
				break;
			}
			int i1 = it.Current;
			if (!it.MoveNext())
			{
				break;
			}
			yield return it.Current;
			yield return i1;
			yield return i0;
		}
	}
}
