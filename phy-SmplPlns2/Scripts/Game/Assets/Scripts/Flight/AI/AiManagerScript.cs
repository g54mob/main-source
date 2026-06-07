using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Flight.AI.ControlFunctions;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.AI.Guidance;
using Assets.Scripts.Flight.Proximity;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Levels;
using Jundroo.Common.Events;
using Jundroo.Common.Math;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight.AI
{
	public class AiManagerScript : MonoBehaviour
	{
		private enum LocationSelectionType
		{
			Closest = 0,
			Random = 1,
			ClosestRunway = 2,
			RandomRunway = 3
		}

		public class AiSpawnedEventArgs : EventArgs
		{
			public AiControlledAircraftScript AiAircraft { get; private set; }

			public AiSpawnedEventArgs(AiControlledAircraftScript aiAircraft)
			{
				AiAircraft = aiAircraft;
			}
		}

		public bool AutoDespawn = true;

		public bool DisableAiSpawning;

		public GameObject GroundAvoidanceEnd;

		public GameObject GroundAvoidanceMaxHeight;

		public GameObject GroundAvoidanceStart;

		public bool MakePlayerAiControllable;

		public bool RealtimeHeightmapAvoidance;

		public bool ShowDebugInfo;

		public bool ShowDebugInfoBasedOnCalls;

		public bool ShowGroundAvoidanceDebugInfo;

		private const int DownsampledHeightmapResolution = 16;

		private static AiManagerSettings _aiSettings;

		private static AiManagerScript _instance;

		private List<AiControlledAircraftScript> _aiAircraftAutoDespawn = new List<AiControlledAircraftScript>();

		private List<AiControlledAircraftScript> _aiAircraftAutoDespawnLoading = new List<AiControlledAircraftScript>();

		private List<AiControlledAircraftScript> _aiAircraftManualDespawn = new List<AiControlledAircraftScript>();

		private List<AiCsTestFlyability> _aiAircraftRunningFlyabilityTests = new List<AiCsTestFlyability>();

		private Dictionary<Terrain, List<Transform>> _debugGroundAvoidancePoints = new Dictionary<Terrain, List<Transform>>();

		private Dictionary<Terrain, float[,]> _downsampledHeightmapData = new Dictionary<Terrain, float[,]>();

		private List<AiPath> _flightPaths = new List<AiPath>();

		private GameObject _groundAvoidancePlane;

		private bool _initialAiWorldPopulationComplete;

		private List<Point2i> _linePoints;

		private Transform _positionForGroundAvoidance;

		public static AiManagerSettings AiSettings
		{
			get
			{
				if (_aiSettings == null)
				{
					_aiSettings = new AiManagerSettings();
				}
				return _aiSettings;
			}
		}

		public static AiManagerScript Instance
		{
			get
			{
				if (_instance == null)
				{
					if (!LevelBase.CurrentLevel.ApplicationQuitting)
					{
						FlightSceneScript.Instance.AircraftContainer.gameObject.AddComponent<AiManagerScript>();
					}
					else
					{
						Debug.LogWarning("Do not access AiManager from OnDestroy while LevelBase.CurrentLevel.ApplicationQuitting.");
					}
				}
				return _instance;
			}
		}

		public static bool RunningBenchmark { get; set; }

		public ReadOnlyCollection<AiControlledAircraftScript> AiAircraft => _aiAircraftAutoDespawn.Concat(_aiAircraftManualDespawn).ToList().AsReadOnly();

		public int CurrentAiCount => _aiAircraftAutoDespawn.Count + _aiAircraftManualDespawn.Count;

		public bool HasPlayerBeenAiControllable { get; private set; }

		public string NextAircraftIdToSpawn { get; set; }

		public AiControlledAircraftScript PlayerAiScript { get; private set; }

		public event EventHandler<AiSpawnedEventArgs> AiSpawned
		{
			add
			{
				_aiSpawned += WeakEventHandler.Create(value, delegate(EventHandler<AiSpawnedEventArgs> x)
				{
					_aiSpawned -= x;
				});
			}
			remove
			{
				_aiSpawned -= WeakEventHandler.FindUnregisterHandler(this._aiSpawned, value);
			}
		}

		private event EventHandler<AiSpawnedEventArgs> _aiSpawned;

		public static AiAircraftInfo GetRandomAircraft(bool allowUntested, bool allowUnflyable, int? maxWingCount, int? maxPartCount)
		{
			List<CraftFileInfo> crafts = Game.Instance.CraftDatabase.GetCrafts();
			AiAircraftInfo aiAircraftInfo = null;
			int num = 0;
			while (aiAircraftInfo == null)
			{
				num++;
				int index = UnityEngine.Random.Range(0, crafts.Count);
				CraftFileInfo craftFileInfo = crafts[index];
				if (craftFileInfo.IsHidden || craftFileInfo.Id == "__editor__.xml")
				{
					continue;
				}
				AiAircraftInfo aiAircraftInfo2 = new AiAircraftInfo(craftFileInfo.Id);
				if ((!maxWingCount.HasValue || aiAircraftInfo2.WingCount <= maxWingCount.Value) && (!maxPartCount.HasValue || aiAircraftInfo2.PartCount <= maxPartCount.Value))
				{
					if (aiAircraftInfo2.AircraftIsFylable.HasValue)
					{
						if (aiAircraftInfo2.AircraftIsFylable.Value || allowUnflyable)
						{
							aiAircraftInfo = aiAircraftInfo2;
							break;
						}
					}
					else if (allowUntested)
					{
						aiAircraftInfo = aiAircraftInfo2;
						break;
					}
				}
				if (num >= crafts.Count)
				{
					break;
				}
			}
			return aiAircraftInfo;
		}

		public static void MarkAircraftAsNotAbleToTakeOff(AiControlledAircraftScript aiControlledAircraftScript)
		{
			aiControlledAircraftScript.AiAircraftInfo.AircraftIsAbleToTakeOff = false;
			aiControlledAircraftScript.AiAircraftInfo.Save();
		}

		public static void MarkAircraftAsUnflyable(AiControlledAircraftScript aiControlledAircraftScript)
		{
			aiControlledAircraftScript.AiAircraftInfo.AircraftIsFylable = false;
			aiControlledAircraftScript.AiAircraftInfo.Save();
		}

		public void DespawnAircraft(AiControlledAircraftScript aiAircraftToDespawn, float delayToRemove)
		{
			DespawnAircraft(aiAircraftToDespawn, delayToRemove, null);
		}

		public void DespawnAircraft(AiControlledAircraftScript aiAircraftToDespawn, float delayToRemove, Func<bool> removalCheck)
		{
			if (base.isActiveAndEnabled && !LevelBase.CurrentLevel.ApplicationQuitting)
			{
				StartCoroutine(DespawnAircraftCoroutine(aiAircraftToDespawn, delayToRemove, removalCheck));
			}
		}

		public void DespawnAllAI()
		{
			List<AiControlledAircraftScript> value;
			using (CollectionPool<List<AiControlledAircraftScript>, AiControlledAircraftScript>.Get(out value))
			{
				value.AddRange(_aiAircraftManualDespawn);
				for (int i = 0; i < value.Count; i++)
				{
					DespawnAircraft(value[i], 0f);
				}
				value.Clear();
				value.AddRange(_aiAircraftAutoDespawn);
				for (int j = 0; j < value.Count; j++)
				{
					DespawnAircraft(value[j], 0f);
				}
			}
		}

		public AiPath GetAiFlightPath(Vector3 referencePosition, AiPath.PathType? pathType, float maxDistance, bool closest)
		{
			float num = float.MaxValue;
			AiPath result = null;
			AiPath aiPath = null;
			List<AiPath> list = new List<AiPath>();
			foreach (AiPath flightPath in _flightPaths)
			{
				float num2 = Vector3.Distance(referencePosition, flightPath.PathManager.waypoints[0].position);
				if ((!pathType.HasValue || pathType.Value == flightPath.Type) && num2 < maxDistance)
				{
					if (num2 < num)
					{
						num = num2;
						result = flightPath;
					}
					list.Add(flightPath);
				}
			}
			if (closest)
			{
				return result;
			}
			if (list.Count > 0)
			{
				return list[UnityEngine.Random.Range(0, list.Count)];
			}
			return null;
		}

		public void GetLinePoints(int x, int y, int x2, int y2, List<Point2i> points)
		{
			points.Clear();
			int num = x2 - x;
			int num2 = y2 - y;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (num < 0)
			{
				num3 = -1;
			}
			else if (num > 0)
			{
				num3 = 1;
			}
			if (num2 < 0)
			{
				num4 = -1;
			}
			else if (num2 > 0)
			{
				num4 = 1;
			}
			if (num < 0)
			{
				num5 = -1;
			}
			else if (num > 0)
			{
				num5 = 1;
			}
			int num7 = Mathf.Abs(num);
			int num8 = Mathf.Abs(num2);
			if (num7 <= num8)
			{
				num7 = Mathf.Abs(num2);
				num8 = Mathf.Abs(num);
				if (num2 < 0)
				{
					num6 = -1;
				}
				else if (num2 > 0)
				{
					num6 = 1;
				}
				num5 = 0;
			}
			if (num7 > 1000)
			{
				num7 = 1000;
			}
			int num9 = num7 >> 1;
			for (int i = 0; i <= num7; i++)
			{
				points.Add(new Point2i(x, y));
				num9 += num8;
				if (num9 >= num7)
				{
					num9 -= num7;
					x += num3;
					y += num4;
				}
				else
				{
					x += num5;
					y += num6;
				}
			}
		}

		public Vector3? GetOptimalTargetBetween(Vector3 startWorldPosition, Vector3 endWorldPosition)
		{
			Vector3? result = null;
			if (_positionForGroundAvoidance == null)
			{
				_positionForGroundAvoidance = new GameObject("GroundAvoidancePoint").transform;
				_positionForGroundAvoidance.transform.parent = base.transform;
			}
			foreach (Terrain terrain in ProximityLoader.Instance.Terrains)
			{
				Point2i heightmapSectorCoord = GetHeightmapSectorCoord(terrain, startWorldPosition);
				Point2i heightmapSectorCoord2 = GetHeightmapSectorCoord(terrain, endWorldPosition);
				GetLinePoints(heightmapSectorCoord.x, heightmapSectorCoord.y, heightmapSectorCoord2.x, heightmapSectorCoord2.y, _linePoints);
				_positionForGroundAvoidance.position = startWorldPosition;
				_positionForGroundAvoidance.LookAt(endWorldPosition, Vector3.up);
				_positionForGroundAvoidance.position += _positionForGroundAvoidance.right;
				Plane plane = new Plane(_positionForGroundAvoidance.position, startWorldPosition, endWorldPosition);
				if (_linePoints.Count <= 1)
				{
					continue;
				}
				for (int i = 1; i < _linePoints.Count; i++)
				{
					Point2i sectorCoord = _linePoints[i];
					if (sectorCoord.x >= 0 && sectorCoord.x < 16 && sectorCoord.y >= 0 && sectorCoord.y < 16)
					{
						float height = GetDownsampledHeightmapData(terrain)[sectorCoord.y, sectorCoord.x];
						Vector3 worldPositionFromDownsampledHeightmapSectorCoord = GetWorldPositionFromDownsampledHeightmapSectorCoord(terrain, sectorCoord, height);
						if (Math3d.SignedDistancePlanePoint(plane.normal, startWorldPosition, worldPositionFromDownsampledHeightmapSectorCoord) > 0f)
						{
							result = worldPositionFromDownsampledHeightmapSectorCoord + plane.normal * 500f;
							break;
						}
					}
				}
			}
			return result;
		}

		public void RaiseAiSpawnedEvent(AiControlledAircraftScript aiAircraft)
		{
			if (this._aiSpawned == null)
			{
				return;
			}
			Delegate[] invocationList = this._aiSpawned.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				EventHandler<AiSpawnedEventArgs> eventHandler = (EventHandler<AiSpawnedEventArgs>)invocationList[i];
				try
				{
					eventHandler(this, new AiSpawnedEventArgs(aiAircraft));
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void RegisterAiFlightPath(AiPath flightPath)
		{
			_flightPaths.Add(flightPath);
		}

		public AiControlledAircraftScript SetPlayerAsAiControllable(AiControlSystem controlSystem)
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraftScript == null)
			{
				return null;
			}
			PlayerAiScript = aircraftScript.gameObject.AddComponent<AiControlledAircraftScript>();
			PlayerAiScript.Initialize(new AiAircraftInfo(aircraftScript.Aircraft.Name));
			if (controlSystem == null)
			{
				controlSystem = new AiCsFlyToLocation<AiCfFlyToLocation>();
			}
			PlayerAiScript.SetAiControlSystem(controlSystem);
			HasPlayerBeenAiControllable = true;
			return PlayerAiScript;
		}

		public void SpawnAi<T>(AiAircraftInfo aircraftInfo, Vector3 position, Vector3 rotation, float speed, bool autoDespawn, bool multipleFrames, ushort teamId, Action<AiControlledAircraftScript> onDone = null) where T : AiControlSystem, new()
		{
			FlightSceneScript.Instance.FlightSceneNetwork.SpawnAIAircraft(aircraftInfo, position, rotation, speed, autoDespawn, teamId, delegate(AircraftScript aircraftScript)
			{
				AiControlledAircraftScript aiScript = null;
				PostCreation();
				ProcessCreatedCraft();
				void PostCreation()
				{
					GameObject gameObject = aircraftScript.gameObject;
					aiScript = gameObject.AddComponent<AiControlledAircraftScript>();
					aiScript.PreInitialize(aircraftScript);
					aircraftScript.SetAIControlled(aiScript);
				}
			});
			void ProcessCreatedCraft()
			{
				P_0.aircraftScript.name = "AiAircraft: " + P_0.aiScript.AiAircraftScript.Aircraft.Name;
				P_0.aiScript.Initialize(null, aircraftInfo);
				P_0.aiScript.AutoDespawn = autoDespawn;
				AiControlSystem aiControlSystem = new T();
				P_0.aiScript.SetAiControlSystem(aiControlSystem);
				if (autoDespawn)
				{
					if (_aiAircraftAutoDespawnLoading.Contains(P_0.aiScript))
					{
						_aiAircraftAutoDespawnLoading.Remove(P_0.aiScript);
					}
					_aiAircraftAutoDespawn.Add(P_0.aiScript);
				}
				else
				{
					_aiAircraftManualDespawn.Add(P_0.aiScript);
				}
				P_0.aircraftScript.Unloaded += AircraftUnloaded;
				RaiseAiSpawnedEvent(P_0.aiScript);
				onDone?.Invoke(P_0.aiScript);
			}
		}

		public void SpawnSandboxAi(string aircraftId, bool autoDespawn, bool forceSpawnEvenIfUnflyable, StartLocation location, AiCsSandboxAirTraffic.AiMode? aiMode, bool aggressive, ushort teamId, Action<AiControlledAircraftScript> onDone)
		{
			AiAircraftInfo aiAircraftInfo;
			if (!string.IsNullOrEmpty(aircraftId))
			{
				aiAircraftInfo = new AiAircraftInfo(aircraftId);
			}
			else if (string.IsNullOrEmpty(NextAircraftIdToSpawn))
			{
				aiAircraftInfo = GetRandomAircraft(allowUntested: true, allowUnflyable: false, 7, 150);
			}
			else
			{
				aiAircraftInfo = new AiAircraftInfo(NextAircraftIdToSpawn);
				NextAircraftIdToSpawn = null;
			}
			if (aiAircraftInfo == null)
			{
				Debug.LogWarning("No suitable aircraft found to spawn for Sandbox AI traffic.");
			}
			else
			{
				SpawnSandboxAiInternal(aiAircraftInfo, autoDespawn, forceSpawnEvenIfUnflyable, location, aiMode, aggressive, teamId, onDone);
			}
		}

		protected virtual void Awake()
		{
			if (_instance != null)
			{
				UnityEngine.Object.Destroy(this);
				throw new InvalidOperationException("Only one AiManagerScript can be active in a scene");
			}
			_instance = this;
			_linePoints = new List<Point2i>(1000);
		}

		protected virtual void OnDestroy()
		{
			ProximityLoader instance = ProximityLoader.Instance;
			if (instance != null)
			{
				instance.TerrainProximityLoaded -= OnTerrainProximityLoaded;
				instance.TerrainProximityUnloaded -= OnTerrainProximityUnloaded;
			}
			FlightSceneScript instance2 = FlightSceneScript.Instance;
			if (instance2 != null)
			{
				instance2.FlightSceneLoaded -= OnFlightSceneLoaded;
			}
		}

		protected virtual void Start()
		{
			ProximityLoader instance = ProximityLoader.Instance;
			if (instance != null)
			{
				instance.TerrainProximityLoaded += OnTerrainProximityLoaded;
				instance.TerrainProximityUnloaded += OnTerrainProximityUnloaded;
			}
			FlightSceneScript instance2 = FlightSceneScript.Instance;
			if (instance2 != null)
			{
				instance2.FlightSceneLoaded += OnFlightSceneLoaded;
			}
		}

		protected virtual void Update()
		{
			if (AutoDespawn)
			{
				MonitorForAircraftToDespawn();
			}
			MonitorFlyabilityTestsInProgress();
		}

		private static Vector3 MetersPerSector(Terrain terrain)
		{
			return terrain.terrainData.size / 16f;
		}

		private void AircraftUnloaded(object sender, AircraftScriptEventArgs e)
		{
			AircraftScript craft = e.Craft;
			if ((object)craft == null)
			{
				return;
			}
			craft.Unloaded -= AircraftUnloaded;
			AiControlledAircraftScript aIScript = craft.AIScript;
			if ((object)aIScript != null)
			{
				List<AiControlledAircraftScript> aiAircraftAutoDespawn = _aiAircraftAutoDespawn;
				if (aiAircraftAutoDespawn != null && aiAircraftAutoDespawn.Contains(aIScript))
				{
					_aiAircraftAutoDespawn.Remove(aIScript);
				}
				List<AiControlledAircraftScript> aiAircraftManualDespawn = _aiAircraftManualDespawn;
				if (aiAircraftManualDespawn != null && aiAircraftManualDespawn.Contains(aIScript))
				{
					_aiAircraftManualDespawn.Remove(aIScript);
				}
			}
		}

		private IEnumerator AiSpawner()
		{
			int failsafeCounter = 0;
			while (failsafeCounter++ < 100)
			{
				bool flag = RunningBenchmark || DisableAiSpawning;
				try
				{
					if (!flag && _aiAircraftAutoDespawnLoading.Count + _aiAircraftAutoDespawn.Count < AiSettings.MaxAiTrafficCount)
					{
						int num = UnityEngine.Random.Range(1, AiSettings.AircraftSpawnProbabilityPerSecond + 1);
						if (!_initialAiWorldPopulationComplete || num == AiSettings.AircraftSpawnProbabilityPerSecond)
						{
							ushort nextTeamId = Game.Instance.NetworkGameManager.TeamManager.GetNextTeamId(null);
							SpawnSandboxAi(null, autoDespawn: true, forceSpawnEvenIfUnflyable: false, null, AiCsSandboxAirTraffic.AiMode.Default, aggressive: false, nextTeamId, delegate(AiControlledAircraftScript ai)
							{
								_aiAircraftAutoDespawnLoading.Add(ai);
							});
						}
					}
					if (_aiAircraftAutoDespawnLoading.Count + _aiAircraftAutoDespawn.Count > AiSettings.MaxAiTrafficCount)
					{
						DespawnAircraft(_aiAircraftAutoDespawn.Last(), 0f);
					}
					else if (_aiAircraftAutoDespawnLoading.Count + _aiAircraftAutoDespawn.Count == AiSettings.MaxAiTrafficCount)
					{
						_initialAiWorldPopulationComplete = true;
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				if (_initialAiWorldPopulationComplete || flag)
				{
					failsafeCounter = 0;
					yield return new WaitForSeconds(1f);
				}
			}
			Debug.LogError("AiSpawner got stuck in no-delay loop...disabling aircraft spawning");
		}

		private bool CheckForDespawnDamaged(AiControlledAircraftScript aiControlledAircraft)
		{
			return aiControlledAircraft.AiAircraftScript.CriticallyDamaged;
		}

		private bool CheckForDespawnDistance(AiControlledAircraftScript aiControlledAircraft)
		{
			Vector3? vector = FlightSceneScript.Instance.LocalPlayer?.FramePosition;
			if (vector.HasValue && Vector3.Distance(vector.Value, aiControlledAircraft.AiRigidbody.transform.position) > AiSettings.AircraftDespawnDistance)
			{
				return true;
			}
			return false;
		}

		private IEnumerator DespawnAircraftCoroutine(AiControlledAircraftScript aiAircraftToDespawn, float delayToRemove, Func<bool> removalCheck)
		{
			aiAircraftToDespawn.PrepareForDespawn();
			if (delayToRemove > 0f)
			{
				yield return new WaitForSeconds(delayToRemove);
			}
			if (aiAircraftToDespawn.AiAircraftScript != null)
			{
				if (removalCheck == null || removalCheck())
				{
					_aiAircraftManualDespawn.Remove(aiAircraftToDespawn);
					_aiAircraftAutoDespawn.Remove(aiAircraftToDespawn);
					AircraftScript aiAircraftScript = aiAircraftToDespawn.AiAircraftScript;
					aiAircraftScript.gameObject.SetActive(value: false);
					aiAircraftScript.NetworkAircraft.RequestDespawn();
				}
				else
				{
					aiAircraftToDespawn.AbortDespawn();
				}
			}
		}

		private void DoDebugStuffInUpdate()
		{
			if (MakePlayerAiControllable && !HasPlayerBeenAiControllable)
			{
				SetPlayerAsAiControllable(null);
			}
			UnityEngine.Input.GetKeyUp(KeyCode.Slash);
			DoGroundAvoidanceDebugStuff();
		}

		private void DoGroundAvoidanceDebugStuff()
		{
			if (RealtimeHeightmapAvoidance)
			{
				GenerateAllDownsampledHeightmaps();
			}
			if (ShowGroundAvoidanceDebugInfo && ShowDebugInfoBasedOnCalls && _downsampledHeightmapData.Count == 0)
			{
				GenerateAllDownsampledHeightmaps();
			}
			if (_downsampledHeightmapData.Count <= 0)
			{
				return;
			}
			if (GroundAvoidanceStart == null)
			{
				AircraftScript aircraftScript = FlightSceneScript.Instance?.LocalPlayer?.Aircraft;
				GroundAvoidanceStart = new GameObject("GroundAvoidanceStart");
				GroundAvoidanceStart.transform.position = ((aircraftScript == null) ? Vector3.zero : aircraftScript.transform.position);
				GroundAvoidanceStart.transform.parent = LevelBase.CurrentLevel.LevelLoader.transform;
			}
			if (GroundAvoidanceEnd == null)
			{
				AircraftScript aircraftScript2 = FlightSceneScript.Instance?.LocalPlayer?.Aircraft;
				GroundAvoidanceEnd = new GameObject("GroundAvoidanceEnd");
				GroundAvoidanceEnd.transform.position = ((aircraftScript2 == null) ? (GroundAvoidanceStart.transform.position + GroundAvoidanceStart.transform.forward * 10000f) : (aircraftScript2.transform.position + aircraftScript2.OrientedCenterOfMassRigidBodies.forward * 10000f));
				GroundAvoidanceEnd.transform.parent = LevelBase.CurrentLevel.LevelLoader.transform;
			}
			if (GroundAvoidanceMaxHeight == null)
			{
				GroundAvoidanceMaxHeight = new GameObject("GroundAvoidanceMaxHeight");
			}
			if (!ShowDebugInfoBasedOnCalls)
			{
				Vector3? optimalTargetBetween = GetOptimalTargetBetween(GroundAvoidanceStart.transform.position, GroundAvoidanceEnd.transform.position);
				if (optimalTargetBetween.HasValue)
				{
					GroundAvoidanceMaxHeight.transform.position = optimalTargetBetween.Value;
				}
			}
		}

		private void GenerateAllDownsampledHeightmaps()
		{
			foreach (Terrain terrain in ProximityLoader.Instance.Terrains)
			{
				GenerateDownsampledHeightmap(terrain);
			}
		}

		private void GenerateDownsampledHeightmap(Terrain terrain)
		{
			float[,] array = new float[16, 16];
			int num = terrain.terrainData.heightmapResolution / 16;
			for (int i = 0; i < terrain.terrainData.heightmapResolution - num; i += num)
			{
				for (int j = 0; j < terrain.terrainData.heightmapResolution - num; j += num)
				{
					int num2 = i / num;
					int num3 = j / num;
					if (num2 > 15)
					{
						Debug.LogError("Index out of range");
					}
					else if (num3 > 15)
					{
						Debug.LogError("Index out of range");
					}
					else
					{
						array[num2, num3] = GetMaxHeightFromTerrainSector(terrain, j, i, num);
					}
				}
			}
			if (_downsampledHeightmapData.ContainsKey(terrain))
			{
				_downsampledHeightmapData.Remove(terrain);
			}
			_downsampledHeightmapData.Add(terrain, array);
		}

		private float[,] GetDownsampledHeightmapData(Terrain terrain)
		{
			if (!_downsampledHeightmapData.ContainsKey(terrain))
			{
				GenerateDownsampledHeightmap(terrain);
			}
			return _downsampledHeightmapData[terrain];
		}

		private Point2i GetHeightmapSectorCoord(Terrain terrain, Vector3 worldPositionToCheck)
		{
			float x = terrain.transform.position.x;
			float z = terrain.transform.position.z;
			Vector2 vector = new Vector2(worldPositionToCheck.x - x, worldPositionToCheck.z - z);
			Vector3 vector2 = MetersPerSector(terrain);
			return new Point2i((int)(vector.x / vector2.x), (int)(vector.y / vector2.z));
		}

		private float GetMaxHeightFromTerrainSector(Terrain terrain, int startX, int startY, int sectorSize)
		{
			float num = 0f;
			float[,] heights = terrain.terrainData.GetHeights(startX, startY, sectorSize, sectorSize);
			for (int i = 0; i < sectorSize; i++)
			{
				for (int j = 0; j < sectorSize; j++)
				{
					float num2 = heights[i, j];
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			return num * terrain.terrainData.size.y;
		}

		private void GetStartingPosition(out Vector3 position, out Vector3 rotation)
		{
			float maxInclusive = AiSettings.AircraftDespawnDistance / 2f;
			Vector3 vector = new Vector3(UnityEngine.Random.Range(1000f, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)), UnityEngine.Random.Range(-1000f, 1000f), UnityEngine.Random.Range(1000f, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)));
			position = (Vector3)(((Vector3d?)FlightSceneScript.Instance.LocalPlayer?.GlobalPosition) ?? Vector3d.zero) + vector;
			float? heightAboveTerrain = Utility.GetHeightAboveTerrain(Utility.ConvertAbsoluteToFloatingOriginPosition(position));
			if (heightAboveTerrain.HasValue)
			{
				if (heightAboveTerrain < 1000f)
				{
					position += new Vector3(0f, 1000f - heightAboveTerrain.Value, 0f);
				}
			}
			else
			{
				float num = GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault() + 1000f;
				if (position.y < num)
				{
					position.y = num;
				}
			}
			rotation = UnityEngine.Random.rotation.eulerAngles;
			rotation.Scale(new Vector3(0f, 1f, 0f));
		}

		private Vector3 GetWorldPositionFromDownsampledHeightmapSectorCoord(Terrain terrain, Point2i sectorCoord, float height)
		{
			Vector3 vector = MetersPerSector(terrain);
			Vector3 vector2 = new Vector3((float)sectorCoord.x * vector.x + vector.x / 2f, height, (float)sectorCoord.y * vector.z + vector.y / 2f);
			return terrain.transform.position + vector2;
		}

		private void MonitorFlyabilityTestsInProgress()
		{
			for (int i = 0; i < _aiAircraftRunningFlyabilityTests.Count; i++)
			{
				AiCsTestFlyability aiCsTestFlyability = _aiAircraftRunningFlyabilityTests[i];
				if (aiCsTestFlyability.DoneTestingFlyability)
				{
					if (aiCsTestFlyability.AiControlledAircraft.AiAircraftInfo.AircraftIsFylable.Value)
					{
						AiControlledAircraftScript aiControlledAircraft = aiCsTestFlyability.AiControlledAircraft;
						aiControlledAircraft.SetAiControlSystem(new AiCsSandboxAirTraffic());
						aiControlledAircraft.RegisterAsPlayerTarget();
					}
					else
					{
						DespawnAircraft(aiCsTestFlyability.AiControlledAircraft, 0f);
					}
					_aiAircraftRunningFlyabilityTests.Remove(aiCsTestFlyability);
					i--;
				}
			}
		}

		private void MonitorForAircraftToDespawn()
		{
			Dictionary<AiControlledAircraftScript, float> dictionary = null;
			for (int i = 0; i < _aiAircraftAutoDespawn.Count; i++)
			{
				AiControlledAircraftScript aiControlledAircraftScript = _aiAircraftAutoDespawn[i];
				if (!aiControlledAircraftScript.AutoDespawn || aiControlledAircraftScript.CurrentControlSystem is AiCsTestFlyability || aiControlledAircraftScript.PreparingForDespawn)
				{
					continue;
				}
				if (CheckForDespawnDistance(aiControlledAircraftScript))
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<AiControlledAircraftScript, float>();
					}
					dictionary.Add(aiControlledAircraftScript, 0f);
				}
				else if (CheckForDespawnDamaged(aiControlledAircraftScript))
				{
					if (dictionary == null)
					{
						dictionary = new Dictionary<AiControlledAircraftScript, float>();
					}
					dictionary.Add(aiControlledAircraftScript, 120f);
				}
			}
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<AiControlledAircraftScript, float> item in dictionary)
			{
				DespawnAircraft(item.Key, item.Value);
			}
		}

		private void OnFlightSceneLoaded(object sender, EventArgs e)
		{
			if (Game.Instance.CurrentLevel.IsSandbox && Game.Instance.NetworkGameManager.IsServer)
			{
				StartCoroutine(AiSpawner());
			}
		}

		private void OnTerrainProximityLoaded(Terrain terrain)
		{
			GenerateDownsampledHeightmap(terrain);
		}

		private void OnTerrainProximityUnloaded(Terrain terrain)
		{
			_downsampledHeightmapData.Remove(terrain);
		}

		private IEnumerator SetAiSpeed(AircraftScript aircraftScript, float speed)
		{
			yield return new WaitForEndOfFrame();
			aircraftScript.AirSpeed = speed;
		}

		private void SpawnSandboxAiInternal(AiAircraftInfo aircraftInfo, bool autoDespawn, bool forceSpawnEvenIfUnflyable, StartLocation startLocation, AiCsSandboxAirTraffic.AiMode? aiMode, bool aggressive, ushort teamId, Action<AiControlledAircraftScript> onDone)
		{
			if (aircraftInfo == null)
			{
				return;
			}
			float speed = 150f;
			Vector3 position;
			Vector3 rotation;
			if (startLocation != null)
			{
				startLocation.ReadyLocationSynchronously();
				position = startLocation.Position;
				rotation = startLocation.Rotation;
				speed = startLocation.Velocity.magnitude;
			}
			else
			{
				GetStartingPosition(out position, out rotation);
			}
			if (forceSpawnEvenIfUnflyable || aircraftInfo.AircraftIsFylable.HasValue)
			{
				if (!forceSpawnEvenIfUnflyable && !aircraftInfo.AircraftIsFylable.Value)
				{
					return;
				}
				bool friendly;
				bool flag = (friendly = startLocation != null && startLocation.Flags.HasFlag(StartLocationFlags.IsFinalApproach));
				Action<AiControlledAircraftScript> a = delegate(AiControlledAircraftScript aiAircraft)
				{
					aiAircraft.RegisterAsPlayerTarget(friendly);
				};
				onDone = (Action<AiControlledAircraftScript>)Delegate.Combine(a, onDone);
				if (flag || (aiMode.HasValue && aiMode != AiCsSandboxAirTraffic.AiMode.Default))
				{
					if (flag)
					{
						aiMode = AiCsSandboxAirTraffic.AiMode.Land;
					}
					AiPath aiPath = Instance.GetAiFlightPath(position, AiPath.PathType.Landing, AiSettings.AircraftDespawnDistance, closest: true);
					if (aiPath != null)
					{
						Transform transform = aiPath.PathManager.waypoints[0];
						Vector3 normalized = (aiPath.PathManager.waypoints[1].position - transform.position).normalized;
						Vector3 startingPos = transform.position - normalized * 500f;
						onDone = (Action<AiControlledAircraftScript>)Delegate.Combine((Action<AiControlledAircraftScript>)delegate(AiControlledAircraftScript aiAircraft)
						{
							(aiAircraft.CurrentControlSystem as AiCsSandboxAirTraffic).SetAiMode(aiMode.Value, allowAutoSwitch: false, startingPos, aiPath);
						}, onDone);
						SpawnAi<AiCsSandboxAirTraffic>(aircraftInfo, startingPos, transform.rotation.eulerAngles, speed, autoDespawn, multipleFrames: true, teamId, onDone);
					}
					else
					{
						SpawnAi<AiCsSandboxAirTraffic>(aircraftInfo, position, rotation, speed, autoDespawn, multipleFrames: true, teamId, onDone);
					}
					return;
				}
				SpawnAi<AiCsSandboxAirTraffic>(aircraftInfo, position, rotation, speed, autoDespawn, multipleFrames: true, teamId, delegate(AiControlledAircraftScript aiAircraft)
				{
					if (aggressive)
					{
						(aiAircraft.CurrentControlSystem as AiCsSandboxAirTraffic).BecomeAggressive();
					}
					onDone?.Invoke(aiAircraft);
				});
				return;
			}
			SpawnAi<AiCsTestFlyability>(aircraftInfo, new Vector3(position.x, 5000f, position.z), rotation, speed, autoDespawn, multipleFrames: true, teamId, delegate(AiControlledAircraftScript aiAircraft)
			{
				_aiAircraftRunningFlyabilityTests.Add((AiCsTestFlyability)aiAircraft.CurrentControlSystem);
				if (Game.Instance.Device.IsUnityEditor && ShowDebugInfo)
				{
					Debug.Log("Aircraft hasn't been tested before, running with flyability control system.");
				}
				onDone?.Invoke(aiAircraft);
			});
		}

		private void UpdateDebugInfo(Terrain currentTerrain, List<Point2i> sectorLinePointsToEndpoint)
		{
			List<Transform> list;
			if (!_debugGroundAvoidancePoints.ContainsKey(currentTerrain))
			{
				list = new List<Transform>();
				GameObject gameObject = new GameObject("AvoidanceObjectsContainer");
				for (int i = 0; i < 256; i++)
				{
					GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
					gameObject2.GetComponent<Collider>().enabled = false;
					gameObject2.GetComponent<Renderer>().material.color = Color.yellow;
					gameObject2.transform.localScale = MetersPerSector(currentTerrain);
					gameObject2.transform.parent = gameObject.transform;
					list.Add(gameObject2.transform);
				}
				_debugGroundAvoidancePoints.Add(currentTerrain, list);
			}
			else
			{
				list = _debugGroundAvoidancePoints[currentTerrain];
			}
			foreach (Transform item in list)
			{
				item.gameObject.SetActive(value: false);
			}
			float[,] downsampledHeightmapData = GetDownsampledHeightmapData(currentTerrain);
			for (int j = 0; j < sectorLinePointsToEndpoint.Count; j++)
			{
				if (sectorLinePointsToEndpoint[j].y < 16 && sectorLinePointsToEndpoint[j].x < 16 && sectorLinePointsToEndpoint[j].y > 0 && sectorLinePointsToEndpoint[j].x > 0)
				{
					float height = downsampledHeightmapData[sectorLinePointsToEndpoint[j].y, sectorLinePointsToEndpoint[j].x];
					Vector3 worldPositionFromDownsampledHeightmapSectorCoord = GetWorldPositionFromDownsampledHeightmapSectorCoord(currentTerrain, sectorLinePointsToEndpoint[j], height);
					list[j].position = worldPositionFromDownsampledHeightmapSectorCoord;
					list[j].gameObject.SetActive(value: true);
				}
			}
		}

		private void UpdateDebugPlane(Plane avoidancePlane, Vector3 startWorldPosition, Vector3 endWorldPosition)
		{
			if (_groundAvoidancePlane == null)
			{
				_groundAvoidancePlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
				_groundAvoidancePlane.GetComponent<Collider>().enabled = false;
				_groundAvoidancePlane.name = "GroundAvoidancePlane";
			}
			_groundAvoidancePlane.transform.localScale = Vector3.one * Vector3.Distance(startWorldPosition, endWorldPosition);
			_groundAvoidancePlane.transform.position = avoidancePlane.normal * avoidancePlane.distance;
			_groundAvoidancePlane.transform.up = avoidancePlane.normal;
		}
	}
}
