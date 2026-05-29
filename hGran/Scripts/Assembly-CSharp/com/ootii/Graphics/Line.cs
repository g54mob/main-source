using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class Line
	{
		public int Scope;

		public Transform Transform;

		public Vector3 Start;

		public Vector3 End;

		public Color Color;

		public float ExpirationTime;

		private static ObjectPool<Line> sPool;

		public static int Length => 0;

		public static Line Allocate()
		{
			return null;
		}

		public static Line Allocate(Line rSource)
		{
			return null;
		}

		public static void Release(Line rInstance)
		{
		}
	}
}
