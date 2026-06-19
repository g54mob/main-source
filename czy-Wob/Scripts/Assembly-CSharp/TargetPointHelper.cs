using System;
using System.Collections.Generic;
using UnityEngine;

public static class TargetPointHelper
{
	private static float radiusMin = 5f;

	private static float radiusMax = 20f;

	private static float stepAmount = 15f;

	private static float downcastDist = 3f;

	private static float roomWeightModifier = 0.9f;

	private static float denScore = 0.4f;

	private static float denScoreAloof = 0.8f;

	private static float denScoreSocial = 0.1f;

	private static bool debugVis = false;

	private static List<ulong> reusableRoomUIDList = new List<ulong>();

	public static bool TargetGivenPoint(GameObject dog, Transform target, WalkController.TargetReachedCallback callback = null, ReservableObjectType targetReservableType = ReservableObjectType.NONE, bool useLooseFacingOffset = false, bool useSuperLooseFacingOffset = false, bool usePointDirectly = false, bool getClose = false, bool isGroundPosition = false)
	{
		bool usePointDirectly2 = usePointDirectly;
		bool getClose2 = getClose;
		return WalkToGivenPoint(dog, target, needsPath: true, callback, targetReservableType, useLooseFacingOffset, useSuperLooseFacingOffset, destroyTargetAfter: false, isGroundPosition, usePointDirectly2, getClose2);
	}

	public static void TargetRandomConnectedPoint(GameObject dog, WalkController.TargetReachedCallback callback = null)
	{
		Vector3 vector = Vector3.zero;
		float num = UnityEngine.Random.Range(radiusMin, radiusMax);
		while (vector == Vector3.zero)
		{
			vector = FindConnectedPointAtRadiusFromDog(num, dog);
			num /= 2f;
		}
		TargetGivenPosition(dog, vector, callback, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, isGroundPosition: true);
	}

	public static void TargetGivenPosition(GameObject dog, Vector3 position, WalkController.TargetReachedCallback callback = null, bool useLooseFacingOffset = false, bool useSuperLooseFacingOffset = false, bool isGroundPosition = false)
	{
		GameObject gameObject = new GameObject("TempFacingTarget (RandomConnectedPoint) " + dog.name);
		gameObject.transform.position = position;
		WalkToGivenPoint(dog, gameObject.transform, needsPath: true, callback, ReservableObjectType.NONE, useLooseFacingOffset, useSuperLooseFacingOffset, destroyTargetAfter: true, isGroundPosition);
	}

	public static void TargetRoom(GameObject dog, RoomBase room, WalkController.TargetReachedCallback callback, bool specifyRoomType = true)
	{
		GameObject gameObject = new GameObject("TempFacingTarget (TargetRoom) " + dog.name);
		Vector3 roomCenter = room.GetRoomCenter();
		gameObject.transform.position = roomCenter;
		ulong uID = room.GetComponent<BuildObjectInfo>().GetUID();
		WalkController component = dog.GetComponent<WalkController>();
		ulong? targetRoomUID = uID;
		component.SetPathingTarget(gameObject, callback, useLooseOffset: false, targetRoomUID, ReservableObjectType.NONE, useSuperLooseFacingOffset: false, destroyTargetAfter: true);
		dog.GetComponent<LegController>().StartSimulatedWalk();
	}

	public static void TargetExploratoryPoint(GameObject dog, WalkController.TargetReachedCallback callback)
	{
		Debug.LogWarning("TargetExploratoryPoint() does not currently work.");
		callback();
	}

	public static void TargetLowDogTrafficPoint(GameObject dog, WalkController.TargetReachedCallback callback, DogBehaviorBase owningBehavior)
	{
		TargetGivenPosition(dog, FindGoodLowDogTrafficPosition(dog, owningBehavior), callback, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, isGroundPosition: true);
	}

	public static void TargetHighDogTrafficPoint(GameObject dog, WalkController.TargetReachedCallback callback, DogBehaviorBase owningBehavior)
	{
		TargetGivenPosition(dog, FindGoodHighTrafficPosition(dog, owningBehavior), callback, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, isGroundPosition: true);
	}

	public static void TargetIsolatedPoint(GameObject dog, WalkController.TargetReachedCallback callback, DogBehaviorBase owningBehavior, bool densAllowed = true, bool densRequired = false, bool nestEncouraged = false, bool bedroomEncouraged = false)
	{
		RoomBase roomRef = null;
		Vector3 position = FindGoodDogTrafficPosition(dog, ref roomRef, lowTrafficFlag: true, isolationFlag: true, densAllowed, densRequired, nestEncouraged, bedroomEncouraged);
		if (owningBehavior != null && roomRef != null)
		{
			owningBehavior.ReservePositionInRoom(position, roomRef);
		}
		TargetGivenPosition(dog, position, callback, useLooseFacingOffset: false, useSuperLooseFacingOffset: false, isGroundPosition: true);
	}

	private static List<ulong> GetRoomsToConsider(ulong currentRoomUID, List<ulong> consideredRooms, ConstructionManager constructionRef)
	{
		List<ulong> list = new List<ulong>();
		list.AddRange(RoomPathfinder.GetLinkedRooms(currentRoomUID, constructionRef));
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (consideredRooms.Contains(list[num]))
			{
				list.Remove(list[num]);
			}
		}
		return list;
	}

	private static Vector3 FindGoodHighTrafficPosition(GameObject dog, DogBehaviorBase owningBehavior)
	{
		RoomBase roomRef = null;
		Vector3 vector = FindGoodDogTrafficPosition(dog, ref roomRef, lowTrafficFlag: false);
		if (owningBehavior != null && roomRef != null)
		{
			owningBehavior.ReservePositionInRoom(vector, roomRef);
		}
		return vector;
	}

	private static Vector3 FindGoodLowDogTrafficPosition(GameObject dog, DogBehaviorBase owningBehavior)
	{
		RoomBase roomRef = null;
		Vector3 vector = FindGoodDogTrafficPosition(dog, ref roomRef, lowTrafficFlag: true);
		if (owningBehavior != null && roomRef != null)
		{
			owningBehavior.ReservePositionInRoom(vector, roomRef);
		}
		return vector;
	}

	private static Vector3 FindGoodDogTrafficPosition(GameObject dog, ref RoomBase roomRef, bool lowTrafficFlag, bool isolationFlag = false, bool densAllowed = true, bool densRequired = false, bool nestEncouraged = false, bool bedroomEncouraged = false)
	{
		Vector3 position = dog.GetComponent<LegController>().bodyFront.transform.position;
		Vector3 vector = position;
		DogDenController component = dog.GetComponent<DogDenController>();
		SocialPersonalityType socialPersonality = dog.GetComponent<DoggyBrain>().GetPersonality().GetSocialPersonality();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		NavmeshHelper globalComponent = registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
		ConstructionManager globalComponent2 = registrationScript.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		ulong? currentlyOccupiedDen = component.GetCurrentlyOccupiedDen();
		ulong? roomUID = dog.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue && currentlyOccupiedDen.HasValue)
		{
			roomUID = registrationScript.GetPlaceableObjectForUID(currentlyOccupiedDen.Value).GetComponent<BoundingBoxComponent>().GetRoomUID();
		}
		if (!roomUID.HasValue)
		{
			dog.GetComponent<DogAI>().ForceInterruptBehavior();
			return position;
		}
		List<bool> list = new List<bool>();
		List<float> list2 = new List<float>();
		List<ulong> list3 = new List<ulong>();
		reusableRoomUIDList.Clear();
		reusableRoomUIDList.AddRange(globalComponent2.GetAllRoomIDsExplicitRef());
		for (int i = 0; i < reusableRoomUIDList.Count; i++)
		{
			if (densRequired)
			{
				continue;
			}
			ulong num = reusableRoomUIDList[i];
			RoomBase component2 = globalComponent2.GetObjectForUID(num).GetComponent<RoomBase>();
			if (num == roomUID.Value && !isolationFlag && component2.GetNumberOfDogsInRoom() == 1)
			{
				if (lowTrafficFlag)
				{
					return position;
				}
				continue;
			}
			float num2 = 0f;
			if (isolationFlag)
			{
				float isolationScore = component2.GetIsolationScore();
				if (isolationScore <= 0f)
				{
					continue;
				}
				num2 = isolationScore;
			}
			else
			{
				num2 = component2.GetDogTrafficScore();
				if (num2 >= 1f && lowTrafficFlag)
				{
					continue;
				}
				if (lowTrafficFlag)
				{
					num2 = 1f - num2;
				}
			}
			float num3 = RoomPathfinder.EstimatePathDistance(roomUID.Value, num, globalComponent2);
			if (num3 != -1f && (num3 != 0f || roomUID.Value == num))
			{
				if (num3 > 0f)
				{
					num3 -= 1f;
				}
				list.Add(item: true);
				list3.Add(num);
				list2.Add(num2 * Mathf.Pow(roomWeightModifier, num3));
			}
		}
		ulong? currentlyOccupiedDen2 = dog.GetComponent<DogDenController>().GetCurrentlyOccupiedDen();
		List<ulong> allDens = DogDenManager.GetAllDens();
		for (int j = 0; j < allDens.Count; j++)
		{
			if (!densAllowed || (!lowTrafficFlag && !isolationFlag))
			{
				continue;
			}
			ulong num4 = allDens[j];
			GameObject placeableObjectForUID = registrationScript.GetPlaceableObjectForUID(num4);
			if (placeableObjectForUID == null)
			{
				continue;
			}
			DogDen component3 = placeableObjectForUID.GetComponent<DogDen>();
			if (!component3.IsCompleted() || ((!currentlyOccupiedDen.HasValue || currentlyOccupiedDen.Value != num4) && !component3.CanAddOccupant()))
			{
				continue;
			}
			ulong? roomUID2 = component3.GetComponent<BoundingBoxComponent>().GetRoomUID();
			if (currentlyOccupiedDen2.HasValue && num4 == currentlyOccupiedDen2 && !nestEncouraged && !bedroomEncouraged)
			{
				return position;
			}
			float num5 = RoomPathfinder.EstimatePathDistance(roomUID, roomUID2, globalComponent2);
			if (num5 == -1f || (num5 == 0f && roomUID.Value != roomUID2))
			{
				continue;
			}
			Vector3 point = component3.GetComponent<InteractibleDogDen>().GetInteractionPoint();
			if (globalComponent.GetNearestPointOnNavmesh(ref point) && globalComponent.GetPath(dog, point).Length != 0)
			{
				if (num5 > 0f)
				{
					num5 -= 1f;
				}
				list.Add(item: false);
				list3.Add(num4);
				float num6 = denScore;
				switch (socialPersonality)
				{
				case SocialPersonalityType.ALOOF:
					num6 = denScoreAloof;
					break;
				case SocialPersonalityType.SOCIAL:
					num6 = denScoreSocial;
					break;
				}
				list2.Add(num6 * Mathf.Pow(roomWeightModifier, num5));
			}
		}
		if (list2.Count == 0)
		{
			dog.GetComponent<DogAI>().ForceInterruptBehavior();
			return position;
		}
		while (list3.Count > 0)
		{
			int index = -1;
			ulong weightedRandom = ListUtil.GetWeightedRandom(list3, list2, ref index);
			if (!list[index])
			{
				DogDenInterior component4 = DenInteriorManager.GetInteriorForDenID(weightedRandom).GetComponent<DogDenInterior>();
				vector = component4.mainRoomTargetTransform.position;
				if (nestEncouraged && component4.DoesDenHaveExpansionType(ExpansionType.NEST))
				{
					vector = component4.GetExpansionTypeTarget(ExpansionType.NEST);
				}
				else if (bedroomEncouraged && component4.DoesDenHaveExpansionType(ExpansionType.BEDROOM))
				{
					vector = component4.GetExpansionTypeTarget(ExpansionType.BEDROOM);
				}
				if (globalComponent.GetNearestPointOnNavmesh(ref vector) && globalComponent.GetPath(dog, vector).Length != 0)
				{
					return vector;
				}
				list.RemoveAt(index);
				list2.RemoveAt(index);
				list3.RemoveAt(index);
				continue;
			}
			roomRef = globalComponent2.GetObjectForUID(weightedRandom).GetComponent<RoomBase>();
			List<float> list4 = new List<float>();
			List<Vector3> list5;
			if (isolationFlag)
			{
				list5 = roomRef.GetGroundIsolationPositions(list4);
				for (int k = 0; k < list5.Count; k++)
				{
					list4[k] /= Vector3.Distance(position, list5[k]);
				}
			}
			else
			{
				list5 = roomRef.GetGroundNoTrafficPoints();
				for (int l = 0; l < list5.Count; l++)
				{
					list4.Add(1f);
				}
			}
			while (list5.Count > 0)
			{
				int index2 = 0;
				vector = ListUtil.GetWeightedRandom(list5, list4, ref index2);
				if (globalComponent.GetNearestPointOnNavmesh(ref vector) && globalComponent.GetPath(dog, vector).Length != 0)
				{
					return vector;
				}
				list4.RemoveAt(index2);
				list5.RemoveAt(index2);
			}
			list.RemoveAt(index);
			list2.RemoveAt(index);
			list3.RemoveAt(index);
		}
		return position;
	}

	private static bool WalkToGivenPoint(GameObject dog, Transform target, bool needsPath = true, WalkController.TargetReachedCallback callback = null, ReservableObjectType targetReservableType = ReservableObjectType.NONE, bool useLooseFacingOffset = false, bool useSuperLooseFacingOffset = false, bool destroyTargetAfter = false, bool isGroundPosition = false, bool usePointDirectly = false, bool getClose = false)
	{
		bool result = true;
		if (needsPath)
		{
			result = dog.GetComponent<WalkController>().SetPathingTarget(target.gameObject, callback, useLooseFacingOffset, null, targetReservableType, useSuperLooseFacingOffset, destroyTargetAfter, isGroundPosition, usePointDirectly, getClose);
		}
		else
		{
			if (targetReservableType != ReservableObjectType.NONE)
			{
				Debug.LogError("Reservable type might be getting lost here.");
			}
			dog.GetComponent<WalkController>().SetFacingTarget(target, callback, useLooseFacingOffset, useSuperLooseFacingOffset, destroyTargetAfter);
		}
		dog.GetComponent<LegController>().StartSimulatedWalk();
		return result;
	}

	private static Vector3 FindConnectedPointAtRadiusFromDog(float radius, GameObject dog)
	{
		Vector3 position = dog.GetComponent<LegController>().internalFacingObj.transform.position;
		if (radius < 1f)
		{
			return position;
		}
		float num = 0f;
		float num2 = UnityEngine.Random.Range(0, 360);
		Vector3 zero = Vector3.zero;
		while (num < 360f)
		{
			zero = new Vector3(position.x + radius * Mathf.Cos((float)Math.PI / 180f * num2), position.y, position.z + radius * Mathf.Sin((float)Math.PI / 180f * num2));
			if (!RaycastUtil.StageRaycast(position, zero - position, radius))
			{
				if (RaycastUtil.StageRaycast(zero, Vector3.down, downcastDist))
				{
					if (debugVis)
					{
						Debug.DrawRay(zero, Vector3.down, Color.green, 5f);
					}
					return zero;
				}
				if (debugVis)
				{
					Debug.DrawRay(zero, Vector3.down, Color.blue, 5f);
				}
			}
			else if (debugVis)
			{
				Debug.DrawRay(zero, Vector3.down, Color.red, 5f);
			}
			num += stepAmount;
			num2 += stepAmount;
		}
		return Vector3.zero;
	}
}
