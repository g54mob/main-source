using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class Spawner : CoreBehaviour
	{
		public bool SpawnSettingsByComplexity;

		[OdinSerialize]
		[ShowIf("SpawnSettingsByComplexity", true)]
		private List<SpawnSettingByComplexity> SpawnList = new List<SpawnSettingByComplexity>();

		[HideIf("SpawnSettingsByComplexity", true)]
		public SpawnSetting DefaultSpawnSetting;

		public List<Transform> SpawnPositions = new List<Transform>();

		public Transform FlockingTarget;

		public float SpawnDiameter;

		[FormerlySerializedAs("HasExclusionDiameter")]
		public bool HasExclusionRadius;

		[ShowIf("HasExclusionRadius", true)]
		[FormerlySerializedAs("ExclusionDiameter")]
		public float ExclusionRadius;

		public bool RandomRotation;

		public List<EChemicalState> DeactivateOnChemicalState = new List<EChemicalState>();

		private SpawnSetting _activeSpawnSetting;

		private int _totalNumberOfEnemies;

		private List<InteractiveWorldObject> _spawnedEnemies;

		private int _seed;

		private bool _stopCoroutine;

		private static bool _shouldSpawn;

		public static bool ShouldSpawn
		{
			get
			{
				if (!_shouldSpawn)
				{
					if (RuntimeGlobals.RunningMode != ERunningMode.TestFlight)
					{
						return RuntimeGlobals.RunningMode != ERunningMode.TestFlightPlanet;
					}
					return false;
				}
				return true;
			}
			set
			{
				_shouldSpawn = value;
			}
		}

		public Vector3 GetTargetPosition()
		{
			if (FlockingTarget != null)
			{
				return FlockingTarget.position;
			}
			if (OwnWorldObject != null)
			{
				return OwnWorldObject.transform.position;
			}
			return Vector3.zero;
		}

		public void TryToSpawn(int amount)
		{
			OwnWorldObject.StartCoroutine(SpawnEnemies(amount));
		}

		public void TryToSpawnImmediate(int amount)
		{
			int num = 0;
			for (int i = 0; i < amount * 2; i++)
			{
				if (!ShouldSpawn)
				{
					break;
				}
				if (num >= amount)
				{
					break;
				}
				if (_activeSpawnSetting.HasSpawnLimit && _totalNumberOfEnemies >= _activeSpawnSetting.SpawnLimit)
				{
					break;
				}
				if (_spawnedEnemies.Count >= _activeSpawnSetting.MaxActive)
				{
					break;
				}
				if (SpawnEnemy())
				{
					num++;
				}
			}
		}

		private IEnumerator SpawnEnemiesBurst()
		{
			yield return new WaitForEndOfFrame();
			float effectiveInterval = _activeSpawnSetting.BurstInterval;
			float t = effectiveInterval;
			bool started = false;
			bool reset = false;
			while (!_stopCoroutine)
			{
				while (!ShouldSpawn || _spawnedEnemies.Count >= _activeSpawnSetting.MaxActive)
				{
					effectiveInterval = _activeSpawnSetting.BurstInterval * _activeSpawnSetting.CooldownMultiplier;
					yield return true;
				}
				if (started && !reset && _spawnedEnemies.Count <= 0)
				{
					t = 0f;
					effectiveInterval = _activeSpawnSetting.BurstInterval * _activeSpawnSetting.CooldownMultiplier;
					reset = true;
				}
				t += Time.deltaTime;
				if (t >= effectiveInterval)
				{
					t = 0f;
					effectiveInterval = _activeSpawnSetting.BurstInterval;
					yield return OwnWorldObject.StartCoroutine(SpawnEnemies(_activeSpawnSetting.BurstSize));
					started = true;
					reset = false;
				}
				if (_activeSpawnSetting.HasSpawnLimit && _totalNumberOfEnemies >= _activeSpawnSetting.SpawnLimit)
				{
					break;
				}
				yield return true;
			}
		}

		private IEnumerator SpawnEnemies(int amount)
		{
			int spawnCount = 0;
			while (!_stopCoroutine && ShouldSpawn && spawnCount < amount && (!_activeSpawnSetting.HasSpawnLimit || _totalNumberOfEnemies < _activeSpawnSetting.SpawnLimit) && _spawnedEnemies.Count < _activeSpawnSetting.MaxActive)
			{
				if (SpawnEnemy())
				{
					spawnCount++;
				}
				yield return true;
			}
		}

		private bool SpawnEnemy()
		{
			if (OwnWorldObject != null && OwnWorldObject.HealthPool != null && DeactivateOnChemicalState.Contains(OwnWorldObject.HealthPool.CurrentState))
			{
				return false;
			}
			Vector3 vector = Random.insideUnitCircle;
			Vector3 position = OwnWorldObject.transform.position;
			if (SpawnPositions != null && SpawnPositions.Count > 0)
			{
				position = SpawnPositions.RandomItem().position;
			}
			Vector3 vector2 = position + vector * SpawnDiameter / 2f;
			if (HasExclusionRadius && (vector2 - position).magnitude < ExclusionRadius)
			{
				return false;
			}
			vector2.z = -0.5f;
			LayerMask spawnCheckLayerEnemyUnits = BaseSingleton<CollisionLayerManager>.Instance.SpawnCheckLayerEnemyUnits;
			bool flag = Physics.CheckSphere(vector2, 5f, spawnCheckLayerEnemyUnits);
			if (RuntimeGlobals.WorldController.GenerateTerrain && RuntimeGlobals.WorldController.ForeGroundTerrain != null)
			{
				NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(vector2);
				if (data.HasValue)
				{
					flag = flag || data.Value.Volume >= 0.5f;
				}
			}
			if (flag)
			{
				return false;
			}
			InteractiveWorldObject interactiveWorldObject = Object.Instantiate(_activeSpawnSetting.ObjectToSpawn, vector2, Quaternion.identity);
			if (RandomRotation)
			{
				interactiveWorldObject.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(0, 360));
			}
			interactiveWorldObject.InitSpawn(_seed, this);
			_spawnedEnemies.Add(interactiveWorldObject);
			_totalNumberOfEnemies++;
			return true;
		}

		public void RemoveFromSpawner(InteractiveWorldObject enemy)
		{
			_spawnedEnemies.Remove(enemy);
		}

		public void SetMaxActive(int maxActive)
		{
			_activeSpawnSetting.MaxActive = maxActive;
		}

		protected override void OnInit()
		{
			_seed = Random.Range(int.MinValue, int.MaxValue);
			_totalNumberOfEnemies = 0;
			_stopCoroutine = false;
			_spawnedEnemies = new List<InteractiveWorldObject>();
			_activeSpawnSetting = DefaultSpawnSetting;
			if (SpawnSettingsByComplexity)
			{
				SpawnSettingByComplexity spawnSettingByComplexity = SpawnList.FirstOrDefault((SpawnSettingByComplexity s) => s.Complexity.Contains(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.GetActiveMissionComplexity()));
				if (spawnSettingByComplexity != null)
				{
					_activeSpawnSetting = spawnSettingByComplexity.Setting;
				}
				else if (SpawnList.Count > 0)
				{
					_activeSpawnSetting = SpawnList[0].Setting;
				}
			}
			if (_activeSpawnSetting.ContinuousBursts)
			{
				OwnWorldObject.StartCoroutine(SpawnEnemiesBurst());
			}
		}

		protected override void OnUpdate()
		{
			if (ShouldSpawn || _spawnedEnemies.Count <= 0)
			{
				return;
			}
			foreach (InteractiveWorldObject item in _spawnedEnemies.ToList())
			{
				RemoveFromSpawner(item);
				item.Destroy();
			}
		}

		protected override void OnRelease()
		{
			_stopCoroutine = true;
			foreach (InteractiveWorldObject spawnedEnemy in _spawnedEnemies)
			{
				spawnedEnemy.RemoveSpawner(this);
			}
			_spawnedEnemies.Clear();
			_totalNumberOfEnemies = 0;
			_seed = 0;
		}

		public void OnDestroy()
		{
			_stopCoroutine = true;
		}
	}
}
