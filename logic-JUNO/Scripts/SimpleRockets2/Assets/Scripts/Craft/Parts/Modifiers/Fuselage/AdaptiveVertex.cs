using System;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class AdaptiveVertex
	{
		private static Vector2i[] _cornerPositions = new Vector2i[4]
		{
			new Vector2i(-1, 1),
			new Vector2i(1, 1),
			new Vector2i(1, -1),
			new Vector2i(-1, -1)
		};

		public float? Anchor { get; private set; }

		public short CornerIndex { get; private set; }

		public float Depth { get; private set; }

		public float Extrusion { get; private set; }

		public short Index { get; private set; }

		public Vector2 SquareVertexPosition { get; private set; }

		public AdaptiveVertex(Vector2 v, float depth, float? anchor, short cornerIndex, short index, bool useSimpleRadialScaling)
		{
			Depth = depth;
			Anchor = anchor;
			if (!useSimpleRadialScaling)
			{
				CornerIndex = cornerIndex;
				if (v.x != 0f || v.y != 0f)
				{
					float magnitude = v.magnitude;
					if (magnitude > 0.01f)
					{
						if (!Utilities.CompareFloats(magnitude, 1f, 0.01f))
						{
							Extrusion = magnitude - 1f;
						}
						Vector2 vector = new Vector2(Mathf.Abs(v.x) - 1f, Math.Abs(v.y) - 1f);
						if (Mathf.Abs(vector.x) > 0.01f && Mathf.Abs(vector.y) > 0.01f)
						{
							v /= Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y));
						}
					}
					else
					{
						v = Vector2.zero;
					}
				}
			}
			SquareVertexPosition = v;
			Index = index;
		}

		public void UpdateVertex(Vector3[] vertices, Vector2 crossSectionScale, Vector3 crossSectionOffset, float cornerRadius, float pinch, float slant, Vector2 clampX, Vector2 clampY, float wallThickness, bool useSimpleRadialScaling)
		{
			Vector2 vector = SquareVertexPosition;
			if (!useSimpleRadialScaling)
			{
				Vector2 vector2 = _cornerPositions[CornerIndex].ToVector2() * (1f - cornerRadius);
				Vector2 normalized;
				if (IsVertexInCornerRadius(SquareVertexPosition, vector2, _cornerPositions[CornerIndex]))
				{
					normalized = (SquareVertexPosition - vector2).normalized;
					vector = normalized * cornerRadius + vector2;
				}
				else
				{
					normalized = SquareVertexPosition.normalized;
				}
				if (slant > 0f)
				{
					crossSectionOffset.y -= Mathf.Lerp(0f, slant, 0.5f - 0.5f * vector.y);
				}
				if (pinch > 0f)
				{
					vector.x *= Mathf.Lerp(1f, 0.5f * vector.y + 0.5f, pinch);
				}
				vector.x = Mathf.Clamp(vector.x, clampX.x, clampX.y);
				vector.y = Mathf.Clamp(vector.y, clampY.x, clampY.y);
				vector.Scale(crossSectionScale);
				if (Extrusion != 0f)
				{
					float num = Extrusion * wallThickness;
					if (num < 0f)
					{
						float num2 = Mathf.Min(crossSectionScale.x, crossSectionScale.y);
						if (Mathf.Abs(num) >= num2 - 0.01f)
						{
							num = Mathf.Sign(Extrusion) * num2;
						}
					}
					vector += normalized * num;
				}
			}
			else
			{
				vector.Scale(crossSectionScale);
			}
			Vector3 vector3 = new Vector3(vector.x, 0f, vector.y);
			vector3 += crossSectionOffset;
			vertices[Index] = vector3;
		}

		private static bool IsVertexInCornerRadius(Vector2 v, Vector2 circleCenterPosition, Vector2i cornerId)
		{
			if (cornerId.x == -1 && cornerId.y == 1)
			{
				if (v.x < circleCenterPosition.x)
				{
					return v.y > circleCenterPosition.y;
				}
				return false;
			}
			if (cornerId.x == 1 && cornerId.y == 1)
			{
				if (v.x > circleCenterPosition.x)
				{
					return v.y > circleCenterPosition.y;
				}
				return false;
			}
			if (cornerId.x == 1 && cornerId.y == -1)
			{
				if (v.x > circleCenterPosition.x)
				{
					return v.y < circleCenterPosition.y;
				}
				return false;
			}
			if (v.x < circleCenterPosition.x)
			{
				return v.y < circleCenterPosition.y;
			}
			return false;
		}
	}
}
