using UnityEngine;

public class PlacedObjectID : MonoBehaviour
{
	private string resourceString;

	private ulong? UID;

	public void SetUID(ulong newID)
	{
		if (UID.HasValue)
		{
			Debug.LogError("Object: " + base.gameObject.name + " already has a UID. Cannot assign it a second time.");
		}
		else
		{
			UID = newID;
		}
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

	public void SetResourceString(string newString)
	{
		resourceString = newString;
	}

	public string GetResourceString()
	{
		return resourceString;
	}
}
