using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class OOBDestroy : MonoBehaviour
{
	public Transform customReferenceTransform;

	public static Vector3 lowLimit = new Vector3(-10000f, -200f, -10000f);

	public static Vector3 highLimit = new Vector3(10000f, 10000f, 10000f);

	private Transform referenceTransform;

	private bool canDestroy = true;

	private DogRegistration dogRegRef;

	private InventoryManager inventoryRef;

	private void Awake()
	{
		if (customReferenceTransform != null)
		{
			referenceTransform = customReferenceTransform;
			return;
		}
		if (GetComponent<LegController>() != null)
		{
			referenceTransform = GetComponent<LegController>().bodyFront.transform;
		}
		else if (GetComponentInChildren<Rigidbody>() != null)
		{
			referenceTransform = GetComponentInChildren<Rigidbody>().transform;
		}
		else
		{
			referenceTransform = base.transform;
		}
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
	}

	public void SetDestroyFlag(bool flag)
	{
		canDestroy = flag;
	}

	private void Update()
	{
		if (!canDestroy || (!float.IsNaN(referenceTransform.position.x) && !float.IsNaN(referenceTransform.position.y) && !float.IsNaN(referenceTransform.position.z) && referenceTransform.position.x > lowLimit.x && referenceTransform.position.x < highLimit.x && referenceTransform.position.y > lowLimit.y && referenceTransform.position.y < highLimit.y && referenceTransform.position.z > lowLimit.z && referenceTransform.position.z < highLimit.z))
		{
			return;
		}
		bool flag = false;
		if (base.gameObject.CompareTag(Tags.DOG))
		{
			flag = true;
		}
		else
		{
			if (base.gameObject.CompareTag(Tags.EGG))
			{
				base.gameObject.GetComponent<DogEgg>().CollectEgg(immediate: true);
				return;
			}
			if (base.gameObject.CompareTag(Tags.DOG_CORE))
			{
				base.gameObject.GetComponent<RegisterTaggedObject>().SetSafeDestroy();
				inventoryRef.playerInventory.AddDogCoreToInventory(new SaveableDogCore(base.gameObject.GetComponent<DogCore>()));
			}
			else
			{
				ObjectID component = base.gameObject.GetComponent<ObjectID>();
				if (component != null)
				{
					RegisterTaggedObject component2 = base.gameObject.GetComponent<RegisterTaggedObject>();
					if (component2 != null)
					{
						component2.SetSafeDestroy();
					}
					inventoryRef.playerInventory.AddObjectToIventory(component.item);
				}
			}
		}
		if (flag)
		{
			SceneManagerBase globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER, nullAllowed: true);
			if (globalComponent != null)
			{
				if (globalComponent.GetGameMode() == GameMode.BREEDING)
				{
					RespawnDog();
					return;
				}
				if (globalComponent.GetGameMode() == GameMode.HOME)
				{
					RespawnDog(homeScene: true);
					return;
				}
			}
		}
		Object.Destroy(base.gameObject);
	}

	private void RespawnDog(bool homeScene = false)
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		ConstructionManager globalComponent = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		List<GameObject> allRooms = globalComponent.GetAllRooms();
		if (allRooms.Count == 0)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		ulong iDFromDog = dogRegRef.GetIDFromDog(base.gameObject);
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(iDFromDog);
		GameObject room = allRooms[0];
		if (homeScene && saveableDogFromID.roomUID.HasValue)
		{
			GameObject objectForUID = globalComponent.GetObjectForUID(saveableDogFromID.roomUID.Value);
			if (objectForUID != null)
			{
				room = objectForUID;
			}
		}
		bool flag = registrationScript.IsIDTemporary(iDFromDog);
		bool flag2 = inventoryRef.playerInventory.IsDogUIDOwned(iDFromDog);
		if (!homeScene)
		{
			if (flag2 && flag)
			{
				MoveDogBackToCenterOfRoom(room);
				return;
			}
		}
		else if (flag2 && !flag)
		{
			MoveDogBackToCenterOfRoom(room);
			return;
		}
		Object.Destroy(base.gameObject);
	}

	private void MoveDogBackToCenterOfRoom(GameObject room)
	{
		DogDenController component = GetComponent<DogDenController>();
		if (component != null && component.IsInDen())
		{
			component.ExitDen(null, particles: false);
		}
		GameObject bodyFront = GetComponent<LegController>().bodyFront;
		Vector3 vector = DogHome.GetRoomCenter(room) - bodyFront.transform.position;
		ObjectUtil.AllowPhysics(base.gameObject, val: false);
		base.transform.position += vector;
		ObjectUtil.AllowPhysics(base.gameObject, val: true);
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.velocity = Vector3.zero;
			obj.angularVelocity = Vector3.zero;
		}
		BoundingBoxComponent component2 = GetComponent<BoundingBoxComponent>();
		if (component2 != null && !component2.MoveToGoodLocation(room.GetComponent<BuildObjectInfo>().GetUID()))
		{
			Object.Destroy(base.gameObject);
		}
	}
}
