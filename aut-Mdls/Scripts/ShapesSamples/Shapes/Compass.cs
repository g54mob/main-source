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
		public float fieldOfView = MathF.PI / 2f;

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

		private string[] directionLabels = new string[4] { "S", "W", "N", "E" };

		public void DrawCompass(Vector3 worldDir)
		{
			Vector2 compArcOrigin = position + Vector2.down * bendRadius;
			float angUiMin = MathF.PI / 2f - width / 2f / bendRadius;
			float angUiMax = MathF.PI / 2f + width / 2f / bendRadius;
			float num = ShapesMath.DirToAng(new Vector2(worldDir.x, worldDir.z).normalized);
			float angWorldMin = num + fieldOfView / 2f;
			float angWorldMax = num - fieldOfView / 2f;
			Vector2 vector = compArcOrigin + Vector2.up * bendRadius + lookAngLabelOffset * 0.1f;
			string content = Mathf.RoundToInt((0f - num) * 57.29578f + 180f) + "°";
			Draw.LineEndCaps = LineEndCap.Square;
			Draw.Thickness = lineThickness;
			Draw.Arc(compArcOrigin, bendRadius, lineThickness, angUiMin, angUiMax, ArcEndCap.Round);
			Draw.FontSize = fontSizeLookLabel;
			Draw.Text(vector, content, TextAlign.Center);
			Draw.RegularPolygon(compArcOrigin + Vector2.up * (bendRadius + 0.01f), 3, triangleNootSize, -MathF.PI / 2f);
			int num2 = (ticksPerQuarterTurn - 1) * 4;
			for (int i = 0; i < num2; i++)
			{
				float num3 = (float)i / (float)num2;
				float num4 = MathF.PI * 2f * num3;
				bool flag = i % (num2 / 4) == 0;
				string label = null;
				if (flag)
				{
					int num5 = Mathf.RoundToInt((1f - num3) * 4f);
					label = directionLabels[num5 % 4];
				}
				float num6 = ShapesMath.InverseLerpAngleRad(angWorldMax, angWorldMin, num4);
				if (num6 < 1f && num6 > 0f)
				{
					DrawTick(num4, flag ? 0.8f : 0.5f, label);
				}
			}
			void DrawTick(float worldAng, float size, string text = null)
			{
				float num7 = ShapesMath.InverseLerpAngleRad(angWorldMax, angWorldMin, worldAng);
				float num8 = Mathf.Lerp(angUiMin, angUiMax, num7);
				Vector2 vector2 = ShapesMath.AngToDir(num8);
				Vector2 vector3 = compArcOrigin + vector2 * bendRadius;
				Vector2 vector4 = compArcOrigin + vector2 * (bendRadius - size * tickSize);
				float a = Mathf.InverseLerp(0f, tickEdgeFadeFraction, 1f - Mathf.Abs(num7 * 2f - 1f));
				Draw.Line(vector3, vector4, LineEndCap.None, new Color(1f, 1f, 1f, a));
				if (text != null)
				{
					Draw.FontSize = fontSizeTickLabel;
					Quaternion rot = Quaternion.Euler(0f, 0f, (num8 - MathF.PI / 2f) * 57.29578f);
					Draw.Text(vector4 - vector2 * tickLabelOffset, rot, text, TextAlign.Center, new Color(1f, 1f, 1f, a));
				}
			}
		}
	}
}
