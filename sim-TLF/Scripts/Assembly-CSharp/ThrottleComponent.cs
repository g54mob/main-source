using UnityEngine;

public class ThrottleComponent : MonoBehaviour
{
	[Header("Throttle Settings")]
	[Range(0f, 1f)]
	[SerializeField]
	private float throttlePosition;

	[SerializeField]
	private float openSpeed = 2f;

	[SerializeField]
	private float closeSpeed = 3f;

	[Header("Input")]
	[SerializeField]
	private string inputAxis = "Vertical";

	[SerializeField]
	private bool useInput = true;

	[Header("Limits")]
	[SerializeField]
	private float minThrottle;

	[SerializeField]
	private float maxThrottle = 1f;

	private float _targetPosition;

	public float ThrottlePosition => throttlePosition;

	public float ThrottlePercent => throttlePosition * 100f;

	private void Update()
	{
		if (useInput)
		{
			float axis = Input.GetAxis(inputAxis);
			_targetPosition = Mathf.Clamp01((axis + 1f) / 2f);
		}
		float num = ((_targetPosition > throttlePosition) ? openSpeed : closeSpeed);
		throttlePosition = Mathf.MoveTowards(throttlePosition, _targetPosition, num * Time.deltaTime);
		throttlePosition = Mathf.Clamp(throttlePosition, minThrottle, maxThrottle);
	}

	public void SetThrottle(float value)
	{
		useInput = false;
		_targetPosition = Mathf.Clamp01(value);
	}

	public void ForceThrottle(float value)
	{
		throttlePosition = Mathf.Clamp01(value);
		_targetPosition = throttlePosition;
	}

	public void EnableInputControl()
	{
		useInput = true;
	}

	public void DisableInputControl()
	{
		useInput = false;
	}

	public void WideOpenThrottle()
	{
		SetThrottle(1f);
	}

	public void Idle()
	{
		SetThrottle(0f);
	}
}
