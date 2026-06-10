using System.Collections.Generic;
using System.Globalization;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.State
{
	public class HumanoidInstanceBelief
	{
		private List<KeyValuePair<string, int>> beliefThresholds;

		private HumanoidInstance humanoid;

		[SerializeField]
		private LinkedList<EffectorLogStruct> religiousEffectorsLog;

		public LinkedList<EffectorLogStruct> ReligiousEffectorsLog
		{
			get
			{
				return religiousEffectorsLog ?? (religiousEffectorsLog = new LinkedList<EffectorLogStruct>());
			}
			set
			{
				religiousEffectorsLog = value;
			}
		}

		public EffectorLogStruct GetLastReligiousLog => religiousEffectorsLog.Last.Value;

		public HumanoidInstanceBelief(HumanoidInstance humanoidOwner)
		{
			humanoid = humanoidOwner;
		}

		public void SetHumanOwner(HumanoidInstance humanoid)
		{
			this.humanoid = humanoid;
		}

		public string GetThresholdName(float value)
		{
			if (beliefThresholds == null)
			{
				beliefThresholds = new List<KeyValuePair<string, int>>();
				StatThresholdTrigger[] thresholdTriggers = humanoid.ActiveBehaviour.GetStatsModel().GetByType(StatType.ReligiousAlignment).ThresholdTriggers;
				foreach (StatThresholdTrigger statThresholdTrigger in thresholdTriggers)
				{
					beliefThresholds.Add(new KeyValuePair<string, int>(statThresholdTrigger.Name, statThresholdTrigger.Trigger));
				}
			}
			foreach (KeyValuePair<string, int> item in beliefThresholds.IterateInReverseDynamic())
			{
				if (value <= (float)item.Value)
				{
					return item.Key;
				}
			}
			return string.Empty;
		}

		public void FireBeliefEffector(string beliefEffectorId, HumanoidInstance targetInstance)
		{
			float current = humanoid.Stats.GetStat(StatType.ReligiousAlignment).Current;
			humanoid.Stats.StartEffector(beliefEffectorId);
			TryLogBeliefChange(current, beliefEffectorId);
			LogReligiousEffector(beliefEffectorId, targetInstance);
		}

		public void FireBeliefEffector(string beliefEffectorId)
		{
			float current = humanoid.Stats.GetStat(StatType.ReligiousAlignment).Current;
			humanoid.Stats.StartEffector(beliefEffectorId);
			TryLogBeliefChange(current, beliefEffectorId);
			LogReligiousEffector(beliefEffectorId, humanoid);
		}

		public void FireBeliefEvent(string beliefEventId)
		{
			MonoSingleton<EventInteractionManager>.Instance.AttemptBeliefChange(beliefEventId, humanoid);
		}

		public void RegisterStatsListeners()
		{
			if (!humanoid.StatsListenersAttached)
			{
				humanoid.Stats.OnEffectorStartEvent += OnEffectorStart;
				humanoid.Stats.Controller.RegisterListener(StatEventType.ValueUpdated, StatType.Health, OnHealthChanged);
			}
		}

		public void RemoveStatsListeners()
		{
			humanoid.Stats.OnEffectorStartEvent -= OnEffectorStart;
			humanoid.Stats.Controller.RemoveListener(OnHealthChanged);
		}

		private void LogReligiousEffector(string effectorId, CreatureBase creatureBase)
		{
			StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(effectorId);
			if (byID == null)
			{
				return;
			}
			float num = 0f;
			EffectDetailsHolder[] effects = byID.Effects;
			for (int i = 0; i < effects.Length; i++)
			{
				if (effects[i].Parameters.TryGetValue("amount", out var value))
				{
					num = float.Parse(value, CultureInfo.InvariantCulture);
					break;
				}
				foreach (EffectorBase instance in byID.Instances)
				{
					if (instance is StatModifyCurrentEffect statModifyCurrentEffect)
					{
						num = statModifyCurrentEffect.Amount;
						break;
					}
				}
			}
			if (num != 0f)
			{
				if (creatureBase == humanoid)
				{
					humanoid.WorkerBehaviour?.WorkerSocial.AddToLog(ReligiousEffectorsLog, new EffectorLogStruct(effectorId, num));
				}
				else
				{
					humanoid.WorkerBehaviour?.WorkerSocial.AddToLog(ReligiousEffectorsLog, new EffectorLogStruct(effectorId, num, creatureBase));
				}
			}
		}

		private void TryLogBeliefChange(float previousValue, string effectorId)
		{
			string thresholdName = GetThresholdName(previousValue);
			float current = humanoid.Stats.GetStat(StatType.ReligiousAlignment).Current;
			string thresholdName2 = GetThresholdName(current);
			if (!thresholdName2.Equals(thresholdName))
			{
				LifeEventLogStruct lifeEventLogStruct = LifeEventUtils.GetBeliefChangeLog(humanoid, thresholdName2, thresholdName);
				if (!string.IsNullOrEmpty(effectorId))
				{
					lifeEventLogStruct = LifeEventUtils.AppendEffectorReasonToLog(lifeEventLogStruct, effectorId);
				}
				humanoid.LogLifeEvent(lifeEventLogStruct);
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(lifeEventLogStruct.LocalizedLog, humanoid.GetGoapAgent()?.GetView(), follow: true);
				if (!(Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(previousValue) == Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(current)))
				{
					string iD = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(current).GetID();
					humanoid.Stats.StartEffector("BeliefConversion" + iD.CapitalizeFirst());
				}
			}
		}

		private void OnHealthChanged(object stat)
		{
			StatInstance stat2 = humanoid.Stats.GetStat(StatType.Health);
			if (stat2.Current < stat2.Max * 0.1f)
			{
				FireBeliefEvent("belief_near_death");
			}
		}

		private void OnEffectorStart(StatEffector statEffector)
		{
			if (statEffector.GetID().Equals("InebriatedVeryHigh"))
			{
				FireBeliefEvent("belief_intoxication");
			}
		}
	}
}
