using UnityEngine;

public class ObjectUnparenter : MonoBehaviour
{
	public InventoryItem itemType;

	private void Awake()
	{
		if (itemType != null)
		{
			ObjectRegistration.GetRegistrationScript().AssignID(base.gameObject, itemType);
		}
		base.transform.SetParent(null);
		Object.Destroy(this);
	}
}
