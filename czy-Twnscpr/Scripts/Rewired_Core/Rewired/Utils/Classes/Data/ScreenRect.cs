using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	public struct ScreenRect
	{
		public float xMin;

		public float yMin;

		public float width;

		public float height;

		public float xMax
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float yMax
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector2 center => default(Vector2);

		public ScreenRect(float left, float bottom, float width, float height)
		{
			xMin = 0f;
			yMin = 0f;
			this.width = 0f;
			this.height = 0f;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator Rect(ScreenRect o)
		{
			return default(Rect);
		}

		public static implicit operator ScreenRect(Rect o)
		{
			return default(ScreenRect);
		}
	}
}
