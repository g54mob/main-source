using System.Collections.Generic;
using System.Linq;
using ClockStone;
using UnityEngine;

public class DogDenController : MonoBehaviour
{
	public delegate void ScratchFinishedCallback();

	private ScratchFinishedCallback currentCallback;

	public RoomCustomizationObject dogDen;

	public RoomCustomizationObject hole;

	public GameObject diggingParticles;

	public GameObject diggingParticlesSnow;

	public GameObject clearedAreaParticles;

	public GameObject clearedAreaParticlesSnow;

	public GameObject dogEnterParticleEffects;

	public GameObject dogExitParticleEffects;

	private bool isScratching;

	private float scratchTimer = 10f;

	private float currentTimer;

	private float baseRoomScoreForDen = 1f;

	private float aloofDogNearbyDenMultiplier = 0.25f;

	private float socialDogNearbyDenMultiplier = 1.5f;

	private float cornerScore = 10f;

	private float backWallScore = 5f;

	private float leftRightWallScore = 1f;

	private float noWallScore = 0.01f;

	private int minDogRoutingSpace = 3;

	private float scratchAnimationTimer;

	private Vector3 scratchVector;

	private List<GameObject> frontLeftFeet = new List<GameObject>();

	private List<GameObject> frontRightFeet = new List<GameObject>();

	private List<GameObject> digBoardsLeft = new List<GameObject>();

	private List<GameObject> digBoardsRight = new List<GameObject>();

	private List<ConfigurableJoint> leftFootJoints = new List<ConfigurableJoint>();

	private List<ConfigurableJoint> rightFootJoints = new List<ConfigurableJoint>();

	private DogDen currentlyOccupiedDen;

	private string digSound = "dig_loop";

	private string holeCreateSound = "create_hole";

	private string dirtPatchCreateSound = "create_dirtPatch";

	private string exitDenSound = "den_exit";

	private string enterDenSound = "den_enter";

	private AudioObject digAudioObject;

	private FaceController faceRef;

	private BoundingBoxComponent bbc;

	private NavmeshHelper navmeshRef;

	private DogRegistration dogRegRef;

	private ObjectRegistration regRef;

	private LegController controllerRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		bbc = GetComponent<BoundingBoxComponent>();
		if (bbc == null)
		{
			bbc = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
		faceRef = base.gameObject.GetComponent<FaceController>();
		controllerRef = base.gameObject.GetComponent<LegController>();
		regRef = ObjectRegistration.GetRegistrationScript();
		navmeshRef = regRef.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
		dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		constructionRef = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
	}

	private void OnDestroy()
	{
		if (currentlyOccupiedDen != null)
		{
			currentlyOccupiedDen.RemoveOccupant(dogRegRef.GetIDFromDog(base.gameObject));
			currentlyOccupiedDen = null;
		}
	}

	private void FixedUpdate()
	{
		if (isScratching)
		{
			UpdateScratch();
		}
	}

	public bool CanDigHole(RoomBase roomRef, Vector2Int gridPos)
	{
		Vector3 chosenPosition = Vector3.zero;
		return ObjectPlacementManager.CanReserveSpaceForObject(roomRef, hole, gridPos, ref chosenPosition);
	}

	public void ReserveHoleArea()
	{
		ulong? roomUID = bbc.GetRoomUID(requireInRoom: true);
		if (!roomUID.HasValue)
		{
			ulong? uIDForDenObjectIsInsideOf = DenInteriorManager.GetUIDForDenObjectIsInsideOf(base.gameObject);
			if (uIDForDenObjectIsInsideOf.HasValue)
			{
				roomUID = regRef.GetPlaceableObjectForUID(uIDForDenObjectIsInsideOf.Value).GetComponent<BoundingBoxComponent>().GetRoomUID();
			}
			if (!roomUID.HasValue)
			{
				GetComponent<DogAI>().ForceInterruptBehavior();
				return;
			}
		}
		List<ulong> list = new List<ulong>();
		GetAllRoutableRooms(roomUID.Value, list);
		DogBehaviorBase currentBehavior = GetComponent<DogAI>().GetCurrentBehavior();
		ulong? num = null;
		Vector3 chosenWorldPosition = Vector3.zero;
		Vector2Int chosenGridPosition = Vector2Int.zero;
		if (currentBehavior.GetStoredGridSquare().HasValue)
		{
			num = currentBehavior.GetStoredRoomUID();
			chosenGridPosition = currentBehavior.GetStoredGridSquare().Value;
			RoomBase component = constructionRef.GetObjectForUID(num.Value).GetComponent<RoomBase>();
			if (!ObjectPlacementManager.ReserveSpaceForObject(dogRegRef.GetIDFromDog(base.gameObject), component, hole, chosenGridPosition, ref chosenWorldPosition))
			{
				GetComponent<DogAI>().ForceInterruptBehavior();
				return;
			}
		}
		else
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (TryReserveHoleLocationInRoom(list[i], ref chosenWorldPosition, ref chosenGridPosition))
				{
					num = list[i];
					break;
				}
			}
		}
		RoomBase component2 = constructionRef.GetObjectForUID(num.Value).GetComponent<RoomBase>();
		currentBehavior.StorePosition(chosenWorldPosition);
		((DogBehaviorCreateBuildableObject)currentBehavior).StoreRoomCustomizationObject(hole, component2, chosenGridPosition);
	}

	public void CreateHole()
	{
		DogBehaviorCreateBuildableObject dogBehaviorCreateBuildableObject = (DogBehaviorCreateBuildableObject)GetComponent<DogAI>().GetCurrentBehavior();
		dogBehaviorCreateBuildableObject.ReleaseReservedTiles();
		DogAI component = GetComponent<DogAI>();
		if (dogBehaviorCreateBuildableObject.storedRoom == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		dogBehaviorCreateBuildableObject.storedRoom.ReleaseAllTilesDogHasReservedForPlacement(dogRegRef.GetIDFromDog(base.gameObject));
		PlacedObjectInfo placedObjectInfo = ObjectPlacementManager.PlaceObjectManually(dogBehaviorCreateBuildableObject.storedRoom, dogBehaviorCreateBuildableObject.storedCustomizationObject, dogBehaviorCreateBuildableObject.storedGridPos);
		if (placedObjectInfo == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		GameObject objectRef = placedObjectInfo.objectRef;
		if (objectRef == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		Hole component2 = objectRef.GetComponent<Hole>();
		component2.CreateClumps();
		component2.SetStage(HoleStage.EMPTY);
		GoalsController.ReportGoalEvent(GoalCondition.DIG_HOLE);
		AudioController.Play(holeCreateSound, component2.transform.position);
	}

	public void ReserveDenArea()
	{
		DogAI component = GetComponent<DogAI>();
		ulong? roomUID = bbc.GetRoomUID(requireInRoom: true);
		if (!roomUID.HasValue)
		{
			ulong? uIDForDenObjectIsInsideOf = DenInteriorManager.GetUIDForDenObjectIsInsideOf(base.gameObject);
			if (uIDForDenObjectIsInsideOf.HasValue)
			{
				roomUID = ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(uIDForDenObjectIsInsideOf.Value).GetComponent<BoundingBoxComponent>()
					.GetRoomUID();
			}
			if (!roomUID.HasValue)
			{
				component.OnFixationDone();
				return;
			}
		}
		List<float> roomScores = new List<float>();
		List<ulong> roomsToCheck = new List<ulong>();
		List<ulong> list = new List<ulong>();
		GetAllRoutableRooms(roomUID.Value, roomsToCheck);
		for (int num = roomsToCheck.Count - 1; num >= 0; num--)
		{
			RoomBase component2 = constructionRef.GetObjectForUID(roomsToCheck[num]).GetComponent<RoomBase>();
			if (component2.GetNumberOfDens() >= component2.GetNumberOfDensToBuild())
			{
				roomsToCheck.RemoveAt(num);
			}
		}
		DogPersonality personality = GetComponent<DoggyBrain>().GetPersonality();
		for (int i = 0; i < roomsToCheck.Count; i++)
		{
			int num2 = constructionRef.GetObjectForUID(roomsToCheck[i]).GetComponent<RoomBase>().GetNumberOfDens();
			float num3 = baseRoomScoreForDen;
			if (personality.GetSocialPersonality() == SocialPersonalityType.SOCIAL)
			{
				while (num2 > 0)
				{
					num2--;
					num3 *= socialDogNearbyDenMultiplier;
				}
			}
			else if (personality.GetSocialPersonality() == SocialPersonalityType.ALOOF)
			{
				while (num2 > 0)
				{
					num2--;
					num3 *= aloofDogNearbyDenMultiplier;
				}
			}
			roomScores.Add(num3);
		}
		list = roomsToCheck.OrderBy((ulong r) => roomScores[roomsToCheck.IndexOf(r)]).ToList();
		ulong? num4 = null;
		int chosenRotationValue = 0;
		Vector3 chosenWorldPosition = Vector3.zero;
		Vector2Int chosenGridPosition = Vector2Int.zero;
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			if (TryReserveDenAreaInRoom(list[num5], ref chosenWorldPosition, ref chosenGridPosition, ref chosenRotationValue))
			{
				num4 = list[num5];
				break;
			}
		}
		if (!num4.HasValue)
		{
			component.OnFixationDone();
			return;
		}
		DogBehaviorBase currentBehavior = component.GetCurrentBehavior();
		RoomBase component3 = constructionRef.GetObjectForUID(num4.Value).GetComponent<RoomBase>();
		currentBehavior.StorePosition(chosenWorldPosition);
		((DogBehaviorCreateBuildableObject)currentBehavior).StoreRoomCustomizationObject(dogDen, component3, chosenGridPosition, chosenRotationValue, clearingDenArea: true);
	}

	public void FinalizeDenConstruction(GameObject denRef, DogDen.DenCallback callbackRef)
	{
		denRef.GetComponent<DogDen>().FinalizeDenConstruction(base.gameObject, callbackRef);
	}

	public bool IsInDen()
	{
		return currentlyOccupiedDen != null;
	}

	public ulong? GetCurrentlyOccupiedDen()
	{
		if (currentlyOccupiedDen == null)
		{
			return null;
		}
		return currentlyOccupiedDen.GetComponent<PlacedObjectID>().GetUID();
	}

	public GameObject GetCurrentlyOccupiedDenObject()
	{
		if (currentlyOccupiedDen == null)
		{
			return null;
		}
		return currentlyOccupiedDen.gameObject;
	}

	public void EnterDen(GameObject denRef)
	{
		DogDen component = denRef.GetComponent<DogDen>();
		if (!component.CanAddOccupant())
		{
			GetComponent<DogAI>().ForceInterruptBehavior();
			return;
		}
		currentlyOccupiedDen = component;
		currentlyOccupiedDen.AddOccupant(base.gameObject);
		Vector3 position = base.gameObject.GetComponent<LegController>().bodyFront.transform.position;
		AudioController.Play(enterDenSound, position);
		Object.Instantiate(dogEnterParticleEffects, position, Quaternion.identity);
		DenInteriorManager.EnterDen(base.gameObject, denRef, fromDogDenController: true);
		position = base.gameObject.GetComponent<LegController>().bodyFront.transform.position;
		AudioController.Play(enterDenSound, position);
		Object.Instantiate(dogExitParticleEffects, position, Quaternion.identity);
	}

	public void ExitDen(Vector3? customExitPos = null, bool particles = true)
	{
		if (!(currentlyOccupiedDen == null))
		{
			if (particles)
			{
				Vector3 position = base.gameObject.GetComponent<LegController>().bodyFront.transform.position;
				AudioController.Play(exitDenSound, position);
				Object.Instantiate(dogExitParticleEffects, position, Quaternion.identity);
			}
			DenInteriorManager.ExitDen(base.gameObject, currentlyOccupiedDen.gameObject, customExitPos, fromDogDenController: true);
			if (particles)
			{
				Vector3 position2 = base.gameObject.GetComponent<LegController>().bodyFront.transform.position;
				AudioController.Play(exitDenSound, position2);
				Object.Instantiate(dogEnterParticleEffects, position2, Quaternion.identity);
			}
			currentlyOccupiedDen.RemoveOccupant(dogRegRef.GetIDFromDog(base.gameObject));
			currentlyOccupiedDen = null;
		}
	}

	private void GetAllRoutableRooms(ulong startingRoom, List<ulong> currentRoomList)
	{
		if (!currentRoomList.Contains(startingRoom))
		{
			currentRoomList.Add(startingRoom);
			List<ulong> allAttachedRooms = constructionRef.GetAllAttachedRooms(startingRoom);
			for (int i = 0; i < allAttachedRooms.Count; i++)
			{
				GetAllRoutableRooms(allAttachedRooms[i], currentRoomList);
			}
		}
	}

	private bool TryReserveHoleLocationInRoom(ulong roomUID, ref Vector3 chosenWorldPosition, ref Vector2Int chosenGridPosition)
	{
		GameObject objectForUID = constructionRef.GetObjectForUID(roomUID);
		RoomBase component = objectForUID.GetComponent<RoomBase>();
		List<List<int>> groundPlacementGrid = objectForUID.GetComponent<RoomBase>().GetGroundPlacementGrid();
		Vector2Int gridSizeForFootprintBounds = ObjectPlacementManager.GetGridSizeForFootprintBounds(hole.footprint);
		List<int> objects = new List<int>();
		List<int> objects2 = new List<int>();
		for (int i = 0; i < groundPlacementGrid.Count; i++)
		{
			objects.Add(i);
		}
		for (int j = 0; j < groundPlacementGrid[0].Count; j++)
		{
			objects2.Add(j);
		}
		ListUtil.ShuffleList(ref objects);
		ListUtil.ShuffleList(ref objects2);
		bool flag = false;
		Vector2Int vector2Int = Vector2Int.zero;
		for (int k = 0; k < objects.Count; k++)
		{
			for (int l = 0; l < objects2.Count; l++)
			{
				Vector2Int vector2Int2 = new Vector2Int(objects[k], objects2[l]);
				if (CanObjectFit(component, gridSizeForFootprintBounds, groundPlacementGrid, vector2Int2, 0))
				{
					flag = true;
					vector2Int = vector2Int2;
					break;
				}
			}
		}
		if (!flag)
		{
			return false;
		}
		chosenGridPosition = vector2Int;
		if (!ObjectPlacementManager.ReserveSpaceForObject(dogRegRef.GetIDFromDog(base.gameObject), component, hole, vector2Int, ref chosenWorldPosition))
		{
			return false;
		}
		return true;
	}

	private int GetRotationValueForPosition(Vector2Int pos, Vector2Int denFootprint, List<List<int>> placementGrid)
	{
		int num = 10;
		int result = 0;
		if (pos.y != placementGrid[pos.x].Count - denFootprint.y)
		{
			if (pos.x == 0)
			{
				result = -90;
			}
			else if (pos.x == placementGrid.Count - denFootprint.x)
			{
				result = 90;
			}
			else if (pos.x < (placementGrid.Count - denFootprint.x - num) / 2)
			{
				result = -90;
			}
			else if (pos.x > (placementGrid.Count - denFootprint.x + num) / 2)
			{
				result = 90;
			}
			else if (pos.y < minDogRoutingSpace)
			{
				result = 180;
			}
		}
		return result;
	}

	private bool TryReserveDenAreaInRoom(ulong roomUID, ref Vector3 chosenWorldPosition, ref Vector2Int chosenGridPosition, ref int chosenRotationValue)
	{
		RoomBase component = constructionRef.GetObjectForUID(roomUID).GetComponent<RoomBase>();
		List<List<int>> groundPlacementGrid = component.GetGroundPlacementGrid();
		Mathf.Max(dogDen.footprint.x, dogDen.footprint.z);
		Vector2Int gridSizeForFootprintBounds = ObjectPlacementManager.GetGridSizeForFootprintBounds(dogDen.footprint);
		GetComponent<DoggyBrain>().GetPersonality().GetSocialPersonality();
		List<float> list = new List<float>();
		List<Vector2Int> list2 = new List<Vector2Int>();
		for (int i = 0; i <= groundPlacementGrid.Count - gridSizeForFootprintBounds.x; i++)
		{
			for (int j = 0; j <= groundPlacementGrid[i].Count - gridSizeForFootprintBounds.y; j++)
			{
				Vector2Int vector2Int = new Vector2Int(i, j);
				int rotationValueForPosition = GetRotationValueForPosition(vector2Int, gridSizeForFootprintBounds, groundPlacementGrid);
				if (!CanObjectFit(component, gridSizeForFootprintBounds, groundPlacementGrid, vector2Int, rotationValueForPosition))
				{
					continue;
				}
				float item = noWallScore;
				Vector2Int vector2Int2 = gridSizeForFootprintBounds;
				if (rotationValueForPosition == 90 || rotationValueForPosition == -90)
				{
					vector2Int2 = new Vector2Int(gridSizeForFootprintBounds.y, gridSizeForFootprintBounds.x);
				}
				if ((i == 0 && j == groundPlacementGrid[i].Count - vector2Int2.y) || (i == groundPlacementGrid.Count - vector2Int2.x && j == groundPlacementGrid[i].Count - vector2Int2.y))
				{
					item = cornerScore;
				}
				else if (j == groundPlacementGrid[i].Count - vector2Int2.y)
				{
					item = backWallScore;
					if (component.GetWallForDirection(WallDirection.BACK).HasAttachedFloorPipe())
					{
						continue;
					}
				}
				else if (i <= vector2Int2.x)
				{
					if (i == 0)
					{
						item = leftRightWallScore;
					}
					if (j != 0 && component.GetWallForDirection(WallDirection.LEFT).HasAttachedFloorPipe())
					{
						continue;
					}
				}
				else if (i >= groundPlacementGrid.Count - vector2Int2.x - vector2Int2.x)
				{
					if (i == groundPlacementGrid.Count - vector2Int2.x)
					{
						item = leftRightWallScore;
					}
					if (j != 0 && component.GetWallForDirection(WallDirection.RIGHT).HasAttachedFloorPipe())
					{
						continue;
					}
				}
				list2.Add(vector2Int);
				list.Add(item);
			}
		}
		bool flag = false;
		Vector2Int vector2Int3 = Vector2Int.zero;
		while (list2.Count > 0 && !flag)
		{
			int index = -1;
			Vector2Int weightedRandom = ListUtil.GetWeightedRandom(list2, list, ref index);
			if (navmeshRef.GetPath(base.gameObject, component.GetWorldPositionForGridSquare(weightedRandom)).Length != 0)
			{
				flag = true;
				vector2Int3 = weightedRandom;
				break;
			}
			list2.RemoveAt(index);
			list.RemoveAt(index);
		}
		if (!flag)
		{
			return false;
		}
		chosenGridPosition = vector2Int3;
		chosenRotationValue = GetRotationValueForPosition(vector2Int3, gridSizeForFootprintBounds, groundPlacementGrid);
		if (!ObjectPlacementManager.ReserveSpaceForObject(dogRegRef.GetIDFromDog(base.gameObject), component, dogDen, vector2Int3, ref chosenWorldPosition, chosenRotationValue))
		{
			return false;
		}
		return true;
	}

	private bool CanObjectFit(RoomBase roomRef, Vector2Int objectFootprint, List<List<int>> grid, Vector2Int llStartPos, int rotationValue)
	{
		Vector2Int vector2Int = objectFootprint;
		if (rotationValue == 90 || rotationValue == -90)
		{
			vector2Int = new Vector2Int(objectFootprint.y, objectFootprint.x);
		}
		for (int i = 0; i < vector2Int.x; i++)
		{
			for (int j = 0; j < vector2Int.y; j++)
			{
				int num = llStartPos.x + i;
				int num2 = llStartPos.y + j;
				if (num >= grid.Count || num2 >= grid[num].Count)
				{
					return false;
				}
				if (grid[num][num2] != 0)
				{
					return false;
				}
				if (!roomRef.CanReserveTileForPlacement(new Vector2Int(num, num2)))
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool IsDigging()
	{
		return isScratching;
	}

	public void RequestScratchAtGround(ScratchFinishedCallback callback = null)
	{
		if (isScratching)
		{
			Debug.LogError("Attempting to scratch at the ground but we're already doing that.");
			return;
		}
		currentCallback = callback;
		if (controllerRef.GetLegCountForBodySegment(controllerRef.bodyFront) == 0)
		{
			GetComponent<DogAI>().ForceInterruptBehavior();
		}
		else
		{
			ScratchAtGround();
		}
	}

	public void RequestStopScratchingAtGround()
	{
		if (isScratching)
		{
			StopScratchingAtGround();
		}
	}

	public void CreateDen()
	{
		DogBehaviorCreateBuildableObject dogBehaviorCreateBuildableObject = (DogBehaviorCreateBuildableObject)GetComponent<DogAI>().GetCurrentBehavior();
		dogBehaviorCreateBuildableObject.ReleaseReservedTiles();
		DogAI component = GetComponent<DogAI>();
		if (dogBehaviorCreateBuildableObject.storedRoom == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		dogBehaviorCreateBuildableObject.storedRoom.ReleaseAllTilesDogHasReservedForPlacement(dogRegRef.GetIDFromDog(base.gameObject));
		PlacedObjectInfo placedObjectInfo = ObjectPlacementManager.PlaceObjectManually(dogBehaviorCreateBuildableObject.storedRoom, dogBehaviorCreateBuildableObject.storedCustomizationObject, dogBehaviorCreateBuildableObject.storedGridPos, dogBehaviorCreateBuildableObject.storedRotationValue);
		if (placedObjectInfo == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		GameObject objectRef = placedObjectInfo.objectRef;
		if (objectRef == null)
		{
			component.ForceInterruptBehavior();
			return;
		}
		DogDenManager.RegisterDen(placedObjectInfo.objectID.Value);
		DogDen component2 = objectRef.GetComponent<DogDen>();
		component2.SetStage(DenStage.CLEARED);
		AudioController.Play(dirtPatchCreateSound, objectRef.transform.position);
		GameObject original = clearedAreaParticles;
		ulong? roomUID = bbc.GetRoomUID();
		if (roomUID.HasValue && constructionRef.GetObjectForUID(roomUID.Value).GetComponent<RoomBase>().GetCurrentCarpet()
			.associatedItemSet == ItemSet.WINTER)
		{
			component2.SetIsSnowy(val: true);
			original = clearedAreaParticlesSnow;
		}
		Object.Instantiate(original, objectRef.transform.position, Quaternion.identity);
	}

	private void ScratchAtGround()
	{
		isScratching = true;
		currentTimer = 0f;
		List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyBack);
		for (int i = 0; i < legsForBodySegment.Count; i++)
		{
			legsForBodySegment[i].GetComponent<Limb>().PlantLeg();
		}
		Vector3 centerPos = StrapFeetToPlanks();
		DogBehaviorBase currentBehavior = GetComponent<DogAI>().GetCurrentBehavior();
		if (currentBehavior.IsCreateBuildableObjectBehavior())
		{
			DogBehaviorCreateBuildableObject dogBehaviorCreateBuildableObject = (DogBehaviorCreateBuildableObject)currentBehavior;
			GameObject temporaryFocusTarget = dogBehaviorCreateBuildableObject.temporaryFocusTarget;
			if (temporaryFocusTarget != null)
			{
				dogBehaviorCreateBuildableObject.RepositionFocusTarget(centerPos);
				faceRef.FocusOnTarget(temporaryFocusTarget.transform);
			}
		}
	}

	private Vector3 StrapFeetToPlanks()
	{
		ulong? roomUID = bbc.GetRoomUID();
		Transform parent = null;
		DogAI component = GetComponent<DogAI>();
		GameObject original = diggingParticles;
		GameObject targetObject = component.GetTargetObject();
		if (targetObject != null && targetObject.CompareTag(Tags.HOLE))
		{
			if (targetObject.GetComponent<Hole>().IsInSnow())
			{
				original = diggingParticlesSnow;
			}
		}
		else if (roomUID.HasValue)
		{
			RoomBase component2 = constructionRef.GetObjectForUID(roomUID.Value).GetComponent<RoomBase>();
			parent = component2.GetWallForDirection(WallDirection.DOWN).transform;
			if (component2.GetCurrentCarpet().associatedItemSet == ItemSet.WINTER)
			{
				original = diggingParticlesSnow;
			}
		}
		if (frontLeftFeet.Count == 0 && frontRightFeet.Count == 0)
		{
			List<GameObject> legsForBodySegment = controllerRef.GetLegsForBodySegment(controllerRef.bodyFront);
			for (int i = 0; i < legsForBodySegment.Count; i++)
			{
				if (i % 2 == 0)
				{
					frontLeftFeet.Add(controllerRef.GetFootForLeg(legsForBodySegment[i]));
				}
				else
				{
					frontRightFeet.Add(controllerRef.GetFootForLeg(legsForBodySegment[i]));
				}
			}
		}
		Vector3 position = controllerRef.bodyFront.transform.position;
		if (frontLeftFeet.Count > 0)
		{
			position = frontLeftFeet[0].transform.position;
		}
		Vector3 position2 = controllerRef.bodyFront.transform.position;
		if (frontRightFeet.Count > 0)
		{
			position2 = frontRightFeet[0].transform.position;
		}
		Vector3 result = position + (position2 - position) / 2f;
		for (int j = 0; j < frontLeftFeet.Count; j++)
		{
			digBoardsLeft.Add(new GameObject("DigBoardLeft_" + j));
			digBoardsLeft[j].transform.SetParent(parent);
			digBoardsLeft[j].transform.position = frontLeftFeet[j].transform.position;
			Object.Instantiate(original, digBoardsLeft[j].transform).transform.localPosition = Vector3.zero;
			Rigidbody rigidbody = digBoardsLeft[j].AddComponent<Rigidbody>();
			rigidbody.mass = 100f;
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			ConfigurableJoint configurableJoint = frontLeftFeet[j].AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = rigidbody;
			configurableJoint.xMotion = ConfigurableJointMotion.Limited;
			configurableJoint.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint.zMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			configurableJoint.enablePreprocessing = false;
			configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			configurableJoint.projectionAngle = 1f;
			configurableJoint.projectionDistance = 0.1f;
			configurableJoint.breakForce = 100000f;
			configurableJoint.breakTorque = 100000f;
			configurableJoint.linearLimitSpring = new SoftJointLimitSpring
			{
				spring = 0.1f
			};
			leftFootJoints.Add(configurableJoint);
		}
		for (int k = 0; k < frontRightFeet.Count; k++)
		{
			digBoardsRight.Add(new GameObject("DigBoardRight_" + k));
			digBoardsRight[k].transform.SetParent(parent);
			digBoardsRight[k].transform.position = frontRightFeet[k].transform.position;
			Object.Instantiate(original, digBoardsRight[k].transform).transform.localPosition = Vector3.zero;
			Rigidbody rigidbody2 = digBoardsRight[k].AddComponent<Rigidbody>();
			rigidbody2.mass = 100f;
			rigidbody2.useGravity = false;
			rigidbody2.isKinematic = true;
			ConfigurableJoint configurableJoint2 = frontRightFeet[k].AddComponent<ConfigurableJoint>();
			configurableJoint2.connectedBody = rigidbody2;
			configurableJoint2.xMotion = ConfigurableJointMotion.Limited;
			configurableJoint2.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint2.zMotion = ConfigurableJointMotion.Limited;
			configurableJoint2.angularXMotion = ConfigurableJointMotion.Locked;
			configurableJoint2.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint2.angularZMotion = ConfigurableJointMotion.Locked;
			configurableJoint2.enablePreprocessing = false;
			configurableJoint2.projectionMode = JointProjectionMode.PositionAndRotation;
			configurableJoint2.projectionAngle = 1f;
			configurableJoint2.projectionDistance = 0.1f;
			configurableJoint2.breakForce = 100000f;
			configurableJoint2.breakTorque = 100000f;
			configurableJoint2.linearLimitSpring = new SoftJointLimitSpring
			{
				spring = 0.1f
			};
			rightFootJoints.Add(configurableJoint2);
		}
		scratchAnimationTimer = 0f;
		scratchVector = controllerRef.bodyFront.transform.right.normalized;
		digAudioObject = AudioController.Play(digSound, digBoardsLeft[0].transform.position);
		return result;
	}

	private void StopScratchingAtGround()
	{
		isScratching = false;
		controllerRef.UnplantLegs();
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
		faceRef.StopFocus();
		for (int i = 0; i < leftFootJoints.Count; i++)
		{
			if (leftFootJoints[i] != null)
			{
				Object.Destroy(leftFootJoints[i]);
			}
		}
		for (int j = 0; j < rightFootJoints.Count; j++)
		{
			if (rightFootJoints[j] != null)
			{
				Object.Destroy(rightFootJoints[j]);
			}
		}
		for (int k = 0; k < digBoardsLeft.Count; k++)
		{
			Object.Destroy(digBoardsLeft[k]);
		}
		for (int l = 0; l < digBoardsRight.Count; l++)
		{
			Object.Destroy(digBoardsRight[l]);
		}
		leftFootJoints.Clear();
		rightFootJoints.Clear();
		digBoardsLeft.Clear();
		digBoardsRight.Clear();
		if (digAudioObject != null)
		{
			digAudioObject.Stop(0.25f);
			digAudioObject = null;
		}
	}

	private void UpdateScratch()
	{
		currentTimer += Time.fixedDeltaTime;
		if (currentTimer >= scratchTimer)
		{
			StopScratchingAtGround();
			return;
		}
		scratchAnimationTimer += Time.fixedDeltaTime * 25f;
		Vector3 vector = scratchVector * Mathf.Sin(scratchAnimationTimer) / 10f;
		for (int i = 0; i < digBoardsLeft.Count; i++)
		{
			digBoardsLeft[i].GetComponent<Rigidbody>().MovePosition(digBoardsLeft[i].transform.position + vector);
		}
		for (int j = 0; j < digBoardsRight.Count; j++)
		{
			digBoardsRight[j].GetComponent<Rigidbody>().MovePosition(digBoardsRight[j].transform.position - vector);
		}
	}
}
