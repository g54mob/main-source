using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Pathfinding.Clipper2Lib
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct LocMinSorter : IComparer<LocalMinima>
	{
		public readonly int Compare(LocalMinima locMin1, LocalMinima locMin2)
		{
			return 0;
		}
	}
}
