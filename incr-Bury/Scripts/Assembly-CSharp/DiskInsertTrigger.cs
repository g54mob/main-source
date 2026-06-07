using UnityEngine;

public class DiskInsertTrigger : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.transform.root.gameObject.CompareTag("PickUp"))
		{
			return;
		}
		try
		{
			PickUppable component = other.transform.root.gameObject.GetComponent<PickUppable>();
			if (component.GetItemIdentity() == ItemIdentity.Disk)
			{
				PcManager.Singleton.InsertDisk(component.gameObject, component);
			}
		}
		catch
		{
			Debug.Log("Failed to find a pickuppable script attached to this object? Weird. Ignoring.");
		}
	}
}
