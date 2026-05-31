using UnityEngine;

public class SubEffectsScript : MonoBehaviour
{
	public Transform FakeSub;

	public BoxCollider ProxRight;

	public BoxCollider ProxLeft;

	public BoxCollider ProxUp;

	public BoxCollider ProxDown;

	private float MyProxTime;

	private void Start()
	{
	}

	private void Update()
	{
		MyProxTime -= Time.deltaTime;
		if (MyProxTime <= 0f)
		{
			ProxRight.enabled = false;
			ProxLeft.enabled = false;
			ProxUp.enabled = false;
			ProxDown.enabled = false;
			MyProxTime = 0f;
		}
	}

	private void FixedUpdate()
	{
		base.transform.position = FakeSub.position;
	}

	public void SetProx(float time, int sensor)
	{
		MyProxTime = time;
		if (sensor == 0)
		{
			ProxUp.enabled = true;
		}
		if (sensor == 1)
		{
			ProxRight.enabled = true;
		}
		if (sensor == 2)
		{
			ProxDown.enabled = true;
		}
		if (sensor == 3)
		{
			ProxLeft.enabled = true;
		}
	}
}
