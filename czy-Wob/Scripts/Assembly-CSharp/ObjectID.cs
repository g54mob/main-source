using UnityEngine;

public class ObjectID : MonoBehaviour
{
	private ulong? UID;

	public InventoryItem item;

	private void OnDestroy()
	{
		ObjectRegistration.GetRegistrationScript().UnregisterID(UID.Value);
		if (base.gameObject.CompareTag(Tags.DOG))
		{
			DogRegistration globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
			if (globalComponent != null)
			{
				globalComponent.OnDogDestroyed(UID.Value);
			}
		}
		ObjectConnectionsManager.OnObjectDestroyed(base.gameObject);
	}

	public void SetUID(ulong newID)
	{
		if (UID.HasValue)
		{
			Debug.LogError("Object: " + base.gameObject.name + " already has a UID. Cannot assign it a second time.");
			return;
		}
		UID = newID;
		ObjectRegistration.GetRegistrationScript().RegisterID(UID.Value, base.gameObject);
	}

	public ulong GetUID()
	{
		if (!UID.HasValue)
		{
			Debug.LogError("Object: " + base.gameObject.name + " does not have a UID. Cannot view it.");
			return 0uL;
		}
		return UID.Value;
	}
}
