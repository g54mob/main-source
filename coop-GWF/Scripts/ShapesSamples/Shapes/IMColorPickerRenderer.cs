using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class IMColorPickerRenderer : ImmediateModeShapeDrawer
	{
		[Header("Color value")]
		[Range(0f, 1f)]
		public float hue;

		[Range(0f, 1f)]
		public float saturation = 1f;

		[Range(0f, 1f)]
		public float value = 1f;

		[Header("Styling")]
		[Range(0f, 0.3f)]
		public float hueStripThickness;

		[Range(0f, 0.1f)]
		public float outline;

		[Range(0f, 0.1f)]
		public float quadMargin;

		[Range(0f, 1.5f)]
		public float hueDotScale;

		public Vector2 labelSize;

		private PolylinePath hueStripPath;

		public Color CurrentPureColor => Color.HSVToRGB(hue, 1f, 1f);

		public Color CurrentColor => Color.HSVToRGB(hue, saturation, value);

		public float QuadScale => (1f - hueStripThickness / 2f - quadMargin) / Mathf.Sqrt(2f);

		public Rect QuadRect
		{
			get
			{
				Rect result = new Rect(default(Vector2), Vector2.one * QuadScale * 2f);
				result.center = default(Vector2);
				return result;
			}
		}

		public float HueStripRadiusOuter => 1f + hueStripThickness / 2f + outline;

		public float HueStripRadiusInner => 1f - hueStripThickness / 2f - outline;

		public static Vector2 HueToVector(float hue)
		{
			return ShapesMath.AngToDir(hue * (MathF.PI * 2f));
		}

		public static float VectorToHue(Vector2 v)
		{
			return ShapesMath.Frac(ShapesMath.DirToAng(v) / (MathF.PI * 2f));
		}

		public override void OnEnable()
		{
			base.OnEnable();
			ConstructHueStripPolyline();
		}

		public override void OnDisable()
		{
			base.OnDisable();
			hueStripPath.Dispose();
		}

		public override void DrawShapes(Camera cam)
		{
			using (Draw.Command(cam))
			{
				Draw.Matrix = base.transform.localToWorldMatrix;
				Draw.Ring(Vector3.zero, 1f, hueStripThickness + outline, Color.black);
				Draw.PolylineJoins = PolylineJoins.Simple;
				Draw.PolylineGeometry = PolylineGeometry.Flat2D;
				Draw.Polyline(hueStripPath, closed: true, hueStripThickness);
				float quadScale = QuadScale;
				Draw.Rectangle(Vector3.zero, Vector2.one * (quadScale * 2f + outline), Color.black);
				using (Draw.MatrixScope)
				{
					Draw.Scale(quadScale);
					Draw.Quad(new Vector2(-1f, -1f), new Vector2(1f, -1f), new Vector2(1f, 1f), new Vector2(-1f, 1f), Color.black, Color.black, CurrentPureColor, Color.white);
				}
				Rect rect = new Rect((0f - labelSize.x) / 2f, 0f - quadScale - labelSize.y, labelSize.x, labelSize.y);
				Draw.Rectangle(rect, 0.1f, Color.black);
				string content = "#" + ColorUtility.ToHtmlStringRGB(CurrentColor);
				Draw.FontSize = labelSize.y * 8.5f;
				Draw.TextAlign = TextAlign.Center;
				Draw.TextRect(rect, content);
				float num = hueStripThickness / 2f * hueDotScale;
				Vector2 vector = HueToVector(hue);
				Draw.Disc(vector, num + outline / 2f, Color.black);
				Draw.Disc(vector, num, CurrentPureColor);
				Vector2 vector2 = ShapesMath.Lerp(QuadRect, new Vector2(saturation, value));
				Draw.Disc(vector2, num + outline / 2f, Color.black);
				Draw.Disc(vector2, num, CurrentColor);
			}
		}

		private void ConstructHueStripPolyline()
		{
			hueStripPath = new PolylinePath();
			for (int i = 0; i < 100; i++)
			{
				float h = (float)i / 100f;
				Color color = Color.HSVToRGB(h, 1f, 1f);
				Vector3 pos = HueToVector(h);
				hueStripPath.AddPoint(pos, color);
			}
		}
	}
}
