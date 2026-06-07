using UnityEngine;

public class PidController
{
	private float up;

	private float ui;

	private float ud;

	private float currentError;

	private float lastError;

	public float KP { get; set; }

	public float KI { get; set; }

	public float KI2 { get; set; }

	public float KD { get; set; }

	public float MinIOffset { get; set; }

	public float MaxIOffset { get; set; }

	public float OutputMinValue { get; set; }

	public float OutputMaxValue { get; set; }

	public PidController(float kP, float kI, float kD)
	{
		KP = kP;
		KI = kI;
		KD = kD;
		KI2 = 1f;
		MinIOffset = -100f;
		MaxIOffset = 100f;
		OutputMinValue = float.NegativeInfinity;
		OutputMaxValue = float.PositiveInfinity;
		up = (ui = (ud = 0f));
		currentError = (lastError = 0f);
	}

	public float Compute(float currentPoint, float targetPoint, float dt)
	{
		currentError = targetPoint - currentPoint;
		up = currentError;
		ui += currentError * dt * KI2;
		ud = (currentError - lastError) / dt;
		lastError = currentError;
		ui = Mathf.Clamp(ui, MinIOffset, MaxIOffset);
		return Mathf.Clamp(KP * up + KI * ui + KD * ud, OutputMinValue, OutputMaxValue);
	}

	public void Reset()
	{
		up = (ui = (ud = 0f));
		currentError = (lastError = 0f);
	}
}
