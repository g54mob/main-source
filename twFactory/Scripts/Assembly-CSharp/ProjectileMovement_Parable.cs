using System;
using UnityEngine;

public class ProjectileMovement_Parable : ProjectileMovement
{
	[SerializeField]
	private float gravity = 9.81f;

	[SerializeField]
	private bool useFixedAngle;

	[SerializeField]
	private float fixedAngle = 45f;

	[SerializeField]
	private bool lowParable;

	[SerializeField]
	private bool increaseSpeedIfNeeded;

	[SerializeField]
	private float speedIncreaseStep = 1f;

	[SerializeField]
	private int maxSpeedIncreaseSteps = 10;

	private float originalSpeed;

	[SerializeField]
	private bool lookForward = true;

	[SerializeField]
	private bool updateTargetPosition;

	[SerializeField]
	[Tooltip("Time between each update. Use this to increase performance reducing accurancy.")]
	private float timeBetweenUpdates;

	private float currentTimeBetweenUpdates;

	private Vector3 targetPos;

	private float range;

	private float height;

	private float angle;

	private float internalAngle;

	private Quaternion shotRotation;

	private Vector3 startPosition;

	private float time;

	protected override void Awake()
	{
		base.Awake();
		projectile.onProjectileShot += OnProjectileShot;
		originalSpeed = speed;
	}

	protected override void Move()
	{
		if (Time.timeScale == 0f)
		{
			return;
		}
		time += Time.deltaTime;
		Vector3 vector = startPosition + Vector3.forward * speed * time * Mathf.Cos(angle) + Vector3.up * (speed * time * Mathf.Sin(angle) - 0.5f * gravity * Mathf.Pow(time, 2f));
		vector = startPosition + shotRotation * (vector - startPosition);
		if (lookForward)
		{
			base.transform.rotation = Quaternion.LookRotation((vector - base.transform.position).normalized, base.transform.up);
		}
		base.transform.position = vector;
		if (updateTargetPosition)
		{
			if (currentTimeBetweenUpdates >= timeBetweenUpdates)
			{
				currentTimeBetweenUpdates = 0f;
				CalculateParableParameters(resetMovement: false);
			}
			else
			{
				currentTimeBetweenUpdates += Time.deltaTime;
			}
		}
	}

	protected override bool CheckTargetReached()
	{
		float num = speed * time * Mathf.Cos(angle);
		float num2 = startPosition.y + speed * time * Mathf.Sin(angle) - 0.5f * gravity * Mathf.Pow(time, 2f);
		if (num > range)
		{
			return num2 < targetPos.y;
		}
		return false;
	}

	private void OnProjectileShot()
	{
		CalculateParableParameters(resetMovement: true);
	}

	private void CalculateParableParameters(bool resetMovement)
	{
		if (resetMovement)
		{
			time = 0f;
			startPosition = base.transform.position;
			speed = originalSpeed;
		}
		if ((bool)projectile.Target)
		{
			projectile.TargetPosition = projectile.Target.transform.position;
		}
		targetPos = (projectile.Target ? projectile.Target.transform.position : projectile.TargetPosition);
		Vector3 vector = (projectile.Target ? (targetPos + Vector3.up * FunctionLibrary.GetObjectHeight(projectile.Target.gameObject) * 0.75f) : targetPos);
		range = Mathf.Abs((startPosition.XZ() - vector.XZ()).magnitude);
		height = vector.y - startPosition.y;
		if (useFixedAngle)
		{
			angle = fixedAngle * (MathF.PI / 180f);
			speed = range / Mathf.Cos(angle) * Mathf.Sqrt(gravity * 0.5f * (1f / (range * Mathf.Tan(angle) - height)));
			if (float.IsNaN(speed))
			{
				speed = 1f;
			}
		}
		else
		{
			float num = Mathf.Pow(speed, 2f);
			bool flag = true;
			angle = Mathf.Atan((num + (float)((!lowParable) ? 1 : (-1)) * Mathf.Sqrt(Mathf.Pow(num, 2f) - gravity * (gravity * Mathf.Pow(range, 2f) + 2f * height * num))) / (gravity * range));
			if (float.IsNaN(angle))
			{
				flag = false;
				if (increaseSpeedIfNeeded)
				{
					for (int i = 0; i < maxSpeedIncreaseSteps; i++)
					{
						num = Mathf.Pow(speed + speedIncreaseStep * (float)(i + 1), 2f);
						angle = Mathf.Atan((num + (float)((!lowParable) ? 1 : (-1)) * Mathf.Sqrt(Mathf.Pow(num, 2f) - gravity * (gravity * Mathf.Pow(range, 2f) + 2f * height * num))) / (gravity * range));
						if (!float.IsNaN(angle))
						{
							speed += speedIncreaseStep * (float)(i + 1);
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					angle = 0f;
				}
			}
		}
		shotRotation = Quaternion.LookRotation((vector.XZ().XZ() - startPosition.XZ().XZ()).normalized, Vector3.up);
	}
}
