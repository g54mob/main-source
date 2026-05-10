using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class WorkerSpawn : AgentSpawn<Worker>, IGive<Worker>
	{
		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private bool _startChoresPaused;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		[Range(0f, 5f)]
		private int _workerLevel = 3;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private bool _levelingPaused;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private SerializableDictionary<ChoreCategory, bool> _specificChoreCategories = new SerializableDictionary<ChoreCategory, bool>();

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private SerializableDictionary<EAgentStatistics, float> _specificStatisticUnitInterval = new SerializableDictionary<EAgentStatistics, float>();

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private bool _overrideSalary;

		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "IsSpawningAllowed", "_overrideSalary" })]
		private int _salary;

		[SerializeField]
		[ShowIf("IsSpawningAllowed")]
		private bool _specificPower;

		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "IsSpawningAllowed", "_specificPower" })]
		private WorkerPowerFeature.e_PowerFeatures _power;

		[SerializeField]
		private WorkerParameters _workerParameters;

		private static readonly Addressable<Worker> _workerPrefab = new Addressable<Worker>("Assets/Prefabs/Units/Worker.prefab");

		protected override Color GizmoColor
		{
			get
			{
				if (!IsSpawningAllowed())
				{
					return Color.red;
				}
				return new Color(1f, 0.5f, 0f);
			}
		}

		protected override bool IsSpawningAllowed()
		{
			return _workerParameters;
		}

		protected override Worker SpawnAgent()
		{
			if (!_workerParameters)
			{
				return null;
			}
			Worker worker = Pooler.Pull((Worker)_workerPrefab, false);
			worker.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			worker.WorkerParameters = _workerParameters;
			CharacterData characterData = new CharacterData
			{
				Ethnics = EEthnics.Europeen,
				Species = ESpecies.Vampire,
				SubSpecies = ESubSpecies.Waiter
			};
			if (_spawnSpecificGender)
			{
				characterData.Gender = ((_gender == EGender.Man) ? CTS.EGender.Male : CTS.EGender.Female);
				worker.gameObject.SetActive(value: true);
				worker.Spawn(_workerLevel, characterData);
			}
			else
			{
				characterData.Gender = ((Random.value > 0.5f) ? CTS.EGender.Male : CTS.EGender.Female);
				worker.gameObject.SetActive(value: true);
				worker.Spawn(_workerLevel, characterData);
			}
			if (_specificPower)
			{
				worker.PowerFeatures.UnlockCapacity(_power);
			}
			else
			{
				worker.PowerFeatures.UnlockCapacity(MonoSingleton<WorkerSpawner>.Instance.GetPower);
			}
			if (!_autoSpawn)
			{
				worker.UpdateLighting(1f);
			}
			if (_overrideSalary)
			{
				worker.WorkerSalary.CurrentSalary = _salary;
			}
			worker.Engage();
			MonoSingleton<InterimAgency>.Instance.Import(worker);
			worker.AutonomousActions.Paused = _startPaused;
			if (_startChoresPaused)
			{
				worker.ChoreAssigner.SetActive(value: false);
			}
			if (_levelingPaused)
			{
				worker.Level.Paused = true;
			}
			foreach (var (cat, value) in _specificChoreCategories)
			{
				worker.ChoreAssigner.TogglePriority(cat, value);
			}
			foreach (KeyValuePair<EAgentStatistics, float> item in _specificStatisticUnitInterval)
			{
				worker.Statistics.SetStatisticFromUnitInterval(item.Key, item.Value);
			}
			if (!_autoSpawn)
			{
				worker.SetVisualActive(value: false);
				worker.ActionPlayer.InsertAction(new AgentActionVampireSpawn(worker.transform.position), AgentActionPlayer.EInsertType.CancelAction, EActionPriority.Forced);
			}
			return worker;
		}

		Worker IGive<Worker>.Get()
		{
			return GetSpawned();
		}
	}
}
