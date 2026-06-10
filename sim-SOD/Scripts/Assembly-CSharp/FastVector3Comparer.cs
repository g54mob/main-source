using System.Collections.Generic;
using UnityEngine;

public class FastVector3Comparer : IEqualityComparer<Vector3>
{
	private static FastVector3Comparer sharedFastVector3Comparer;

	public static FastVector3Comparer SharedFastVector3Comparer => null;

	bool IEqualityComparer<Vector3>.Equals(Vector3 x, Vector3 y)
	{
		return false;
	}

	int IEqualityComparer<Vector3>.GetHashCode(Vector3 obj)
	{
		return 0;
	}
}
