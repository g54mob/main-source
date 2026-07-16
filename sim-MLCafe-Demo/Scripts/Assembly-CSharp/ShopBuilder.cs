using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Events;

public class ShopBuilder : MonoBehaviour, IDataPersistence
{
	[SerializeField]
	private CafeBuildingOptionsLibrary buildingOptionsLibrary;

	[SerializeField]
	private RoomEditorInterface roomEditor;

	[SerializeField]
	private GameObject roomPrefab;

	[SerializeField]
	private Transform shopContent;

	[SerializeField]
	private Vector2Int maxShopSize;

	[SerializeField]
	private Transform startPointOffset;

	[SerializeField]
	private Vector2Int startPosition;

	[SerializeField]
	private WallComponent.WallFaceDirection WindowSide;

	[SerializeField]
	private List<RoomComponent> rooms = new List<RoomComponent>();

	[SerializeField]
	private UnlockableRoomExtension[] unlockableRoomExtensions;

	[SerializeField]
	private int availableStartRooms;

	private int availableRoomExtensions;

	public static UnityEvent<int> OnUpdateRoomExtensions = new UnityEvent<int>();

	public static UnityEvent OnRoomCountChanged = new UnityEvent();

	private static ShopBuilder instance;

	private bool loadGameData;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(instance);
		}
	}

	private void Start()
	{
		if (!loadGameData)
		{
			Init();
		}
	}

	private void Init()
	{
		rooms = GetComponentsInChildren<RoomComponent>().ToList();
		PreConnect();
		availableRoomExtensions = availableStartRooms;
		UnlockableRoomExtension[] array = unlockableRoomExtensions;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Init();
		}
		ProgressionManager.ListenOnLevelUp(delegate(int level)
		{
			TryUnlockRoomExtensions(level);
		});
		OnUpdateRoomExtensions.Invoke(availableRoomExtensions);
		Object.FindFirstObjectByType<NavMeshSurface>().BuildNavMesh();
		if (roomEditor == null)
		{
			roomEditor = Object.FindFirstObjectByType<RoomEditorInterface>();
		}
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
		if (isNewGameData)
		{
			return;
		}
		Init();
		availableStartRooms = data.cafeLayoutData.remainingRoomExtension;
		availableRoomExtensions = data.cafeLayoutData.remainingRoomExtension;
		SerializedMapCell[] layoutData = data.cafeLayoutData.map;
		int i;
		for (i = 0; i < layoutData.Length; i++)
		{
			if (!rooms.Exists((RoomComponent r) => r.GetPosition() == layoutData[i].position) && layoutData[i].type > -1)
			{
				AddRoom(layoutData[i].position, reduceAvailableRooms: false);
			}
		}
		StartCoroutine(LoadPaintDelayed(data, layoutData));
	}

	private IEnumerator LoadPaintDelayed(GameData data, SerializedMapCell[] layoutData)
	{
		yield return new WaitForSeconds(1f);
		int i;
		for (i = 0; i < layoutData.Length; i++)
		{
			PaintRoom(rooms.FirstOrDefault((RoomComponent r) => r.GetPosition() == layoutData[i].position), data.wallPaintSaveData);
		}
		OnRoomCountChanged.Invoke();
	}

	public void SaveData(ref GameData data)
	{
		CafeRoomLayoutData cafeRoomLayoutData = new CafeRoomLayoutData();
		cafeRoomLayoutData.remainingRoomExtension = availableRoomExtensions;
		cafeRoomLayoutData.map = CafeRoomLayoutData.CreateMapData(rooms, maxShopSize);
		data.cafeLayoutData = cafeRoomLayoutData;
		WallPaintInstance[] array = Object.FindObjectsByType<WallPaintInstance>(FindObjectsSortMode.InstanceID);
		List<WallPaintSaveData> list = new List<WallPaintSaveData>();
		WallPaintInstance[] array2 = array;
		foreach (WallPaintInstance wallPaintInstance in array2)
		{
			list.Add(wallPaintInstance.saveData);
		}
		data.wallPaintSaveData.Clear();
		data.wallPaintSaveData = list;
	}

	public static int GetRoomCount()
	{
		return instance.rooms.Count;
	}

	private void TryUnlockRoomExtensions(int level)
	{
		if (unlockableRoomExtensions.ToList().Exists((UnlockableRoomExtension x) => x.GetUnlockLevel() == level))
		{
			unlockableRoomExtensions.FirstOrDefault((UnlockableRoomExtension x) => x.Unlock(level));
		}
	}

	[ContextMenu("PreConnect")]
	private void PreConnect()
	{
		for (int i = 0; i < rooms.Count; i++)
		{
			if (rooms[i].IsStartRoom())
			{
				WallComponent.WallFaceDirection[] outsideWalls = new WallComponent.WallFaceDirection[1];
				rooms[i].InitRoom(startPosition, outsideWall: true, outsideWalls);
			}
			else
			{
				InitExistingRoom(rooms[i]);
			}
		}
		OnRoomCountChanged.Invoke();
	}

	[ContextMenu("Add Room North")]
	private void AddRoomNorth()
	{
		if (!CheckMaxShopoSize(rooms[0], WallComponent.WallFaceDirection.North) && !CheckIsOutsideWall(rooms[0], WallComponent.WallFaceDirection.North))
		{
			Vector2Int vector2Int = rooms[0].GetPosition() + WallComponent.GetDirectionPosition(WallComponent.WallFaceDirection.North);
			if (!CheckExpansionPosition(vector2Int))
			{
				WallComponent.WallFaceDirection[] outsideWalls = rooms[0].GetOutsideWalls();
				RoomComponent roomComponent = CreateRoom(vector2Int, outsideWalls);
				rooms[0].ConnectRoomOnSide(roomComponent.GetWalls(), WallComponent.WallFaceDirection.North);
			}
		}
	}

	public static bool AddRoom(Vector2Int position, bool reduceAvailableRooms = true)
	{
		if (instance.roomEditor == null)
		{
			instance.roomEditor = Object.FindFirstObjectByType<RoomEditorInterface>();
		}
		RoomComponent[] neighbouringRooms = instance.GetNeighbouringRooms(position);
		if (neighbouringRooms.Length == 0)
		{
			return false;
		}
		if (instance.CheckExpansionPosition(position))
		{
			return false;
		}
		WallComponent.WallFaceDirection[] outsideDirections = instance.CheckOutsideWalls(position);
		RoomComponent roomComponent = instance.CreateRoom(position, outsideDirections);
		for (int i = 0; i < neighbouringRooms.Length; i++)
		{
			WallComponent.WallFaceDirection neighbourWallDirection = instance.GetNeighbourWallDirection(neighbouringRooms[i], roomComponent);
			neighbouringRooms[i].ConnectRoomOnSide(roomComponent.GetWalls(), WallComponent.GetOppositeDirection(neighbourWallDirection));
		}
		instance.rooms.Add(roomComponent);
		if (instance.roomEditor != null)
		{
			instance.roomEditor.UpdateRoomState();
		}
		if (reduceAvailableRooms)
		{
			instance.availableRoomExtensions--;
			OnUpdateRoomExtensions.Invoke(instance.availableRoomExtensions);
		}
		if (roomComponent.roomType == RoomComponent.RoomType.CafeArea)
		{
			CustomerManager.IncreaseMaxCustomerCapacity(6);
		}
		OnRoomCountChanged.Invoke();
		CafeShopManager.AddExtensions(1);
		return true;
	}

	private RoomComponent CreateRoom(Vector2Int position, WallComponent.WallFaceDirection[] outsideDirections)
	{
		RoomComponent component = Object.Instantiate(roomPrefab, shopContent).GetComponent<RoomComponent>();
		bool outsideWall = outsideDirections.Length != 0;
		component.InitRoom(position, outsideWall, outsideDirections);
		return component;
	}

	private void PaintRoom(RoomComponent room, List<WallPaintSaveData> saveData)
	{
		if (!(room == null) && saveData != null && saveData.Count != 0)
		{
			WallPaintSaveData[] roomPaint = (from x in saveData.ToList()
				where x.roomPosition == room.GetPosition()
				select x).ToArray();
			room.PaintRoom(roomPaint);
		}
	}

	private void InitExistingRoom(RoomComponent room)
	{
		if (instance == null || roomEditor == null)
		{
			return;
		}
		RoomComponent[] neighbouringRooms = instance.GetNeighbouringRooms(room.GetPosition(), excludeSelf: true, room);
		if (neighbouringRooms.Length != 0)
		{
			WallComponent.WallFaceDirection[] array = instance.CheckOutsideWalls(room.GetPosition());
			room.InitRoom(room.GetPosition(), array.Length != 0, array);
			for (int i = 0; i < neighbouringRooms.Length; i++)
			{
				WallComponent.WallFaceDirection neighbourWallDirection = instance.GetNeighbourWallDirection(neighbouringRooms[i], room);
				neighbouringRooms[i].ConnectRoomOnSide(room.GetWalls(), WallComponent.GetOppositeDirection(neighbourWallDirection));
			}
			instance.roomEditor.UpdateRoomState();
			room.ApplyRoomProperties(room.GetPosition());
		}
	}

	public static CafeBuildingOptionsLibrary GetCafeBuildingOptionsLibrary()
	{
		if (instance == null)
		{
			return Resources.Load<CafeBuildingOptionsLibrary>("Libraries/CafeBuildingOptions/CafeBuildingOptionsLibrary");
		}
		return instance.buildingOptionsLibrary;
	}

	public static int GetAvailableExtensionsCount()
	{
		return instance.availableRoomExtensions;
	}

	public static void UnlockRoomExtensions(int amount)
	{
		instance.availableRoomExtensions += amount;
		OnUpdateRoomExtensions.Invoke(instance.availableRoomExtensions);
	}

	public static Vector3 GetStartOffset()
	{
		return instance.startPointOffset.position - new Vector3(instance.startPosition.x * instance.rooms[0].GetDimensions().x, 0f, instance.startPosition.y * instance.rooms[0].GetDimensions().y);
	}

	public static WallComponent.WallFaceDirection GetWindowSide()
	{
		return instance.WindowSide;
	}

	private WallComponent.WallFaceDirection[] CheckOutsideWalls(Vector2Int position)
	{
		List<WallComponent.WallFaceDirection> list = new List<WallComponent.WallFaceDirection>();
		for (int i = 0; i < 4; i++)
		{
			Vector2Int directionPosition = WallComponent.GetDirectionPosition((WallComponent.WallFaceDirection)i);
			Vector2Int vector2Int = position + directionPosition;
			if (vector2Int.x < 0)
			{
				list.Add(WallComponent.WallFaceDirection.West);
			}
			if (vector2Int.x >= instance.maxShopSize.x)
			{
				list.Add(WallComponent.WallFaceDirection.East);
			}
			if (vector2Int.y < 0)
			{
				list.Add(WallComponent.WallFaceDirection.South);
			}
			if (vector2Int.y >= instance.maxShopSize.y)
			{
				list.Add(WallComponent.WallFaceDirection.North);
			}
		}
		return list.ToArray();
	}

	private bool CheckIsOutsideWall(RoomComponent room, WallComponent.WallFaceDirection tryDirection)
	{
		if (room.GetWallFacingDirection(tryDirection).outsideWall)
		{
			return true;
		}
		return false;
	}

	private bool CheckMaxShopoSize(RoomComponent room, WallComponent.WallFaceDirection direction)
	{
		Vector2Int position = room.GetPosition();
		Vector2Int directionPosition = WallComponent.GetDirectionPosition(direction);
		if (position.x + directionPosition.x < 0 || position.x + directionPosition.x > maxShopSize.x || position.y + directionPosition.y < 0 || position.y + directionPosition.y > maxShopSize.y)
		{
			return true;
		}
		return false;
	}

	private bool CheckExpansionPosition(Vector2Int roomPosition)
	{
		return rooms.Any((RoomComponent x) => x.GetPosition() == roomPosition);
	}

	public static RoomComponent.RoomType GetRoomType(Vector2Int position)
	{
		return GetRoom(position).roomType;
	}

	public static Vector2Int GetMaxSize()
	{
		if (!(instance != null))
		{
			return new Vector2Int(5, 5);
		}
		return instance.maxShopSize;
	}

	public static Vector2Int[] GetNeighbourPositions(Vector2Int position)
	{
		List<Vector2Int> list = new List<Vector2Int>();
		for (int i = 0; i < 4; i++)
		{
			Vector2Int directionPosition = WallComponent.GetDirectionPosition((WallComponent.WallFaceDirection)i);
			Vector2Int item = position + directionPosition;
			if (item.x >= 0 && item.x <= instance.maxShopSize.x && item.y >= 0 && item.x <= instance.maxShopSize.y)
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	private RoomComponent[] GetNeighbouringRooms(Vector2Int position, bool excludeSelf = false, RoomComponent self = null)
	{
		RoomComponent[] array = rooms.ToList().FindAll((RoomComponent room) => (room.GetPosition().x == position.x || room.GetPosition().y == position.y) && Vector2Int.Distance(room.GetPosition(), position) < 2f).ToArray();
		if (excludeSelf)
		{
			List<RoomComponent> list = new List<RoomComponent>(array.Length - 1);
			for (int num = 0; num < array.Length; num++)
			{
				if (array[num] != self)
				{
					list.Add(array[num]);
				}
			}
			return list.ToArray();
		}
		return array;
	}

	private WallComponent.WallFaceDirection GetNeighbourWallDirection(RoomComponent roomA, RoomComponent roomB)
	{
		return WallComponent.GetDirection(roomA.GetPosition() - roomB.GetPosition());
	}

	public static bool Exists(Vector2Int position)
	{
		return instance.rooms.Any((RoomComponent x) => x.GetPosition() == position);
	}

	public static RoomComponent GetRoom(Vector2Int position)
	{
		return instance.rooms.First((RoomComponent x) => x.GetPosition() == position);
	}

	public static bool IsNeighbourOfExisting(Vector2Int[] checkNeighbours)
	{
		int i;
		for (i = 0; i < checkNeighbours.Length; i++)
		{
			if (instance.rooms.ToList().Exists((RoomComponent x) => x.GetPosition() == checkNeighbours[i]))
			{
				return true;
			}
		}
		return false;
	}
}
