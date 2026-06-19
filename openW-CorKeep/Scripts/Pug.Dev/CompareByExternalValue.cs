using System.Collections.Generic;
using Unity.Collections;

public struct CompareByExternalValue : IComparer<int>
{
	public NativeArray<int> ExternalValues;

	public int Compare(int x, int y)
	{
		return ExternalValues[x].CompareTo(ExternalValues[y]);
	}
}
