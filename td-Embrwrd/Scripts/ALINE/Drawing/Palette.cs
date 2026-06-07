using UnityEngine;

namespace Drawing
{
	public static class Palette
	{
		public static class Pure
		{
			public static readonly Color Yellow;

			public static readonly Color Clear;

			public static readonly Color Grey;

			public static readonly Color Magenta;

			public static readonly Color Cyan;

			public static readonly Color Red;

			public static readonly Color Black;

			public static readonly Color White;

			public static readonly Color Blue;

			public static readonly Color Green;
		}

		public static class Colorbrewer
		{
			public static class Set1
			{
				public static readonly Color Red;

				public static readonly Color Blue;

				public static readonly Color Green;

				public static readonly Color Purple;

				public static readonly Color Orange;

				public static readonly Color Yellow;

				public static readonly Color Brown;

				public static readonly Color Pink;

				public static readonly Color Grey;
			}

			public static class Blues
			{
				private static readonly Color[] Colors;

				public static Color GetColor(int classes, int index)
				{
					return default(Color);
				}
			}
		}
	}
}
