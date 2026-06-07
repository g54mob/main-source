using Mirror;
using UnityEngine;

public class T_ForkliftAttach : MonoBehaviour
{
	[SerializeField]
	private string attachTag = "Activator";

	[SerializeField]
	private T_Forklift forklift;

	private void Awake()
	{
		if (forklift == null)
		{
			forklift = GetComponentInParent<T_Forklift>();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (forklift == null || !other.CompareTag(attachTag))
		{
			return;
		}
		NetworkIdentity networkIdentity = other.GetComponentInParent<NetworkIdentity>();
		if (networkIdentity == null)
		{
			networkIdentity = other.transform.root.GetComponent<NetworkIdentity>();
		}
		if (networkIdentity == null)
		{
			Debug.LogWarning("[T_ForkliftAttach] NetworkIdentity bulunamadı. Collider: " + other.name + ", root: " + other.transform.root.name);
			return;
		}
		BuildingObject component = networkIdentity.GetComponent<BuildingObject>();
		if (!(component != null) || component.IsPlaced)
		{
			forklift.SetCandidatePallet(networkIdentity);
			forklift.NotifyLocalPalletEnter(networkIdentity);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (!(forklift == null) && other.CompareTag(attachTag))
		{
			NetworkIdentity networkIdentity = other.GetComponentInParent<NetworkIdentity>();
			if (networkIdentity == null)
			{
				networkIdentity = other.transform.root.GetComponent<NetworkIdentity>();
			}
			if (!(networkIdentity == null))
			{
				forklift.ClearCandidatePallet(networkIdentity);
				forklift.NotifyLocalPalletExit(networkIdentity);
			}
		}
	}
}
