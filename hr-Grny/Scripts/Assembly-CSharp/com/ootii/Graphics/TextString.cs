using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class TextString
	{
		public int Scope;

		public Transform Transform;

		public string Value;

		public Vector3 Position;

		public Color Color;

		public float ExpirationTime;

		private static ObjectPool<TextString> sPool;

		public static int Length => 0;

		public static TextString Allocate()
		{
			return null;
		}

		public static void Release(TextString rInstance)
		{
		}
	}
}
