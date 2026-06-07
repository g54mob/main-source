using System;
using UnityEngine;

public class Wobble : MonoBehaviour
{
	private Renderer rend;

	private Vector3 lastPos;

	private Vector3 velocity;

	private Vector3 lastRot;

	private Vector3 angularVelocity;

	public float MaxWobble = 0.03f;

	public float WobbleSpeed = 1f;

	public float Recovery = 1f;

	private float wobbleAmountX;

	private float wobbleAmountZ;

	private float wobbleAmountToAddX;

	private float wobbleAmountToAddZ;

	private float pulse;

	private float time = 0.5f;

	private void Start()
	{
		rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		time += Time.deltaTime;
		wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0f, Time.deltaTime * Recovery);
		wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0f, Time.deltaTime * Recovery);
		pulse = MathF.PI * 2f * WobbleSpeed;
		wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
		wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);
		rend.material.SetFloat("_WobbleX", wobbleAmountX);
		rend.material.SetFloat("_WobbleZ", wobbleAmountZ);
		velocity = (lastPos - base.transform.position) / Time.deltaTime;
		angularVelocity = base.transform.rotation.eulerAngles - lastRot;
		wobbleAmountToAddX += Mathf.Clamp((velocity.x + angularVelocity.z * 0.2f) * MaxWobble, 0f - MaxWobble, MaxWobble);
		wobbleAmountToAddZ += Mathf.Clamp((velocity.z + angularVelocity.x * 0.2f) * MaxWobble, 0f - MaxWobble, MaxWobble);
		lastPos = base.transform.position;
		lastRot = base.transform.rotation.eulerAngles;
	}
}
