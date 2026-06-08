using System;
using UnityEngine;

namespace Shapes
{
	public class AmmoBar : MonoBehaviour
	{
		public int totalBullets = 20;

		public int bullets = 15;

		[Header("Style")]
		[Range(0f, 1f)]
		public float bulletThicknessScale = 1f;

		[Range(0f, 0.5f)]
		public float bulletEjectScale = 0.5f;

		[Header("Animation")]
		public float bulletDisappearTime = 1f;

		[Range(0f, (float)Math.PI * 2f)]
		public float bulletEjectAngSpeed = 0.5f;

		[Range(0f, (float)Math.PI * 2f)]
		public float ejectRotSpeedVariance = 1f;

		public AnimationCurve bulletEjectX = AnimationCurve.Constant(0f, 1f, 0f);

		public AnimationCurve bulletEjectY = AnimationCurve.Constant(0f, 1f, 0f);

		private float[] bulletFireTimes;

		public bool HasBulletsLeft => bullets > 0;

		private Vector2 GetBulletEjectPos(Vector2 origin, float t)
		{
			Vector2 vector = new Vector2(bulletEjectX.Evaluate(t), bulletEjectY.Evaluate(t));
			return origin + vector * bulletEjectScale;
		}

		public void Fire()
		{
			bulletFireTimes[--bullets] = Time.time;
		}

		public void Reload()
		{
			bullets = totalBullets;
		}

		private void Awake()
		{
			bulletFireTimes = new float[totalBullets];
		}

		public void DrawBar(FpsController fpsController, float barRadius)
		{
			float ammoBarThickness = fpsController.ammoBarThickness;
			float ammoBarOutlineThickness = fpsController.ammoBarOutlineThickness;
			float num = (0f - fpsController.ammoBarAngularSpanRad) / 2f;
			float num2 = fpsController.ammoBarAngularSpanRad / 2f;
			Draw.LineEndCaps = LineEndCap.Round;
			float thickness = (barRadius - ammoBarThickness / 2f) * fpsController.ammoBarAngularSpanRad / (float)totalBullets * bulletThicknessScale;
			for (int i = 0; i < totalBullets; i++)
			{
				float t = (float)i / ((float)totalBullets - 1f);
				Vector2 vector = ShapesMath.AngToDir(Mathf.Lerp(num, num2, t));
				Vector2 vector2 = vector * barRadius;
				Vector2 vector3 = vector * (ammoBarThickness / 2f - ammoBarOutlineThickness * 1.5f);
				float a = 1f;
				if (i >= bullets && Application.isPlaying)
				{
					float num3 = Time.time - bulletFireTimes[i];
					float num4 = Mathf.Clamp01(num3 / bulletDisappearTime);
					a = 1f - num4;
					vector2 = GetBulletEjectPos(vector2, num4);
					float angRad = num3 * (bulletEjectAngSpeed + Mathf.Cos((float)i * 92372.8f) * ejectRotSpeedVariance);
					vector3 = ShapesMath.Rotate(vector3, angRad);
				}
				Vector2 vector4 = vector2 + vector3;
				Draw.Line(end: vector2 - vector3, start: vector4, thickness: thickness, color: new Color(1f, 1f, 1f, a));
			}
			FpsController.DrawRoundedArcOutline(Vector2.zero, barRadius, ammoBarThickness, ammoBarOutlineThickness, num, num2);
		}
	}
}
