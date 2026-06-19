using Unity.Collections;
using UnityEngine;

namespace PugWorldGen
{
	internal struct PointRequest
	{
		public int index;

		public NativeArray<Vector2> points;

		public int count;
	}
}
