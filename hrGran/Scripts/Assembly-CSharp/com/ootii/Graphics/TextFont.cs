using System.Collections.Generic;
using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Graphics
{
	public class TextFont
	{
		public Font Font;

		public Texture2D Texture;

		public int MinX;

		public int MaxX;

		public int MinY;

		public int MaxY;

		public Dictionary<char, TextCharacter> Characters;

		private static ObjectPool<TextFont> sPool;

		public static int Length => 0;

		public static TextFont Allocate()
		{
			return null;
		}

		public static void Release(TextFont rInstance)
		{
		}
	}
}
