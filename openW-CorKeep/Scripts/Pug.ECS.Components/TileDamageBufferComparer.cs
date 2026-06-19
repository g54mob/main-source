using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct TileDamageBufferComparer : IComparer<TileDamageBuffer>
{
	public int Compare(TileDamageBuffer x, TileDamageBuffer y)
	{
		int num = x.position.y.CompareTo(y.position.y);
		if (num == 0)
		{
			num = x.position.x.CompareTo(y.position.x);
		}
		if (num == 0)
		{
			num = x.damage.CompareTo(y.damage);
		}
		return num;
	}
}
