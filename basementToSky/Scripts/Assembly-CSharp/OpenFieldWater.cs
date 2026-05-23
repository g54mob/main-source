using UnityEngine;

public class OpenFieldWater : MonoBehaviour
{
	[SerializeField]
	private GameObject splashPrefab;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((bool)other.attachedRigidbody && other.attachedRigidbody.TryGetComponent<Rocket>(out var _))
		{
			float y = base.transform.position.y;
			Vector3 position = other.transform.position;
			position.y = y;
			Object.Instantiate(splashPrefab, position, Quaternion.identity);
			AudioManager.S.PlayWaterCollisionSound();
		}
	}
}
