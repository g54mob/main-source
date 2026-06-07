using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class Triangle
	{
		public int Scope;

		public Transform Transform;

		public Vector3 Point1;

		public Vector3 Point2;

		public Vector3 Point3;

		public Color Color;

		public float ExpirationTime;

		private static ObjectPool<Triangle> sPool;

		public static int Length => 0;

		public static Triangle Allocate()
		{
			return null;
		}

		public static Triangle Allocate(Triangle rSource)
		{
			return null;
		}

		public static void Release(Triangle rInstance)
		{
		}
	}
}
