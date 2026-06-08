using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct GroupComparer : IComparer<CWaitingGroup>
	{
		public int Compare(CWaitingGroup x, CWaitingGroup y)
		{
			int num = 0;
			num = ((!(x.ForceLocation != default(Entity))) ? ((y.ForceLocation != default(Entity)) ? 1 : 0) : ((!(y.ForceLocation != default(Entity))) ? (-1) : 0));
			if (num != 0)
			{
				return num;
			}
			int state = (int)x.State;
			num = -state.CompareTo((int)y.State);
			if (num != 0)
			{
				return num;
			}
			return x.PatienceRemaining.CompareTo(y.PatienceRemaining);
		}
	}
}
