using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
	[SerializeField]
	private GameObject teleLocation;

	private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.CompareTag("Player"))
		{
			return;
		}
		try
		{
			NetworkObject component = other.gameObject.GetComponent<NetworkObject>();
			if (component.IsOwner)
			{
				component.gameObject.GetComponent<NetworkTransform>().Teleport(teleLocation.transform.position, teleLocation.transform.rotation, component.gameObject.transform.localScale);
			}
		}
		catch
		{
			Debug.Log("Teleported ran into an issue, ignoring.");
		}
	}
}
