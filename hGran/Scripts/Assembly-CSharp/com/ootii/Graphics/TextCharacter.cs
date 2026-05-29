using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class TextCharacter
	{
		public char Character;

		public Color[] Pixels;

		public int Width;

		public int Height;

		public int MinX;

		public int MinY;

		public int Advance;

		private static ObjectPool<TextCharacter> sPool;

		public static int Length => 0;

		public static TextCharacter Allocate()
		{
			return null;
		}

		public static void Release(TextCharacter rInstance)
		{
		}
	}
}
