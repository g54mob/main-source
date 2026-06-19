using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ObjectDataCDComparer : IComparer<ObjectDataCD>
{
	public int Compare(ObjectDataCD x, ObjectDataCD y)
	{
		if (x.objectID < y.objectID)
		{
			return -1;
		}
		if (x.objectID > y.objectID)
		{
			return 1;
		}
		if (x.variation < y.variation)
		{
			return -1;
		}
		if (x.variation > y.variation)
		{
			return 1;
		}
		return 0;
	}
}
