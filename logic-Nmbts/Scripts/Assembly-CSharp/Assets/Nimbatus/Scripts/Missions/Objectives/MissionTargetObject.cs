using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.Objectives
{
	[Serializable]
	public class MissionTargetObject
	{
		public List<EMissionComplexity> SpecificComplexity = new List<EMissionComplexity>();

		public InteractiveWorldObject WorldObject;

		public bool DynamicAmount;

		public int Amount;

		[ShowIf("DynamicAmount", true)]
		public bool SubtractFromDynamicAmount;

		public int ActualAmount { get; private set; }

		public int Progress { get; private set; }

		public void Init()
		{
			if (DynamicAmount)
			{
				int num = UnityEngine.Object.FindObjectsOfType<InteractiveWorldObject>().Count((InteractiveWorldObject g) => g.UniqueId == WorldObject.UniqueId);
				ActualAmount = (SubtractFromDynamicAmount ? (num - Amount) : Mathf.Min(Amount, num));
			}
			else
			{
				ActualAmount = Amount;
			}
		}

		public bool IsCompatibleWithDifficulty(EMissionComplexity difficulty)
		{
			if (SpecificComplexity == null || SpecificComplexity.Count <= 0)
			{
				return true;
			}
			return SpecificComplexity.Contains(difficulty);
		}

		public void IncreaseProgress(int amount)
		{
			Progress = Mathf.Min(ActualAmount, Progress + amount);
		}

		public void DecreaseProgress(int amount)
		{
			Progress = Mathf.Max(0, Progress - amount);
		}

		public bool IsFullfilled()
		{
			return Progress >= ActualAmount;
		}

		public void ResetProgress()
		{
			Progress = 0;
		}

		public void SetFullfilled()
		{
			Progress = ActualAmount;
		}
	}
}
