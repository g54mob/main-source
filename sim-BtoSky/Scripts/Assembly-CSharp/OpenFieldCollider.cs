using UnityEngine;

public class OpenFieldCollider : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			GameManager.S.PlayerTryGetOut();
		}
	}
}
