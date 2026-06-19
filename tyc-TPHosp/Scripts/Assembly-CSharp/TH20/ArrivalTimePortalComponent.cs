using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalTimePortalComponent : ArrivalBaseComponent
	{
		public enum Type
		{
			Natural = 0,
			Artificial = 1
		}

		private struct SpawnTransform
		{
			public ArrivalTimePortalComponent _component;

			public float _time;

			public Type _type;

			public Transform _transform;

			public int _spawnIndex;

			public IllnessDefinition _illnessDefinition;

			public ArrivalMethodDefinition _arrivalMethod;

			public IPatientSpawned _onSpawned;
		}

		[SerializeField]
		private Type _type;

		[SerializeField]
		private int _initialSpawnCount;

		[SerializeField]
		private float _initialSpawnRate;

		[SerializeField]
		private float _spawnCooldownTime = 5f;

		[SerializeField]
		private List<Transform> _landingPoints = new List<Transform>();

		private List<float> _landingCooldownTimes = new List<float>();

		private bool _completedInitialSpawn;

		private static float _spawnTime;

		private static List<SpawnTransform> _transformsQueued;

		public static bool _isRestoringFromSave;

		public static List<ArrivalTimePortalComponent> Components { get; private set; }

		public static void Reset()
		{
			_spawnTime = 0f;
			_transformsQueued = new List<SpawnTransform>();
			Components = new List<ArrivalTimePortalComponent>();
		}

		private void Awake()
		{
			_landingCooldownTimes = new List<float>();
			for (int i = 0; i < _landingPoints.Count; i++)
			{
				_landingCooldownTimes.Add(0f);
			}
			if (_isRestoringFromSave || _initialSpawnCount == 0)
			{
				Components.Add(this);
				_completedInitialSpawn = true;
				return;
			}
			int num = 0;
			List<int> list = new List<int>();
			int count = _landingPoints.Count;
			float num2 = 0f;
			for (int j = 0; j < _initialSpawnCount; j++)
			{
				do
				{
					num = Random.Range(0, count);
				}
				while (list.Contains(num));
				list.Add(num);
				if (list.Count == count)
				{
					list.Clear();
				}
				QueueSpawn(num2, num);
				num2 += _initialSpawnRate;
			}
		}

		private void Update()
		{
			for (int i = 0; i < _landingCooldownTimes.Count; i++)
			{
				float num = _landingCooldownTimes[i];
				if (num > 0f)
				{
					_landingCooldownTimes[i] = Mathf.Max(num - Time.deltaTime, 0f);
				}
			}
		}

		private void OnDestroy()
		{
			Components.Remove(this);
		}

		private void QueueSpawn(float spawnTime, int spawnIndex)
		{
			_transformsQueued.Add(new SpawnTransform
			{
				_component = this,
				_time = _spawnTime + spawnTime,
				_type = _type,
				_transform = base.transform,
				_spawnIndex = spawnIndex
			});
			_transformsQueued.Sort((SpawnTransform t1, SpawnTransform t2) => t1._time.CompareTo(t2._time));
		}

		private bool IsValidToSpawn()
		{
			if (GetComponent<RoomItemVisualInvalidComponent>() != null)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < _landingCooldownTimes.Count; i++)
			{
				if (_landingCooldownTimes[i] > 0f)
				{
					num++;
				}
			}
			return num < _landingCooldownTimes.Count;
		}

		public void QueueSpawn(float spawnTime, IllnessDefinition illnessDefinition, ArrivalMethodDefinition arrivalMethod, IPatientSpawned onSpawned)
		{
			int spawnIndex = Random.Range(0, _landingPoints.Count);
			_transformsQueued.Add(new SpawnTransform
			{
				_component = this,
				_time = _spawnTime + spawnTime,
				_type = _type,
				_transform = base.transform,
				_spawnIndex = spawnIndex,
				_illnessDefinition = illnessDefinition,
				_arrivalMethod = arrivalMethod,
				_onSpawned = onSpawned
			});
			_transformsQueued.Sort((SpawnTransform t1, SpawnTransform t2) => t1._time.CompareTo(t2._time));
		}

		public static int Count()
		{
			return Components.Count;
		}

		private static void ValidateComponents()
		{
			for (int num = Components.Count - 1; num >= 0; num--)
			{
				if (Components[num] == null)
				{
					Components.RemoveAt(num);
				}
			}
		}

		public static void RandomTransform(out Type type, out Vector3 spawnPosition, out Vector3 landingPosition, out Quaternion rotation)
		{
			ValidateComponents();
			ArrivalTimePortalComponent arrivalTimePortalComponent = Components.RandomItem();
			if (Components.Count > 1)
			{
				while (!arrivalTimePortalComponent.IsValidToSpawn())
				{
					arrivalTimePortalComponent = Components.RandomItem();
				}
			}
			arrivalTimePortalComponent.GetRandomTransform(out type, out spawnPosition, out landingPosition, out rotation);
		}

		public static void Update(float deltaTime)
		{
			_spawnTime += deltaTime;
		}

		public static bool PopSpawnTransform(ref Type type, ref Vector3 spawnPosition, ref Vector3 landingPosition, ref Quaternion rotation)
		{
			if (!CanSpawnQueuedTransform())
			{
				return false;
			}
			SpawnTransform spawnTransform = _transformsQueued[0];
			ArrivalTimePortalComponent component = spawnTransform._component;
			if (!component.IsValidToSpawn())
			{
				return false;
			}
			_transformsQueued.RemoveAt(0);
			if (_transformsQueued.Count == 0 && !component._completedInitialSpawn)
			{
				component._completedInitialSpawn = true;
				Components.Add(component);
			}
			Transform transform = component._landingPoints[spawnTransform._spawnIndex];
			type = spawnTransform._type;
			spawnPosition = spawnTransform._transform.position;
			landingPosition = transform.position;
			rotation = transform.rotation;
			component._landingCooldownTimes[spawnTransform._spawnIndex] = component._spawnCooldownTime;
			return true;
		}

		public static bool CanSpawnQueuedTransform()
		{
			if (_transformsQueued.Count == 0)
			{
				return false;
			}
			SpawnTransform spawnTransform = _transformsQueued[0];
			if (spawnTransform._time > _spawnTime)
			{
				return false;
			}
			if (spawnTransform._component == null)
			{
				_transformsQueued.RemoveAt(0);
				return false;
			}
			return spawnTransform._component.IsValidToSpawn();
		}

		public static bool CanSpawnQueuedTransform(ref IllnessDefinition illnessDefinition, ref ArrivalMethodDefinition arrivalMethod, ref IPatientSpawned onSpawned)
		{
			if (CanSpawnQueuedTransform())
			{
				SpawnTransform spawnTransform = _transformsQueued[0];
				illnessDefinition = spawnTransform._illnessDefinition;
				arrivalMethod = spawnTransform._arrivalMethod;
				onSpawned = spawnTransform._onSpawned;
				return true;
			}
			return false;
		}

		public static bool ValidToSpawn()
		{
			ValidateComponents();
			foreach (ArrivalTimePortalComponent component in Components)
			{
				if (component.IsValidToSpawn())
				{
					return true;
				}
			}
			return false;
		}

		private void GetRandomTransform(out Type type, out Vector3 spawnPosition, out Vector3 landingPosition, out Quaternion rotation)
		{
			int index;
			do
			{
				index = Random.Range(0, _landingPoints.Count);
			}
			while (_landingCooldownTimes[index] > 0f);
			Transform transform = _landingPoints[index];
			type = _type;
			spawnPosition = base.transform.position;
			landingPosition = transform.position;
			rotation = transform.rotation;
			_landingCooldownTimes[index] = _spawnCooldownTime;
		}
	}
}
