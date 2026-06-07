using System;
using UnityEngine;

namespace Placemaker.Props
{
	public class ShiftingMesh : MonoBehaviour, IComparable<Vector3>, IComparable<ShiftingMesh>
	{
		public MeshFilter targetMeshFilter;

		int IComparable<Vector3>.CompareTo(Vector3 other)
		{
			return 0;
		}

		int IComparable<ShiftingMesh>.CompareTo(ShiftingMesh other)
		{
			return 0;
		}
	}
}
