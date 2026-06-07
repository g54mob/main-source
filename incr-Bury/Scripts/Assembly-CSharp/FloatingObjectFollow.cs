using System;
using UnityEngine;

public class FloatingObjectFollow : MonoBehaviour
{
	private Rigidbody rb;

	[SerializeField]
	private Transform followTarget;

	[SerializeField]
	private Transform lookTarget;

	[Header("Torque To Face")]
	[SerializeField]
	private float torque_Strength = 10f;

	[SerializeField]
	private float torque_Dampening = 2f;

	[Header("Movement")]
	public float heightOffset = 2f;

	public float followRange = 3f;

	public float followStrength = 8f;

	public float damping = 5f;

	public float maxSpeed = 10f;

	[Header("Nighttime")]
	[SerializeField]
	private bool freezeAtNighttime;

	[SerializeField]
	private bool flipAtNighttime;

	[SerializeField]
	private bool currentlyDisabled;

	public bool skipGamestateBoolChecks;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		if (GameManager.Singleton.hasTimerElapsed_IsNighttime && freezeAtNighttime)
		{
			DisablePhysicsAndColliders();
		}
		if (freezeAtNighttime && !currentlyDisabled)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Combine(singleton.OnNightTime_Action, new Action(DisablePhysicsAndColliders));
		}
	}

	private void OnDestroy()
	{
		if (freezeAtNighttime)
		{
			GameManager singleton = GameManager.Singleton;
			singleton.OnNightTime_Action = (Action)Delegate.Remove(singleton.OnNightTime_Action, new Action(DisablePhysicsAndColliders));
		}
	}

	private void FixedUpdate()
	{
		if ((GameManager.Singleton.gameState == GameManager.GameState.Playing || skipGamestateBoolChecks) && !currentlyDisabled)
		{
			if (rb.isKinematic)
			{
				rb.isKinematic = false;
			}
			HandleTorqueToFaceTarget();
			MoveToTarget();
		}
	}

	private void MoveToTarget()
	{
		if ((bool)followTarget)
		{
			Vector3 vector = followTarget.position + Vector3.up * heightOffset;
			float magnitude = (new Vector3(rb.position.x, vector.y, rb.position.z) - vector).magnitude;
			Vector3 zero = Vector3.zero;
			zero = ((!(magnitude > followRange)) ? (-rb.linearVelocity * (damping * 0.5f)) : ((vector - rb.position).normalized * (magnitude - followRange) * followStrength - rb.linearVelocity * damping));
			float num = vector.y - rb.position.y;
			zero += Vector3.up * num * followStrength * 0.5f;
			rb.AddForce(zero, ForceMode.Acceleration);
			if (rb.linearVelocity.magnitude > maxSpeed)
			{
				rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
			}
		}
	}

	private void HandleTorqueToFaceTarget()
	{
		Vector3 zero = Vector3.zero;
		zero = ((!flipAtNighttime) ? (lookTarget.transform.position - base.transform.position).normalized : ((!GameManager.Singleton.hasTimerElapsed_IsNighttime) ? (lookTarget.transform.position - base.transform.position).normalized : (base.transform.position - lookTarget.transform.position).normalized));
		if (!(zero.sqrMagnitude < 0.0001f))
		{
			_ = base.transform.forward;
			(Quaternion.LookRotation(zero, Vector3.up) * Quaternion.Inverse(base.transform.rotation)).ToAngleAxis(out var angle, out var axis);
			if (angle > 180f)
			{
				angle -= 360f;
			}
			if (!(Mathf.Abs(angle) < 0.1f))
			{
				Vector3 torque = axis.normalized * angle * (MathF.PI / 180f) * torque_Strength;
				torque -= rb.angularVelocity * torque_Dampening;
				rb.AddTorque(torque, ForceMode.Acceleration);
			}
		}
	}

	private void DisablePhysicsAndColliders()
	{
		currentlyDisabled = true;
		rb.isKinematic = true;
		Collider[] componentsInChildren = base.gameObject.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
	}

	public void DisableMovement()
	{
		currentlyDisabled = true;
	}

	public void EnableMovement()
	{
		currentlyDisabled = false;
	}
}
