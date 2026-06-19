using System.Collections.Generic;
using UnityEngine;

public static class DogDenManager
{
	private static List<ulong> denList = new List<ulong>();

	private static List<ulong> roomsWhereDogsAreClearingArea = new List<ulong>();

	private static ObjectRegistration regRef;

	private static SceneManagerBase sceneRef;

	private static DogRegistration dogRegRef;

	private static ConstructionManager constructionRef;

	private static bool InBreedingCenter()
	{
		if (sceneRef == null)
		{
			sceneRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		}
		return sceneRef.GetGameMode() == GameMode.BREEDING;
	}

	public static ulong? CanDogAccessAnyCompletedDen(ulong dogUID)
	{
		return CanDogAccessAnyDen(dogUID, requireCompleted: true);
	}

	public static ulong? CanDogAccessAndExpandAnyCompletedDen(ulong dogUID)
	{
		return CanDogAccessAnyDen(dogUID, requireCompleted: true, requireIncomplete: false, requireExpandable: true);
	}

	public static ulong? CanDogAccessAndFinalizeAnyDen(ulong dogUID)
	{
		return CanDogAccessAnyDen(dogUID, requireCompleted: false, requireIncomplete: false, requireExpandable: false, requireFinalizable: true);
	}

	public static ulong? CanDogAccessAnyIncompleteDen(ulong dogUID)
	{
		return CanDogAccessAnyDen(dogUID, requireCompleted: false, requireIncomplete: true);
	}

	public static bool CanDogAccessSpecificCompletedDen(ulong dogUID, ulong denUID)
	{
		return CanDogAccessSpecificDen(dogUID, denUID, requireCompleted: true);
	}

	public static bool CanDogAccessSpecificIncompleteDen(ulong dogUID, ulong denUID)
	{
		return CanDogAccessSpecificDen(dogUID, denUID, requireCompleted: false, requireIncomplete: true);
	}

	public static ulong? CanDogAccessAnyDen(ulong dogUID, bool requireCompleted = false, bool requireIncomplete = false, bool requireExpandable = false, bool requireFinalizable = false)
	{
		if (InBreedingCenter())
		{
			return null;
		}
		SaveRefs();
		ulong? uIDForDenObjectIsInsideOf = DenInteriorManager.GetUIDForDenObjectIsInsideOf(dogRegRef.GetDogFromID(dogUID));
		if (uIDForDenObjectIsInsideOf.HasValue && CanDogAccessSpecificDen(dogUID, uIDForDenObjectIsInsideOf.Value, requireCompleted, requireIncomplete, requireExpandable, requireFinalizable))
		{
			return uIDForDenObjectIsInsideOf;
		}
		for (int i = 0; i < denList.Count; i++)
		{
			if (CanDogAccessSpecificDen(dogUID, denList[i], requireCompleted, requireIncomplete, requireExpandable, requireFinalizable))
			{
				return denList[i];
			}
		}
		return null;
	}

	public static bool CanDogAccessSpecificDen(ulong dogUID, ulong denUID, bool requireCompleted = false, bool requireIncomplete = false, bool requireExpandable = false, bool requireFinalizable = false)
	{
		SaveRefs();
		GameObject dogFromID = dogRegRef.GetDogFromID(dogUID);
		if (dogFromID == null)
		{
			return false;
		}
		ulong? num = null;
		GameObject placeableObjectForUID = regRef.GetPlaceableObjectForUID(denUID);
		if (placeableObjectForUID == null)
		{
			return false;
		}
		ulong? uIDForDenObjectIsInsideOf = DenInteriorManager.GetUIDForDenObjectIsInsideOf(dogFromID);
		num = ((uIDForDenObjectIsInsideOf.HasValue && uIDForDenObjectIsInsideOf == denUID) ? placeableObjectForUID.GetComponent<BoundingBoxComponent>().GetRoomUID() : (uIDForDenObjectIsInsideOf.HasValue ? regRef.GetPlaceableObjectForUID(uIDForDenObjectIsInsideOf.Value).GetComponent<BoundingBoxComponent>().GetRoomUID() : dogFromID.GetComponent<BoundingBoxComponent>().GetRoomUID()));
		ulong? roomUID = placeableObjectForUID.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!num.HasValue || !roomUID.HasValue)
		{
			return false;
		}
		DogDen component = placeableObjectForUID.GetComponent<DogDen>();
		bool flag = component.IsCompleted();
		bool flag2 = component.IsExpandable();
		bool flag3 = component.CanFinalize();
		if (requireCompleted && !flag)
		{
			return false;
		}
		if (requireIncomplete && flag)
		{
			return false;
		}
		if (requireExpandable && !flag2)
		{
			return false;
		}
		if (requireFinalizable && !flag3)
		{
			return false;
		}
		return constructionRef.AreRoomsConnected(num.Value, roomUID.Value);
	}

	public static DogDen IsAccessibleDenWaitingFinalization(ulong dogID)
	{
		ulong? num = CanDogAccessAndFinalizeAnyDen(dogID);
		if (!num.HasValue)
		{
			return null;
		}
		SaveRefs();
		return regRef.GetPlaceableObjectForUID(num.Value).GetComponent<DogDen>();
	}

	public static SaveableDogDenManager GetSaveableDogDenManager()
	{
		return new SaveableDogDenManager();
	}

	public static void LoadSavedDogDenManager(SaveableDogDenManager saveData)
	{
		_ = denList.Count;
		_ = 0;
	}

	public static List<ulong> GetAllDens()
	{
		if (InBreedingCenter())
		{
			return new List<ulong>();
		}
		return denList;
	}

	public static List<ulong> GetAllAccessibleIncompleteDens(ulong dogUID)
	{
		List<ulong> list = new List<ulong>();
		if (InBreedingCenter())
		{
			return list;
		}
		for (int i = 0; i < denList.Count; i++)
		{
			if (CanDogAccessSpecificIncompleteDen(dogUID, denList[i]))
			{
				list.Add(denList[i]);
			}
		}
		return list;
	}

	public static void RegisterDen(ulong denID)
	{
		if (denList.Contains(denID))
		{
			Debug.LogError("Attempting to double-register den: " + denID);
		}
		else
		{
			denList.Add(denID);
		}
	}

	public static void RemoveDen(ulong denID)
	{
		if (!denList.Contains(denID))
		{
			Debug.LogError("No den registered for ID: " + denID);
		}
		else
		{
			denList.Remove(denID);
		}
	}

	public static void RegisterDogClearingArea(ulong roomUID)
	{
		if (roomsWhereDogsAreClearingArea.Contains(roomUID))
		{
			Debug.LogError("Attempting to double-register room with den area being cleared: " + roomUID);
		}
		else
		{
			roomsWhereDogsAreClearingArea.Add(roomUID);
		}
	}

	public static void UnregisterDogClearingArea(ulong roomUID)
	{
		if (!roomsWhereDogsAreClearingArea.Contains(roomUID))
		{
			Debug.LogError("Attempting to unregister a room where dog was attempting to clear a den area, but it was not registered: " + roomUID);
		}
		else
		{
			roomsWhereDogsAreClearingArea.Remove(roomUID);
		}
	}

	public static List<DogDen> GetAllAccessibleIncompleteDensInRoom(ulong dogUID, ulong? roomUID)
	{
		List<DogDen> list = new List<DogDen>();
		if (!roomUID.HasValue)
		{
			return list;
		}
		SaveRefs();
		for (int i = 0; i < denList.Count; i++)
		{
			GameObject placeableObjectForUID = regRef.GetPlaceableObjectForUID(denList[i]);
			DogDen component = placeableObjectForUID.GetComponent<DogDen>();
			if (!component.IsCompleted())
			{
				ulong? roomUID2 = placeableObjectForUID.GetComponent<BoundingBoxComponent>().GetRoomUID();
				if (roomUID2.HasValue && roomUID2.Value == roomUID.Value && CanDogAccessSpecificDen(dogUID, denList[i]))
				{
					list.Add(component);
				}
			}
		}
		return list;
	}

	public static bool IsAreaBeingClearedInRoom(ulong? roomUID)
	{
		if (!roomUID.HasValue)
		{
			return false;
		}
		if (roomsWhereDogsAreClearingArea.Contains(roomUID.Value))
		{
			return true;
		}
		return false;
	}

	public static void PrepareForTravel()
	{
		if (regRef == null)
		{
			regRef = ObjectRegistration.GetRegistrationScript();
		}
		for (int i = 0; i < denList.Count; i++)
		{
			DogDen component = regRef.GetPlaceableObjectForUID(denList[i]).GetComponent<DogDen>();
			if (component != null)
			{
				component.MarkForTravel();
			}
		}
		regRef = null;
	}

	private static void SaveRefs()
	{
		if (regRef == null)
		{
			regRef = ObjectRegistration.GetRegistrationScript();
		}
		if (dogRegRef == null)
		{
			dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		}
		if (constructionRef == null)
		{
			constructionRef = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		}
	}
}
