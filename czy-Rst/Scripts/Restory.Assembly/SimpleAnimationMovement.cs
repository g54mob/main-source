using UnityEngine;

public class SimpleAnimationMovement : MonoBehaviour
{
	[SerializeField]
	private bool isActive;

	[SerializeField]
	private Vector3 direction = Vector3.up;

	private Vector3 initialPosition;

	private void Awake()
	{
		initialPosition = base.transform.position;
	}

	private void Update()
	{
		if (isActive)
		{
			base.transform.position = initialPosition + direction * Mathf.Sin(Time.realtimeSinceStartup);
		}
	}
}
