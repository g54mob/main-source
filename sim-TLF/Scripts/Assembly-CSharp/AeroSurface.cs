using System;
using UnityEngine;

public class AeroSurface : MonoBehaviour
{
	[SerializeField]
	private AeroSurfaceConfig config;

	public bool IsControlSurface;

	public ControlInputType InputType;

	public float InputMultiplyer = 1f;

	private float flapAngle;

	public void SetFlapAngle(float angle)
	{
		flapAngle = Mathf.Clamp(angle, -0.87266463f, 0.87266463f);
	}

	public BiVector3 CalculateForces(Vector3 worldAirVelocity, float airDensity, Vector3 relativePosition)
	{
		BiVector3 result = default(BiVector3);
		if (!base.gameObject.activeInHierarchy || config == null)
		{
			return result;
		}
		float num = config.liftSlope * config.aspectRatio / (config.aspectRatio + 2f * (config.aspectRatio + 4f) / (config.aspectRatio + 2f));
		float num2 = Mathf.Acos(2f * config.flapFraction - 1f);
		float num3 = 1f - (num2 - Mathf.Sin(num2)) / MathF.PI;
		float num4 = num * num3 * FlapEffectivnessCorrection(flapAngle) * flapAngle;
		float num5 = config.zeroLiftAoA * (MathF.PI / 180f);
		float num6 = num5 - num4 / num;
		float num7 = config.stallAngleHigh * (MathF.PI / 180f);
		float num8 = config.stallAngleLow * (MathF.PI / 180f);
		float num9 = num * (num7 - num5) + num4 * LiftCoefficientMaxFraction(config.flapFraction);
		float num10 = num * (num8 - num5) + num4 * LiftCoefficientMaxFraction(config.flapFraction);
		float stallAngleHigh = num6 + num9 / num;
		float stallAngleLow = num6 + num10 / num;
		Vector3 vector = base.transform.InverseTransformDirection(worldAirVelocity);
		vector = new Vector3(vector.x, vector.y);
		Vector3 vector2 = base.transform.TransformDirection(vector.normalized);
		Vector3 vector3 = Vector3.Cross(vector2, base.transform.forward);
		float num11 = config.chord * config.span;
		float num12 = 0.5f * airDensity * vector.sqrMagnitude;
		float angleOfAttack = Mathf.Atan2(vector.y, 0f - vector.x);
		Vector3 vector4 = CalculateCoefficients(angleOfAttack, num, num6, stallAngleHigh, stallAngleLow);
		Vector3 vector5 = vector3 * vector4.x * num12 * num11;
		Vector3 vector6 = vector2 * vector4.y * num12 * num11;
		Vector3 vector7 = -base.transform.forward * vector4.z * num12 * num11 * config.chord;
		result.p += vector5 + vector6;
		result.q += Vector3.Cross(relativePosition, result.p);
		result.q += vector7;
		return result;
	}

	private Vector3 CalculateCoefficients(float angleOfAttack, float correctedLiftSlope, float zeroLiftAoA, float stallAngleHigh, float stallAngleLow)
	{
		float num = MathF.PI / 180f * Mathf.Lerp(15f, 5f, (57.29578f * flapAngle + 50f) / 100f);
		float num2 = MathF.PI / 180f * Mathf.Lerp(15f, 5f, (-57.29578f * flapAngle + 50f) / 100f);
		float num3 = stallAngleHigh + num;
		float num4 = stallAngleLow - num2;
		if (angleOfAttack < stallAngleHigh && angleOfAttack > stallAngleLow)
		{
			return CalculateCoefficientsAtLowAoA(angleOfAttack, correctedLiftSlope, zeroLiftAoA);
		}
		if (angleOfAttack > num3 || angleOfAttack < num4)
		{
			return CalculateCoefficientsAtStall(angleOfAttack, correctedLiftSlope, zeroLiftAoA, stallAngleHigh, stallAngleLow);
		}
		Vector3 a;
		Vector3 b;
		float t;
		if (angleOfAttack > stallAngleHigh)
		{
			a = CalculateCoefficientsAtLowAoA(stallAngleHigh, correctedLiftSlope, zeroLiftAoA);
			b = CalculateCoefficientsAtStall(num3, correctedLiftSlope, zeroLiftAoA, stallAngleHigh, stallAngleLow);
			t = (angleOfAttack - stallAngleHigh) / (num3 - stallAngleHigh);
		}
		else
		{
			a = CalculateCoefficientsAtLowAoA(stallAngleLow, correctedLiftSlope, zeroLiftAoA);
			b = CalculateCoefficientsAtStall(num4, correctedLiftSlope, zeroLiftAoA, stallAngleHigh, stallAngleLow);
			t = (angleOfAttack - stallAngleLow) / (num4 - stallAngleLow);
		}
		return Vector3.Lerp(a, b, t);
	}

	private Vector3 CalculateCoefficientsAtLowAoA(float angleOfAttack, float correctedLiftSlope, float zeroLiftAoA)
	{
		float num = correctedLiftSlope * (angleOfAttack - zeroLiftAoA);
		float num2 = num / (MathF.PI * config.aspectRatio);
		float num3 = angleOfAttack - zeroLiftAoA - num2;
		float num4 = config.skinFriction * Mathf.Cos(num3);
		float num5 = (num + Mathf.Sin(num3) * num4) / Mathf.Cos(num3);
		float y = num5 * Mathf.Sin(num3) + num4 * Mathf.Cos(num3);
		float z = (0f - num5) * TorqCoefficientProportion(num3);
		return new Vector3(num, y, z);
	}

	private Vector3 CalculateCoefficientsAtStall(float angleOfAttack, float correctedLiftSlope, float zeroLiftAoA, float stallAngleHigh, float stallAngleLow)
	{
		float num = ((!(angleOfAttack > stallAngleHigh)) ? (correctedLiftSlope * (stallAngleLow - zeroLiftAoA)) : (correctedLiftSlope * (stallAngleHigh - zeroLiftAoA)));
		float b = num / (MathF.PI * config.aspectRatio);
		float t = ((!(angleOfAttack > stallAngleHigh)) ? ((-MathF.PI / 2f - Mathf.Clamp(angleOfAttack, -MathF.PI / 2f, MathF.PI / 2f)) / (-MathF.PI / 2f - stallAngleLow)) : ((MathF.PI / 2f - Mathf.Clamp(angleOfAttack, -MathF.PI / 2f, MathF.PI / 2f)) / (MathF.PI / 2f - stallAngleHigh)));
		b = Mathf.Lerp(0f, b, t);
		float num2 = angleOfAttack - zeroLiftAoA - b;
		float num3 = FrictionAt90Degrees(flapAngle) * Mathf.Sin(num2) * (1f / (0.56f + 0.44f * Mathf.Abs(Mathf.Sin(num2))) - 0.41f * (1f - Mathf.Exp(-17f / config.aspectRatio)));
		float num4 = 0.5f * config.skinFriction * Mathf.Cos(num2);
		float x = num3 * Mathf.Cos(num2) - num4 * Mathf.Sin(num2);
		float y = num3 * Mathf.Sin(num2) + num4 * Mathf.Cos(num2);
		float z = (0f - num3) * TorqCoefficientProportion(num2);
		return new Vector3(x, y, z);
	}

	private float TorqCoefficientProportion(float effectiveAngle)
	{
		return 0.25f - 0.175f * (1f - 2f * Mathf.Abs(effectiveAngle) / MathF.PI);
	}

	private float FrictionAt90Degrees(float flapAngle)
	{
		return 1.98f - 0.0426f * flapAngle * flapAngle + 0.21f * flapAngle;
	}

	private float FlapEffectivnessCorrection(float flapAngle)
	{
		return Mathf.Lerp(0.8f, 0.4f, (Mathf.Abs(flapAngle) * 57.29578f - 10f) / 50f);
	}

	private float LiftCoefficientMaxFraction(float flapFraction)
	{
		return Mathf.Clamp01(1f - 0.5f * (flapFraction - 0.1f) / 0.3f);
	}
}
