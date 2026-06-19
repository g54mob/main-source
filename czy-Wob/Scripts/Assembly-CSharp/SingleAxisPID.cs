using UnityEngine;

internal class SingleAxisPID
{
	private float targetAngle;

	private float currentAngle;

	private float appliedTorque;

	private float lastError;

	private float integrator;

	private float minError = 0.1f;

	private float pGain = 50f;

	private float iGain;

	private float dGain = 75f;

	public SingleAxisPID(float targetAngle)
	{
		this.targetAngle = targetAngle;
	}

	public float GetTorqueFixedUpdate(float newAngle, float maxAcceleration)
	{
		currentAngle = newAngle;
		float num = Mathf.DeltaAngle(currentAngle, targetAngle);
		if (Mathf.Abs(num) < minError)
		{
			num = 0f;
		}
		integrator += num * Time.fixedDeltaTime;
		float num2 = (num - lastError) / Time.fixedDeltaTime;
		lastError = num;
		appliedTorque = num * pGain + integrator * iGain + num2 * dGain;
		appliedTorque = Mathf.Clamp(appliedTorque, 0f - maxAcceleration, maxAcceleration);
		return appliedTorque;
	}
}
