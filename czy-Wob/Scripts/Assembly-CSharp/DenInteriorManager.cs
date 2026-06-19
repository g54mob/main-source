using System.Collections.Generic;
using UnityEngine;

public static class DenInteriorManager
{
	public static List<int> usedIndices = new List<int>();

	public static List<InteriorInfo> interiors = new List<InteriorInfo>();

	private static int interiorCount = 0;

	private static Vector3 spacing = new Vector3(150f, 150f, 150f);

	private static Vector3 startingLocation = new Vector3(0f, 0f, 1000f);

	private static PenFocus penFocusRef;

	private static NavmeshHelper navmeshRef;

	private static DogRegistration dogRegRef;

	public static bool CanBuildNewDenInteriors()
	{
		Vector3 vector = startingLocation + interiorCount * spacing;
		if (vector.x >= OOBDestroy.highLimit.x || vector.y >= OOBDestroy.highLimit.y || vector.z >= OOBDestroy.highLimit.z)
		{
			return false;
		}
		return true;
	}

	public static GameObject CreateDenInterior(GameObject interiorPrefab, ulong denUID, DogDen denRef, int? specificIndex = null)
	{
		AssignMiscRefs();
		if (!CanBuildNewDenInteriors())
		{
			Debug.LogError("Cannot place new den interior! Too many to safely find a location!");
			return null;
		}
		int num = 0;
		if (!specificIndex.HasValue)
		{
			for (int i = 0; i < usedIndices.Count && num == usedIndices[i]; i++)
			{
				num++;
			}
		}
		else
		{
			num = specificIndex.Value;
		}
		Vector3 position = startingLocation + num * spacing;
		GameObject gameObject = Object.Instantiate(interiorPrefab);
		gameObject.transform.position = position;
		gameObject.transform.rotation = denRef.transform.rotation;
		DogDenInterior component = gameObject.GetComponent<DogDenInterior>();
		component.associatedDenUID = denUID;
		component.associatedDenRef = denRef;
		interiors.Add(new InteriorInfo(num, gameObject, denUID));
		usedIndices.Add(num);
		usedIndices.Sort();
		interiorCount = interiors.Count;
		navmeshRef.AddPortalForDen(ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(denUID));
		return gameObject;
	}

	public static void DestroyDenInterior(ulong denUID, BoundingBoxComponent denBBC, bool fromTravel)
	{
		int interiorIndexForDenID = GetInteriorIndexForDenID(denUID);
		if (!fromTravel)
		{
			List<GameObject> allContainedObjects = GetAllContainedObjects(denUID);
			bool flag = false;
			Vector3 value = Vector3.zero;
			if (ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(denUID) != null && denBBC.GetRoomUID().HasValue)
			{
				flag = true;
				value = denBBC.GetBoxCenter();
			}
			for (int i = 0; i < allContainedObjects.Count; i++)
			{
				if (allContainedObjects[i].CompareTag(Tags.EGG))
				{
					allContainedObjects[i].GetComponent<DogEgg>().CollectEgg();
				}
				else if (allContainedObjects[i].CompareTag(Tags.DOG))
				{
					if (flag)
					{
						allContainedObjects[i].GetComponent<DogDenController>().ExitDen(value, particles: false);
					}
					else
					{
						Object.Destroy(allContainedObjects[i]);
					}
				}
				else
				{
					Object.Destroy(allContainedObjects[i]);
				}
			}
			allContainedObjects.Clear();
		}
		usedIndices.Remove(interiors[interiorIndexForDenID].index);
		Object.Destroy(interiors[interiorIndexForDenID].obj);
		interiors.RemoveAt(interiorIndexForDenID);
		interiorCount = interiors.Count;
		navmeshRef.RemovePortalForDenUID(denUID);
	}

	public static List<GameObject> GetAllContainedObjects(ulong denUID, TagsEnum tag = TagsEnum.ALL, bool dogsAllowed = true)
	{
		List<GameObject> list = new List<GameObject>();
		BoundingBoxComponent component = interiors[GetInteriorIndexForDenID(denUID)].obj.GetComponent<BoundingBoxComponent>();
		List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(tag);
		for (int i = 0; i < allObjectsForTag.Count; i++)
		{
			if (!(allObjectsForTag[i] == null) && (dogsAllowed || !allObjectsForTag[i].CompareTag(Tags.DOG)))
			{
				BoundingBoxComponent component2 = allObjectsForTag[i].GetComponent<BoundingBoxComponent>();
				if (component.CheckBoxIntersect(component2))
				{
					list.Add(allObjectsForTag[i]);
				}
			}
		}
		return list;
	}

	public static void EnterDen(GameObject dog, GameObject den, bool fromDogDenController = false)
	{
		if (!fromDogDenController)
		{
			Debug.LogError("You should only call this from DogDenController's EnterDen function!");
		}
		AssignCamRef();
		AssignMiscRefs();
		int interiorIndexForDen = GetInteriorIndexForDen(den);
		GameObject obj = interiors[interiorIndexForDen].obj;
		DogDenInterior component = obj.GetComponent<DogDenInterior>();
		Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
		Vector3 position2 = component.entranceTransform.position;
		Vector3 vector = (position - position2) * -1f;
		ObjectUtil.AllowPhysics(dog, val: false);
		MouthController component2 = dog.GetComponent<MouthController>();
		if (component2 != null && component2.IsCarryingObject() && component2.GetCarriedObject().CompareTag(Tags.COCOON))
		{
			component2.DropObject();
		}
		ObjectConnectionsManager.OnObjectTeleported(dog, vector);
		dog.transform.position += vector;
		BoundingBoxComponent component3 = dog.GetComponent<BoundingBoxComponent>();
		component3.ForceUpdateBoundingBox();
		if (!component3.MoveToGoodLocation(null, null, obj))
		{
			Debug.LogError(string.Concat("Failed to find a good location for dog: ", dog, " to enter its current den."));
			dog.transform.position -= vector;
			component3.ForceUpdateBoundingBox();
			ObjectUtil.AllowPhysics(dog, val: true);
			dog.GetComponent<DogAI>().ForceInterruptBehavior();
			dog.GetComponent<DogDenController>().ExitDen();
			return;
		}
		ObjectUtil.AllowPhysics(dog, val: true);
		penFocusRef.OnDogEnterDen(dog, vector);
		Rigidbody[] componentsInChildren = dog.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj2 in componentsInChildren)
		{
			obj2.velocity = Vector3.zero;
			obj2.angularVelocity = Vector3.zero;
		}
	}

	public static void ExitDen(GameObject dog, GameObject den, Vector3? customExitPos = null, bool fromDogDenController = false)
	{
		if (!fromDogDenController)
		{
			Debug.LogError("You should only call this from DogDenController's ExitDen function!");
		}
		AssignCamRef();
		AssignMiscRefs();
		Vector3 vector = den.GetComponent<InteractibleDogDen>().GetInteractionPointTransform().position;
		if (customExitPos.HasValue)
		{
			vector = customExitPos.Value;
		}
		Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
		Vector3 vector2 = vector;
		ObjectUtil.AllowPhysics(dog, val: false);
		Vector3 vector3 = (position - vector2) * -1f;
		ObjectConnectionsManager.OnObjectTeleported(dog, vector3);
		dog.transform.position += vector3;
		dog.GetComponent<BoundingBoxComponent>().ForceUpdateBoundingBox();
		if (!dog.GetComponent<BoundingBoxComponent>().MoveToGoodLocation())
		{
			Debug.LogError(string.Concat("Failed to find a good location for dog: ", dog, " to exit its current den. Destroying it to prevent issues. Sorry."));
			Object.Destroy(dog);
			return;
		}
		ObjectUtil.AllowPhysics(dog, val: true);
		penFocusRef.OnDogExitDen(dog, vector3);
		Rigidbody[] componentsInChildren = dog.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody obj in componentsInChildren)
		{
			obj.velocity = Vector3.zero;
			obj.angularVelocity = Vector3.zero;
		}
	}

	public static GameObject GetInteriorForDen(GameObject den)
	{
		return interiors[GetInteriorIndexForDen(den)].obj;
	}

	public static GameObject GetInteriorForDenID(ulong denID)
	{
		return interiors[GetInteriorIndexForDenID(denID)].obj;
	}

	public static int GetInteriorIndexForDen(GameObject den)
	{
		return GetInteriorIndexForDenID(den.GetComponent<PlacedObjectID>().GetUID());
	}

	public static int GetInteriorIndexForDenID(ulong denUID)
	{
		for (int i = 0; i < interiorCount; i++)
		{
			if (interiors[i].associatedDenUID == denUID)
			{
				return i;
			}
		}
		Debug.LogError("No interior found.");
		return -1;
	}

	public static void ExpelObjectFromDen(GameObject obj)
	{
		ulong? uIDForDenObjectIsInsideOf = GetUIDForDenObjectIsInsideOf(obj);
		if (uIDForDenObjectIsInsideOf.HasValue)
		{
			DogDen component = ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(uIDForDenObjectIsInsideOf.Value).GetComponent<DogDen>();
			if (obj.CompareTag(Tags.DOG))
			{
				component.ExpelDog(obj);
			}
			else
			{
				component.ExpelObject(obj);
			}
		}
	}

	public static bool IsObjectInsideOfAnyDenInterior(GameObject obj)
	{
		if (GetUIDForDenObjectIsInsideOf(obj).HasValue)
		{
			return true;
		}
		return false;
	}

	public static ulong? GetUIDForDenObjectIsInsideOf(GameObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		BoundingBoxComponent boundingBoxComponent = obj.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = obj.AddComponent<BoundingBoxComponent>();
		}
		return GetUIDForDenBBCIsInsideOf(boundingBoxComponent);
	}

	public static ulong? GetUIDForDenBBCIsInsideOf(BoundingBoxComponent bbc)
	{
		if (bbc == null)
		{
			return null;
		}
		for (int i = 0; i < interiorCount; i++)
		{
			InteriorInfo interiorInfo = interiors[i];
			if (bbc.CheckBoxContained(interiorInfo.bbcRef))
			{
				return interiorInfo.associatedDenUID;
			}
		}
		return null;
	}

	private static void AssignCamRef()
	{
		if (!(penFocusRef != null))
		{
			penFocusRef = Camera.main.GetComponent<PenFocus>();
		}
	}

	public static void ClearRefs()
	{
		penFocusRef = null;
		navmeshRef = null;
		dogRegRef = null;
	}

	private static void AssignMiscRefs()
	{
		if (!(dogRegRef != null))
		{
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			navmeshRef = registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
			dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
	}
}
