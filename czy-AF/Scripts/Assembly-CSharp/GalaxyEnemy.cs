using System;
using UnityEngine;

public class GalaxyEnemy : MonoBehaviour
{
	public Transform target;

	private float speed;

	private Vector3 moveDirection;

	private Vector3 previousPosition;

	private Vector3 releaseVelocity;

	private float timer;

	private bool orbit = true;

	private void Awake()
	{
		speed = UnityEngine.Random.Range(20f, 60f);
		moveDirection.x = UnityEngine.Random.Range(-1f, 1f);
		moveDirection.y = UnityEngine.Random.Range(-1f, 1f);
		moveDirection.z = UnityEngine.Random.Range(-1f, 1f);
	}

	private void Update()
	{
		if (orbit)
		{
			base.transform.RotateAround(target.position, moveDirection, speed * Time.deltaTime);
		}
		else
		{
			base.transform.Translate(releaseVelocity * Time.deltaTime, Space.World);
		}
		base.transform.rotation = Quaternion.LookRotation(base.transform.position - previousPosition);
		previousPosition = base.transform.position;
		float num = Vector3.Distance(target.position, base.transform.position);
		if (timer <= 0f)
		{
			if (num > 120f)
			{
				orbit = true;
			}
			else
			{
				if (orbit)
				{
					Release();
				}
				orbit = false;
			}
			timer = 3f;
		}
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
	}

	private void Release()
	{
		Vector3 rhs = base.transform.position - target.position;
		float magnitude = rhs.magnitude;
		Vector3 normalized = Vector3.Cross(moveDirection, rhs).normalized;
		releaseVelocity = magnitude * speed * (MathF.PI / 180f) * normalized;
	}
}
