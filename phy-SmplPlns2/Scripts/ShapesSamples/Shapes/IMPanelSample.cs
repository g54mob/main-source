using UnityEngine;

namespace Shapes
{
	public class IMPanelSample : ImmediateModePanel
	{
		[Range(0f, 1f)]
		public float fillAmount = 1f;

		public Gradient colorGradient;

		public string title = "Title";

		public override void DrawPanelShapes(Rect rect, ImCanvasContext ctx)
		{
			if (colorGradient != null)
			{
				Draw.Rectangle(rect, 8f, Color.black);
				Rect rect2 = Inset(rect, 8f);
				rect2.width *= fillAmount;
				Draw.Rectangle(rect2, colorGradient.Evaluate(fillAmount));
				Draw.RectangleBorder(rect, 4f, 8f, Color.white);
				Draw.FontSize = 240f;
				Draw.Text(new Vector2(rect.xMin + 6f, rect.yMax + 6f), title, TextAlign.BaselineLeft);
			}
		}

		private Rect Inset(Rect r, float amount)
		{
			return new Rect(r.x + amount, r.y + amount, r.width - amount * 2f, r.height - amount * 2f);
		}
	}
}
