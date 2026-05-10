using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.TechTree;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS.BBT.TechTree
{
	[DefaultExecutionOrder(-10)]
	public class TechTreeManager : CTSSingleton<TechTreeManager>
	{
		[SerializeField]
		private bool _debugMode;

		private static Dictionary<TechTreeTechnologySO, ETechTreeTechnologyLevel> _technologyResearchStates = new Dictionary<TechTreeTechnologySO, ETechTreeTechnologyLevel>();

		private static IList<TechTreeTechnologySO> _technologySO;

		private static bool _debugModeStatic;

		public static bool IsInitialized { get; private set; }

		public static ReadOnlyDictionary<TechTreeTechnologySO, ETechTreeTechnologyLevel> ResearchStates => _technologyResearchStates;

		public static int GetCurrentPoints
		{
			get
			{
				if (!CTSSingleton<TechTreePoints>.InstanceExists())
				{
					return 0;
				}
				return CTSSingleton<TechTreePoints>.Instance.CurrentPoints;
			}
		}

		public static event Action OnTechTreeInitialized;

		public static event Action<TechTreeTechnologySO> OnTechnologyIgnoreRequirements;

		public static event Action<TechTreeTechnologySO> OnTechnologyResearched;

		protected override void SingletonAwake()
		{
			_debugModeStatic = _debugMode;
			_technologySO = Addressables.LoadAssetsAsync<TechTreeTechnologySO>("Technologies").WaitForCompletion();
			InitializeTechTree();
		}

		protected override void OnSingletonDestroy()
		{
			_technologyResearchStates.Clear();
			IsInitialized = false;
		}

		private static bool HasEnoughPoints(int requiredPoints)
		{
			return GetCurrentPoints >= requiredPoints;
		}

		public void ResetTechTree()
		{
			IsInitialized = false;
			InitializeTechTree();
		}

		private void InitializeTechTree()
		{
			if (IsInitialized)
			{
				return;
			}
			_technologyResearchStates.Clear();
			foreach (TechTreeTechnologySO item in _technologySO)
			{
				_technologyResearchStates[item] = item.DefaultLevel;
			}
			IsInitialized = true;
			TechTreeManager.OnTechTreeInitialized?.Invoke();
		}

		private static bool AreRequiredTechnologiesResearched(TechTreeTechnologySO tech)
		{
			foreach (KeyValuePair<TechTreeTechnologySO, ETechTreeTechnologyLevel> requiredTechnology in tech.RequiredTechnologies)
			{
				if (!_technologyResearchStates.TryGetValue(requiredTechnology.Key, out var value) || !FirstLevelHasBeenResearched(requiredTechnology.Key) || value < requiredTechnology.Value)
				{
					return false;
				}
			}
			return true;
		}

		public static bool AttemptToResearchTechnology(TechTreeTechnologySO tech)
		{
			if (!_technologyResearchStates.TryGetValue(tech, out var value))
			{
				return false;
			}
			ETechTreeTechnologyLevel technologyMaxResearchLevel = GetTechnologyMaxResearchLevel(tech);
			ETechTreeTechnologyLevel key = ((value == technologyMaxResearchLevel) ? value : (value + 1));
			if (value == technologyMaxResearchLevel && FirstLevelHasBeenResearched(tech))
			{
				return false;
			}
			if (!HasEnoughPoints(tech.ResearchPointsLevels[key]))
			{
				return false;
			}
			if (!AreRequiredTechnologiesResearched(tech))
			{
				return false;
			}
			if (CTSSingleton<TechTreePoints>.InstanceExists())
			{
				CTSSingleton<TechTreePoints>.Instance.SpendPoints(tech.ResearchPointsLevels[key]);
			}
			if (value < technologyMaxResearchLevel)
			{
				_technologyResearchStates[tech]++;
			}
			TechTreeManager.OnTechnologyResearched?.Invoke(tech);
			return true;
		}

		public static void DeliberatelyIgnoreTechnologyRequirements(TechTreeTechnologySO tech)
		{
			TechTreeManager.OnTechnologyIgnoreRequirements?.Invoke(tech);
		}

		public static void ResearchATechnology(TechTreeTechnologySO tech, ETechTreeTechnologyLevel level)
		{
			if (_technologyResearchStates.ContainsKey(tech))
			{
				_technologyResearchStates[tech] = level;
			}
			else
			{
				_technologyResearchStates.Add(tech, (level <= GetTechnologyMaxResearchLevel(tech)) ? level : GetTechnologyMaxResearchLevel(tech));
			}
			TechTreeManager.OnTechnologyResearched?.Invoke(tech);
		}

		public static void ResearchSomeTechnologies(List<KeyValuePair<TechTreeTechnologySO, ETechTreeTechnologyLevel>> techsToUnlock)
		{
			foreach (KeyValuePair<TechTreeTechnologySO, ETechTreeTechnologyLevel> item in techsToUnlock)
			{
				TechTreeTechnologySO key = item.Key;
				ETechTreeTechnologyLevel value = item.Value;
				if (_technologyResearchStates.ContainsKey(key))
				{
					_technologyResearchStates[key] = value;
				}
				else
				{
					_technologyResearchStates.Add(key, (value <= GetTechnologyMaxResearchLevel(key)) ? value : GetTechnologyMaxResearchLevel(key));
				}
				TechTreeManager.OnTechnologyResearched?.Invoke(key);
			}
		}

		public static void ResearchAllTechnologies()
		{
			foreach (TechTreeTechnologySO item in _technologySO)
			{
				_technologyResearchStates[item] = GetTechnologyMaxResearchLevel(item);
				TechTreeManager.OnTechnologyResearched?.Invoke(item);
			}
		}

		public static bool CheckIfAllRequirementsAreResearched(TechTreeTechnologySO tech)
		{
			return AreRequiredTechnologiesResearched(tech);
		}

		public static bool FirstLevelHasBeenResearched(TechTreeTechnologySO tech)
		{
			if (!tech)
			{
				return false;
			}
			return _technologyResearchStates[tech] >= ETechTreeTechnologyLevel.Level1;
		}

		public static ETechTreeTechnologyLevel GetTechnologyResearchLevel(TechTreeTechnologySO tech)
		{
			return _technologyResearchStates[tech];
		}

		public static ETechTreeTechnologyLevel GetTechnologyMaxResearchLevel(TechTreeTechnologySO tech)
		{
			return (ETechTreeTechnologyLevel)(tech.ResearchPointsLevels.Count - 1);
		}
	}
}
