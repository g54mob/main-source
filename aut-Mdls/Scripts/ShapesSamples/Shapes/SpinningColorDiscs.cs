using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class SpinningColorDiscs : ImmediateModeShapeDrawer
	{
		[Range(3f, 32f)]
		public int discCount = 24;

		[Range(0f, 1f)]
		public float discRadius = 0.1f;

		public override void DrawShapes(Camera cam)
		{
			using (Draw.Command(cam))
			{
				Draw.ResetAllDrawStates();
				Draw.Matrix = base.transform.localToWorldMatrix;
				for (int i = 0; i < discCount; i++)
				{
					float num = (float)i / (float)discCount;
					Color color = Color.HSVToRGB(num, 1f, 1f);
					Draw.Disc(GetDiscPosition(num), discRadius, color);
				}
			}
		}

		private Vector2 GetDiscPosition(float t)
		{
			float num = t * (MathF.PI * 2f) + MathF.PI * 2f * Time.time * 0.25f;
			return ShapesMath.AngToDir(num + Mathf.Cos(num * 2f + Time.time * (MathF.PI * 2f) * 0.5f) * 0.16f);
		}
	}
}
