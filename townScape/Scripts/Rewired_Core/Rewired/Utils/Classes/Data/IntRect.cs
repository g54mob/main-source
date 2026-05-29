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
				return 0;
			}
			set
			{
			}
		}

		public int yMax
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int xMin
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int xMax
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int top
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int bottom
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int left
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int right
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public IntRect()
		{
		}

		public IntRect(int inX, int inY, int inWidth, int inHeight)
		{
		}

		public IntRect Clone()
		{
			return null;
		}

		public static IntRect Clone(IntRect intRect)
		{
			return null;
		}
	}
}
