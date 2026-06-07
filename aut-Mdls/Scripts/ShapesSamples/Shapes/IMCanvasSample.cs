using UnityEngine;

namespace Shapes
{
	public class IMCanvasSample : ImmediateModeCanvas
	{
		public override void DrawCanvasShapes(Rect rect)
		{
			float radius = Mathf.Min(rect.width, rect.height) / 2f * 0.9f;
			Draw.Ring(Vector3.zero, Quaternion.identity, radius, 1f, new Color(1f, 1f, 1f, 0.3f));
			Draw.RectangleBorder(rect, 8f, 16f, Color.white);
			DrawPanels();
			Draw.Disc(Vector3.zero, 4f);
			Vector2 vector = new Vector2(14f, 0f);
			Vector2 vector2 = new Vector2(28f, 0f);
			for (int i = 0; i < 4; i++)
			{
				Draw.Line(vector, vector2, 4f, LineEndCap.Round);
				vector = ShapesMath.Rotate90CCW(vector);
				vector2 = ShapesMath.Rotate90CCW(vector2);
			}
		}
	}
}
