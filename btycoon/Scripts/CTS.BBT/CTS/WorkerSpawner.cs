using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class WorkerSpawner : MonoSingleton<WorkerSpawner>
	{
		[SerializeField]
		private Worker _workerPrefab;

		[SerializeField]
		private Transform mainWorkerSpawnPoint;

		[SerializeField]
		private int _poolSize = 5;

		[SerializeField]
		private CharacterData _characterData;

		[SerializeField]
		private List<CharacterSpecificClothesData> _clothes;

		private static List<CharacterSpecificClothesData> _specificClothes = new List<CharacterSpecificClothesData>();

		[SerializeField]
		private PercentageList<WorkerPowerFeature.e_PowerFeatures> _basePowerRepartition;

		private PercentageList<WorkerPowerFeature.e_PowerFeatures> _powerRepartition;

		public static ReadOnlyList<CharacterSpecificClothesData> SpecificClothes => _specificClothes;

		[field: SerializeField]
		public List<NavigationArea> NavAreaSpawnPriorities { get; private set; } = new List<NavigationArea>();

		[field: SerializeField]
		public NavigationArea WorkerArea { get; private set; }

		public WorkerPowerFeature.e_PowerFeatures GetPower => _powerRepartition.GetWeightedRandom();

		protected override void SingletonAwake()
		{
			foreach (CharacterSpecificClothesData item in _clothes)
			{
				AddClothes(item);
			}
		}

		protected override void OnSingletonDestroy()
		{
		}

		public static void AddClothes(CharacterSpecificClothesData clothes)
		{
			if (!_specificClothes.Contains(clothes))
			{
				_specificClothes.Add(clothes);
			}
		}

		public void SetPowerRepartition(PercentageList<WorkerPowerFeature.e_PowerFeatures> repartition)
		{
			if (repartition == null)
			{
				_powerRepartition = _basePowerRepartition;
			}
			else
			{
				_powerRepartition = repartition;
			}
		}

		private void Start()
		{
			Pooler.Create(_workerPrefab, _poolSize);
		}

		public Worker Spawn(Transform _spawnPoint, int p_level, WorkerParameters _params = null)
		{
			if (_spawnPoint == null)
			{
				return null;
			}
			Worker worker = Pooler.Pull(_workerPrefab);
			worker.transform.SetPositionAndRotation(_spawnPoint);
			worker.gameObject.SetActive(value: true);
			worker.Spawn(p_level, _characterData, _params);
			_specificClothes.GetRandom()?.ChangeClothes(worker.AgentVisualControler);
			if (_powerRepartition.TryGetWeightedRandom(out var outData))
			{
				worker.PowerFeatures.UnlockCapacity(outData);
			}
			return worker;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void DebugSpawn()
		{
			Spawn(base.transform, 1);
		}
	}
}
