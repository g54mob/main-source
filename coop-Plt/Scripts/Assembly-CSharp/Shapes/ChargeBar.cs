using System;
using UnityEngine;

namespace Shapes
{
	public class ChargeBar : MonoBehaviour
	{
		[Header("Gameplay")]
		[SerializeField]
		private float chargeSpeed = 1f;

		[SerializeField]
		private float chargeDecaySpeed = 1f;

		[NonSerialized]
		public bool isCharging;

		private float charge;

		[Header("Style")]
		public Color tickColor = Color.white;

		public Gradient chargeFillGradient;

		[Range(0f, 0.1f)]
		public float tickSizeSmol = 0.1f;

		[Range(0f, 0.1f)]
		public float tickSizeLorge = 0.1f;

		[Range(0f, 0.05f)]
		public float tickTickness;

		[Range(0f, 0.5f)]
		public float fontSize = 0.1f;

		[Range(0f, 0.5f)]
		public float fontSizeLorge = 0.1f;

		[Range(0f, 0.1f)]
		public float percentLabelOffset = 0.1f;

		[Range(0f, 0.4f)]
		public float fontGrowRangePrev = 0.1f;

		[Range(0f, 0.4f)]
		public float fontGrowRangeNext = 0.1f;

		[Header("Animation")]
		public AnimationCurve chargeFillCurve;

		public AnimationCurve animChargeShakeMagnitude = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Range(0f, 0.05f)]
		public float chargeShakeMagnitude = 0.1f;

		public float chargeShakeSpeed = 1f;

		public void UpdateCharge()
		{
			if (isCharging)
			{
				charge += chargeSpeed * Time.deltaTime;
			}
			else
			{
				charge -= chargeDecaySpeed * Time.deltaTime;
			}
			charge = Mathf.Clamp01(charge);
		}

		public void DrawBar(FpsController fpsController, float barRadius)
		{
			float ammoBarThickness = fpsController.ammoBarThickness;
			float ammoBarOutlineThickness = fpsController.ammoBarOutlineThickness;
			float num = (0f - fpsController.ammoBarAngularSpanRad) / 2f;
			float num2 = fpsController.ammoBarAngularSpanRad / 2f;
			float num3 = num + (float)Math.PI;
			float num4 = num2 + (float)Math.PI;
			float num5 = barRadius + ammoBarThickness / 2f;
			float num6 = chargeFillCurve.Evaluate(charge);
			float amp = animChargeShakeMagnitude.Evaluate(num6) * chargeShakeMagnitude;
			Vector2 shake = fpsController.GetShake(chargeShakeSpeed, amp);
			float num7 = Mathf.Lerp(num4, num3, num6);
			Color color = chargeFillGradient.Evaluate(num6);
			Draw.Arc(shake, fpsController.ammoBarRadius, ammoBarThickness, num4, num7, color);
			Vector2 vector = shake + ShapesMath.AngToDir(num7) * barRadius;
			Draw.Disc(shake + ShapesMath.AngToDir(num4) * barRadius, ammoBarThickness / 2f, color);
			Draw.LineEndCaps = LineEndCap.None;
			for (int i = 0; i < 7; i++)
			{
				float num8 = (float)i / 6f;
				float num9 = Mathf.Lerp(num4, num3, num8);
				Vector2 vector2 = ShapesMath.AngToDir(num9);
				Vector2 vector3 = shake + vector2 * num5;
				bool flag = i % 3 == 0;
				Draw.Line(end: vector3 + vector2 * (flag ? tickSizeLorge : tickSizeSmol), start: vector3, thickness: tickTickness, color: tickColor);
				float num10 = num8 - num6;
				float num11 = ((num10 < 0f) ? fontGrowRangePrev : fontGrowRangeNext);
				Draw.FontSize = ShapesMath.Eerp(t: 1f - ShapesMath.SmoothCos01(Mathf.Clamp01(Mathf.Abs(num10) / num11)), a: fontSize, b: fontSizeLorge);
				Vector2 vector4 = vector3 + vector2 * percentLabelOffset;
				Draw.Text(content: Mathf.RoundToInt(num8 * 100f) + "%", pos: vector4, angle: num9 + (float)Math.PI, align: TextAlign.Right);
			}
			Draw.Disc(vector, ammoBarThickness / 2f + ammoBarOutlineThickness / 2f);
			Draw.Disc(vector, ammoBarThickness / 2f - ammoBarOutlineThickness / 2f, color);
			FpsController.DrawRoundedArcOutline(shake, barRadius, ammoBarThickness, ammoBarOutlineThickness, num3, num4);
			Draw.LineEndCaps = LineEndCap.Round;
			Draw.BlendMode = ShapesBlendMode.Additive;
			Draw.DiscGradientRadial(vector, ammoBarThickness * 2f, color, Color.clear);
			Draw.BlendMode = ShapesBlendMode.Transparent;
		}
	}
}
