using UnityEngine;

public class MillRotor : MonoBehaviour
{
	public float rotationSpeed = 90f;

	private float acceleration = 10f;

	private float currentSpeed;

	private DayNightCycle daynight;

	private void Start()
	{
		daynight = DayNightCycle.Instance;
	}

	private void Update()
	{
		if (daynight.CurrentTimestate == DayNightCycle.Timestate.Day)
		{
			if (currentSpeed < rotationSpeed)
			{
				currentSpeed += acceleration * Time.deltaTime;
			}
			if (currentSpeed > rotationSpeed)
			{
				currentSpeed = rotationSpeed;
			}
		}
		else if (daynight.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			if (currentSpeed > 0f)
			{
				currentSpeed -= acceleration * Time.deltaTime;
			}
			if (currentSpeed < 0f)
			{
				currentSpeed = 0f;
			}
		}
		base.transform.Rotate(0f, currentSpeed * Time.deltaTime, 0f, Space.Self);
	}
}
