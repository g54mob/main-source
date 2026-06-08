using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private const float ROOM_UPDATE_TIME = 0.5f;

	public static EnemyManager Instance = null;

	public static int SeedAdditionalSlime = -1;

	public GameObject BruteEnemyPrefab;

	public GameObject SwarmEnemyPrefab;

	public GameObject SlimeEnemyPrefab;

	public GameObject PatrolBotEnemyPrefab;

	public GameObject DronesBestFriendPrefab;

	public bool ShowEnemyDebugWindow;

	public bool SpawnFixedEnemies;

	public List<BaseEnemy> Enemies = new List<BaseEnemy>();

	private List<SwarmManager> _swarmManagers = new List<SwarmManager>();

	public List<BaseEnemy> CollidingEnemies = new List<BaseEnemy>();

	private int _nextUniqueEnemyId = 1;

	private Rect _enemyWindowRect;

	private DungeonManager _dungeonManager;

	private Vector2 _scrollPosition = default(Vector2);

	private DroneManager _droneManager;

	private float _slimeSpawnCheckTimer;

	private int _slimesSpawnedSoFar;

	protected static System.Random _random = new System.Random();

	private System.Random rndSlime;

	private float _roomUpdateTimer;

	private bool hasEnemiesToRemove;

	private List<BaseEnemy> enemiesToRemoveList = new List<BaseEnemy>();

	private List<SwarmManager> swarmManagersToRemoveList = new List<SwarmManager>();

	private List<Room> _slimeSpawnableRooms = new List<Room>();

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_enemyWindowRect = new Rect(3f, Screen.height - 300 - 3, 550f, 300f);
		_slimeSpawnCheckTimer = 120f;
		_droneManager = DroneManager.Instance;
		_dungeonManager = DungeonManager.Instance;
	}

	private void OnDestroy()
	{
		BruteEnemyPrefab = null;
		SwarmEnemyPrefab = null;
		SlimeEnemyPrefab = null;
		PatrolBotEnemyPrefab = null;
		DronesBestFriendPrefab = null;
	}

	public void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (hasEnemiesToRemove)
			{
				foreach (BaseEnemy enemiesToRemove in enemiesToRemoveList)
				{
					Enemies.Remove(enemiesToRemove);
				}
				foreach (SwarmManager swarmManagersToRemove in swarmManagersToRemoveList)
				{
					_swarmManagers.Remove(swarmManagersToRemove);
					int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Swarm), 0) + 1;
					GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_ENKILL", ShipInfestationType.Swarm), num);
					GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Swarm), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_ENKILL", ShipInfestationType.Swarm), 0) + num);
					if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Swarm), 0))
					{
						GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_ENKILL", ShipInfestationType.Swarm), num);
					}
				}
				hasEnemiesToRemove = false;
				enemiesToRemoveList.Clear();
				swarmManagersToRemoveList.Clear();
			}
			_roomUpdateTimer -= Time.deltaTime;
			if (_roomUpdateTimer <= 0f)
			{
				_roomUpdateTimer = 0.5f;
				int count = Enemies.Count;
				for (int i = 0; i < count; i++)
				{
					BaseEnemy baseEnemy = Enemies[i];
					if (!baseEnemy.HasBehavior(EnemyAiBehaviors.CanMove) || baseEnemy.IsDead)
					{
						continue;
					}
					Room currentRoom = baseEnemy.CurrentRoom;
					CalcEnemyCurrentRoom(baseEnemy);
					if (baseEnemy.CurrentRoom == null)
					{
						Corridor currentCorridor = baseEnemy.CurrentCorridor;
						CalcEnemyCurrentCorridor(baseEnemy);
						if (baseEnemy.CurrentCorridor == null && currentCorridor != null)
						{
							baseEnemy.CurrentCorridor = currentCorridor;
						}
					}
					else if (baseEnemy.CurrentCorridor != null)
					{
						baseEnemy.CurrentCorridor = null;
					}
					if (baseEnemy.CurrentRoom == null && baseEnemy.CurrentCorridor == null && currentRoom != null)
					{
						baseEnemy.CurrentRoom = currentRoom;
					}
				}
			}
			if (GlobalSettings.MissionStarted && DungeonWantsSlime())
			{
				CheckForRandomSlimeSpawn();
			}
		}
		int count2 = _swarmManagers.Count;
		for (int j = 0; j < count2; j++)
		{
			_swarmManagers[j].Update();
		}
	}

	private void CalcEnemyCurrentRoom(BaseEnemy enemy)
	{
		if (enemy.CurrentRoom != null && enemy.CurrentRoom.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds))
		{
			return;
		}
		Room currentRoom = null;
		Room[] rooms = _dungeonManager.rooms;
		foreach (Room room in rooms)
		{
			if (room.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds))
			{
				currentRoom = room;
				break;
			}
		}
		enemy.CurrentRoom = currentRoom;
	}

	public void ForgetEnemy(BaseEnemy enemy)
	{
		hasEnemiesToRemove = true;
		enemiesToRemoveList.Add(enemy);
	}

	public void ForgetSwarmManager(SwarmManager manager)
	{
		hasEnemiesToRemove = true;
		swarmManagersToRemoveList.Add(manager);
	}

	private void CalcEnemyCurrentCorridor(BaseEnemy enemy)
	{
		if (enemy.CurrentCorridor != null && CollidesWithCorridor(enemy, enemy.CurrentCorridor))
		{
			return;
		}
		Corridor currentCorridor = null;
		Corridor[] corridors = _dungeonManager.corridors;
		foreach (Corridor corridor in corridors)
		{
			if (CollidesWithCorridor(enemy, corridor))
			{
				currentCorridor = corridor;
				break;
			}
		}
		enemy.CurrentCorridor = currentCorridor;
	}

	private bool CollidesWithCorridor(BaseEnemy enemy, Corridor corridor)
	{
		return corridor.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds) || corridor.door.sliderA.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds) || corridor.door.sliderB.GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds);
	}

	public BruteEnemy CreateBrute(Waypoint spawnPoint)
	{
		BruteEnemy bruteEnemy = (BruteEnemy)CreateEnemy(spawnPoint, BruteEnemyPrefab, true);
		bruteEnemy.CurrentRoom = spawnPoint.Room;
		return bruteEnemy;
	}

	public SlimeEnemy CreateSlime(Vector3 spawnPosition, Room room)
	{
		return CreateSlime(spawnPosition, room, false);
	}

	public SlimeEnemy CreateSlime(Vector3 spawnPosition, Room room, bool createNewBrain)
	{
		SlimeEnemy slimeEnemy = (SlimeEnemy)CreateEnemy(spawnPosition, SlimeEnemyPrefab);
		slimeEnemy.CurrentRoom = room;
		if (createNewBrain)
		{
			slimeEnemy.InitializeBrain();
		}
		return slimeEnemy;
	}

	public SlimeEnemy CreateSlime(Waypoint spawnWaypoint)
	{
		return CreateSlime(spawnWaypoint, false);
	}

	public SlimeEnemy CreateSlime(Waypoint spawnWaypoint, bool createNewBrain)
	{
		Vector3 randomPointOnWall = getRandomPointOnWall(spawnWaypoint.Room);
		return CreateSlime(randomPointOnWall, spawnWaypoint.Room, createNewBrain);
	}

	public SlimeEnemy CreateSlime(Waypoint spawnWaypoint, bool createNewBrain, System.Random rnd)
	{
		Vector3 randomPointOnWall = getRandomPointOnWall(spawnWaypoint.Room, rnd);
		return CreateSlime(randomPointOnWall, spawnWaypoint.Room, createNewBrain);
	}

	public void CreateSwarm(Waypoint spawnPoint)
	{
		SwarmManager swarmManager = new SwarmManager();
		int num = 20;
		if (UnityEngine.Random.Range(0, 100) < 10)
		{
			num = 10;
		}
		for (int i = 0; i < num; i++)
		{
			SwarmEnemy swarmEnemy = CreateSingleSwarm(spawnPoint);
			swarmManager.AddSwarmEnemy(swarmEnemy);
			swarmEnemy.CurrentRoom = spawnPoint.Room;
		}
		_swarmManagers.Add(swarmManager);
	}

	public SwarmManager SpawnSwarm(Vector3 spawnPos, int numberOfEnemies, Room initialRoom)
	{
		SwarmManager swarmManager = new SwarmManager();
		for (int i = 0; i < numberOfEnemies; i++)
		{
			SwarmEnemy swarmEnemy = (SwarmEnemy)CreateEnemy(spawnPos, SwarmEnemyPrefab);
			swarmEnemy.CurrentRoom = initialRoom;
			swarmManager.AddSwarmEnemy(swarmEnemy);
		}
		swarmManager.GetAlphaEnemy();
		_swarmManagers.Add(swarmManager);
		return swarmManager;
	}

	private SwarmEnemy CreateSingleSwarm(Waypoint spawnPoint)
	{
		return (SwarmEnemy)CreateEnemy(spawnPoint, SwarmEnemyPrefab);
	}

	public DronesBestFriend CreateDronesBestFriend(Waypoint spawnPoint)
	{
		DronesBestFriend dronesBestFriend = (DronesBestFriend)CreateEnemy(spawnPoint, DronesBestFriendPrefab, true);
		dronesBestFriend.CurrentRoom = spawnPoint.Room;
		return dronesBestFriend;
	}

	private BaseEnemy CreateEnemy(Waypoint spawnPoint, GameObject prefab)
	{
		return CreateEnemy(spawnPoint, prefab, false);
	}

	private BaseEnemy CreateEnemy(Waypoint spawnPoint, GameObject prefab, bool usePrefabZ)
	{
		BaseEnemy baseEnemy = CreateEnemy(spawnPoint.transform.position, prefab, usePrefabZ);
		float z = baseEnemy.transform.position.z;
		baseEnemy.SetPosition(spawnPoint.transform.position);
		if (usePrefabZ)
		{
			baseEnemy.transform.position = new Vector3(baseEnemy.transform.position.x, baseEnemy.transform.position.y, z);
		}
		return baseEnemy;
	}

	private BaseEnemy CreateEnemy(Vector3 spawnPosition, GameObject prefab)
	{
		return CreateEnemy(spawnPosition, prefab, false);
	}

	private BaseEnemy CreateEnemy(Vector3 spawnPosition, GameObject prefab, bool usePrefabZ)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
		float z = gameObject.transform.position.z;
		if (usePrefabZ)
		{
			gameObject.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, z);
		}
		else
		{
			gameObject.transform.position = spawnPosition;
		}
		BaseEnemy baseEnemy = (BaseEnemy)gameObject.GetComponent(typeof(BaseEnemy));
		baseEnemy.SetId(_nextUniqueEnemyId++);
		Enemies.Add(baseEnemy);
		if (baseEnemy is BruteEnemy || baseEnemy is PatrolBotEnemy || baseEnemy is DronesBestFriend)
		{
			CollidingEnemies.Add(baseEnemy);
		}
		return baseEnemy;
	}

	public PatrolBotEnemy CreatePatrolBot(Waypoint spawnPoint)
	{
		PatrolBotEnemy patrolBotEnemy = (PatrolBotEnemy)CreateEnemy(spawnPoint, PatrolBotEnemyPrefab, true);
		patrolBotEnemy.CurrentRoom = spawnPoint.Room;
		return patrolBotEnemy;
	}

	private void DrawEnemyTestWindow(int id)
	{
		GUILayout.BeginVertical();
		GUILayout.Label("Enemies: " + Enemies.Count);
		GUILayout.Space(5f);
		_scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
		foreach (SwarmManager swarmManager in _swarmManagers)
		{
			GUILayout.BeginHorizontal();
			SwarmEnemy alphaEnemy = swarmManager.GetAlphaEnemy();
			string arg = "n/a";
			string arg2 = "n/a";
			if (alphaEnemy != null)
			{
				arg = "...";
				if (alphaEnemy.CurrentRoom != null)
				{
					arg = alphaEnemy.CurrentRoom.Label;
				}
				else if (alphaEnemy.CurrentCorridor != null)
				{
					arg = "_" + alphaEnemy.CurrentCorridor.door.Label + "_";
				}
				arg2 = alphaEnemy.Position.ToString();
			}
			GUILayout.Label(string.Format("SwarmManager: {0} - {1} - {2}", swarmManager.CurrentState, arg, arg2));
			GUILayout.EndHorizontal();
		}
		GUILayout.Space(5f);
		foreach (BaseEnemy enemy in Enemies)
		{
			GUILayout.BeginHorizontal();
			bool flag = enemy is BruteEnemy;
			string text = "...";
			if (enemy.CurrentRoom != null)
			{
				text = enemy.CurrentRoom.Label;
			}
			else if (enemy.CurrentCorridor != null)
			{
				text = "_" + enemy.CurrentCorridor.door.Label + "_";
			}
			GUILayout.Label(string.Format("{0} ({4}) - hitpoints: {1} - {2} - {3} - {5} - {6} - {7}", enemy.Id, enemy.CurrentHitPoints, enemy.CurrentState, enemy.transform.position, (!flag) ? "Swarm" : "Brute", text, enemy.LastVelocity, enemy.transform.rotation));
			GUILayout.EndHorizontal();
		}
		GUILayout.EndScrollView();
		GUILayout.Space(5f);
		GUILayout.BeginHorizontal();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		GUI.DragWindow();
	}

	public bool DoesSlimeIntersectWithPosition(Vector3 position, Room room)
	{
		foreach (BaseEnemy enemy in Enemies)
		{
			if (!enemy.IsDead && enemy is SlimeEnemy && (enemy.CurrentRoom == room || room == null) && enemy.ObjectCollider.bounds.Contains(position))
			{
				return true;
			}
		}
		return false;
	}

	public SlimeEnemy ClosestEnemySlime(SlimeEnemy slime)
	{
		return ClosestEnemySlime(slime.Position, slime.CurrentRoom, slime);
	}

	public SlimeEnemy ClosestEnemySlime(Vector3 testPosition, Room room)
	{
		return ClosestEnemySlime(testPosition, room, null);
	}

	public SlimeEnemy ClosestEnemySlime(Vector3 testPosition, Room room, SlimeEnemy slimeToExclude)
	{
		SlimeEnemy slimeEnemy = null;
		float num = float.MaxValue;
		foreach (BaseEnemy enemy in Enemies)
		{
			if (!enemy.IsDead && enemy is SlimeEnemy && enemy.CurrentRoom == room && enemy != slimeToExclude)
			{
				SlimeEnemy slimeEnemy2 = (SlimeEnemy)enemy;
				float num2 = Vector3.Distance(enemy.Position, testPosition);
				if (slimeEnemy == null || num2 < num)
				{
					slimeEnemy = slimeEnemy2;
					num = num2;
				}
			}
		}
		return slimeEnemy;
	}

	private void CheckForRandomSlimeSpawn()
	{
		if (rndSlime == null)
		{
			if (GlobalSettings.gameMode == GameModeEnum.Normal)
			{
				rndSlime = _random;
			}
			else
			{
				int seed = (int)DateTime.Now.Ticks;
				if (SeedAdditionalSlime != -1)
				{
					seed = SeedAdditionalSlime;
				}
				rndSlime = new System.Random(seed);
			}
		}
		if (_slimesSpawnedSoFar >= 3)
		{
			return;
		}
		_slimeSpawnCheckTimer -= Time.deltaTime;
		if (!(_slimeSpawnCheckTimer <= 0f))
		{
			return;
		}
		_slimeSpawnCheckTimer = 120f;
		bool flag = rndSlime.Next(1, 101) <= 40;
		bool flag2 = rndSlime.Next(1, 101) <= 20;
		bool flag3 = rndSlime.Next(1, 101) <= 65;
		_slimeSpawnableRooms.Clear();
		if (flag)
		{
			Room boardingVessel = _dungeonManager.BoardingVessel;
			foreach (Drone drones in _droneManager.dronesList)
			{
				if (!drones.IsDead && !drones.IsHidden && drones.CurrentRoom != null && drones.CurrentRoom != boardingVessel)
				{
					_slimeSpawnableRooms.Add(drones.CurrentRoom);
				}
			}
			BaseEnemy enemy;
			foreach (BaseEnemy enemy3 in Enemies)
			{
				enemy = enemy3;
				if (enemy is SlimeEnemy && !enemy.IsDead)
				{
					_slimeSpawnableRooms.RemoveAll((Room x) => x == enemy.CurrentRoom);
				}
			}
		}
		else if (flag2)
		{
			Room boardingVessel2 = _dungeonManager.BoardingVessel;
			Room[] rooms = _dungeonManager.rooms;
			foreach (Room room in rooms)
			{
				if (room != boardingVessel2)
				{
					_slimeSpawnableRooms.Add(room);
				}
			}
			foreach (Drone drones2 in _droneManager.dronesList)
			{
				if (!drones2.IsDead && !drones2.IsHidden && drones2.CurrentRoom != null && _slimeSpawnableRooms.Contains(drones2.CurrentRoom))
				{
					_slimeSpawnableRooms.Remove(drones2.CurrentRoom);
				}
			}
			BaseEnemy enemy2;
			foreach (BaseEnemy enemy4 in Enemies)
			{
				enemy2 = enemy4;
				if (enemy2 is SlimeEnemy && !enemy2.IsDead)
				{
					_slimeSpawnableRooms.RemoveAll((Room x) => x == enemy2.CurrentRoom);
				}
			}
		}
		else if (flag3)
		{
			foreach (BaseEnemy enemy5 in Enemies)
			{
				if (enemy5 is SlimeEnemy && enemy5.IsDead && !((SlimeEnemy)enemy5).IsHibernating && enemy5.CurrentRoom != null && !_slimeSpawnableRooms.Contains(enemy5.CurrentRoom))
				{
					_slimeSpawnableRooms.Add(enemy5.CurrentRoom);
				}
			}
			Room room2;
			foreach (Room item in _slimeSpawnableRooms.ToList())
			{
				room2 = item;
				if (Enemies.Any((BaseEnemy x) => x is SlimeEnemy && (!x.IsDead || ((SlimeEnemy)x).IsHibernating) && x.CurrentRoom == room2))
				{
					_slimeSpawnableRooms.Remove(room2);
				}
			}
			if (_slimeSpawnableRooms.Count > 0)
			{
				Debug.Log("Gonna respawn slime!!!");
			}
		}
		if (_slimeSpawnableRooms.Count <= 0)
		{
			return;
		}
		Room room3 = CommonMethods.PickRandomItem(_slimeSpawnableRooms, rndSlime);
		if (room3 != null)
		{
			Debug.Log("Spawning Slime in " + room3.Label);
			Vector3 randomPointOnWall = getRandomPointOnWall(room3, rndSlime);
			Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room3);
			if (room3.GetComponent<Collider>().bounds.Contains(randomPointOnWall))
			{
				CreateSlime(randomPointOnWall, room3, true);
			}
			else
			{
				CreateSlime(mainRoomWaypoint, true);
			}
			_slimesSpawnedSoFar++;
		}
	}

	private bool DungeonWantsSlime()
	{
		if (GlobalSettings.GameStartedFromGalaxyMap && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType != null)
		{
			return GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType.Contains(ShipInfestationType.Slime);
		}
		return false;
	}

	private Vector3 getRandomPointOnWall(Room room)
	{
		int whichSide = UnityEngine.Random.Range(0, 4);
		float whichPoint = UnityEngine.Random.Range(-1f, 1f);
		return getRandomPointOnWall(room, whichSide, whichPoint);
	}

	private Vector3 getRandomPointOnWall(Room room, System.Random rnd)
	{
		int whichSide = rnd.Next(0, 4);
		float whichPoint = rnd.NextFloat(-1f, 1f);
		return getRandomPointOnWall(room, whichSide, whichPoint);
	}

	private Vector3 getRandomPointOnWall(Room room, int whichSide, float whichPoint)
	{
		Vector3 zero = Vector3.zero;
		switch (whichSide)
		{
		case 0:
			zero.y = room.transform.position.y + room.transform.localScale.y / 2f;
			zero.x = room.transform.position.x + whichPoint * (room.transform.localScale.x / 2f);
			break;
		case 1:
			zero.y = room.transform.position.y - room.transform.localScale.y / 2f;
			zero.x = room.transform.position.x + whichPoint * (room.transform.localScale.x / 2f);
			break;
		case 2:
			zero.x = room.transform.position.x + room.transform.localScale.x / 2f;
			zero.y = room.transform.position.y + whichPoint * (room.transform.localScale.y / 2f);
			break;
		case 3:
			zero.x = room.transform.position.x - room.transform.localScale.x / 2f;
			zero.y = room.transform.position.y + whichPoint * (room.transform.localScale.y / 2f);
			break;
		}
		return zero;
	}

	public bool ShouldSpawnDronesBestFriend()
	{
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			return false;
		}
		int num = UniverseSaveFile.Get("STAT_VDUN", 0);
		if (num > 25)
		{
			int num2 = _random.Next(1, 101);
			if (num2 <= 5)
			{
				return true;
			}
		}
		return false;
	}
}
