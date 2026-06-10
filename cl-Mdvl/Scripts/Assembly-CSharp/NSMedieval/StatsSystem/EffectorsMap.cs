using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class EffectorsMap
	{
		private static Dictionary<EffectorType, ConstructorInfo> constructors;

		public static Dictionary<EffectorType, ConstructorInfo> Constuctors
		{
			get
			{
				if (constructors == null)
				{
					constructors = new Dictionary<EffectorType, ConstructorInfo>();
					constructors.Add(EffectorType.ChangeGoalPriority, typeof(ChangeGoalPriorityEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.GoapEvent, typeof(GoapEventEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.LifeEvent, typeof(LifeEventEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.MoodModify, typeof(MoodModifyEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.AttributeModify, typeof(AttributeModifyEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.WarningMessage, typeof(WarningMessageEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.ForceWorkHour, typeof(ForceWorkHourEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.ModifyGoalPreference, typeof(ModifyGoalPreferenceEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.DebugEffect, typeof(DebugLogEffector).GetConstructors()[0]);
					constructors.Add(EffectorType.AttributeAdderModify, typeof(AttributeAdderModifyEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.StatModifyCurrent, typeof(StatModifyCurrentEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.AffectionModify, typeof(AffectionModifyEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.ModifyTemperature, typeof(ModifyComfortableTemperatureEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.FixedGoalPriority, typeof(FixedGoalPriorityEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.ForceGoalEnableState, typeof(ForceGoalEnableStateEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.DisableStat, typeof(StatEnableDisableEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.LockStat, typeof(StatLockUnlockEffect).GetConstructors()[0]);
					constructors.Add(EffectorType.ModifyExperience, typeof(ModifyExperienceEffect).GetConstructors()[0]);
				}
				return constructors;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			constructors = null;
		}
	}
}
