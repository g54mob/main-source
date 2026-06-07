using UnityEngine;

public class ShakeObject : MonoBehaviour
{
	[SerializeField]
	private bool shouldShake = true;

	[SerializeField]
	private Vector3 frequency;

	[SerializeField]
	private Vector3 amplitude;

	private Vector3 initialPosition;

	private void Awake()
	{
		initialPosition = base.transform.position;
	}

	private void FixedUpdate()
	{
		if (shouldShake)
		{
			float x = initialPosition.x + Mathf.Sin(Time.time * frequency.x) * amplitude.x;
			float y = initialPosition.y + Mathf.Sin(Time.time * frequency.y) * amplitude.y;
			float z = initialPosition.z + Mathf.Sin(Time.time * frequency.z) * amplitude.z;
			base.transform.position = new Vector3(x, y, z);
		}
	}
}
