using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class Text
	{
		public Transform Transform;

		public string Value;

		public Vector3 Position;

		public Color Color;

		public Texture2D Texture;

		public float ExpirationTime;

		private static ObjectPool<Text> sPool;

		public static int Length => 0;

		public static Text Allocate()
		{
			return null;
		}

		public static void Release(Text rInstance)
		{
		}
	}
}
