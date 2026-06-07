using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Achievements;
using ClipperLib;
using SINetworking;
using UnityEngine;

public class RoadManager : Writeable
{
	[Flags]
	public enum RoadType
	{
		None = 0,
		Road = 1,
		HorizontalParking = 4,
		VerticalParking = 8,
		WestRamp = 0x10,
		NorthRamp = 0x20,
		EastRamp = 0x40,
		SouthRamp = 0x80,
		HorizontalBike = 0x100,
		VerticalBike = 0x200,
		Parking = 0xC,
		BikeRack = 0x300,
		AllParking = 0x30C,
		Ramp = 0xF0
	}

	public enum ParkingState
	{
		Public = 0,
		Player = 1,
		Closed = 2
	}

	[Serializable]
	public struct RoadPiece
	{
		[SerializeField]
		public GameObject Piece;

		[SerializeField]
		public int Rotation;
	}

	[Serializable]
	public class ParkingAssignment
	{
		public int X;

		public int Y;

		public int Floor;

		public int ID;

		public RoadNode.ParkingAssign Assignment;

		public ParkingAssignment()
		{
		}

		public ParkingAssignment(RoadNode node)
		{
			X = Mathf.FloorToInt(node.transform.position.x / Instance.RoadSize);
			Y = Mathf.FloorToInt(node.transform.position.z / Instance.RoadSize);
			Floor = node.Parent.floor;
			ID = node.ID;
			Assignment = node.Assign;
		}
	}

	public static int Floors = 3;

	public static RoadManager Instance;

	public RoadPiece[] RoadPieces;

	public GameObject ParkingHors;

	public GameObject Ramp;

	public GameObject BikeRack;

	public int GridSize = 32;

	public int SidewalkSplit = 8;

	private int _sideWalkSize;

	public Color CompanyCarColor;

	public float RoadSize;

	public byte[][,] RoadMap;

	[NonSerialized]
	private int[,] RoadHeight;

	[NonSerialized]
	private bool[,] _visited;

	[NonSerialized]
	private GameObject[,] RoadSupports;

	private SideWalkGroup[][,] _sidewalks;

	[NonSerialized]
	public HashList<RoadNode> CheckUnreachable = new HashList<RoadNode>();

	[NonSerialized]
	public bool CheckAIAllowed;

	[NonSerialized]
	public bool AIAllowedBeingChecked;

	[NonSerialized]
	private ObjectPool<RoadLightScript> _lampPool;

	public List<RoadLightScript> Lamps = new List<RoadLightScript>();

	public RoadLightScript LampPrefab;

	[Header("In order of size starting with biggest")]
	public BurbHouse[] BurbHousePrefabs;

	public Lake LakePrefab;

	public RoadSegment[][,] ObjectMap;

	public Vector2 PCur;

	public bool PClick;

	private List<Vector2> Points;

	[NonSerialized]
	private bool _parkingDirty;

	private Dictionary<RoadNode, ParkingState> Parking = new Dictionary<RoadNode, ParkingState>();

	private List<RoadNode> InputList = new List<RoadNode>();

	private List<RoadNode> OutputList = new List<RoadNode>();

	public List<CarScript> Cars = new List<CarScript>();

	public Dictionary<int, HashSet<CarScript>> CachedCars = new Dictionary<int, HashSet<CarScript>>();

	public GameObject BuildingPrefab;

	public GameObject RoadSupportPrefab;

	public Mesh SideWalkStraight;

	public Mesh SideWalkCorner1;

	public Mesh SideWalkCorner2;

	public Mesh SideWalkCross;

	public Mesh SideWalkLip;

	public Mesh SideWalkCrossLip;

	public Subway SubwayPrefab;

	public List<Landmark> Landmarks = new List<Landmark>();

	private uint _landmarkID;

	[NonSerialized]
	private List<GameObject> _roadSupportPool = new List<GameObject>();

	[NonSerialized]
	public HashSet<RoadSegment> GroundLevelRamps = new HashSet<RoadSegment>();

	private static List<RoadNode> _parkingCache = new List<RoadNode>();

	private static List<RoadNode> _searchCache = new List<RoadNode>();

	[NonSerialized]
	private Dictionary<KeyValuePair<RoadNode, RoadNode>, List<Vector3>> CachedPaths = new Dictionary<KeyValuePair<RoadNode, RoadNode>, List<Vector3>>();

	[NonSerialized]
	private Dictionary<KeyValuePair<RoadSegment, RoadSegment>, List<Vector3>> _bikePathCache = new Dictionary<KeyValuePair<RoadSegment, RoadSegment>, List<Vector3>>();

	[NonSerialized]
	private ParkingAssignment[] _deserializedParking;

	private static HashSet<RoadSegment> _AIVisited = new HashSet<RoadSegment>();

	private IEnumerable<RoadNode> FreePark
	{
		get
		{
			if (!GameSettings.Instance.RentMode)
			{
				return from x in Parking
					where x.Value == ParkingState.Player
					select x.Key;
			}
			return Parking.Keys;
		}
	}

	public static bool IsRoadType(byte type, RoadType flags)
	{
		return ((1 << (int)type) & (byte)flags) > 0;
	}

	public ParkingState PlayerParking(RoadNode node)
	{
		return Parking.GetOrDefault(node, ParkingState.Public);
	}

	public uint GetLandmarkID()
	{
		_landmarkID++;
		return _landmarkID;
	}

	public void RegisterParking(RoadNode node)
	{
		if (node.Parking)
		{
			CheckUnreachable.Add(node);
			Parking[node] = ParkingState.Public;
			UpdateParkingAvailability(false);
		}
	}

	public IEnumerable<RoadNode> GetParkingMesh()
	{
		return Parking.Keys;
	}

	public CarScript CreateCar(int idx, bool initDID = true, bool ai = false)
	{
		HashSet<CarScript> value;
		if (CachedCars.TryGetValue(idx, out value) && value.Count > 0)
		{
			CarScript carScript = value.First();
			while (carScript == null && value.Count > 0)
			{
				int count = value.Count;
				value.Remove(carScript);
				if (count == value.Count)
				{
					break;
				}
				carScript = value.First();
			}
			if (carScript != null)
			{
				carScript.Reset();
				value.Remove(carScript);
				Cars.Add(carScript);
				if (ai)
				{
					carScript.GetComponent<NormalCar>().IsAI = true;
				}
				carScript.gameObject.SetActive(true);
				if (initDID)
				{
					carScript.InitWritable();
				}
				return carScript;
			}
		}
		CarScript carScript2 = UnityEngine.Object.Instantiate(ObjectDatabase.Instance.CarPrefabs[idx]);
		if (initDID)
		{
			carScript2.InitWritable();
		}
		Cars.Add(carScript2);
		if (ai)
		{
			carScript2.GetComponent<NormalCar>().IsAI = true;
		}
		return carScript2;
	}

	public void DestroyCar(CarScript car)
	{
		car.DestroyEvent();
		car.gameObject.SetActive(false);
		Cars.Remove(car);
		HashSet<CarScript> value;
		if (!CachedCars.TryGetValue(car.CarIdx, out value))
		{
			value = new HashSet<CarScript>();
			CachedCars[car.CarIdx] = value;
		}
		value.Add(car);
		TimeOfDay.Instance.canSkip = TimeOfDay.Instance.CanSkip();
	}

	public CarScript SendCar(Actor employee, Func<Room, float> priority, RoadNode.ParkingAssign type, float delay, Vector3? optimalSpot, bool onlyBike)
	{
		RoadNode roadNode = (employee.IsEmployee() ? FindParkingSpot(employee, type, optimalSpot, onlyBike) : FindParkingSpotStaff(employee, type, priority, optimalSpot));
		if (roadNode != null)
		{
			Company logoCompany = null;
			int num;
			if (roadNode.Bike)
			{
				num = 6;
				AchievementController.SetInteraction(AchievementController.Mechanics.BikeRack);
			}
			else if (employee.AItype == AI.AIType.Courier)
			{
				num = 3;
				employee.SetCar(num);
				if (!employee.OnCall)
				{
					logoCompany = GameSettings.Instance.MyCompany;
				}
			}
			else if (employee.AItype == AI.AIType.FireFighter || employee.AItype == AI.AIType.Burglar || employee.AItype == AI.AIType.FireInspector || AI.IsStaff(employee.AItype))
			{
				num = PickCar(false, employee.CarIdx);
				employee.SetCar(num);
			}
			else if (employee.AItype == AI.AIType.Police)
			{
				num = 4;
				employee.SetCar(num);
			}
			else if (employee.AItype == AI.AIType.Guest)
			{
				num = 2;
				employee.SetCar(num);
				Deal deal = employee.deal;
				logoCompany = ((deal != null) ? deal.Client : null);
			}
			else if (employee.AItype == AI.AIType.Parent)
			{
				num = 8;
				employee.SetCar(num);
			}
			else if (employee.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryCar))
			{
				num = 7;
				employee.SetCar(num);
			}
			else
			{
				float benefitValue = employee.GetBenefitValue("Company car");
				if (benefitValue > 0f)
				{
					logoCompany = GameSettings.Instance.MyCompany;
					num = (int)benefitValue;
					if (num == 1 && SDateTime.Now().RealYear > 1995)
					{
						num = 8;
					}
				}
				else
				{
					num = PickCar(employee.GetRealSalary() > 875f, employee.CarIdx);
					employee.SetCar(num);
				}
			}
			CarScript carScript = CreateCar(num);
			carScript.AddOccupant(employee, true);
			carScript.Target = roadNode;
			carScript.Delay = (roadNode.Bike ? 0f : delay);
			carScript.LogoCompany = logoCompany;
			carScript.Init();
			return carScript;
		}
		return null;
	}

	public float SampleHeight(Vector3 p)
	{
		Vector2 vector = p.FlattenVector3();
		RoadSegment segment = GetSegment(vector, Mathf.Clamp(Mathf.FloorToInt(p.y / 4f), 0, Floors - 1));
		if (segment != null)
		{
			segment.SampleHeight(vector);
		}
		return p.y;
	}

	public CarScript SendCar(Actor employee, int carIdx, RoadNode target, float delay)
	{
		CarScript carScript = CreateCar(carIdx);
		carScript.AddOccupant(employee, true);
		carScript.Target = target;
		carScript.Delay = delay;
		carScript.Init();
		return carScript;
	}

	public static int PickCar(bool rich, int previous = -1)
	{
		if (rich)
		{
			return 2;
		}
		if (previous == 8)
		{
			return 8;
		}
		float num = SDateTime.Now().ToFloat() + 1900f;
		if (num < 1990f)
		{
			return 1;
		}
		if (previous == 1)
		{
			if (!(Utilities.RandomValue < num.MapRange(1990f, 2000f, 0f, 0.5f)))
			{
				return 1;
			}
			return 8;
		}
		if (!(Utilities.RandomValue > num.MapRange(1990f, 2000f, 0f, 0.9f)))
		{
			return 8;
		}
		return 1;
	}

	public void UpdateParkingAvailability(bool now)
	{
		if (now)
		{
			_parkingDirty = false;
			_parkingCache.Clear();
			_parkingCache.AddRange(Parking.Select((KeyValuePair<RoadNode, ParkingState> x) => x.Key));
			for (int num = 0; num < _parkingCache.Count; num++)
			{
				RoadNode roadNode = _parkingCache[num];
				if (GameSettings.Instance.IsNetworkMode)
				{
					PlotArea plot = GameSettings.Instance.GetPlot(new Vector2(roadNode.transform.position.x, roadNode.transform.position.z));
					if (plot != null)
					{
						if (plot.Owner == 0)
						{
							Parking[roadNode] = ParkingState.Public;
						}
						else if (plot.Owner == NetworkManager.LocalPlayerID)
						{
							Parking[roadNode] = ParkingState.Player;
						}
						else
						{
							Parking[roadNode] = ParkingState.Closed;
						}
					}
					else
					{
						Parking[roadNode] = ParkingState.Public;
					}
				}
				else
				{
					Parking[roadNode] = (GameSettings.Instance.PlayerOwnedPoint(new Vector2(roadNode.transform.position.x, roadNode.transform.position.z), true) ? ParkingState.Player : ParkingState.Public);
				}
			}
			_parkingCache.Clear();
		}
		else
		{
			_parkingDirty = true;
		}
	}

	public void GetAvailableParking(List<RoadNode> output, Actor emp, RoadNode.ParkingAssign type, bool onlyBike)
	{
		output.Clear();
		foreach (KeyValuePair<RoadNode, ParkingState> item in Parking)
		{
			if (!item.Key.Taken && (!onlyBike || item.Key.Bike) && (emp.AItype == AI.AIType.Police || item.Value != ParkingState.Closed) && (emp.AllowAlternativeTraffic() || !item.Key.Bike) && !HUD.Instance.UnreachableParking.Contains(item.Key))
			{
				bool flag = false;
				switch (emp.AItype)
				{
				case AI.AIType.Employee:
				case AI.AIType.Janitor:
				case AI.AIType.Cleaning:
				case AI.AIType.IT:
				case AI.AIType.Receptionist:
				case AI.AIType.Cook:
				case AI.AIType.Courier:
				case AI.AIType.Security:
				case AI.AIType.Robot:
					flag = item.Value == ParkingState.Player && (item.Key.Assign == RoadNode.ParkingAssign.Anyone || item.Key.Assign == type);
					break;
				case AI.AIType.Guest:
				case AI.AIType.FireInspector:
					flag = item.Key.Assign == RoadNode.ParkingAssign.Anyone || item.Key.Assign == type;
					break;
				case AI.AIType.Burglar:
				case AI.AIType.Police:
				case AI.AIType.FireFighter:
				case AI.AIType.Parent:
					flag = true;
					break;
				}
				if (flag)
				{
					output.Add(item.Key);
				}
			}
		}
	}

	public RoadNode FindParkingSpotStaff(Actor emp, RoadNode.ParkingAssign type, Func<Room, float> priority, Vector3? optimalSpot)
	{
		GetAvailableParking(_searchCache, emp, type, false);
		if (_searchCache.Count == 0)
		{
			return null;
		}
		if (optimalSpot.HasValue && optimalSpot.Value.x < 0f)
		{
			if (emp.AItype != AI.AIType.Courier && emp.AItype != AI.AIType.Burglar && emp.AItype != AI.AIType.Police && emp.AItype != AI.AIType.FireInspector)
			{
				return null;
			}
			return _searchCache.FirstOrDefault();
		}
		Vector3 p = optimalSpot ?? FindOptimalStaffSpawn(emp, priority);
		if (p.x < 0f)
		{
			if (emp.AItype != AI.AIType.Courier && emp.AItype != AI.AIType.Burglar && emp.AItype != AI.AIType.Police && emp.AItype != AI.AIType.FireInspector)
			{
				return null;
			}
			return _searchCache.FirstOrDefault();
		}
		return _searchCache.MinInstance((RoadNode x) => (x.transform.position - p).Multiply(1f, 3f, 1f).sqrMagnitude * ((x.Assign == type) ? 0.25f : 1f) * (float)((!x.Bike) ? 1 : 4));
	}

	public Vector3 FindOptimalStaffSpawn(Actor emp, Func<Room, float> priority)
	{
		Room room = (emp.HasAssignedRooms ? emp.GetAssignedRooms().MinInstance(priority) : null);
		if (room != null)
		{
			return room.Center.ToVector3(room.Floor * 2);
		}
		room = GameSettings.Instance.sRoomManager.Rooms.MinInstanceRandom(priority);
		if (room != null)
		{
			return room.Center.ToVector3(room.Floor * 2);
		}
		return -Vector3.one;
	}

	public Vector3? FindOptimalSpawn(Actor emp)
	{
		Furniture furniture = emp.Owns.FirstOrDefault((Furniture x) => x.Type.Equals("Computer"));
		if (furniture != null)
		{
			furniture.Reserved = emp;
			return furniture.transform.position;
		}
		Room room = null;
		if (emp.Team != null)
		{
			Room room2 = null;
			Team team = emp.GetTeam();
			for (int num = 0; num < GameSettings.Instance.sRoomManager.Rooms.Count; num++)
			{
				Room room3 = GameSettings.Instance.sRoomManager.Rooms[num];
				if (room3.Teams.Contains(team))
				{
					room2 = room3;
					if (!emp.employee.HasDemanded(LeadDesignDemands.Demand.PrivateOffice) || room3.GetFurniture("Computer").Count == 1)
					{
						break;
					}
				}
				if (room3.ForceRole == -2 && room3.AllowedInRoom(emp))
				{
					room = room3;
				}
			}
			if (room2 != null)
			{
				return room2.Center.ToVector3(room2.Floor * 2);
			}
		}
		List<InteractionPoint> list = emp.FindFurniture("Computer", InteractionPoint.ActionType.Use, -1, GameSettings.Instance.sRoomManager.Outside, false, null, false, -1f, false);
		InteractionPoint interactionPoint = list.FirstOrDefault();
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			InteractionPoint interactionPoint2 = list[num2];
			if (interactionPoint2.Parent.Parent.OrderByRole((int)emp.GetRole()) == 0)
			{
				interactionPoint = interactionPoint2;
				break;
			}
		}
		if (interactionPoint != null)
		{
			furniture = interactionPoint.Parent;
			furniture.Reserved = emp;
			return furniture.transform.position;
		}
		if (room != null)
		{
			return room.Center.ToVector3(room.Floor * 2);
		}
		return null;
	}

	public RoadNode FindParkingSpot(Actor emp, RoadNode.ParkingAssign type, Vector3? optimalSpot, bool onlyBike)
	{
		GetAvailableParking(_searchCache, emp, type, onlyBike);
		if (_searchCache.Count == 0)
		{
			return null;
		}
		Vector3? p = optimalSpot ?? FindOptimalSpawn(emp);
		if (!p.HasValue)
		{
			return null;
		}
		return _searchCache.MinInstance((RoadNode x) => (x.transform.position - p.Value).Multiply(1f, 3f, 1f).sqrMagnitude * ((x.Assign == type) ? 0.25f : 1f) * (float)((!x.Bike) ? 1 : 4));
	}

	public void DeregisterParking(RoadNode node)
	{
		if (node.Parking)
		{
			Parking.Remove(node);
		}
	}

	public void PlaceRoad(int x, int y, int floor, byte type, List<UndoObject.UndoAction> undos = null)
	{
		CachedPaths.Clear();
		_bikePathCache.Clear();
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize)
		{
			if (IsRoadType(type, RoadType.Ramp) || IsRoadType(RoadMap[floor][x, y], RoadType.Ramp))
			{
				CheckAllParkingAbove(floor);
			}
			byte b = RoadMap[floor][x, y];
			RoadMap[floor][x, y] = type;
			int num = RaiseDirection(type) | RaiseDirection(b);
			for (int i = -1; i <= 1; i++)
			{
				if (i == 0)
				{
					UpdateRoad(x, y, floor, RoadMap[floor][x, y] < 2 || b != RoadMap[floor][x, y], undos);
					continue;
				}
				if (x + i >= 0 && x + i < GridSize && y >= 0 && y < GridSize)
				{
					UpdateRoad(x + i, y, floor, RoadMap[floor][x + i, y] < 2, undos);
					if ((num & ((i >= 0) ? 1 : 2)) > 0)
					{
						UpdateRoad(x + i, y, floor + 1, RoadMap[floor][x + i, y] < 2, undos);
					}
				}
				if (x >= 0 && x < GridSize && y + i >= 0 && y + i < GridSize)
				{
					UpdateRoad(x, y + i, floor, RoadMap[floor][x, y + i] < 2, undos);
					if ((num & ((i < 0) ? 8 : 4)) > 0)
					{
						UpdateRoad(x, y + i, floor + 1, RoadMap[floor][x, y + i] < 2, undos);
					}
				}
			}
			for (int j = -1; j <= 1; j++)
			{
				if (j == 0)
				{
					UpdateConnections(x, y, floor);
					continue;
				}
				UpdateConnections(x + j, y, floor);
				UpdateConnections(x, y + j, floor);
				if ((num & ((j >= 0) ? 1 : 2)) > 0)
				{
					UpdateConnections(x + j, y, floor + 1);
				}
				if ((num & ((j < 0) ? 8 : 4)) > 0)
				{
					UpdateConnections(x, y + j, floor + 1);
				}
			}
			UpdateSupports(new Rect(x, y, 1f, 1f));
			CheckAIAllowed = true;
		}
		UpdateUnreachable();
		NetworkMeta.CheckDirty();
	}

	private void UpdateUnreachable()
	{
		CheckUnreachable.AddRange(HUD.Instance.UnreachableParking);
	}

	public void PlaceRoad(Rect r, int floor, byte type, List<UndoObject.UndoAction> undos, bool force = false)
	{
		bool flag = IsRoadType(type, RoadType.Ramp);
		_bikePathCache.Clear();
		CachedPaths.Clear();
		byte[,] array = new byte[GridSize, GridSize];
		Array.Copy(RoadMap[floor], array, GridSize * GridSize);
		bool extraClearance = RaiseDirection(type) > 0;
		for (int i = (int)r.xMin; (float)i < r.xMax; i++)
		{
			for (int j = (int)r.yMin; (float)j < r.yMax; j++)
			{
				if (force || CheckFree(i, j, floor, false, extraClearance))
				{
					if (!flag && IsRoadType(RoadMap[floor][i, j], RoadType.Ramp))
					{
						flag = true;
					}
					RoadMap[floor][i, j] = type;
					NetworkMessaging.SendPlaceRoad(i, j, floor, type, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
			}
		}
		for (int k = (int)r.xMin - 1; (float)k < r.xMax + 1f; k++)
		{
			for (int l = (int)r.yMin - 1; (float)l < r.yMax + 1f; l++)
			{
				if (k >= 0 && k < GridSize && l >= 0 && l < GridSize)
				{
					UpdateRoad(k, l, floor, RoadMap[floor][k, l] < 2 || array[k, l] != RoadMap[floor][k, l], undos);
					if (floor < Floors - 1 && RoadMap[floor + 1][k, l] == 1)
					{
						UpdateRoad(k, l, floor + 1, true, undos);
					}
				}
			}
		}
		for (int m = (int)r.xMin - 1; (float)m < r.xMax + 1f; m++)
		{
			for (int n = (int)r.yMin - 1; (float)n < r.yMax + 1f; n++)
			{
				if (m >= 0 && m < GridSize && n >= 0 && n < GridSize)
				{
					UpdateConnections(m, n, floor);
					if (floor < Floors - 1)
					{
						UpdateConnections(m, n, floor + 1);
					}
				}
			}
		}
		if (flag)
		{
			CheckAllParkingAbove(floor);
		}
		UpdateUnreachable();
		UpdateSupports(r);
		CheckAIAllowed = true;
		NetworkMeta.CheckDirty();
	}

	private void ForcePlaceRoad(Rect r, int floor, byte type)
	{
		for (int i = (int)r.xMin; (float)i < r.xMax; i++)
		{
			for (int j = (int)r.yMin; (float)j < r.yMax; j++)
			{
				RoadMap[floor][i, j] = type;
			}
		}
		for (int k = (int)r.xMin - 1; (float)k < r.xMax + 1f; k++)
		{
			for (int l = (int)r.yMin - 1; (float)l < r.yMax + 1f; l++)
			{
				if (k >= 0 && k < GridSize && l >= 0 && l < GridSize)
				{
					UpdateRoad(k, l, floor, true, null);
					if (floor < Floors - 1 && RoadMap[floor + 1][k, l] == 1)
					{
						UpdateRoad(k, l, floor + 1, true, null);
					}
				}
			}
		}
		for (int m = (int)r.xMin - 1; (float)m < r.xMax + 1f; m++)
		{
			for (int n = (int)r.yMin - 1; (float)n < r.yMax + 1f; n++)
			{
				if (m >= 0 && m < GridSize && n >= 0 && n < GridSize)
				{
					UpdateConnections(m, n, floor);
					if (floor < Floors - 1)
					{
						UpdateConnections(m, n, floor + 1);
					}
				}
			}
		}
	}

	public bool CheckFree(int x, int y, int floor, bool withErrors, bool extraClearance, bool checkCollisions = true)
	{
		if (x < 1 || x >= GridSize - 1 || y < 1 || y >= GridSize - 1)
		{
			return false;
		}
		if (floor > 0)
		{
			int fromFloor;
			byte road = GetRoad(x, y, floor - 1, out fromFloor);
			if (fromFloor == floor - 1 && road >= 4 && road < 8)
			{
				if (withErrors)
				{
					ErrorOverlay.Instance.ShowError("OnRampError");
				}
				return false;
			}
		}
		int num = Mathf.RoundToInt(GameSettings.Instance.BusStopSign.transform.position.x / RoadSize);
		int num2 = Mathf.RoundToInt(GameSettings.Instance.BusStopSign.transform.position.z / RoadSize);
		if (num >= 16)
		{
			num--;
		}
		if (num2 >= 16)
		{
			num2--;
		}
		if (x == num && y == num2 && floor == 0)
		{
			if (withErrors)
			{
				ErrorOverlay.Instance.ShowError("RoadBusSignError");
			}
			return false;
		}
		bool flag = true;
		int num3 = (int)RoadSize;
		for (int i = 0; i < num3; i++)
		{
			for (int j = 0; j < num3; j++)
			{
				int num4 = x * num3 + i;
				int num5 = y * num3 + j;
				if (num4 != 8 && num5 != 8 && num4 != 247 && num5 != 247 && !GameSettings.Instance.PlayerOwnedPoint(new Vector2(num4, num5)))
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		if (!flag)
		{
			int num6 = 0;
			if (GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x - 0.5f, (float)y - 0.5f) * RoadSize))
			{
				num6++;
			}
			if (GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x - 0.5f, (float)y + 1.5f) * RoadSize))
			{
				num6++;
			}
			if (GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x + 1.5f, (float)y - 0.5f) * RoadSize))
			{
				num6++;
			}
			if (GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x + 1.5f, (float)y + 1.5f) * RoadSize))
			{
				num6++;
			}
			if (floor == 0 || (num6 < 3 && (!GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x - 0.5f, (float)y + 0.5f) * RoadSize) || !GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x + 1.5f, (float)y + 0.5f) * RoadSize)) && (!GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x + 0.5f, (float)y - 0.5f) * RoadSize) || !GameSettings.Instance.PlayerOwnedPoint(new Vector2((float)x + 0.5f, (float)y + 1.5f) * RoadSize))))
			{
				if (withErrors)
				{
					ErrorOverlay.Instance.ShowError("RoomOutOfPlot");
				}
				return false;
			}
		}
		if (checkCollisions)
		{
			if (extraClearance)
			{
				floor++;
			}
			int num7 = floor * 2;
			int num8 = floor * 2 + 1;
			Rect rect = new Rect(x * num3, y * num3, num3, num3);
			for (int k = 0; k <= num8; k++)
			{
				Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(k, rect.center);
				if (roomFromPoint != null && roomFromPoint != GameSettings.Instance.sRoomManager.Outside)
				{
					if (withErrors)
					{
						ErrorOverlay.Instance.ShowError((k > num7) ? "RoadUnderRoomError" : "RoadAboveRoomError");
					}
					return false;
				}
			}
			List<Room> rooms = GameSettings.Instance.sRoomManager.GetRooms();
			for (int l = 0; l < rooms.Count; l++)
			{
				Room room = rooms[l];
				if (room.Floor >= 0 && room.Floor <= num8)
				{
					for (int m = 0; m < room.Edges.Count; m++)
					{
						if (rect.CompletelyWithin(room.Edges[m].Pos))
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError((room.Floor > num7) ? "RoadUnderRoomError" : "RoadAboveRoomError");
							}
							return false;
						}
					}
				}
				else
				{
					if (room.Floor != -1)
					{
						continue;
					}
					List<Furniture> furnitures = room.GetFurnitures();
					for (int n = 0; n < furnitures.Count; n++)
					{
						Furniture furniture = furnitures[n];
						if (furniture.PokesThroughRoof && !CheckFurnitureColl(furniture, x, y, num7))
						{
							return false;
						}
					}
				}
			}
			Vector2[] array = new Vector2[4]
			{
				new Vector2(rect.xMin, rect.yMin),
				new Vector2(rect.xMax, rect.yMin),
				new Vector2(rect.xMax, rect.yMax),
				new Vector2(rect.xMin, rect.yMax)
			};
			foreach (WallEdge allSegment in GameSettings.Instance.sRoomManager.AllSegments)
			{
				if (allSegment.Floor < 0 || allSegment.Floor > num8)
				{
					continue;
				}
				foreach (WallEdge value in allSegment.Links.Values)
				{
					for (int num9 = 0; num9 < array.Length; num9++)
					{
						Vector2 pos = allSegment.Pos;
						Vector2 pos2 = value.Pos;
						Vector2 vector = (pos + pos2) * 0.5f;
						if (Utilities.LinesIntersect(pos, pos2, array[num9], array[(num9 + 1) % array.Length], true, false))
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError((allSegment.Floor > num7) ? "RoadUnderRoomError" : "RoadAboveRoomError");
							}
							return false;
						}
						if (vector.x > array[0].x && vector.x < array[2].x && vector.y > array[0].y && vector.y < array[2].y)
						{
							if (withErrors)
							{
								ErrorOverlay.Instance.ShowError((allSegment.Floor > num7) ? "RoadUnderRoomError" : "RoadAboveRoomError");
							}
							return false;
						}
					}
				}
			}
			List<Furniture> furnitures2 = GameSettings.Instance.sRoomManager.Outside.GetFurnitures();
			for (int num10 = 0; num10 < furnitures2.Count; num10++)
			{
				Furniture f = furnitures2[num10];
				if (!CheckFurnitureColl(f, x, y, num7))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool CheckFurnitureColl(Furniture f, int x, int y, int floor)
	{
		if (f.Height2 + (float)(f.Floor * 2) < (float)(floor * 2))
		{
			return true;
		}
		if (Mathf.FloorToInt(f.OriginalPosition.x / RoadSize) == x && Mathf.FloorToInt(f.OriginalPosition.z / RoadSize) == y)
		{
			return false;
		}
		for (int i = 0; i < f.FinalBoundary.Length; i++)
		{
			Vector2 vector = f.FinalBoundary[i];
			int num = Mathf.FloorToInt(vector.x / RoadSize);
			int num2 = Mathf.FloorToInt(vector.y / RoadSize);
			if (num == x && num2 == y)
			{
				return false;
			}
		}
		return true;
	}

	private void UpdateRoad(int x, int y, int floor, bool change, List<UndoObject.UndoAction> undos, bool treeRemoval = true)
	{
		if (x < 0 || x >= GridSize || y < 0 || y >= GridSize)
		{
			return;
		}
		if (ObjectMap[floor][x, y] != null && change)
		{
			RoadSegment roadSegment = ObjectMap[floor][x, y];
			if (x == 0 && y == GridSize - 1)
			{
				InputList.Remove(roadSegment.WestIn);
				OutputList.Remove(roadSegment.WestOut);
			}
			if (x == 0 && y == 0)
			{
				InputList.Remove(roadSegment.EastIn);
				OutputList.Remove(roadSegment.EastOut);
			}
			if (x == GridSize - 1 && y == GridSize - 1)
			{
				InputList.Remove(roadSegment.NorthIn);
				OutputList.Remove(roadSegment.NorthOut);
			}
			if (x == GridSize - 1 && y == 0)
			{
				InputList.Remove(roadSegment.NorthIn);
				OutputList.Remove(roadSegment.NorthOut);
			}
			roadSegment.RemoveConnections();
			GroundLevelRamps.Remove(roadSegment);
			roadSegment.AllNodes.ForEach(delegate(RoadNode z)
			{
				z.DestroyGO();
			});
			UnityEngine.Object.Destroy(roadSegment.gameObject);
			ObjectMap[floor][x, y] = null;
			GameSettings.Instance.sRoomManager.RoomRoadDirty = 2;
		}
		if (RoadMap[floor][x, y] == 1)
		{
			byte roadType = GetRoadType(x, y, floor);
			RoadPiece roadPiece = RoadPieces[roadType];
			RoadSegment roadSegment2 = MakeRoad(x, y, floor, roadPiece.Rotation, undos, treeRemoval, roadPiece.Piece);
			if (x == 0 && y == GridSize - 1)
			{
				roadSegment2.IsInputOutput = true;
				InputList.Add(roadSegment2.WestIn);
				OutputList.Add(roadSegment2.WestOut);
				roadSegment2.WestIn.IsInput = true;
				roadSegment2.WestOut.IsOutput = true;
			}
			if (x == 0 && y == 0)
			{
				roadSegment2.IsInputOutput = true;
				InputList.Add(roadSegment2.EastIn);
				OutputList.Add(roadSegment2.EastOut);
				roadSegment2.EastIn.IsInput = true;
				roadSegment2.EastOut.IsOutput = true;
			}
			if (x == GridSize - 1 && y == GridSize - 1)
			{
				roadSegment2.IsInputOutput = true;
				InputList.Add(roadSegment2.NorthIn);
				OutputList.Add(roadSegment2.NorthOut);
				roadSegment2.NorthIn.IsInput = true;
				roadSegment2.NorthOut.IsOutput = true;
			}
			if (x == GridSize - 1 && y == 0)
			{
				roadSegment2.IsInputOutput = true;
				InputList.Add(roadSegment2.NorthIn);
				OutputList.Add(roadSegment2.NorthOut);
				roadSegment2.NorthIn.IsInput = true;
				roadSegment2.NorthOut.IsOutput = true;
			}
		}
		if (change && RoadMap[floor][x, y] == 2)
		{
			MakeRoad(x, y, floor, 0, undos, treeRemoval, ParkingHors);
		}
		if (change && RoadMap[floor][x, y] == 3)
		{
			MakeRoad(x, y, floor, 90, undos, treeRemoval, ParkingHors);
		}
		if (change && RoadMap[floor][x, y] >= 4 && RoadMap[floor][x, y] < 8)
		{
			RoadSegment item = MakeRoad(x, y, floor, RoadMap[floor][x, y] * 90, undos, treeRemoval, Ramp);
			if (floor == 0)
			{
				GroundLevelRamps.Add(item);
			}
		}
		if (change && RoadMap[floor][x, y] == 8)
		{
			MakeRoad(x, y, floor, 0, undos, treeRemoval, BikeRack);
		}
		if (change && RoadMap[floor][x, y] == 9)
		{
			MakeRoad(x, y, floor, 90, undos, treeRemoval, BikeRack);
		}
		if (ObjectMap[floor][x, y] != null)
		{
			ObjectMap[floor][x, y].Connect();
		}
		RoadHeight[x, y] = -1;
		for (int num = Floors - 1; num >= 0; num--)
		{
			int fromFloor;
			if (GetRoad(x, y, num, out fromFloor) > 0)
			{
				RoadHeight[x, y] = fromFloor + num;
				break;
			}
		}
		SetSidewalkDirty(x, y, floor);
	}

	private void CheckAllParkingAbove(int floor)
	{
		foreach (KeyValuePair<RoadNode, ParkingState> item in Parking)
		{
			if (item.Key.Parent.floor > floor)
			{
				CheckUnreachable.Add(item.Key);
			}
		}
	}

	private RoadSegment MakeRoad(int x, int y, int floor, int rot, List<UndoObject.UndoAction> undos, bool treeRemoval, GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
		gameObject.transform.SetPositionAndRotation(gameObject.transform.position + new Vector3((float)x * RoadSize + RoadSize / 2f, (float)floor * 4f, (float)y * RoadSize + RoadSize / 2f), Quaternion.Euler(0f, rot, 0f) * gameObject.transform.rotation);
		gameObject.transform.SetParent(base.transform);
		RoadSegment component = gameObject.GetComponent<RoadSegment>();
		component.x = x;
		component.y = y;
		component.floor = floor;
		component.Init(rot);
		ObjectMap[floor][x, y] = component;
		if (treeRemoval)
		{
			RemoveTrees(x, y, undos);
		}
		return component;
	}

	public void PlaceRoadLamps()
	{
		_lampPool.ReleaseAll();
		Lamps.Clear();
		if (_visited == null)
		{
			_visited = new bool[GridSize, GridSize];
		}
		else
		{
			for (int i = 0; i < GridSize; i++)
			{
				for (int j = 0; j < GridSize; j++)
				{
					_visited[i, j] = false;
				}
			}
		}
		PlaceSubLamps(0, 0, false, 1);
	}

	private void PlaceSubLamps(int x, int y, bool side, int last)
	{
		if (x < 0 || x >= GridSize || y < 0 || y >= GridSize)
		{
			return;
		}
		byte road = GetRoad(x, y, 0);
		if (_visited[x, y] || road == 0)
		{
			return;
		}
		_visited[x, y] = true;
		bool flag = side;
		int num = last - 1;
		int num2 = 0;
		if (last <= 0 && (road < 4 || road >= 8))
		{
			int num3 = 1;
			int num4 = 0;
			if (side)
			{
				num3 *= -1;
				num4 += 180;
			}
			if (GetRoad(x + num3, y, 0) == 0 && CheckNav(x, y, num3, 0))
			{
				AddLamp(x, y, num4);
				num2 = 1;
			}
			else if (GetRoad(x, y + num3, 0) == 0 && CheckNav(x, y, 0, num3))
			{
				AddLamp(x, y, num4 - 90);
				num2 = 2;
			}
			else if (GetRoad(x - num3, y, 0) == 0 && CheckNav(x, y, -num3, 0))
			{
				AddLamp(x, y, num4 - 180);
				num2 = 1;
			}
			else if (GetRoad(x, y - num3, 0) == 0 && CheckNav(x, y, 0, -num3))
			{
				AddLamp(x, y, num4 + 90);
				num2 = 2;
			}
			flag = !flag;
			num = 3;
		}
		PlaceSubLamps(x + 1, y, flag, num - ((num2 == 1) ? 1 : 0));
		PlaceSubLamps(x, y + 1, flag, num - ((num2 == 2) ? 1 : 0));
		PlaceSubLamps(x - 1, y, flag, num - ((num2 == 1) ? 1 : 0));
		PlaceSubLamps(x, y - 1, flag, num - ((num2 == 2) ? 1 : 0));
	}

	private bool CheckNav(int x, int y, int xTo, int yTo)
	{
		float x2 = (float)x * RoadSize + RoadSize / 2f + (float)xTo * (RoadSize / 2f + 1f);
		float y2 = (float)y * RoadSize + RoadSize / 2f + (float)yTo * (RoadSize / 2f + 1f);
		return GameSettings.Instance.sRoomManager.Outside.GetNodeAt(new Vector2(x2, y2)) != null;
	}

	private void AddLamp(int x, int y, float r)
	{
		RoadLightScript roadLightScript = _lampPool.Get();
		roadLightScript.transform.SetPositionAndRotation(new Vector3((float)x * RoadSize + RoadSize / 2f, 0f, (float)y * RoadSize + RoadSize / 2f), Quaternion.Euler(0f, r, 0f));
		roadLightScript.RefreshColor();
		Lamps.Add(roadLightScript);
	}

	private void UpdateConnections(int x, int y, int floor)
	{
		RoadSegment segment = GetSegment(x, y, floor);
		if (segment == null)
		{
			return;
		}
		if (segment.floor < floor)
		{
			floor = segment.floor;
		}
		segment.Connect();
		RoadSegment segment2 = GetSegment(x + 1, y, floor + (segment.NorthRaised ? 1 : 0), !segment.NorthRaised);
		if (segment2 != null && segment2.floor < floor == segment2.SouthRaised)
		{
			if (segment2.SouthIn != null && segment.NorthOut != null)
			{
				segment.NorthOut.self.AddConnection(segment2.SouthIn.self);
			}
			if (segment2.SouthOut != null && segment.NorthIn != null)
			{
				segment2.SouthOut.self.AddConnection(segment.NorthIn.self);
			}
		}
		RoadSegment segment3 = GetSegment(x - 1, y, floor + (segment.SouthRaised ? 1 : 0), !segment.SouthRaised);
		if (segment3 != null && segment3.floor < floor == segment3.NorthRaised)
		{
			if (segment3.NorthOut != null && segment.SouthIn != null)
			{
				segment3.NorthOut.self.AddConnection(segment.SouthIn.self);
			}
			if (segment3.NorthIn != null && segment.SouthOut != null)
			{
				segment.SouthOut.self.AddConnection(segment3.NorthIn.self);
			}
		}
		RoadSegment segment4 = GetSegment(x, y - 1, floor + (segment.EastRaised ? 1 : 0), !segment.EastRaised);
		if (segment4 != null && segment4.floor < floor == segment4.WestRaised)
		{
			if (segment4.WestOut != null && segment.EastIn != null)
			{
				segment4.WestOut.self.AddConnection(segment.EastIn.self);
			}
			if (segment4.WestIn != null && segment.EastOut != null)
			{
				segment.EastOut.self.AddConnection(segment4.WestIn.self);
			}
		}
		RoadSegment segment5 = GetSegment(x, y + 1, floor + (segment.WestRaised ? 1 : 0), !segment.WestRaised);
		if (segment5 != null && segment5.floor < floor == segment5.EastRaised)
		{
			if (segment5.EastIn != null && segment.WestOut != null)
			{
				segment.WestOut.self.AddConnection(segment5.EastIn.self);
			}
			if (segment5.EastOut != null && segment.WestIn != null)
			{
				segment5.EastOut.self.AddConnection(segment.WestIn.self);
			}
		}
	}

	public RoadSegment GetSegment(Vector3 v, int floor, bool fallThrough = true)
	{
		return GetSegment(Mathf.FloorToInt(v.x / RoadSize), Mathf.FloorToInt(v.z / RoadSize), floor, fallThrough);
	}

	public RoadSegment GetSegment(Vector2 v, int floor, bool fallThrough = true)
	{
		return GetSegment(Mathf.FloorToInt(v.x / RoadSize), Mathf.FloorToInt(v.y / RoadSize), floor, fallThrough);
	}

	public RoadSegment GetSegment(int x, int y, int floor, bool fallThrough = true)
	{
		if (ObjectMap == null)
		{
			return null;
		}
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize && floor >= 0 && floor < Floors)
		{
			if (floor > 0 && fallThrough)
			{
				byte b = RoadMap[floor - 1][x, y];
				if (b >= 4 && b < 8)
				{
					return ObjectMap[floor - 1][x, y];
				}
			}
			return ObjectMap[floor][x, y];
		}
		return null;
	}

	private void RemoveTrees(int x, int y, List<UndoObject.UndoAction> undos)
	{
		if (GameSettings.Instance.TreeTree == null || x < 0 || x >= GridSize || y < 0 || y >= GridSize)
		{
			return;
		}
		HashSet<TreeInstance> hashSet = new HashSet<TreeInstance>();
		bool flag = false;
		Bounds bounds = new Bounds(new Vector3((float)x * RoadSize + RoadSize / 2f, 1f, (float)y * RoadSize + RoadSize / 2f), new Vector3(RoadSize, 2f, RoadSize));
		foreach (TreeInstance item in GameSettings.Instance.TreeTree.Query(bounds.Flatten().Expand(4f, 4f)))
		{
			if (item.Bounds.Intersects(bounds))
			{
				hashSet.Add(item);
				flag = true;
			}
		}
		if (!flag)
		{
			return;
		}
		if (undos != null)
		{
			undos.Add(new UndoObject.UndoAction(hashSet.ToArray(), true));
		}
		foreach (TreeInstance item2 in hashSet)
		{
			GameSettings.Instance.RemoveTree(item2);
		}
	}

	public void UpdateRoadVisibility()
	{
		if (ObjectMap == null)
		{
			return;
		}
		for (int i = 0; i < Floors; i++)
		{
			bool flag = GameSettings.Instance.ActiveFloor >= 0 && (float)i * 2f <= (float)GameSettings.Instance.ActiveFloor;
			for (int j = 0; j < GridSize; j++)
			{
				for (int k = 0; k < GridSize; k++)
				{
					RoadSegment roadSegment = ObjectMap[i][j, k];
					if (!(roadSegment != null))
					{
						continue;
					}
					for (int l = 0; l < roadSegment.rends.Length; l++)
					{
						Renderer renderer = roadSegment.rends[l];
						if (l > 0 || (!roadSegment.AlwaysShadow && i == 0))
						{
							renderer.enabled = flag;
						}
						else
						{
							renderer.sharedMaterial = (flag ? TimeOfDay.Instance.RoadMaterial : RoomMaterialController.Instance.ShadowsOnly);
						}
					}
				}
			}
		}
	}

	private bool Connectable(byte type)
	{
		if (type > 0 && type != 8)
		{
			return type != 9;
		}
		return false;
	}

	private byte GetRoadType(int x, int y, int floor)
	{
		byte b = 0;
		int fromFloor;
		byte road = GetRoad(x, y - 1, floor, out fromFloor);
		byte b2 = RaiseDirection(road);
		if (Connectable(road) && (b2 & 3) == 0 && fromFloor < floor == (b2 & 4) > 0)
		{
			b |= 1;
		}
		byte road2 = GetRoad(x + 1, y, floor, out fromFloor);
		b2 = RaiseDirection(road2);
		if (Connectable(road2) && (b2 & 0xC) == 0 && fromFloor < floor == (b2 & 2) > 0)
		{
			b |= 2;
		}
		byte road3 = GetRoad(x, y + 1, floor, out fromFloor);
		b2 = RaiseDirection(road3);
		if (Connectable(road3) && (b2 & 3) == 0 && fromFloor < floor == (b2 & 8) > 0)
		{
			b |= 4;
		}
		byte road4 = GetRoad(x - 1, y, floor, out fromFloor);
		b2 = RaiseDirection(road4);
		if (Connectable(road4) && (b2 & 0xC) == 0 && fromFloor < floor == (b2 & 1) > 0)
		{
			b |= 8;
		}
		return b;
	}

	public static byte RaiseDirection(byte type)
	{
		switch (type)
		{
		case 4:
			return 4;
		case 5:
			return 1;
		case 6:
			return 8;
		case 7:
			return 2;
		default:
			return 0;
		}
	}

	public byte GetRoad(Vector2 p, int floor)
	{
		return GetRoad(Mathf.FloorToInt(p.x / RoadSize), Mathf.FloorToInt(p.y / RoadSize), floor);
	}

	public byte GetRoad(int x, int y, int floor)
	{
		int fromFloor;
		return GetRoad(x, y, floor, out fromFloor);
	}

	public byte GetRoad(int x, int y, int floor, out int fromFloor)
	{
		fromFloor = floor;
		if (RoadMap == null)
		{
			return 0;
		}
		if (floor == 0)
		{
			if (x == 0 && y == -1)
			{
				return 1;
			}
			if (x == 0 && y == GridSize)
			{
				return 1;
			}
			if (x == GridSize && y == 0)
			{
				return 1;
			}
			if (x == GridSize && y == GridSize - 1)
			{
				return 1;
			}
		}
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize && floor >= 0 && floor < Floors)
		{
			if (floor > 0)
			{
				byte b = RoadMap[floor - 1][x, y];
				if (b >= 4 && b < 8)
				{
					fromFloor = floor - 1;
					return b;
				}
			}
			return RoadMap[floor][x, y];
		}
		return 0;
	}

	public bool GetRoadClearance(int x, int y, int floor, bool roundUp)
	{
		int roadHeight = GetRoadHeight(x, y, roundUp);
		if (roadHeight >= 0)
		{
			return roadHeight < floor - 1;
		}
		return true;
	}

	public int GetRoadHeight(Vector2 p, bool roundUp)
	{
		return GetRoadHeight(Mathf.FloorToInt(p.x / RoadSize), Mathf.FloorToInt(p.y / RoadSize), roundUp);
	}

	public int GetRoadHeight(int x, int y, bool roundUp)
	{
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize)
		{
			int num = RoadHeight[x, y];
			if (num % 2 == 1)
			{
				if (!roundUp)
				{
					return num - 1;
				}
				return num + 1;
			}
			return num;
		}
		return -1;
	}

	public int GetRoadHeightNoRamps(int x, int y)
	{
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize)
		{
			int num = RoadHeight[x, y];
			if (num > 0)
			{
				byte road = GetRoad(x, y, num);
				while (num > 0 && RaiseDirection(road) > 0)
				{
					num--;
					road = GetRoad(x, y, num);
				}
			}
			return num;
		}
		return -1;
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		_lampPool = new ObjectPool<RoadLightScript>(() => UnityEngine.Object.Instantiate(LampPrefab), delegate(RoadLightScript x)
		{
			x.gameObject.SetActive(true);
		}, delegate(RoadLightScript x)
		{
			x.gameObject.SetActive(false);
		});
	}

	private void InitStuff()
	{
		if (RoadSupports == null)
		{
			RoadSupports = new GameObject[GridSize + 1, GridSize + 1];
		}
		if (RoadHeight != null)
		{
			return;
		}
		RoadHeight = new int[GridSize, GridSize];
		for (int i = 0; i < GridSize; i++)
		{
			for (int j = 0; j < GridSize; j++)
			{
				RoadHeight[i, j] = -1;
			}
		}
	}

	public void Generate()
	{
		InitStuff();
		if (GameData.LoadBuildingOnLoad || Deserialized)
		{
			return;
		}
		bool multiplayerMode = GameData.MultiplayerMode;
		RoadMap = new byte[Floors][,];
		ObjectMap = new RoadSegment[Floors][,];
		for (int i = 0; i < Floors; i++)
		{
			RoadMap[i] = new byte[GridSize, GridSize];
			ObjectMap[i] = new RoadSegment[GridSize, GridSize];
		}
		for (int j = 0; j < GridSize; j++)
		{
			PlaceRoad(0, j, 0, 1);
		}
		for (int k = 0; k < GridSize; k++)
		{
			PlaceRoad(GridSize - 1, k, 0, 1);
		}
		for (int l = 1; l < GridSize - 1; l++)
		{
			PlaceRoad(l, 0, 0, 1);
			PlaceRoad(l, GridSize - 1, 0, 1);
		}
		if (GameData.Environment == GameData.EnvironmentType.City)
		{
			int num = ((!(GameData.RNDValue > 0.5f)) ? 1 : (-2));
			List<Rect> list = new List<Rect>();
			PlaceLine(false, 1, GridSize - 1, 1, GridSize - 1, list, GridSize / 2 + num, 5, multiplayerMode);
			int num2 = list.Count / 4;
			List<KeyValuePair<Rect, float>> list2 = new List<KeyValuePair<Rect, float>>();
			List<Rect> list3 = new List<Rect> { list.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(16f, 128f))) };
			if (multiplayerMode)
			{
				list3.Add(list.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(128f, 16f))));
				list3.Add(list.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(240f, 128f))));
				list3.Add(list.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(128f, 240f))));
			}
			for (int num3 = 0; num3 < list3.Count; num3++)
			{
				list.Remove(list3[num3]);
			}
			float num4 = RoadBuildCube.ActualRoadCost(1, 0);
			for (int num5 = 0; num5 < num2; num5++)
			{
				Rect random = list.GetRandom(GameData.RND);
				list.Remove(random);
				Rect key = new Rect(random.x * RoadSize, random.y * RoadSize, random.width * RoadSize, random.height * RoadSize);
				list2.Add(new KeyValuePair<Rect, float>(key, random.width * random.height * num4 * 0.5f));
				ForcePlaceRoad(random, 0, (byte)((GameData.RNDValue > 0.5f) ? 2u : 3u));
			}
			CheckUnreachable.Clear();
			list = list.Select((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize)).ToList();
			List<KeyValuePair<Rect, float>> collection = PlaceBuildings(list, multiplayerMode);
			GameSettings.Instance.SpawnTreeAreas(list);
			if (!GameSettings.Instance.RNDString.StartsWith("NOLAKES"))
			{
				for (int num6 = 0; num6 < 2; num6++)
				{
					int index = GameData.RNDRange(0, list.Count);
					CreateLake(list[index], 0.66f);
					list.RemoveAt(index);
				}
			}
			int num7 = -1;
			float num8 = float.MaxValue;
			int num9 = -1;
			float num10 = float.MaxValue;
			Vector2 p = GameSettings.Instance.BusStopSign.transform.position.FlattenVector3();
			float num11 = Mathf.Sqrt(Subway.MaxDistanceSq);
			for (int num12 = 0; num12 < list.Count; num12++)
			{
				Rect r = list[num12];
				if (!(r.width >= 8f) || !(r.height >= 8f))
				{
					continue;
				}
				float num13 = r.width * r.height;
				if (r.DistanceToClosestCorner(p) < num11)
				{
					if (num13 < num8)
					{
						num8 = num13;
						num7 = num12;
					}
				}
				else if (num13 < num10)
				{
					num9 = num12;
					num10 = num13;
				}
			}
			if (num9 == -1 && num7 >= 0)
			{
				num9 = num7;
			}
			if (num9 >= 0)
			{
				Rect rect = list[num9];
				int num14 = GameData.RNDRange(0, 3) - 1;
				int num15 = GameData.RNDRange(0, 3) - 1;
				Vector2 zero = Vector2.zero;
				if (num14 == 0 && num15 == 0)
				{
					if (GameData.RNDValue > 0.5f)
					{
						num14 = ((GameData.RNDValue > 0.5f) ? 1 : (-1));
					}
					else
					{
						num15 = ((GameData.RNDValue > 0.5f) ? 1 : (-1));
					}
				}
				zero = ((num14 == 0 || num15 == 0) ? new Vector2(num14, num15) : ((GameData.RNDValue > 0.5f) ? new Vector2(num14, 0f) : new Vector2(0f, num15)));
				Vector2 v = new Vector2((num14 < 0) ? (rect.xMin + 4f) : ((num14 > 0) ? (rect.xMax - 4f) : rect.center.x), (num15 < 0) ? (rect.yMin + 4f) : ((num15 > 0) ? (rect.yMax - 4f) : rect.center.y));
				Subway subway = UnityEngine.Object.Instantiate(SubwayPrefab);
				subway.transform.position = v.ToVector3(0f);
				subway.transform.rotation = Quaternion.LookRotation(zero.ToVector3(0f));
				subway.ClearTrees();
				Landmarks.Add(subway);
				list.RemoveAt(num9);
			}
			TimeOfDay.Instance.GroundTopDirty = true;
			if (!GameSettings.Instance.EditMode)
			{
				List<KeyValuePair<Rect, float>> list4 = new List<KeyValuePair<Rect, float>>();
				list4.AddRange(list.Select((Rect x) => new KeyValuePair<Rect, float>(x, 0f)));
				list4.AddRange(collection);
				list4.AddRange(list2);
				List<Rect> list5 = new List<Rect>
				{
					new Rect(8f, 120f, 16f, 16f)
				};
				int count = list4.Count;
				if (multiplayerMode)
				{
					list4.Add(new KeyValuePair<Rect, float>(new Rect(120f, 8f, 16f, 16f), 0f));
					list4.Add(new KeyValuePair<Rect, float>(new Rect(232f, 120f, 16f, 16f), 0f));
					list4.Add(new KeyValuePair<Rect, float>(new Rect(120f, 232f, 16f, 16f), 0f));
					list5.Add(new Rect(120f, 8f, 16f, 16f));
					list5.Add(new Rect(232f, 120f, 16f, 16f));
					list5.Add(new Rect(120f, 232f, 16f, 16f));
				}
				list4.Add(new KeyValuePair<Rect, float>(new Rect(8f, 120f, 16f, 16f), 0f));
				GameSettings.Instance.Plots = PlotArea.PlotsFromRects(list4, count);
				for (int num16 = 0; num16 < list3.Count; num16++)
				{
					GameSettings.Instance.Plots[GameSettings.Instance.Plots.Count - num16 - 1].Price = (multiplayerMode ? 0f : PlotArea.StartPlotPrice);
				}
				PlotArea plotArea = GameSettings.Instance.Plots[GameSettings.Instance.Plots.Count - 1];
				for (int num17 = 0; num17 < list3.Count; num17++)
				{
					Rect rect2 = list3[num17];
					List<Vector2> list6 = CreatePlotDiff(new Rect(rect2.x * RoadSize, rect2.y * RoadSize, rect2.width * RoadSize, rect2.height * RoadSize), list5[num17]);
					if (list6 != null)
					{
						GameSettings.Instance.Plots.Add(new PlotArea(list6.Select((Vector2 x) => new PlotArea.PlotPoint(x.x, x.y)).ToArray()));
					}
				}
				GameSettings.Instance.InitPlots(false);
				GameSettings.Instance.BuyPlot(plotArea, true);
				if (GameData.MultiplayerMode)
				{
					NetworkManager.Self.StartPlot = plotArea.ID;
				}
			}
		}
		if (GameData.Environment == GameData.EnvironmentType.Town)
		{
			int num18 = ((GameData.RNDValue > 0.5f) ? (-3) : 2);
			List<Rect> list7 = new List<Rect>();
			PlaceLine(false, 1, GridSize - 1, 1, GridSize - 1, list7, GridSize / 2 + num18, 10, multiplayerMode);
			List<Rect> list8 = new List<Rect> { list7.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(16f, 128f))) };
			if (multiplayerMode)
			{
				list8.Add(list7.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(128f, 16f))));
				list8.Add(list7.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(240f, 128f))));
				list8.Add(list7.FirstOrDefault((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize).Contains(new Vector2(128f, 240f))));
			}
			for (int num19 = 0; num19 < list8.Count; num19++)
			{
				list7.Remove(list8[num19]);
			}
			list7 = list7.Select((Rect x) => new Rect(x.x * RoadSize, x.y * RoadSize, x.width * RoadSize, x.height * RoadSize)).ToList();
			List<Rect> list9 = new List<Rect>();
			for (int num20 = 0; num20 < 2; num20++)
			{
				int index2 = GameData.RNDRange(0, list7.Count);
				list9.Add(list7[index2]);
				list7.RemoveAt(index2);
			}
			GameSettings.Instance.SpawnTreeAreas(list9);
			if (!GameSettings.Instance.RNDString.StartsWith("NOLAKES"))
			{
				int index3 = GameData.RNDRange(0, list9.Count);
				CreateLake(list9[index3], 0.33f);
				list9.RemoveAt(index3);
			}
			TimeOfDay.Instance.GroundTopDirty = true;
			List<PlotArea> list10 = PlotArea.PlotsFromRects(list7);
			List<Rect> list11 = new List<Rect>
			{
				new Rect(8f, 120f, 16f, 16f)
			};
			if (multiplayerMode)
			{
				list11.Add(new Rect(120f, 8f, 16f, 16f));
				list11.Add(new Rect(232f, 120f, 16f, 16f));
				list11.Add(new Rect(120f, 232f, 16f, 16f));
			}
			for (int num21 = 0; num21 < list8.Count; num21++)
			{
				Rect rect3 = list8[num21];
				List<Rect> list12 = CreatePlotDiffs(new Rect(rect3.x * RoadSize, rect3.y * RoadSize, rect3.width * RoadSize, rect3.height * RoadSize), list11[num21]);
				if (list12 != null && list12.Count > 0)
				{
					list10.AddRange(PlotArea.PlotsFromRects(list12));
				}
			}
			list10 = PlotArea.DividePlots(list10, 16f);
			SpawnHouses(list10);
			if (!GameSettings.Instance.EditMode)
			{
				list10.AddRange(PlotArea.DividePlots(PlotArea.PlotsFromRects(list9), 32f));
				if (multiplayerMode)
				{
					list10.Add(new PlotArea(new Rect(120f, 8f, 16f, 16f).ToPolygon().SelectInPlace((Vector2 x) => new PlotArea.PlotPoint(x)))
					{
						PlayerStarterPlot = true,
						Price = 0f
					});
					list10.Add(new PlotArea(new Rect(232f, 120f, 16f, 16f).ToPolygon().SelectInPlace((Vector2 x) => new PlotArea.PlotPoint(x)))
					{
						PlayerStarterPlot = true,
						Price = 0f
					});
					list10.Add(new PlotArea(new Rect(120f, 232f, 16f, 16f).ToPolygon().SelectInPlace((Vector2 x) => new PlotArea.PlotPoint(x)))
					{
						PlayerStarterPlot = true,
						Price = 0f
					});
				}
				list10.Add(new PlotArea(new Rect(8f, 120f, 16f, 16f).ToPolygon().SelectInPlace((Vector2 x) => new PlotArea.PlotPoint(x)))
				{
					PlayerStarterPlot = true
				});
				GameSettings.Instance.Plots = list10;
				GameSettings.Instance.InitPlots(true);
				PlotArea plotArea2 = GameSettings.Instance.Plots[GameSettings.Instance.Plots.Count - 1];
				plotArea2.Price = (multiplayerMode ? 0f : PlotArea.StartPlotPrice);
				GameSettings.Instance.BuyPlot(plotArea2, true);
				if (GameData.MultiplayerMode)
				{
					NetworkManager.Self.StartPlot = plotArea2.ID;
				}
			}
		}
		GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
		UpdateTreeRemoval();
		GrassSystem.Instance.Init(new Vector2(GameData.RNDValue, GameData.RNDValue));
	}

	private void Start()
	{
		InitStuff();
		_sidewalks = new SideWalkGroup[Floors][,];
		_sideWalkSize = GridSize / SidewalkSplit;
		for (int i = 0; i < Floors; i++)
		{
			_sidewalks[i] = new SideWalkGroup[SidewalkSplit, SidewalkSplit];
			for (int j = 0; j < SidewalkSplit; j++)
			{
				for (int k = 0; k < SidewalkSplit; k++)
				{
					_sidewalks[i][j, k] = new SideWalkGroup(j * _sideWalkSize, k * _sideWalkSize, _sideWalkSize, _sideWalkSize, i, base.transform);
				}
			}
		}
	}

	private IList<Vector2> MakeLakeReady(Rect plot, float coverage)
	{
		if (plot.width > 16f && plot.height > 16f)
		{
			int num = Mathf.CeilToInt(plot.width / 16f);
			int num2 = Mathf.CeilToInt(plot.height / 16f);
			float num3 = plot.width / (float)num;
			float num4 = plot.height / (float)num2;
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					if (GameData.RNDValue < coverage)
					{
						float num5 = plot.xMin + (float)i * num3;
						float num6 = plot.yMin + (float)j * num4;
						list.Add(new Vector2(num5, num6));
						list.Add(new Vector2(num5 + num3, num6));
						list.Add(new Vector2(num5 + num3, num6 + num4));
						list.Add(new Vector2(num5, num6 + num4));
					}
				}
			}
			if (list.Count > 4)
			{
				for (int k = 0; k < list.Count; k++)
				{
					for (int l = k + 1; l < list.Count; l++)
					{
						if ((list[k] - list[l]).sqrMagnitude < 0.1f)
						{
							list.RemoveAt(k);
							k--;
							break;
						}
					}
				}
				return Utilities.ComputeConcaveHull(list);
			}
		}
		return plot.ToPolygon();
	}

	private GameObject CreateSupport(float x, float y, float offX, float offY, int height)
	{
		GameObject gameObject;
		if (_roadSupportPool.Count > 0)
		{
			gameObject = _roadSupportPool[_roadSupportPool.Count - 1];
			_roadSupportPool.RemoveAt(_roadSupportPool.Count - 1);
			gameObject.SetActive(true);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate(RoadSupportPrefab);
		}
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.position = new Vector3(x * RoadSize + offX, 0f, y * RoadSize + offY);
		gameObject.transform.GetChild(0).transform.localScale = new Vector3(1f, (float)(height * 4) - 0.01f, 1f);
		return gameObject;
	}

	private void KillSupport(GameObject support)
	{
		if (support != null)
		{
			support.SetActive(false);
			_roadSupportPool.Add(support);
		}
	}

	private void UpdateSupports(Rect rect)
	{
		int num = Mathf.Max(0, (int)rect.xMin - 1);
		int num2 = Mathf.Max(0, (int)rect.yMin - 1);
		int num3 = Mathf.Min(GridSize, (int)rect.xMax + 1);
		int num4 = Mathf.Min(GridSize, (int)rect.yMax + 1);
		for (int i = num; i < num3; i++)
		{
			for (int j = num2; j < num4; j++)
			{
				KillSupport(RoadSupports[i, j]);
				RoadSupports[i, j] = null;
				int roadHeight = GetRoadHeight(i, j, false);
				int roadHeight2 = GetRoadHeight(i - 1, j, false);
				int roadHeight3 = GetRoadHeight(i, j - 1, false);
				int roadHeight4 = GetRoadHeight(i - 1, j - 1, false);
				int num5 = Mathf.Max(roadHeight, roadHeight2, roadHeight3, roadHeight4);
				if (num5 > 0)
				{
					bool flag = roadHeight >= num5;
					bool flag2 = roadHeight2 >= num5;
					bool flag3 = roadHeight3 >= num5;
					bool num6 = roadHeight4 >= num5;
					float num7 = 0f;
					if (num6 || flag2)
					{
						num7 -= 0.25f;
					}
					if (flag3 || flag)
					{
						num7 += 0.25f;
					}
					float num8 = 0f;
					if (num6 || flag3)
					{
						num8 -= 0.25f;
					}
					if (flag2 || flag)
					{
						num8 += 0.25f;
					}
					RoadSupports[i, j] = CreateSupport(i, j, num7, num8, num5);
				}
			}
		}
	}

	private void SpawnHouses(List<PlotArea> plots)
	{
		for (int i = 0; i < plots.Count; i++)
		{
			PlotArea plotArea = plots[i];
			if (plotArea.Polygon.Length == 4 && plotArea.Area > 100f)
			{
				int num = GameData.RNDRange(0, 4);
				bool flag = false;
				for (int j = 0; j < 4; j++)
				{
					int num2 = (j + num) % 4;
					Vector2 vector = plotArea.Polygon[num2];
					Vector2 vector2 = plotArea.Polygon[(num2 + 1) % 4] - vector;
					Vector2 vector3 = vector + vector2 * 0.5f;
					Vector2 vector4 = vector3 - vector2.normalized.Turn90();
					if (GetRoad(vector4, 0) > 0)
					{
						BurbHouse burbHouse = PlaceHouse(vector3.ToVector3(0f), Quaternion.LookRotation((vector4 - vector3).ToVector3(0f)), plotArea.Polygon, plotArea.Area);
						if (burbHouse != null)
						{
							plotArea.AddonCost = burbHouse.Cost;
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					GameSettings.Instance.SpawnTreePolygon(plotArea.Polygon);
				}
			}
			else
			{
				GameSettings.Instance.SpawnTreePolygon(plotArea.Polygon);
			}
		}
	}

	public BurbHouse PlaceHouse(int house, Vector3 p, Quaternion rot)
	{
		BurbHouse burbHouse = UnityEngine.Object.Instantiate(BurbHousePrefabs[house]);
		burbHouse.transform.SetPositionAndRotation(p, rot);
		burbHouse.Init();
		Landmarks.Add(burbHouse);
		return burbHouse;
	}

	private BurbHouse PlaceHouse(Vector3 p, Quaternion rot, Vector2[] polygon, float area)
	{
		Matrix4x4 matrix4x = Matrix4x4.TRS(p, rot, Vector3.one);
		for (int i = 0; i < BurbHousePrefabs.Length; i++)
		{
			BurbHouse burbHouse = BurbHousePrefabs[i];
			if (burbHouse.LowerAreaReq > area)
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < burbHouse.Bounds.Length; j++)
			{
				if (!Utilities.IsInside(matrix4x.MultiplyPoint(burbHouse.Bounds[j].ToVector3(0f)).FlattenVector3(), polygon))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				BurbHouse burbHouse2 = UnityEngine.Object.Instantiate(burbHouse);
				burbHouse2.transform.SetPositionAndRotation(p, rot);
				burbHouse2.Init(polygon);
				Landmarks.Add(burbHouse2);
				return burbHouse2;
			}
		}
		return null;
	}

	private List<Rect> CreatePlotDiffs(Rect surPlot, Rect plot)
	{
		List<Rect> list = new List<Rect>();
		if (surPlot == plot)
		{
			return list;
		}
		list.Add(Rect.MinMaxRect(surPlot.xMin, surPlot.yMin, plot.xMin, plot.yMin));
		list.Add(Rect.MinMaxRect(plot.xMin, surPlot.yMin, plot.xMax, plot.yMin));
		list.Add(Rect.MinMaxRect(plot.xMax, surPlot.yMin, surPlot.xMax, plot.yMin));
		list.Add(Rect.MinMaxRect(surPlot.xMin, plot.yMin, plot.xMin, plot.yMax));
		list.Add(Rect.MinMaxRect(surPlot.xMin, plot.yMax, plot.xMin, surPlot.yMax));
		list.Add(Rect.MinMaxRect(plot.xMin, plot.yMax, plot.xMax, surPlot.yMax));
		list.Add(Rect.MinMaxRect(plot.xMax, plot.yMax, surPlot.xMax, surPlot.yMax));
		list.Add(Rect.MinMaxRect(plot.xMax, plot.yMin, surPlot.xMax, plot.yMax));
		for (int i = 0; i < list.Count; i++)
		{
			Rect rect = list[i];
			if (rect.width == 0f || rect.height == 0f)
			{
				list.RemoveAt(i);
				i--;
			}
		}
		list.Sort((Rect x, Rect y) => y.size.sqrMagnitude.CompareTo(x.size.sqrMagnitude));
		for (int num = 0; num < list.Count; num++)
		{
			for (int num2 = num + 1; num2 < list.Count; num2++)
			{
				Rect r;
				if (CanMerge(list[num], list[num2], out r))
				{
					list[num] = r;
					list.RemoveAt(num2);
					num2--;
				}
			}
		}
		return list;
	}

	private bool CanMerge(Rect r1, Rect r2, out Rect r3)
	{
		r3 = Rect.zero;
		if (r1.yMin == r2.yMin && r1.yMax == r2.yMax)
		{
			if (r1.xMax == r2.xMin)
			{
				r3 = Rect.MinMaxRect(r1.xMin, r1.yMin, r2.xMax, r1.yMax);
				return true;
			}
			if (r1.xMin == r2.xMax)
			{
				r3 = Rect.MinMaxRect(r2.xMin, r1.yMin, r1.xMax, r1.yMax);
				return true;
			}
		}
		else if (r1.xMin == r2.xMin && r1.xMax == r2.xMax)
		{
			if (r1.yMax == r2.yMin)
			{
				r3 = Rect.MinMaxRect(r1.xMin, r1.yMin, r1.xMax, r2.yMax);
				return true;
			}
			if (r1.yMin == r2.yMax)
			{
				r3 = Rect.MinMaxRect(r1.xMin, r2.yMin, r1.xMax, r1.yMax);
				return true;
			}
		}
		return false;
	}

	private List<Vector2> CreatePlotDiff(Rect surPlot, Rect cutoff)
	{
		if (surPlot == cutoff)
		{
			return null;
		}
		Vector2[] l = surPlot.ToPolygon();
		Vector2[] l2 = cutoff.ToPolygon();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPath(l.Select((Vector2 x) => new IntPoint(x.x, x.y)).ToList(), PolyType.ptSubject, true);
		clipper.AddPath(l2.Select((Vector2 x) => new IntPoint(x.x, x.y)).ToList(), PolyType.ptClip, true);
		PolyTree polyTree = new PolyTree();
		clipper.Execute(ClipType.ctDifference, polyTree, PolyFillType.pftPositive, PolyFillType.pftPositive);
		return polyTree.Childs[0].Contour.Select((IntPoint x) => new Vector2(x.X, x.Y)).ToList();
	}

	public void UpdateTreeRemoval()
	{
		if (RoadHeight == null)
		{
			return;
		}
		for (int i = 0; i < GridSize; i++)
		{
			for (int j = 0; j < GridSize; j++)
			{
				if (RoadHeight[i, j] >= 0)
				{
					RemoveTrees(i, j, null);
				}
			}
		}
	}

	private List<KeyValuePair<Rect, float>> PlaceBuildings(List<Rect> blobs, bool online)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = blobs.Count / 2;
		List<KeyValuePair<Rect, float>> list = new List<KeyValuePair<Rect, float>>();
		for (int i = 0; i < num; i++)
		{
			Rect random = blobs.GetRandom(GameData.RND);
			blobs.Remove(random);
			SkraperGen skraperGen = PlaceBuilding(random);
			if (online || GameData.RNDValue > 0.5f)
			{
				list.Add(new KeyValuePair<Rect, float>(random, random.width * random.height * skraperGen.Height * 100f));
			}
		}
		Debug.Log("Skyscraper placement time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime());
		return list;
	}

	public SkraperGen PlaceBuilding(Rect blob)
	{
		SkraperGen component = UnityEngine.Object.Instantiate(BuildingPrefab).GetComponent<SkraperGen>();
		component.Init(blob, GameData.RND.Next(), true);
		Landmarks.Add(component);
		return component;
	}

	public List<UndoObject.UndoAction> UpdateScrapers()
	{
		List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
		for (int i = 0; i < Landmarks.Count; i++)
		{
			Landmark landmark = Landmarks[i];
			if (landmark.RemoveOnBuy() && GameSettings.Instance.PlayerOwnedPoint(landmark.Center()))
			{
				list.Add(new UndoObject.UndoAction(landmark, true));
				landmark.DestroyLandmark();
				Landmarks.RemoveAt(i);
				i--;
				GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
			}
		}
		return list;
	}

	private void PlaceLine(bool horz, int rangeMin, int rangeMax, int borderMin, int borderMax, List<Rect> areas, int mid = -1, int stop = 5, bool forceNext = false)
	{
		if (mid == -1)
		{
			int num = (rangeMax - rangeMin) / 4;
			num = GameData.RNDRange(-num, num);
			mid = (rangeMin + rangeMax) / 2 + num;
		}
		Rect r = ((!horz) ? new Rect(borderMin, mid, borderMax - borderMin, 1f) : new Rect(mid, borderMin, 1f, borderMax - borderMin));
		ForcePlaceRoad(r, 0, 1);
		if (borderMax - borderMin > stop)
		{
			PlaceLine(!horz, borderMin, borderMax, rangeMin, mid, areas, forceNext ? (GridSize / 2 + ((!(GameData.RNDValue > 0.5f)) ? 1 : (-2))) : (-1), stop);
			PlaceLine(!horz, borderMin, borderMax, mid + 1, rangeMax, areas, forceNext ? (GridSize / 2 + ((!(GameData.RNDValue > 0.5f)) ? 1 : (-2))) : (-1), stop);
		}
		else if (horz)
		{
			areas.Add(new Rect(rangeMin, borderMin, mid - rangeMin, borderMax - borderMin));
			areas.Add(new Rect(mid + 1, borderMin, rangeMax - mid - 1, borderMax - borderMin));
		}
		else
		{
			areas.Add(new Rect(borderMin, rangeMin, borderMax - borderMin, mid - rangeMin));
			areas.Add(new Rect(borderMin, mid + 1, borderMax - borderMin, rangeMax - mid - 1));
		}
	}

	private void OnDestory()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		if (_sidewalks == null)
		{
			return;
		}
		for (int i = 0; i < _sidewalks.Length; i++)
		{
			SideWalkGroup[,] array = _sidewalks[i];
			for (int j = 0; j < array.GetLength(0); j++)
			{
				for (int k = 0; k < array.GetLength(1); k++)
				{
					array[j, k].Destroy();
				}
			}
		}
	}

	private RoadNode FindFirst(RoadSegment seg, bool getOut)
	{
		if (getOut)
		{
			if (seg.EastOut != null)
			{
				return seg.EastOut;
			}
			if (seg.NorthOut != null)
			{
				return seg.NorthOut;
			}
			if (seg.WestOut != null)
			{
				return seg.WestOut;
			}
			if (seg.SouthOut != null)
			{
				return seg.SouthOut;
			}
		}
		else
		{
			if (seg.WestIn != null)
			{
				return seg.WestIn;
			}
			if (seg.SouthIn != null)
			{
				return seg.SouthIn;
			}
			if (seg.EastIn != null)
			{
				return seg.EastIn;
			}
			if (seg.NorthIn != null)
			{
				return seg.NorthIn;
			}
		}
		return null;
	}

	private static float RoadNodeDist(Vector3 a, Vector3 b)
	{
		return Vector3.Distance(a, b);
	}

	public List<Vector3> FindPath(RoadNode p1, RoadNode p2, bool cache)
	{
		KeyValuePair<RoadNode, RoadNode> key = new KeyValuePair<RoadNode, RoadNode>(p1, p2);
		List<Vector3> value;
		if (cache && CachedPaths.TryGetValue(key, out value))
		{
			return value;
		}
		object target = p2.self.Tag;
		List<Vector3> list = NodePathFinding<Vector3>.FindPath(p1.self, p2.self, RoadNodeDist, RoadNodeDist, (object tt) => !((RoadNode)tt).Parking || tt == target);
		if (list != null)
		{
			List<Vector3> list2 = list.ToList();
			NodePathFinding<Vector3>.Release(list);
			for (int num = 1; num < list2.Count - 1; num++)
			{
				if ((list2[num] - list2[num + 1]).magnitude < 1f)
				{
					list2.RemoveAt(num);
					num--;
				}
			}
			if (cache)
			{
				FixPathEnds(list2, !p1.Parking, !p2.Parking);
				CachedPaths[key] = list2;
			}
			return list2;
		}
		return null;
	}

	public bool FindPath(RoadSegment p1, RoadSegment p2, bool home, List<Vector3> pathRes)
	{
		KeyValuePair<RoadSegment, RoadSegment> key = new KeyValuePair<RoadSegment, RoadSegment>(p2, p1);
		List<Vector3> value;
		if (_bikePathCache.TryGetValue(key, out value))
		{
			if (pathRes != null)
			{
				pathRes.Clear();
				pathRes.AddRange(value.ReverseEnum());
			}
			return true;
		}
		key = new KeyValuePair<RoadSegment, RoadSegment>(p1, p2);
		if (_bikePathCache.TryGetValue(key, out value))
		{
			if (pathRes != null)
			{
				pathRes.Clear();
				pathRes.AddRange(value);
			}
			return true;
		}
		List<Vector3> list = NodePathFinding<Vector3>.FindPath(p1.Self, p2.Self, RoadNodeDist, RoadNodeDist, (object tt) => tt is RoadSegment);
		RoadNode[] array = (home ? p1.Parking : p2.Parking);
		if (list != null)
		{
			for (int num = 0; num < array.Length; num++)
			{
				array[num].Unreachable = false;
			}
			if (pathRes != null)
			{
				pathRes.Clear();
				pathRes.AddRange(list);
			}
			_bikePathCache[key] = list;
			NodePathFinding<Vector3>.Claim(list);
			return true;
		}
		foreach (RoadNode item in array)
		{
			HUD.Instance.UnreachableParking.Add(item);
		}
		return false;
	}

	public RoadNode FindRandomParking()
	{
		return (from x in Parking
			where x.Value != ParkingState.Closed && !x.Key.Taken
			select x.Key).GetRandom();
	}

	public IEnumerable<RoadNode> GetInputs()
	{
		for (int i = 0; i < InputList.Count; i++)
		{
			yield return InputList[i];
		}
	}

	public IEnumerable<RoadNode> GetOutputs()
	{
		for (int i = 0; i < OutputList.Count; i++)
		{
			yield return OutputList[i];
		}
	}

	public RoadNode GetRandomInput()
	{
		return InputList.GetRandom();
	}

	public List<Vector3> MakeRoadPlan(ref RoadNode goal)
	{
		if (InputList.Count == 0)
		{
			return null;
		}
		if (goal != null)
		{
			RoadNode g = goal;
			foreach (RoadNode item in InputList.OrderBy((RoadNode x) => x.GetPos().ManhattanDist(g.GetPos())))
			{
				List<Vector3> list = FindPath(item, goal, goal.Parking);
				if (list != null)
				{
					goal.Unreachable = false;
					return list;
				}
			}
			if (goal.Parking)
			{
				HUD.Instance.UnreachableParking.Add(goal);
			}
			else
			{
				goal.Unreachable = true;
			}
			return null;
		}
		List<int> list2 = InputList.Select((RoadNode x, int i) => i).ToList();
		int random = list2.GetRandom();
		list2.Remove(random);
		int random2 = list2.GetRandom();
		goal = OutputList[random2];
		return FindPath(InputList[random], goal, true);
	}

	public static void FixPathEnds(List<Vector3> path, bool start, bool end)
	{
		if (path.Count >= 3)
		{
			if (start)
			{
				path[0] += (path[0] - path[1]).normalized * 3f;
			}
			if (end)
			{
				path[path.Count - 1] = path[path.Count - 1] + (path[path.Count - 1] - path[path.Count - 2]).normalized * 3f;
			}
		}
	}

	public List<Vector3> GetHome(RoadNode start)
	{
		foreach (RoadNode item in OutputList.OrderBy((RoadNode x) => x.GetPos().ManhattanDist(start.GetPos())))
		{
			List<Vector3> list = FindPath(start, item, start.Parking);
			if (list != null)
			{
				return list;
			}
		}
		if (start.Parking)
		{
			HUD.Instance.UnreachableParking.Add(start);
		}
		else
		{
			start.Unreachable = true;
		}
		return null;
	}

	public void ClearDataColor()
	{
		for (int i = 0; i < Floors; i++)
		{
			RoadSegment[,] array = ObjectMap[i];
			for (int j = 0; j < array.GetLength(0); j++)
			{
				for (int k = 0; k < array.GetLength(1); k++)
				{
					RoadSegment roadSegment = array[j, k];
					if (roadSegment != null)
					{
						roadSegment.SetDataColor(Color.white);
					}
				}
			}
		}
	}

	private void UpdateDataColor()
	{
		for (int i = 0; i < Floors; i++)
		{
			RoadSegment[,] array = ObjectMap[i];
			for (int j = 0; j < array.GetLength(0); j++)
			{
				for (int k = 0; k < array.GetLength(1); k++)
				{
					RoadSegment roadSegment = array[j, k];
					if (roadSegment != null)
					{
						roadSegment.SetDataColor(DataOverlay.Instance.ActiveOverlay.RFunc(roadSegment));
					}
				}
			}
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_parkingDirty)
		{
			UpdateParkingAvailability(true);
		}
		if (CheckUnreachable.Count > 0)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup - realtimeSinceStartup < 1f / 90f && CheckUnreachable.Count > 0)
			{
				RoadNode roadNode = CheckUnreachable[CheckUnreachable.Count - 1];
				CheckUnreachable.RemoveAt(CheckUnreachable.Count - 1);
				bool flag = true;
				for (int i = 0; i < InputList.Count; i++)
				{
					if (roadNode.Bike ? FindPath(InputList[i].Parent, roadNode.Parent, false, null) : (FindPath(InputList[i], roadNode, false) != null))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					if (roadNode.Bike)
					{
						for (int j = 0; j < roadNode.Parent.Parking.Length; j++)
						{
							RoadNode item = roadNode.Parent.Parking[j];
							HUD.Instance.UnreachableParking.Add(item);
							CheckUnreachable.Remove(item);
						}
					}
					else
					{
						HUD.Instance.UnreachableParking.Add(roadNode);
					}
				}
				else if (roadNode.Bike)
				{
					for (int k = 0; k < roadNode.Parent.Parking.Length; k++)
					{
						RoadNode item2 = roadNode.Parent.Parking[k];
						HUD.Instance.UnreachableParking.Remove(item2);
						CheckUnreachable.Remove(item2);
					}
				}
				else
				{
					roadNode.Unreachable = false;
					HUD.Instance.UnreachableParking.Remove(roadNode);
				}
			}
		}
		if (CheckAIAllowed && !AIAllowedBeingChecked)
		{
			AIAllowedBeingChecked = true;
			CheckAIAllowed = false;
			ThreadPool.QueueUserWorkItem(RefreshAIAllowed);
		}
		if (_sidewalks != null)
		{
			for (int l = 0; l < _sidewalks.Length; l++)
			{
				SideWalkGroup[,] array = _sidewalks[l];
				for (int m = 0; m < array.GetLength(0); m++)
				{
					for (int n = 0; n < array.GetLength(1); n++)
					{
						array[m, n].Update(GameSettings.Instance.ActiveFloor);
					}
				}
			}
		}
		if (DataOverlay.HasActive && DataOverlay.Instance.ActiveOverlay.RFunc != null)
		{
			UpdateDataColor();
		}
	}

	public void SetSidewalkDirty(int x, int y, int floor)
	{
		if (_sidewalks != null && x >= 0 && x < GridSize && y >= 0 && y < GridSize && floor >= 0 && floor < Floors)
		{
			_sidewalks[floor][x / _sideWalkSize, y / _sideWalkSize].Dirty = true;
		}
	}

	private void OnDrawGizmos()
	{
		if (Points != null)
		{
			Gizmos.color = Color.red;
			for (int i = 0; i < Points.Count - 1; i++)
			{
				Vector2 vector = Points[i];
				Vector2 vector2 = Points[i + 1];
				Gizmos.DrawLine(new Vector3(vector.x, 1f, vector.y), new Vector3(vector2.x, 1f, vector2.y));
			}
		}
		Gizmos.color = Color.cyan;
		foreach (List<Vector3> value in CachedPaths.Values)
		{
			Gizmos.DrawSphere(value[0], 0.1f);
			for (int j = 0; j < value.Count - 1; j++)
			{
				Vector3 vector3 = value[j];
				Vector3 vector4 = value[j + 1];
				Gizmos.DrawLine(vector3, vector4);
				Gizmos.DrawSphere(vector4, 0.1f);
			}
		}
		Gizmos.color = Color.white;
	}

	public override string WriteName()
	{
		return "RoadManager";
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		InitStuff();
		if (networkMode != LoadType.NetworkClient)
		{
			byte[][,] val;
			if (dictionary.TryGet<byte[][,]>("NewRoads", out val))
			{
				RoadMap = val;
				if (RoadMap.Length != Floors)
				{
					byte[][,] array = new byte[Floors][,];
					for (int i = 0; i < Floors; i++)
					{
						array[i] = ((i < RoadMap.Length) ? RoadMap[i] : new byte[GridSize, GridSize]);
					}
					RoadMap = array;
				}
				ObjectMap = new RoadSegment[Floors][,];
				for (int j = 0; j < Floors; j++)
				{
					ObjectMap[j] = new RoadSegment[GridSize, GridSize];
				}
				for (int k = 0; k < Floors; k++)
				{
					for (int l = 0; l < GridSize; l++)
					{
						for (int m = 0; m < GridSize; m++)
						{
							if (RoadMap[k][l, m] > 0)
							{
								UpdateRoad(l, m, k, true, null, false);
							}
						}
					}
					for (int n = 0; n < GridSize; n++)
					{
						for (int num = 0; num < GridSize; num++)
						{
							if (RoadMap[k][n, num] > 0)
							{
								UpdateConnections(n, num, k);
							}
						}
					}
				}
			}
			else
			{
				RoadMap = new byte[Floors][,];
				RoadMap[0] = dictionary.Get("Roads", new byte[GridSize, GridSize]);
				ObjectMap = new RoadSegment[Floors][,];
				ObjectMap[0] = new RoadSegment[GridSize, GridSize];
				for (int num2 = 1; num2 < Floors; num2++)
				{
					RoadMap[num2] = new byte[GridSize, GridSize];
					ObjectMap[num2] = new RoadSegment[GridSize, GridSize];
				}
				for (int num3 = 0; num3 < GridSize; num3++)
				{
					for (int num4 = 0; num4 < GridSize; num4++)
					{
						if (RoadMap[0][num3, num4] > 0)
						{
							UpdateRoad(num3, num4, 0, true, null, false);
						}
					}
				}
				for (int num5 = 0; num5 < GridSize; num5++)
				{
					for (int num6 = 0; num6 < GridSize; num6++)
					{
						if (RoadMap[0][num5, num6] > 0)
						{
							UpdateConnections(num5, num6, 0);
						}
					}
				}
			}
			UpdateSupports(new Rect(0f, 0f, GridSize, GridSize));
			CheckAIAllowed = true;
			CheckUnreachable.Clear();
			WriteDictionary[] array2 = dictionary.Get("Landmarks", new WriteDictionary[0]);
			foreach (WriteDictionary dict in array2)
			{
				DeserializeLandmark(dict, loading, networkMode);
			}
		}
		ParkingAssignment[] array3 = dictionary.Get("Parking2", new ParkingAssignment[0]);
		if (networkMode == LoadType.NetworkClient)
		{
			_deserializedParking = array3;
		}
		else
		{
			DeserializeParking(array3);
		}
		GrassSystem.Instance.RNDOffset = dictionary.Get("GrassOff", SVector3.Zero);
		if (networkMode == LoadType.Default || networkMode == LoadType.NetworkClient)
		{
			GameSettings.Instance.sRoomManager.PathController.Deserialize(dictionary);
		}
		return this;
	}

	public void DeserializeParking(ParkingAssignment[] parking = null)
	{
		if (parking == null)
		{
			parking = _deserializedParking;
			_deserializedParking = null;
		}
		if (parking == null)
		{
			return;
		}
		foreach (ParkingAssignment p in parking)
		{
			RoadSegment segment = GetSegment(p.X, p.Y, p.Floor);
			if (segment != null)
			{
				RoadNode roadNode = segment.Parking.FirstOrDefault((RoadNode x) => x.ID == p.ID);
				if (roadNode != null)
				{
					roadNode.Assign = p.Assignment;
				}
			}
		}
	}

	public Landmark DeserializeLandmark(WriteDictionary dict, bool loading, LoadType networkMode)
	{
		Landmark landmark = null;
		if (dict.Name.Equals("SkyScraper"))
		{
			landmark = UnityEngine.Object.Instantiate(BuildingPrefab).GetComponent<SkraperGen>();
		}
		else if (dict.Name.Equals("BurbHouse"))
		{
			landmark = UnityEngine.Object.Instantiate(BurbHousePrefabs[dict.Get("Idx", 0)]);
		}
		else if (dict.Name.Equals("Lake"))
		{
			landmark = UnityEngine.Object.Instantiate(LakePrefab);
		}
		else if (dict.Name.Equals("Subway"))
		{
			landmark = UnityEngine.Object.Instantiate(SubwayPrefab);
		}
		if (landmark != null)
		{
			Landmarks.Add(landmark);
			landmark.DeserializeThis(dict, loading, networkMode);
			return landmark;
		}
		return null;
	}

	public Landmark FindLandmark(uint did)
	{
		for (int i = 0; i < Landmarks.Count; i++)
		{
			Landmark landmark = Landmarks[i];
			if (landmark.DID == did)
			{
				return landmark;
			}
		}
		return null;
	}

	public Lake CreateLake(Rect area, float coverage)
	{
		return CreateLake(MakeLakeReady(area, coverage));
	}

	public Lake CreateLake(IList<Vector2> area)
	{
		Lake lake = UnityEngine.Object.Instantiate(LakePrefab);
		lake.Init(area);
		Landmarks.Add(lake);
		return lake;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["NewRoads"] = RoadMap;
		dictionary["Landmarks"] = Landmarks.Select((Landmark x) => x.SerializeThis(GameReader.NewLoadMode.Full, networkMode, checkDIDs)).ToArray();
		dictionary["Parking2"] = (from x in Parking.Keys
			where x.Assign != RoadNode.ParkingAssign.Anyone
			select new ParkingAssignment(x)).ToArray();
		dictionary["GrassOff"] = (SVector3)GrassSystem.Instance.RNDOffset;
		if (networkMode == LoadType.Default || networkMode == LoadType.NetworkClient)
		{
			GameSettings.Instance.sRoomManager.PathController.Serialize(dictionary);
		}
	}

	public bool CheckSideWalk(Vector3 p)
	{
		if (p.y >= 0f && p.y < (float)(Floors * 4 + 1))
		{
			int num = Mathf.FloorToInt((p.y + 1f) / 2f);
			if ((num & 1) == 0)
			{
				float num2 = p.y % 2f;
				if (num2 < 0.001f || num2 > 1.999f)
				{
					num >>= 1;
					if (num < Floors)
					{
						int num3 = Mathf.FloorToInt(p.z / RoadSize);
						int num4 = Mathf.FloorToInt(p.x / RoadSize);
						if (GetRoad(num4, num3, num) == 0)
						{
							return false;
						}
						int num5 = 0;
						float num6 = p.x - (float)num4 * RoadSize;
						if (num6 < 1f)
						{
							num5 = -1;
						}
						else if (num6 > RoadSize - 1f)
						{
							num5 = 1;
						}
						if (num5 != 0 && GetRoad(num4 + num5, num3, num) == 0)
						{
							return true;
						}
						num5 = 0;
						num6 = p.z - (float)num3 * RoadSize;
						if (num6 < 1f)
						{
							num5 = -1;
						}
						else if (num6 > RoadSize - 1f)
						{
							num5 = 1;
						}
						if (num5 != 0 && GetRoad(num4, num3 + num5, num) == 0)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	private void RefreshAIAllowed(object state)
	{
		for (int i = 0; i < GridSize; i++)
		{
			for (int j = 0; j < GridSize; j++)
			{
				RoadSegment roadSegment = ObjectMap[0][i, j];
				if (roadSegment != null)
				{
					roadSegment.AIAllowed = false;
				}
			}
		}
		_AIVisited.Clear();
		SearchAIAllow(0, 0, 0, 0, 0, 0);
		AIAllowedBeingChecked = false;
	}

	private bool SearchAIAllow(int x, int y, int floor, int xFrom, int yFrom, int floorFrom)
	{
		if (x >= 0 && x < GridSize && y >= 0 && y < GridSize && floor >= 0 && floor < Floors)
		{
			RoadSegment roadSegment = ObjectMap[floor][x, y];
			if (roadSegment == null && floor >= 1)
			{
				floor--;
				roadSegment = ObjectMap[floor][x, y];
				if (roadSegment != null && !roadSegment.RaisedDir(xFrom - x, yFrom - y))
				{
					roadSegment = null;
				}
			}
			if (roadSegment != null && roadSegment.Parking.Length == 0)
			{
				if (roadSegment.Raised && !roadSegment.ValidRaisedIn(xFrom - x, yFrom - y, floorFrom - floor))
				{
					return false;
				}
				if (_AIVisited.Add(roadSegment))
				{
					roadSegment.AIAllowed = true;
					bool flag = false;
					if (roadSegment.Raised)
					{
						Vector2Int raisedVector = roadSegment.GetRaisedVector();
						int num = x + raisedVector.x;
						int num2 = y + raisedVector.y;
						if (num != xFrom || num2 != yFrom)
						{
							flag |= SearchAIAllow(num, num2, floor + 1, x, y, floor);
						}
						num = x - raisedVector.x;
						num2 = y - raisedVector.y;
						if (num != xFrom || num2 != yFrom)
						{
							flag |= SearchAIAllow(num, num2, floor, x, y, floor);
						}
					}
					else
					{
						for (int i = -1; i <= 1; i++)
						{
							for (int j = -1; j <= 1; j++)
							{
								if (i != j && (i == 0 || j == 0))
								{
									int num3 = x + i;
									int num4 = y + j;
									if (num3 != xFrom || num4 != yFrom)
									{
										flag |= SearchAIAllow(num3, num4, floor, x, y, floor);
									}
								}
							}
						}
					}
					if (!roadSegment.IsInputOutput)
					{
						roadSegment.AIAllowed = flag;
					}
					return roadSegment.AIAllowed;
				}
				return roadSegment.AIAllowed;
			}
		}
		return false;
	}

	public void SpawnGhostCar(int x, int y, int floor, int parking, int type, Vector3 p, float rot, Color color, uint logoCompany, byte owner)
	{
		RoadSegment segment = GetSegment(x, y, floor, false);
		if (segment != null)
		{
			RoadNode roadNode = segment.Parking.FirstOrDefault((RoadNode z) => z.ID == parking);
			if (roadNode != null && roadNode.GhostCar == null)
			{
				CarScript carScript = CreateCar(type, false);
				carScript.OwnerPlayer = owner;
				carScript.Ghost = true;
				carScript.transform.position = p;
				carScript.transform.rotation = Quaternion.Euler(0f, rot, 0f);
				carScript.LogoCompany = MarketSimulation.Active.GetCompany(logoCompany);
				carScript.UpdateColor(color);
				carScript.Init();
				carScript.Parked = true;
				carScript.AudioE = false;
				carScript.LightsE = false;
				roadNode.GhostCar = carScript;
			}
		}
	}

	public void ClearGhostCar(int x, int y, int floor, int parking)
	{
		RoadSegment segment = GetSegment(x, y, floor, false);
		if (segment != null)
		{
			RoadNode roadNode = segment.Parking.FirstOrDefault((RoadNode z) => z.ID == parking);
			if (roadNode != null && roadNode.GhostCar != null)
			{
				DestroyCar(roadNode.GhostCar);
				roadNode.GhostCar = null;
			}
		}
	}

	protected override bool WriteDID()
	{
		return false;
	}
}
