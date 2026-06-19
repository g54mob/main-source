using System;

[Serializable]
public class PIDController
{
	public float Kp = 1f;

	public float Ki;

	public float Kd;

	private float integral;

	private float lastError;

	private bool firstTick = true;

	public float Update(float error, float dt)
	{
		if (dt <= 0f)
		{
			return 0f;
		}
		integral += error * dt;
		float num = (firstTick ? 0f : ((error - lastError) / dt));
		firstTick = false;
		lastError = error;
		return Kp * error + Ki * integral + Kd * num;
	}

	public void Reset()
	{
		integral = 0f;
		lastError = 0f;
		firstTick = true;
	}
}
