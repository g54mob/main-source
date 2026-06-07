using UnityEngine;

public struct JointSpringSource
{
	private float _damper;

	private float _spring;

	private float _targetPosition;

	public float Damper
	{
		get
		{
			return _damper;
		}
		set
		{
			_damper = Mathf.Max(0f, value);
		}
	}

	public float Spring
	{
		get
		{
			return _spring;
		}
		set
		{
			_spring = Mathf.Max(0f, value);
		}
	}

	public float TargetPosition
	{
		get
		{
			return _targetPosition;
		}
		set
		{
			_targetPosition = Mathf.Clamp01(value);
		}
	}
}
