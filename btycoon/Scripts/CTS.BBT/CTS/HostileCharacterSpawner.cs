using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS
{
	public class HostileCharacterSpawner : CTSSingleton<HostileCharacterSpawner>
	{
		[SerializeField]
		[Inject(false)]
		private CustomerSpawner _spawner;

		[SerializeField]
		[Range(0f, 1f)]
		private float _allowedCount = 0.1f;

		[FormerlySerializedAs("_investigatorSpawnChance")]
		[SerializeField]
		[CurveRange(0f, 0f, 1f, 1f, EColor.Clear)]
		private AnimationCurve _spawnChance = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		private PercentageList<StringKey> _baseRepartition = new PercentageList<StringKey>();

		[SerializeField]
		private int _baseMaxNaturalHostiles = 3;

		[Header("Investigators")]
		[SerializeField]
		private CustomerParameters _investigatorData;

		[SerializeField]
		private Customer _investigatorPrefab;

		[Header("Hunters")]
		[SerializeField]
		private CustomerParameters _hunterData;

		[SerializeField]
		private Customer _hunterPrefab;

		private readonly HashSet<Customer> _currentInvestigators = new HashSet<Customer>();

		private readonly HashSet<Customer> _currentHunters = new HashSet<Customer>();

		private PercentageList<StringKey> _repartition;

		private AnimationCurve _currentSpawnChance;

		private int _maxNaturalHostiles;

		public ReadOnlyHashSet<Customer> CurrentInvestigators => _currentInvestigators;

		public ReadOnlyHashSet<Customer> CurrentHunters => _currentHunters;

		public int HostileCount => _currentHunters.Count + _currentInvestigators.Count;

		public static StringKey HunterKey { get; } = "Hunter";

		public static StringKey InvestigatorKey { get; } = "Investigator";

		private static StringKey _difficultyMultiplierFlatKey { get; } = "Diff_HostileSpawnFlat";

		private static StringKey _difficultyMultiplierPercentKey { get; } = "Diff_HostileSpawnPercent";

		public static event Action<int> InvestigatorsCountChanged;

		public static event Action<Customer> HunterLeft;

		protected override void SingletonAwake()
		{
			_currentSpawnChance = _spawnChance;
			_spawner.TryingToSpawn += OnTryingToSpawnCustomer;
			Agent.AgentDespawned += OnAgentDespawned;
			CustomerManager.OnCustomerLeavesBar += OnCustomerLeaveBar;
			SetRepartition(_baseRepartition);
		}

		public void SetRepartition(PercentageList<StringKey> repartition)
		{
			if (repartition == null)
			{
				_repartition = _baseRepartition;
			}
			else
			{
				_repartition = repartition;
			}
		}

		public void SetSpawnChance(AnimationCurve curve)
		{
			if (curve == null)
			{
				_currentSpawnChance = _spawnChance;
			}
			else
			{
				_currentSpawnChance = curve;
			}
		}

		public void SetMaxNaturals(int? max)
		{
			if (max.HasValue)
			{
				_maxNaturalHostiles = max.Value;
			}
			else
			{
				_maxNaturalHostiles = _baseMaxNaturalHostiles;
			}
		}

		private void OnAgentDespawned(Agent agent)
		{
			if (agent is Customer customer)
			{
				RemoveInvestigator(customer);
				RemoveHunter(customer);
			}
		}

		protected override void OnSingletonDestroy()
		{
			_spawner.TryingToSpawn -= OnTryingToSpawnCustomer;
			Agent.AgentDespawned -= OnAgentDespawned;
			CustomerManager.OnCustomerLeavesBar -= OnCustomerLeaveBar;
		}

		private void OnCustomerLeaveBar(Customer customer)
		{
			RemoveInvestigator(customer);
			RemoveHunter(customer);
		}

		private void RemoveInvestigator(Customer customer)
		{
			if (_currentInvestigators.Contains(customer))
			{
				_currentInvestigators.Remove(customer);
				HostileCharacterSpawner.InvestigatorsCountChanged?.Invoke(CurrentInvestigators.Count);
			}
		}

		private void RemoveHunter(Customer customer)
		{
			if (_currentHunters.Contains(customer))
			{
				_currentHunters.Remove(customer);
				HostileCharacterSpawner.HunterLeft?.Invoke(customer);
			}
		}

		private void OnTryingToSpawnCustomer()
		{
			if (_spawner.CanSpawn(1) && !((float)HostileCount >= (float)_maxNaturalHostiles * Difficulty.GetMultiplicativeDifficulty(_difficultyMultiplierFlatKey)) && Mathf.CeilToInt((float)Prestige.TotalMaxPopulation(isVampire: false) * _allowedCount / Difficulty.GetMultiplicativeDifficulty(_difficultyMultiplierPercentKey)) - _currentInvestigators.Count > 0 && !(UnityEngine.Random.value > _currentSpawnChance.Evaluate((float)MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance * 0.01f)) && EntranceResolver.EntranceExists(_investigatorPrefab.HumanRandomMovementAreaMask) && _repartition.TryGetWeightedRandom(out var outData))
			{
				if (outData == InvestigatorKey)
				{
					SpawnInvestigator();
				}
				else if (outData == HunterKey)
				{
					SpawnHunter();
				}
			}
		}

		public void AddInvestigatorToList(Customer customer)
		{
			_currentInvestigators.Add(customer);
			CreateEliminationChore(customer);
		}

		public void AddHunterToList(Customer customer)
		{
			_currentHunters.Add(customer);
			CreateEliminationChore(customer);
		}

		private void CreateEliminationChore(Customer customer)
		{
			WorkerChoreHub workerChoreHub = new WorkerChoreHub(ChoreCategory.Investigators, new ActionHubKillHostile(customer), customer.RoomObject);
			workerChoreHub.AssignationBypassPowers = true;
			MonoSingleton<ChoreList>.Instance.AddToList(workerChoreHub);
		}

		private Customer[] SpawnSpecifics(Customer prefab, int count, CustomerParameters data)
		{
			try
			{
				_spawner.PrefabOverride = prefab;
				return _spawner.SpawnSpecific(count, data);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw;
			}
			finally
			{
				_spawner.PrefabOverride = null;
			}
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public Customer SpawnInvestigator()
		{
			Customer[] array = SpawnSpecifics(_investigatorPrefab, 1, _investigatorData);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			Customer customer = array[0];
			customer.Tags.AddTag(EAgentTag.Investigator);
			customer.Cooldowns.StartCooldown(BBTAgentTags.Investigate, 1000f);
			AddInvestigatorToList(customer);
			HostileCharacterSpawner.InvestigatorsCountChanged?.Invoke(CurrentInvestigators.Count);
			return customer;
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public Customer SpawnHunter()
		{
			Customer[] array = SpawnSpecifics(_hunterPrefab, 1, _hunterData);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			Customer customer = array[0];
			customer.Tags.AddTag(EAgentTag.Hunter);
			customer.Cooldowns.StartCooldown(BBTAgentTags.Investigate, 1000f);
			AddHunterToList(customer);
			return customer;
		}

		public List<Customer> SpawnHunters(int count)
		{
			List<Customer> list = new List<Customer>();
			for (int i = 0; i < count; i++)
			{
				Customer item = SpawnHunter();
				list.Add(item);
			}
			return list;
		}

		public List<Customer> SpawnInvestigators(int count, bool forceEnterBar = false)
		{
			List<Customer> list = new List<Customer>();
			for (int i = 0; i < count; i++)
			{
				Customer customer = SpawnInvestigator();
				if (forceEnterBar)
				{
					customer.ActionPlayer.ForceAction(new AgentActionEnterBar(forceEnterBar), EActionPriority.Forced);
				}
				list.Add(customer);
			}
			return list;
		}

		public void SetAllowedCount(float newAllowedCount)
		{
			_allowedCount = Mathf.Clamp01(newAllowedCount);
		}
	}
}
