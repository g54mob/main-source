using System;
using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	[DefaultExecutionOrder(-1)]
	internal class CustomerSpawner : CTSSingleton<CustomerSpawner>, ILockable
	{
		[SerializeField]
		private CustomerSpawnerData _data;

		[SerializeField]
		private bool _isActive = true;

		[SerializeField]
		private bool _debug;

		[SerializeField]
		[Min(0f)]
		private int _originalPoolSize = 20;

		[SerializeField]
		private Customer _customerPrefab;

		[SerializeField]
		private List<ESubSpecies> _possibleSubSpecies;

		[SerializeField]
		private List<ESubSpecies> _possibleVampireSubSpecies;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Prestige _prestige;

		private bool _spawnedCustomers;

		private float _nextSpawn;

		[SerializeField]
		private SpawnPoint[] _spawnPoints;

		private int _lastSpawnPoint;

		public bool SpawnsVampires = true;

		private HashSet<Customer> _customersSpawned = new HashSet<Customer>();

		[field: SerializeField]
		public float EntranceCooldown { get; private set; } = 10f;

		[field: SerializeField]
		public List<NavigationArea> NavAreaSpawnPriorities { get; private set; } = new List<NavigationArea>();

		[field: SerializeField]
		public NavigationArea VampireArea { get; private set; }

		[field: SerializeField]
		public NavigationArea HumanArea { get; private set; }

		public static RoomBuilding EntranceRoom { get; private set; }

		public Customer CurrentCustomerPrefab { get; private set; }

		public Customer PrefabOverride { get; set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public int UnassignedCustomers
		{
			get
			{
				int num = 0;
				foreach (Customer item in _customersSpawned)
				{
					if ((object)item.AssignedSeat == null)
					{
						num++;
					}
				}
				return num;
			}
		}

		public float CurrentHumanVampireRatio
		{
			get
			{
				if (CustomerManager.HumanCount <= 0)
				{
					return 0f;
				}
				return (float)CustomerManager.HumanCount / _prestige.CurrentPrestigeLevel.VampireRatio - (float)CustomerManager.VampireCount;
			}
		}

		public event Action TryingToSpawn;

		public event Action SpawnedCustomers;

		public void SetCustomerPrefab(Customer prefab)
		{
			if (prefab == null)
			{
				CurrentCustomerPrefab = _customerPrefab;
			}
			else
			{
				CurrentCustomerPrefab = prefab;
			}
		}

		protected override void SingletonAwake()
		{
			SetCustomerPrefab(null);
			Agent.AgentDespawned += OnAgentDespawned;
			AgentActionLeave.CustomerLeftBar += OnCustomerLeftBar;
		}

		protected override void OnSingletonDestroy()
		{
			Agent.AgentDespawned -= OnAgentDespawned;
			AgentActionLeave.CustomerLeftBar -= OnCustomerLeftBar;
		}

		private void OnCustomerLeftBar(Customer customer)
		{
			_customersSpawned.Remove(customer);
		}

		private void OnAgentDespawned(Agent agent)
		{
			if (agent is Customer customer)
			{
				OnCustomerLeftBar(customer);
			}
		}

		public MoveTarget GetLeaveTarget()
		{
			return _spawnPoints.GetRandom();
		}

		public SpawnPoint GetClosestSpawnPoint(Vector3 position)
		{
			return _spawnPoints.GetNearest(position.ToHorizontal2D());
		}

		private void Start()
		{
			_nextSpawn = Time.time + _prestige.CurrentPrestigeLevel.TimeBetweenSpawnsInSeconds;
			if (_originalPoolSize > 0)
			{
				Pooler.Create(_customerPrefab, _originalPoolSize);
			}
			EntranceRoom = MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers[0].GeneratedRooms[0];
		}

		private void Update()
		{
			if (_isActive && CTSSingleton<LevelParameters>.Instance.IsOpen && !ObjectLock.IsLocked())
			{
				TrySpawnCustomer();
			}
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}

		private void TrySpawnCustomer()
		{
			if (!(Time.time < _nextSpawn))
			{
				SpawnFromRules();
			}
		}

		public void AddCustomerToSpawnList(Customer customer)
		{
			_customersSpawned.Add(customer);
		}

		public bool CanSpawn(int count, bool isVampire = false)
		{
			return GetMaxSpawnCount(isVampire) >= count;
		}

		public int GetMaxSpawnCount(bool isVampire)
		{
			int num = MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.MaxCustomerPopulation(isVampire);
			int num2 = UnassignedCustomers + CTSSingleton<SeatCounter>.Instance.CurrentUsedHumanSeatCount;
			if (isVampire)
			{
				num2 += CTSSingleton<SeatCounter>.Instance.CurrentUsedVampireSeatCount;
			}
			return num - num2;
		}

		private void SpawnFromRules(bool checkMaxPopulation = true)
		{
			bool flag = SpawnsVampires && CurrentHumanVampireRatio >= 1f;
			int num = _data.MaxGroupSize;
			if (checkMaxPopulation)
			{
				num = Math.Min(num, GetMaxSpawnCount(flag));
				if (num <= 0)
				{
					return;
				}
			}
			_spawnedCustomers = false;
			this.TryingToSpawn?.Invoke();
			if (!_spawnedCustomers)
			{
				int num2 = (int)Math.Ceiling(Mathf.Min(_data.GroupSizeRandomCurve.Evaluate(UnityEngine.Random.value) * (float)_data.MaxGroupSize, num));
				if (num2 == 0)
				{
					num2 = 1;
				}
				if (flag && AgentActionEnterBar.CanCustomerGroupEnterBar(isVampire: true))
				{
					SpawnVampiresFromRules(num2);
					return;
				}
				ESubSpecies customerTypeToSpawn = ((_possibleSubSpecies.Count > 0) ? _possibleSubSpecies.GetRandom() : MonoSingleton<CustomerTypesManager>.Instance.SelectCustomerTypeByInfluence());
				SpawnSpecific(num2, MonoSingleton<CustomerTypesManager>.Instance.GetCustomerParametersByCustomerType(customerTypeToSpawn));
			}
		}

		public Customer[] SpawnVampiresFromRules(int count)
		{
			CustomerParameters vampireByInfluence = MonoSingleton<CustomerTypesManager>.Instance.GetVampireByInfluence();
			return SpawnSpecific(count, vampireByInfluence);
		}

		public void AddPossibleSubSpecies(ESubSpecies subSpecies)
		{
			List<ESubSpecies> list = (MonoSingleton<CustomerTypesManager>.Instance.GetCustomerParametersByCustomerType(subSpecies).IsVampire ? _possibleVampireSubSpecies : _possibleSubSpecies);
			if (!list.Contains(subSpecies))
			{
				list.Add(subSpecies);
			}
		}

		public void RemovePossibleSubSpecies(ESubSpecies subSpecies)
		{
			(MonoSingleton<CustomerTypesManager>.Instance.GetCustomerParametersByCustomerType(subSpecies).IsVampire ? _possibleVampireSubSpecies : _possibleSubSpecies).Remove(subSpecies);
		}

		private void SetupVampire(Customer vampire)
		{
			Vector3 entrancePoint = EntranceResolver.GetEntrancePoint(vampire.transform.position, vampire.VampireAreaMask);
			vampire.transform.SetPositionAndRotation(entrancePoint, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
			vampire.SetVisualActive(value: false);
			vampire.RoomObject.TryFindCurrentRoom();
			vampire.GroupData.CanEnterBar = true;
			vampire.ActionPlayer.InsertAction(new AgentActionVampireSpawn(entrancePoint, NavAreaSpawnPriorities), AgentActionPlayer.EInsertType.CancelAction, EActionPriority.Forced);
		}

		public Customer[] Spawn(int count, ESubSpecies customerTypeToSpawn, SpawnPoint spawnPoint = null)
		{
			CustomerParameters customerParametersByCustomerType = MonoSingleton<CustomerTypesManager>.Instance.GetCustomerParametersByCustomerType(customerTypeToSpawn);
			return SpawnSpecific(count, customerParametersByCustomerType, spawnPoint);
		}

		[Obsolete]
		public Customer[] Spawn(int count, string customerTypeToSpawn, SpawnPoint spawnPoint = null)
		{
			CustomerParameters customerDatasFromCustomerType = MonoSingleton<CustomerTypesManager>.Instance.GetCustomerDatasFromCustomerType(customerTypeToSpawn);
			return SpawnSpecific(count, customerDatasFromCustomerType, spawnPoint);
		}

		public Customer[] SpawnSpecific(int count, CustomerParameters data, SpawnPoint spawnPoint = null)
		{
			Customer customer = PrefabOverride ?? CurrentCustomerPrefab;
			if (data.IsVampire)
			{
				if (!AgentActionVampireSpawn.RoomExists(VampireArea) && !AgentActionVampireSpawn.RoomExists(HumanArea))
				{
					return Array.Empty<Customer>();
				}
			}
			else if (!EntranceResolver.EntranceExists(customer.HumanRandomMovementAreaMask))
			{
				return Array.Empty<Customer>();
			}
			_nextSpawn = Time.time + _prestige.CurrentPrestigeLevel.TimeBetweenSpawnsInSeconds;
			Customer[] array = new Customer[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = Pooler.Pull(customer);
			}
			CustomerGroups.GetOrCreateGroup().SetMembers(array);
			if (data == null)
			{
				Debug.LogError("Failed to spawn Customer ");
				return null;
			}
			if (!spawnPoint)
			{
				spawnPoint = GetRandomSpawnPoint();
			}
			Customer[] array2 = array;
			foreach (Customer customer2 in array2)
			{
				customer2.Spawn(data, spawnPoint);
				_customersSpawned.Add(customer2);
				if (data.IsVampire)
				{
					SetupVampire(customer2);
				}
			}
			this.SpawnedCustomers?.Invoke();
			_spawnedCustomers = true;
			return array;
		}

		public SpawnPoint GetRandomSpawnPoint()
		{
			int num;
			for (num = _lastSpawnPoint; num == _lastSpawnPoint; num = UnityEngine.Random.Range(0, _spawnPoints.Length))
			{
			}
			_lastSpawnPoint = num;
			return _spawnPoints[num];
		}

		public int GetSpawnPointIndex(SpawnPoint point)
		{
			for (int i = 0; i < _spawnPoints.Length; i++)
			{
				SpawnPoint spawnPoint = _spawnPoints[i];
				if (point == spawnPoint)
				{
					return i;
				}
			}
			return -1;
		}

		public SpawnPoint GetSpawnPoint(int index)
		{
			index = index.ClampIndex(_spawnPoints);
			return _spawnPoints[index];
		}

		private void OnDestroy()
		{
			CustomerManager.Clear();
		}
	}
}
