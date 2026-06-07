using ModApi.Craft.Program.Craft;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class LineWidgetScript : SpriteWidgetScript, ILineWidget
	{
		public float Length
		{
			get
			{
				return Size.x;
			}
			set
			{
				Size = new Vector2(value, Size.y);
			}
		}

		public float Thickness
		{
			get
			{
				return Size.y;
			}
			set
			{
				Size = new Vector2(Size.x, value);
			}
		}

		public void SetLineEndPoints(Vector3 pointA, Vector3 pointB)
		{
			Vector3 vector = pointB - pointA;
			Vector2 pivot = base.Pivot;
			base.Pivot = new Vector2(0f, 0f);
			LocalRotation = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
			LocalPosition = (pointA + pointB) * 0.5f;
			Length = vector.magnitude;
			base.Pivot = pivot;
		}
	}
}
