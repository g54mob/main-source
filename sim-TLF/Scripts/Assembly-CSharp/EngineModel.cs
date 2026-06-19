using System;
using UnityEngine;

[Serializable]
public class EngineModel
{
	[Header("Specs")]
	public int cylinders = 8;

	public float displacementL = 4f;

	public float compressionRatio = 10.5f;

	public float peakTorqueNm = 450f;

	public float peakTorqueRPM = 4500f;

	public float peakPowerKW = 320f;

	public float peakPowerRPM = 6500f;

	public float redlineRPM = 8000f;

	[Header("Torque Curve")]
	public AnimationCurve torqueCurve = DefaultTorqueCurve();

	[Header("Pressures")]
	public float intakeManifoldPressureKPa = 101.3f;

	public float maxBoostPressureKPa = 200f;

	public float oilPressureBarMin = 1.5f;

	public float oilPressureBarMax = 5f;

	public float fuelPressureBar = 3.5f;

	[Header("Timing")]
	public float ignitionAdvanceDegBase = 10f;

	public float ignitionAdvanceDegMax = 35f;

	public float valveIntakeOpenDeg = 10f;

	public float valveIntakeCloseDeg = 50f;

	public float valveExhaustOpenDeg = 55f;

	public float valveExhaustCloseDeg = 15f;

	[Header("Temperatures")]
	public float coolantTempMin = 80f;

	public float coolantTempMax = 105f;

	public float oilTempMin = 90f;

	public float oilTempMax = 130f;

	public float exhaustTempBase = 700f;

	public float EvaluateTorque(float rpm)
	{
		float time = Mathf.Clamp01(rpm / redlineRPM);
		return torqueCurve.Evaluate(time) * peakTorqueNm;
	}

	public float GetManifoldPressure(float throttlePosition, float rpm)
	{
		float t = throttlePosition * (rpm / redlineRPM);
		return Mathf.Lerp(30f, intakeManifoldPressureKPa, t);
	}

	public float GetOilPressure(float rpm)
	{
		float t = Mathf.Clamp01(rpm / redlineRPM);
		return Mathf.Lerp(oilPressureBarMin, oilPressureBarMax, t);
	}

	public float GetExhaustTemperature(float throttlePos, float afrEfficiency)
	{
		return exhaustTempBase * throttlePos / Mathf.Max(0.1f, afrEfficiency);
	}

	public static AnimationCurve DefaultTorqueCurve()
	{
		return new AnimationCurve(new Keyframe(0f, 0.2f), new Keyframe(0.1f, 0.5f), new Keyframe(0.25f, 0.8f), new Keyframe(0.5f, 1f), new Keyframe(0.7f, 0.95f), new Keyframe(0.85f, 0.8f), new Keyframe(1f, 0.5f));
	}
}
