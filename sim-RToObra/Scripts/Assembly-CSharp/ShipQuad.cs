using UnityEngine;

public class ShipQuad : MonoBehaviour
{
	private Vector3 startPosition;

	private void Start()
	{
		startPosition = base.transform.position;
	}

	private void Update()
	{
		base.transform.position = new Vector3(startPosition.x, startPosition.y + 0.02f * Mathf.Cos(Clock.play.time), startPosition.z);
	}
}
