using System;
using System.Collections;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	public class WandererSpawner : MonoBehaviour, ILockable
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
		private float _spawnFrequency = 0.5f;

		[SerializeField]
		private int _minimumWandererCount = 10;

		[SerializeField]
		private int _maximumWandererCount = 20;

		[SerializeField]
		private ESubSpecies[] _possibleSubSpecies;

		[SerializeField]
		private SpawnPoint[] _spawnPoints;

		private int _lastSpawnPoint;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public MoveTarget GetLeaveTarget()
		{
			return _spawnPoints.GetRandom();
		}

		private void Start()
		{
			if (_originalPoolSize > 0)
			{
				Pooler.Create(_customerPrefab, _originalPoolSize);
			}
			if (_isActive && !ObjectLock.IsLocked())
			{
				StartCoroutine(SpawnUpdate());
			}
		}

		void ILockable.OnLocked()
		{
			StopAllCoroutines();
		}

		void ILockable.OnUnlocked()
		{
			StopAllCoroutines();
			StartCoroutine(SpawnUpdate());
		}

		private IEnumerator SpawnUpdate()
		{
			while (true)
			{
				if (_isActive || ObjectLock.IsLocked())
				{
					SpawnFromRules();
				}
				yield return Coroutines.WaitForSeconds(_spawnFrequency);
			}
		}

		private void SpawnFromRules(bool maxPopulationCheck = true)
		{
			if (!maxPopulationCheck || Wanderer.TotalInGame < _minimumWandererCount || Wanderer.TotalInGame < _maximumWandererCount - CustomerManager.CustomersCount)
			{
				ESubSpecies customerTypeToSpawn = ((_possibleSubSpecies.Length != 0) ? _possibleSubSpecies.GetRandom() : MonoSingleton<CustomerTypesManager>.Instance.SelectCustomerTypeByInfluence());
				Spawn(customerTypeToSpawn);
			}
		}

		public Customer Spawn(ESubSpecies customerTypeToSpawn, SpawnPoint spawnPoint = null)
		{
			CustomerParameters customerParametersByCustomerType = MonoSingleton<CustomerTypesManager>.Instance.GetCustomerParametersByCustomerType(customerTypeToSpawn);
			if (!spawnPoint)
			{
				int num;
				for (num = _lastSpawnPoint; num == _lastSpawnPoint; num = UnityEngine.Random.Range(0, _spawnPoints.Length))
				{
				}
				spawnPoint = _spawnPoints[num];
				_lastSpawnPoint = num;
			}
			return SpawnSpecific(customerParametersByCustomerType, spawnPoint);
		}

		public Customer SpawnSpecific(CustomerParameters specificCustomer, SpawnPoint spawnPoint)
		{
			Customer customer = Pooler.Pull(_customerPrefab);
			customer.Spawn(specificCustomer, spawnPoint);
			return customer;
		}
	}
}
