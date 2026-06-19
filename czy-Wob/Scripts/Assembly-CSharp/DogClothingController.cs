using System.Collections.Generic;
using UnityEngine;

public class DogClothingController : MonoBehaviour
{
	public InventoryItem hat;

	public Transform hatParent;

	public Transform hatTransform;

	public Rigidbody hatAttachmentRB;

	private Joint hatJoint;

	private GameObject currentHat;

	public void Initialize()
	{
		WearHat(hat);
	}

	private void Update()
	{
		CheckHatStatus();
	}

	private void CheckHatStatus()
	{
		if (currentHat != null && (hatJoint == null || hatJoint.connectedBody == null))
		{
			currentHat.transform.SetParent(null);
			IgnoreHatCollisions(ignore: false);
			if (hatJoint != null)
			{
				Object.Destroy(hatJoint);
			}
		}
	}

	public void WearHat(InventoryItem newHat)
	{
		if (!(newHat == null))
		{
			if (currentHat != null)
			{
				Object.Destroy(currentHat);
				currentHat = null;
			}
			currentHat = Object.Instantiate(newHat.itemPrefab);
			currentHat.name = newHat.itemName;
			ObjectRegistration.GetRegistrationScript().AssignID(currentHat, newHat);
			currentHat.transform.localScale = Vector3.one;
			currentHat.transform.parent = hatTransform;
			currentHat.transform.localPosition = Vector3.zero;
			currentHat.transform.localRotation = Quaternion.identity;
			Rigidbody componentInChildren = currentHat.GetComponentInChildren<Rigidbody>();
			hatJoint = hatAttachmentRB.gameObject.AddComponent<FixedJoint>();
			hatJoint.connectedBody = componentInChildren;
			hatJoint.breakForce = 1000f;
			hatJoint.breakTorque = 1000f;
			currentHat.transform.SetParent(hatParent);
			IgnoreHatCollisions();
		}
	}

	private void IgnoreHatCollisions(bool ignore = true)
	{
		List<Collider> list = new List<Collider>();
		list.AddRange(currentHat.GetComponentsInChildren<Collider>());
		IgnoreCollisions(list, base.transform.root, ignore);
	}

	private void IgnoreCollisions(List<Collider> colliderList, Transform t, bool ignore)
	{
		List<Collider> list = new List<Collider>();
		list.AddRange(GetComponents<Collider>());
		list.AddRange(GetComponentsInChildren<Collider>());
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = 0; j < colliderList.Count; j++)
			{
				if (list[i] != colliderList[j])
				{
					Physics.IgnoreCollision(list[i], colliderList[j], ignore);
				}
			}
		}
	}
}
