using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GoToTarget : DynamicObjectBase
{
	[SerializeField]
	private Transform target;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float timeToMaxSpeed = 0.3f;

	[SerializeField]
	private float timeToMinSpeed = 0.3f;

	[SerializeField]
	private float startDelay;

	private float timeToMaxSpeedCounter;

	private float timeToMinSpeedCounter;

	private float distanceToMinSpeed;

	private float currentSpeed;

	private float startDelayCounter;

	private bool isStartDelayEnded;

	private bool shouldGoToTarget;

	private Rigidbody rb;

	public event Action<bool, float, float> OnMovingToTargetEvent;

	protected override void Awake()
	{
		base.Awake();
		base.enabled = false;
		isStartDelayEnded = false;
		shouldGoToTarget = false;
		timeToMaxSpeedCounter = 0f;
		timeToMinSpeedCounter = 0f;
		currentSpeed = 0f;
		startDelayCounter = 0f;
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		this.OnMovingToTargetEvent?.Invoke(shouldGoToTarget, currentSpeed, speed);
	}

	private void FixedUpdate()
	{
		if (!base.IsInAction)
		{
			return;
		}
		if (!isStartDelayEnded)
		{
			startDelayCounter += Time.fixedDeltaTime;
			if (startDelayCounter >= startDelay)
			{
				isStartDelayEnded = true;
			}
		}
		if (shouldGoToTarget && isStartDelayEnded)
		{
			currentSpeed = speed;
			if (timeToMaxSpeedCounter <= timeToMaxSpeed)
			{
				timeToMaxSpeedCounter += Time.fixedDeltaTime;
				currentSpeed = speed * timeToMaxSpeedCounter / timeToMaxSpeed;
			}
			if (Vector3.Distance(base.transform.position, target.position) <= distanceToMinSpeed)
			{
				timeToMinSpeedCounter += Time.fixedDeltaTime;
				currentSpeed = speed * (1f - timeToMinSpeedCounter / timeToMinSpeed);
			}
			currentSpeed = Mathf.Clamp(currentSpeed, 0.05f, speed);
			Vector3 position = Vector3.MoveTowards(base.transform.position, target.position, currentSpeed * Time.fixedDeltaTime);
			rb.MovePosition(position);
			if (base.transform.position == target.position)
			{
				shouldGoToTarget = false;
			}
		}
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		distanceToMinSpeed = speed / timeToMinSpeed * timeToMinSpeed * timeToMinSpeed / 2f;
		shouldGoToTarget = true;
		base.enabled = true;
	}

	public override void Recycle()
	{
		base.Recycle();
		base.enabled = false;
		isStartDelayEnded = false;
		shouldGoToTarget = false;
		timeToMaxSpeedCounter = 0f;
		timeToMinSpeedCounter = 0f;
		currentSpeed = 0f;
		startDelayCounter = 0f;
		StartCoroutine(OnMovingToTargetEventDelayed());
		IEnumerator OnMovingToTargetEventDelayed()
		{
			yield return new WaitForEndOfFrame();
			this.OnMovingToTargetEvent?.Invoke(arg1: false, currentSpeed, speed);
		}
	}

	private void OnDrawGizmos()
	{
		if (!(target == null))
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(base.transform.position, 0.25f);
			Gizmos.DrawSphere(target.position, 0.25f);
			Gizmos.DrawLine(base.transform.position, target.position);
		}
	}
}
