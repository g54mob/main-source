using UnityEngine;

namespace Shapes
{
	public class Crosshair : MonoBehaviour
	{
		[Header("Style")]
		[Range(0f, 0.05f)]
		public float crosshairCrossInnerRad = 0.1f;

		[Range(0f, 0.05f)]
		public float crosshairCrossOuterRad = 0.3f;

		[Range(0f, 0.05f)]
		public float crosshairCrossThickness = 0.2f;

		[Range(0f, 0.05f)]
		public float crosshairHitCrossInnerRad = 0.1f;

		[Range(0f, 0.05f)]
		public float crosshairHitCrossOuterRad = 0.3f;

		[Range(0f, 0.05f)]
		public float crosshairHitCrossThickness = 0.2f;

		[Header("Animation")]
		[Range(0f, 1f)]
		public float scaleFire = 0.1f;

		public Decayer fireDecayer = new Decayer();

		public Decayer hitDecayer = new Decayer();

		public void Fire()
		{
			fireDecayer.SetT(1f);
		}

		public void FireHit()
		{
			hitDecayer.SetT(1f);
		}

		public void UpdateCrosshairDecay()
		{
			fireDecayer.Update();
			hitDecayer.Update();
		}

		public void DrawCrosshair()
		{
			Vector2[] dirs = new Vector2[4]
			{
				Vector2.up,
				Vector2.right,
				Vector2.down,
				Vector2.left
			};
			Vector2[] dirs2 = new Vector2[4]
			{
				(Vector2.up + Vector2.right).normalized,
				(Vector2.right + Vector2.down).normalized,
				(Vector2.down + Vector2.left).normalized,
				(Vector2.left + Vector2.up).normalized
			};
			DrawCross(thickness: crosshairCrossThickness * Mathf.Lerp(1f, scaleFire, fireDecayer.t), dirs: dirs, radInner: crosshairCrossInnerRad, radOuter: crosshairCrossOuterRad, radialOffset: fireDecayer.value, color: Color.white);
			DrawCross(dirs2, crosshairHitCrossInnerRad, crosshairHitCrossOuterRad, crosshairHitCrossThickness, hitDecayer.valueInv, new Color(1f, 0f, 0f, hitDecayer.t));
			static void DrawCross(Vector2[] array, float radInner, float radOuter, float thickness, float radialOffset, Color color)
			{
				foreach (Vector2 vector in array)
				{
					Vector2 vector2 = vector * (radInner + radialOffset);
					Vector2 vector3 = vector * (radOuter + radialOffset);
					Draw.Line(vector2, vector3, thickness, LineEndCap.Round, color);
				}
			}
		}
	}
}
