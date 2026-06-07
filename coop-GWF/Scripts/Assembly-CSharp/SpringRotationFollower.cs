using System;
using UnityEngine;

public class SpringRotationFollower : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField]
	private float springStrength = 300f;

	[SerializeField]
	private float damping = 12f;

	[SerializeField]
	private float maxAngularSpeed = 720f;

	[SerializeField]
	private float rotationOffsetMultiplier = 0.2f;

	[Header("References")]
	[SerializeField]
	private Transform target;

	private Quaternion _rotationState;

	private Vector3 _angularVelocity;

	private void Awake()
	{
		_rotationState = base.transform.rotation;
	}

	private void OnDisable()
	{
		base.transform.localRotation = Quaternion.identity;
		_angularVelocity = Vector3.zero;
	}

	private void OnEnable()
	{
		if ((bool)target)
		{
			_rotationState = target.rotation;
		}
	}

	private void LateUpdate()
	{
		SmoothRotate();
	}

	private void SmoothRotate()
	{
		if ((bool)target)
		{
			(target.rotation * Quaternion.Inverse(_rotationState)).ToAngleAxis(out var angle, out var axis);
			if (angle > 180f)
			{
				angle -= 360f;
			}
			if (!(Mathf.Abs(angle) < 0.001f) && !(axis == Vector3.zero))
			{
				Vector3 vector = axis.normalized * (angle * (MathF.PI / 180f)) * springStrength;
				_angularVelocity += vector * Time.deltaTime;
				_angularVelocity *= Mathf.Exp((0f - damping) * Time.deltaTime);
				_angularVelocity = Vector3.ClampMagnitude(_angularVelocity, maxAngularSpeed * (MathF.PI / 180f));
				Quaternion quaternion = Quaternion.Euler(_angularVelocity * (57.29578f * Time.deltaTime));
				_rotationState = quaternion * _rotationState;
				base.transform.rotation = Quaternion.Slerp(target.rotation, _rotationState, rotationOffsetMultiplier);
			}
		}
	}
}
