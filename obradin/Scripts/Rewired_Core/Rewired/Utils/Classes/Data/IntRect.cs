using System;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public class IntRect
	{
		public int x;

		public int y;

		public int width;

		public int height;

		public int yMin
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public int yMax
		{
			get
			{
				return y + height - 1;
			}
			set
			{
				height = value - 1;
			}
		}

		public int xMin
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int xMax
		{
			get
			{
				return x + width - 1;
			}
			set
			{
				width = value - 1;
			}
		}

		public int top
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

		public int bottom
		{
			get
			{
				return y + height - 1;
			}
			set
			{
				height = value - 1;
			}
		}

		public int left
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

		public int right
		{
			get
			{
				return x + width - 1;
			}
			set
			{
				width = value - 1;
			}
		}

		public IntRect()
		{
		}

		public IntRect(int inX, int inY, int inWidth, int inHeight)
		{
			while (true)
			{
				int num = 1577688284;
				while (true)
				{
					switch (num ^ 0x5E099CDD)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						x = inX;
						y = inY;
						width = inWidth;
						num = 1577688286;
						continue;
					case 3:
						height = inHeight;
						num = 1577688285;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public IntRect Clone()
		{
			return new IntRect(x, y, width, height);
		}

		public static IntRect Clone(IntRect intRect)
		{
			if (intRect == null)
			{
				return null;
			}
			return intRect.Clone();
		}
	}
}
