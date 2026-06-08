using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct LocationComparer : IComparer<CAvailableAssignment>
	{
		public int Compare(CAvailableAssignment x, CAvailableAssignment y)
		{
			int state = (int)x.State;
			int num = -state.CompareTo((int)y.State);
			if (num != 0)
			{
				return num;
			}
			return -x.Attractiveness.CompareTo(y.Attractiveness);
		}
	}
}
