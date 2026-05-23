using UnityEngine;

public class MoneyFlying : MonoBehaviour
{
	public static int maxMoneyObjects;

	public int value;

	private bool pickedUp;

	private Transform target;

	private float speed;

	public ParticleSystem ps;

	public Color colorTier1;

	public Color colorTier2;

	public Color colorTier3;

	private float currentSize;

	private Vector3 randomDir;

	private float rndSpeed;

	private float rndMaxSpeed;

	private float rndTime;

	private Vector3 lastPosition;

	public void Set(int value, Vector3 pos)
	{
	}

	public void AddValue(int value)
	{
	}

	private void RefreshVisuals()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private float DistancePointToSegment(Vector3 p, Vector3 a, Vector3 b)
	{
		return 0f;
	}

	private void Pickup()
	{
	}
}
