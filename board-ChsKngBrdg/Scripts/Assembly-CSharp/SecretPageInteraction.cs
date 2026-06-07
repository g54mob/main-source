using UnityEngine;

public class SecretPageInteraction : MonoBehaviour
{
	[SerializeField]
	private Transform playerTransform;

	private void Update()
	{
		base.transform.position = playerTransform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		SecretPageObject component = collision.GetComponent<SecretPageObject>();
		if (component != null)
		{
			component.SetIsInteractible(state: true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		SecretPageObject component = other.GetComponent<SecretPageObject>();
		if (component != null)
		{
			component.SetIsInteractible(state: false);
		}
	}
}
