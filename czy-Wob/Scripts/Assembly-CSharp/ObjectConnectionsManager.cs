using System.Collections.Generic;
using UnityEngine;

public static class ObjectConnectionsManager
{
	public static Dictionary<ulong, List<ulong>> dogToGrabbedObjectsMap = new Dictionary<ulong, List<ulong>>();

	public static Dictionary<ulong, List<ulong>> objectToDogsGrabbingMap = new Dictionary<ulong, List<ulong>>();

	public static Dictionary<ulong, ulong> dogToConsumedObjectMap = new Dictionary<ulong, ulong>();

	public static Dictionary<ulong, ulong> consumedObjectToDogMap = new Dictionary<ulong, ulong>();

	public static Dictionary<ulong, List<ulong>> objectToAttachedCocoonsMap = new Dictionary<ulong, List<ulong>>();

	public static Dictionary<ulong, List<ulong>> cocoonToObjectAttachmentsMap = new Dictionary<ulong, List<ulong>>();

	public static void OnObjectGrabbedByDog(GameObject dog, GameObject obj)
	{
		if (!(obj == null) && !(obj.GetComponent<ObjectID>() == null))
		{
			ulong uID = dog.GetComponent<ObjectID>().GetUID();
			ulong uID2 = obj.GetComponent<ObjectID>().GetUID();
			OnObjectGrabbedByDog(uID, uID2);
		}
	}

	public static void OnObjectGrabbedByDog(ulong dogID, ulong objID)
	{
		if (!dogToGrabbedObjectsMap.ContainsKey(dogID))
		{
			dogToGrabbedObjectsMap[dogID] = new List<ulong>();
		}
		if (!objectToDogsGrabbingMap.ContainsKey(objID))
		{
			objectToDogsGrabbingMap[objID] = new List<ulong>();
		}
		if (dogToGrabbedObjectsMap[dogID].Contains(objID))
		{
			Debug.LogError("Dog: " + dogID + " attempting to double-grab object: " + objID);
		}
		else
		{
			dogToGrabbedObjectsMap[dogID].Add(objID);
			objectToDogsGrabbingMap[objID].Add(dogID);
		}
	}

	public static void OnObjectDroppedByDog(GameObject dog, GameObject obj)
	{
		if (!(obj == null) && !(obj.GetComponent<ObjectID>() == null))
		{
			ulong uID = dog.GetComponent<ObjectID>().GetUID();
			ulong uID2 = obj.GetComponent<ObjectID>().GetUID();
			OnObjectDroppedByDog(uID, uID2);
		}
	}

	public static void OnObjectDroppedByDog(ulong dogID, ulong objID)
	{
		if (!dogToGrabbedObjectsMap.ContainsKey(dogID) || !dogToGrabbedObjectsMap[dogID].Contains(objID))
		{
			Debug.LogError("Dog: " + dogID + " attempting to drop object: " + objID + " but it doesn't seem to be recorded as grabbed.");
		}
		else
		{
			dogToGrabbedObjectsMap[dogID].Remove(objID);
			objectToDogsGrabbingMap[objID].Remove(dogID);
		}
	}

	public static bool IsObjectBeingGrabbedByAnyDog(GameObject obj)
	{
		if (obj == null || obj.GetComponent<ObjectID>() == null)
		{
			return false;
		}
		return IsObjectBeingGrabbedByAnyDog(obj.GetComponent<ObjectID>().GetUID());
	}

	public static bool IsObjectBeingGrabbedByAnyDog(ulong objID)
	{
		if (objectToDogsGrabbingMap.ContainsKey(objID))
		{
			return objectToDogsGrabbingMap[objID].Count > 0;
		}
		return false;
	}

	public static bool IsObjectConsumedByAnyGhost(GameObject obj)
	{
		if (obj == null || obj.GetComponent<ObjectID>() == null)
		{
			return false;
		}
		ulong uID = obj.GetComponent<ObjectID>().GetUID();
		return consumedObjectToDogMap.ContainsKey(uID);
	}

	public static void OnObjectConsumedByGhost(GameObject dog, GameObject obj)
	{
		if (!(obj == null) && !(obj.GetComponent<ObjectID>() == null))
		{
			ulong uID = dog.GetComponent<ObjectID>().GetUID();
			ulong uID2 = obj.GetComponent<ObjectID>().GetUID();
			OnObjectConsumedByGhost(uID, uID2);
		}
	}

	public static void OnObjectConsumedByGhost(ulong dogID, ulong objID)
	{
		if (dogToConsumedObjectMap.ContainsKey(dogID) || consumedObjectToDogMap.ContainsKey(objID))
		{
			Debug.LogError("Dog: " + dogID + " attempting to double-consume object: " + objID);
		}
		else
		{
			dogToConsumedObjectMap[dogID] = objID;
			consumedObjectToDogMap[objID] = dogID;
		}
	}

	public static void OnConsumedObjectDroppedByGhost(GameObject dog, GameObject obj)
	{
		if (!(obj == null) && !(obj.GetComponent<ObjectID>() == null))
		{
			ulong uID = dog.GetComponent<ObjectID>().GetUID();
			ulong uID2 = obj.GetComponent<ObjectID>().GetUID();
			OnConsumedObjectDroppedByGhost(uID, uID2);
		}
	}

	public static void OnConsumedObjectDroppedByGhost(ulong dogID, ulong objID)
	{
		if (dogToConsumedObjectMap.ContainsKey(dogID))
		{
			dogToConsumedObjectMap.Remove(dogID);
			consumedObjectToDogMap.Remove(objID);
		}
	}

	public static void OnCocoonAttachedToObject(GameObject cocoon, GameObject obj)
	{
		ulong uID = obj.GetComponent<ObjectID>().GetUID();
		OnCocoonAttachedToObject(cocoon.GetComponent<ObjectID>().GetUID(), uID);
	}

	public static void OnCocoonAttachedToObject(ulong cocoonID, ulong objID)
	{
		if (!cocoonToObjectAttachmentsMap.ContainsKey(cocoonID))
		{
			cocoonToObjectAttachmentsMap[cocoonID] = new List<ulong>();
		}
		if (!objectToAttachedCocoonsMap.ContainsKey(objID))
		{
			objectToAttachedCocoonsMap[objID] = new List<ulong>();
		}
		if (cocoonToObjectAttachmentsMap[cocoonID].Contains(objID))
		{
			Debug.LogError("Attempting to double-attach cocoon " + cocoonID + " to object: " + objID);
		}
		else
		{
			objectToAttachedCocoonsMap[objID].Add(cocoonID);
			cocoonToObjectAttachmentsMap[cocoonID].Add(objID);
		}
	}

	public static void OnCocoonDisattachedFromObject(GameObject cocoon, GameObject obj)
	{
		ulong uID = obj.GetComponent<ObjectID>().GetUID();
		OnCocoonDisattachedFromObject(cocoon.GetComponent<ObjectID>().GetUID(), uID);
	}

	public static void OnCocoonDisattachedFromObject(ulong cocoonID, ulong objID)
	{
		if (!cocoonToObjectAttachmentsMap.ContainsKey(cocoonID) || !cocoonToObjectAttachmentsMap[cocoonID].Contains(objID))
		{
			Debug.LogError("Attempting to unattach cocoon: " + cocoonID + " from object: " + objID + " but it doesn't seem to be recorded as attached.");
		}
		else
		{
			objectToAttachedCocoonsMap[objID].Remove(cocoonID);
			cocoonToObjectAttachmentsMap[cocoonID].Remove(objID);
		}
	}

	public static void OnObjectDestroyed(GameObject obj)
	{
		ulong uID = obj.GetComponent<ObjectID>().GetUID();
		if (dogToGrabbedObjectsMap.ContainsKey(uID))
		{
			for (int i = 0; i < dogToGrabbedObjectsMap[uID].Count; i++)
			{
				OnObjectDroppedByDog(uID, dogToGrabbedObjectsMap[uID][i]);
			}
		}
		if (objectToDogsGrabbingMap.ContainsKey(uID))
		{
			for (int j = 0; j < objectToDogsGrabbingMap[uID].Count; j++)
			{
				OnObjectDroppedByDog(objectToDogsGrabbingMap[uID][j], uID);
			}
		}
		if (dogToConsumedObjectMap.ContainsKey(uID))
		{
			OnConsumedObjectDroppedByGhost(uID, dogToConsumedObjectMap[uID]);
		}
		if (consumedObjectToDogMap.ContainsKey(uID))
		{
			OnConsumedObjectDroppedByGhost(consumedObjectToDogMap[uID], uID);
		}
		if (cocoonToObjectAttachmentsMap.ContainsKey(uID))
		{
			for (int k = 0; k < cocoonToObjectAttachmentsMap[uID].Count; k++)
			{
				OnCocoonDisattachedFromObject(uID, cocoonToObjectAttachmentsMap[uID][k]);
			}
		}
		if (objectToAttachedCocoonsMap.ContainsKey(uID))
		{
			for (int l = 0; l < objectToAttachedCocoonsMap[uID].Count; l++)
			{
				OnCocoonDisattachedFromObject(objectToAttachedCocoonsMap[uID][l], uID);
			}
		}
	}

	public static void OnObjectTeleported(GameObject obj, Vector3 mov, List<ulong> processedObjects = null)
	{
		if (obj == null)
		{
			return;
		}
		if (processedObjects == null)
		{
			processedObjects = new List<ulong>();
		}
		ObjectID component = obj.GetComponent<ObjectID>();
		if (component == null)
		{
			return;
		}
		ulong uID = component.GetUID();
		ObjectGrabber globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		if (globalComponent != null)
		{
			GameObject grabbedObject = globalComponent.GetGrabbedObject();
			if (grabbedObject != null)
			{
				ObjectID component2 = grabbedObject.GetComponent<ObjectID>();
				if (component2 != null && component2.GetUID() == uID)
				{
					globalComponent.DropObject();
				}
			}
		}
		if (processedObjects.Contains(uID))
		{
			Debug.LogError("Attempting to double-process object: " + obj);
			return;
		}
		processedObjects.Add(uID);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		DogRegistration globalComponent2 = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		if (obj.CompareTag(Tags.DOG))
		{
			TurnInPlace component3 = obj.GetComponent<TurnInPlace>();
			component3.LockPlantedTurnsFromTeleport();
			component3.RequestStop(forceDone: true);
			obj.GetComponent<LegController>().UnplantLegs();
		}
		if (objectToDogsGrabbingMap.ContainsKey(uID))
		{
			for (int i = 0; i < objectToDogsGrabbingMap[uID].Count; i++)
			{
				if (!processedObjects.Contains(objectToDogsGrabbingMap[uID][i]))
				{
					globalComponent2.GetDogFromID(objectToDogsGrabbingMap[uID][i]).GetComponent<MouthController>().DropObject();
				}
			}
		}
		if (consumedObjectToDogMap.ContainsKey(uID) && !processedObjects.Contains(consumedObjectToDogMap[uID]))
		{
			globalComponent2.GetDogFromID(consumedObjectToDogMap[uID]).GetComponent<GhostEatBehavior>().DropEatenObject();
		}
		if (cocoonToObjectAttachmentsMap.ContainsKey(uID) && cocoonToObjectAttachmentsMap[uID].Count > 0)
		{
			obj.GetComponent<Cocoon>().Disattach();
		}
		if (objectToAttachedCocoonsMap.ContainsKey(uID))
		{
			for (int j = 0; j < objectToAttachedCocoonsMap[uID].Count; j++)
			{
				registrationScript.GetObjectForUID(objectToAttachedCocoonsMap[uID][j]).GetComponent<Cocoon>().Disattach();
			}
		}
		if (dogToGrabbedObjectsMap.ContainsKey(uID))
		{
			for (int num = dogToGrabbedObjectsMap[uID].Count - 1; num >= 0; num--)
			{
				if (!processedObjects.Contains(dogToGrabbedObjectsMap[uID][num]))
				{
					ulong num2 = dogToGrabbedObjectsMap[uID][num];
					GameObject objectForUID = registrationScript.GetObjectForUID(num2);
					if (objectForUID == null)
					{
						dogToGrabbedObjectsMap[uID].Remove(num2);
						objectToDogsGrabbingMap[num2].Remove(uID);
					}
					else if (objectForUID.CompareTag(Tags.DOG))
					{
						obj.GetComponent<MouthController>().DropObject();
					}
					else
					{
						OnObjectTeleported(objectForUID, mov, processedObjects);
						objectForUID.transform.position += mov;
					}
				}
			}
		}
		if (dogToConsumedObjectMap.ContainsKey(uID) && !processedObjects.Contains(dogToConsumedObjectMap[uID]))
		{
			ulong num3 = dogToConsumedObjectMap[uID];
			GameObject objectForUID2 = registrationScript.GetObjectForUID(num3);
			if (objectForUID2 == null)
			{
				dogToConsumedObjectMap.Remove(uID);
				consumedObjectToDogMap.Remove(num3);
			}
			else if (objectForUID2.CompareTag(Tags.DOG))
			{
				Debug.LogError("Somehow ended up in a situation where a dog has consumed another dog. This shouldn't be possible!");
				obj.GetComponent<GhostEatBehavior>().DropEatenObject();
			}
			else
			{
				OnObjectTeleported(objectForUID2, mov, processedObjects);
				objectForUID2.transform.position += mov;
			}
		}
	}
}
