using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class Margin
	{
		[SerializeField]
		private int left;

		[SerializeField]
		private int right;

		[SerializeField]
		private int top;

		[SerializeField]
		private int bottom;

		public float Horizontal => 0f;

		public float Vertical => 0f;

		public int Left
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Right
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Top
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Bottom
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Item
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Margin()
		{
		}

		public Margin(Vector4 source)
		{
		}

		public Margin(RectOffset source)
		{
		}

		public Margin(int left, int right, int top, int bottom)
		{
		}

		public Margin Clone()
		{
			return null;
		}

		public void CopyValuesTo(RectOffset target)
		{
		}

		public Vector4 ToVector4()
		{
			return default(Vector4);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
