using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	public class EZCurveRectAttribute : PropertyAttribute
	{
		public Rect rect;

		public Color color = Color.green;

		public EZCurveRectAttribute()
		{
			rect = new Rect(0f, 0f, 1f, 1f);
		}

		public EZCurveRectAttribute(Rect rect)
		{
			this.rect = rect;
		}

		public EZCurveRectAttribute(float x, float y, float width, float height)
		{
			rect = new Rect(x, y, width, height);
		}

		public EZCurveRectAttribute(Rect rect, Color color)
		{
			this.rect = rect;
			this.color = color;
		}

		public EZCurveRectAttribute(float x, float y, float width, float height, Color color)
		{
			rect = new Rect(x, y, width, height);
			this.color = color;
		}
	}
}
