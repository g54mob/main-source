using System;
using UnityEngine;

namespace Shapes
{
	public class Compass : MonoBehaviour
	{
		public Vector2 position;

		public float width = 1f;

		[Range(0f, 0.01f)]
		public float lineThickness = 0.1f;

		[Range(0.1f, 2f)]
		public float bendRadius = 1f;

		[Range(0.05f, 3.0787609f)]
		public float fieldOfView = (float)Math.PI / 2f;

		[Header("Ticks")]
		public int ticksPerQuarterTurn = 12;

		[Range(0f, 0.2f)]
		public float tickSize = 0.1f;

		[Range(0f, 1f)]
		public float tickEdgeFadeFraction = 0.1f;

		[Range(0.01f, 0.26f)]
		public float fontSizeTickLabel = 1f;

		[Range(0f, 0.1f)]
		public float tickLabelOffset = 0.01f;

		[Header("Degree Marker")]
		[Range(0.01f, 0.26f)]
		public float fontSizeLookLabel = 1f;

		public Vector2 lookAngLabelOffset;

		[Range(0f, 0.05f)]
		public float triangleNootSize = 0.1f;

		public void DrawCompass(Vector3 worldDir)
		{
			Vector2 compArcOrigin = position + Vector2.down * bendRadius;
			float angUiMin = (float)Math.PI / 2f - width / 2f / bendRadius;
			float angUiMax = (float)Math.PI / 2f + width / 2f / bendRadius;
			float num = ShapesMath.DirToAng(new Vector2(worldDir.x, worldDir.z).normalized);
			float angWorldMin = num + fieldOfView / 2f;
			float angWorldMax = num - fieldOfView / 2f;
			Draw.Arc(compArcOrigin, bendRadius, lineThickness, angUiMin, angUiMax, ArcEndCap.Round);
			Draw.LineEndCaps = LineEndCap.Square;
			Draw.LineThickness = lineThickness;
			Vector2 vector = compArcOrigin + Vector2.up * (bendRadius + 0.01f);
			Vector2 vector2 = compArcOrigin + Vector2.up * bendRadius + lookAngLabelOffset * 0.1f;
			string content = Mathf.RoundToInt((0f - num) * 57.29578f + 180f) + "°";
			Draw.FontSize = fontSizeLookLabel;
			Draw.Text(vector2, 0f, content, TextAlign.Center);
			Vector2 vector3 = vector + ShapesMath.AngToDir(-(float)Math.PI / 2f) * triangleNootSize;
			Vector2 vector4 = vector + ShapesMath.AngToDir((float)Math.PI / 6f) * triangleNootSize;
			Vector2 vector5 = vector + ShapesMath.AngToDir(2.6179938f) * triangleNootSize;
			Draw.Triangle(vector3, vector4, vector5);
			int num2 = (ticksPerQuarterTurn - 1) * 4;
			for (int i = 0; i < num2; i++)
			{
				float num3 = (float)i / (float)num2;
				float num4 = (float)Math.PI * 2f * num3;
				bool flag = i % (num2 / 4) == 0;
				string label = null;
				if (flag)
				{
					switch (Mathf.RoundToInt((1f - num3) * 4f))
					{
					case 0:
					case 4:
						label = "S";
						break;
					case 1:
						label = "W";
						break;
					case 2:
						label = "N";
						break;
					case 3:
						label = "E";
						break;
					}
				}
				float num5 = ShapesMath.InverseLerpAngleRad(angWorldMax, angWorldMin, num4);
				if (num5 < 1f && num5 > 0f)
				{
					CompassArcNoot(num4, flag ? 0.8f : 0.5f, label);
				}
			}
			void CompassArcNoot(float worldAng, float size, string text)
			{
				float num6 = ShapesMath.InverseLerpAngleRad(angWorldMax, angWorldMin, worldAng);
				float num7 = Mathf.Lerp(angUiMin, angUiMax, num6);
				Vector2 vector6 = ShapesMath.AngToDir(num7);
				Vector2 vector7 = compArcOrigin + vector6 * bendRadius;
				Vector2 vector8 = compArcOrigin + vector6 * (bendRadius - size * tickSize);
				float a = Mathf.InverseLerp(0f, tickEdgeFadeFraction, 1f - Mathf.Abs(num6 * 2f - 1f));
				Draw.Line(vector7, vector8, LineEndCap.None, new Color(1f, 1f, 1f, a));
				if (text != null)
				{
					Draw.FontSize = fontSizeTickLabel;
					Draw.Text(vector8 - vector6 * tickLabelOffset, num7 - (float)Math.PI / 2f, text, TextAlign.Center, new Color(1f, 1f, 1f, a));
				}
			}
		}
	}
}
