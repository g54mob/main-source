using UnityEngine;

public class DiscreetRotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 axis = Vector3.up;

	[SerializeField]
	private float amount = 45f;

	[SerializeField]
	private float interval = 0.5f;

	private float timeCounter;

	private void Awake()
	{
		timeCounter = 0f;
	}

	private void Update()
	{
		timeCounter += Time.deltaTime;
		if (timeCounter >= interval)
		{
			base.transform.Rotate(axis, amount, Space.Self);
			timeCounter = 0f;
		}
	}
}
