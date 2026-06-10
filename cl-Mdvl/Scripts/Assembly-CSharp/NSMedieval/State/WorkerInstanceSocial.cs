using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using Social;
using UnityEngine;

namespace NSMedieval.State
{
	public class WorkerInstanceSocial
	{
		private const int EffectorLogLimit = 30;

		[SerializeField]
		private LinkedList<EffectorLogStruct> affectionEffectorsLog;

		private HumanoidInstance humanoid;

		public LinkedList<EffectorLogStruct> AffectionEffectorsLog
		{
			get
			{
				return affectionEffectorsLog ?? (affectionEffectorsLog = new LinkedList<EffectorLogStruct>());
			}
			set
			{
				affectionEffectorsLog = value;
			}
		}

		public WorkerInstanceSocial(HumanoidInstance humanoidOwner)
		{
			humanoid = humanoidOwner;
		}

		public void SetHumanOwner(HumanoidInstance humanoid)
		{
			this.humanoid = humanoid;
		}

		public void AddAffectionTowards(HumanoidInstance targetInstance, float value)
		{
			humanoid.AffectionDictionary[targetInstance.UniqueId] = value;
		}

		public void HandleAffectionEffectorToward(HumanoidInstance humanoidInstance, string effectorId)
		{
			if (humanoidInstance != humanoid)
			{
				humanoid.Stats.StartAffectionEffector(effectorId, humanoidInstance);
			}
		}

		public float GetAffectionTowards(HumanoidInstance humanoidInstance)
		{
			if (humanoid.AffectionDictionary.TryGetValue(humanoidInstance.UniqueId, out var value))
			{
				return value;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\WorkerInstanceSocial.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Couldn't find Humanoid ");
				messageBuilder.AppendFormatted(humanoidInstance);
				messageBuilder.AppendLiteral(" in AffectionDictionary!");
			}
			Log.Error(messageBuilder);
			return 0f;
		}

		public void HandleAffectionEffectorTowardOthers(string effectorId)
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				if (worker != humanoid)
				{
					HandleAffectionEffectorToward(worker, effectorId);
				}
			}
		}

		public void FireAffectionEffector(string effectorId, float value, HumanoidInstance targetInstance)
		{
			LogAffectionEffector(effectorId, value, targetInstance);
			TryLogAffectionChange(targetInstance, value, effectorId);
		}

		public float GetSocialCompatibilityAttributeValue()
		{
			float num = 0f;
			float num2 = humanoid.Stats.Attributes[AttributeType.SocialCompatibilityPositive].Multiplier - 1f;
			if (Math.Abs(num2) > 0.001f)
			{
				num += num2;
			}
			float num3 = humanoid.Stats.Attributes[AttributeType.SocialCompatibilityNegative].Multiplier - 1f;
			if (Math.Abs(num3) > 0.001f)
			{
				num -= num3;
			}
			return num;
		}

		public void InitAffectionsIncognito()
		{
			InitAffections();
		}

		public void OnSetupSocial()
		{
			InitAffections();
			InitLifeEvents();
			HandleSettledTogetherEffector();
		}

		private void InitAffections()
		{
			foreach (HumanoidInstance worker in GlobalSaveController.CurrentVillageData.Workers)
			{
				CreateWorkerAffection(worker);
			}
			foreach (CaravanInstance caravan in GlobalSaveController.CurrentVillageData.WorldMapData.Caravans)
			{
				foreach (HumanoidInstance worker2 in caravan.Workers)
				{
					CreateWorkerAffection(worker2);
				}
			}
		}

		private void CreateWorkerAffection(HumanoidInstance humanoidInstance)
		{
			if (!humanoid.AffectionDictionary.ContainsKey(humanoidInstance.UniqueId))
			{
				humanoid.AffectionDictionary.Add(humanoidInstance.UniqueId, 0f);
			}
		}

		private void HandleSettledTogetherEffector()
		{
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				HandleAffectionEffectorTowardOthers("AffectionSettledTogether");
			}
		}

		private void InitLifeEvents()
		{
			if (humanoid.LifeEventLogs.Count <= 0)
			{
				Dictionary<string, string> replacePairs = new Dictionary<string, string>
				{
					{
						"<agent_name>",
						UiUtils.GetWorkerLink(humanoid)
					},
					{
						"<village_name>",
						TextFormatting.HighlightOrange(GlobalSaveController.CurrentVillageData.Name)
					}
				};
				humanoid.LogLifeEvent(LifeEventUtils.GetEventLog("settled_together", replacePairs, null, humanoid));
			}
		}

		private void LogAffectionEffector(string effectorId, float value, CreatureBase creatureBase)
		{
			AddToLog(AffectionEffectorsLog, new EffectorLogStruct(effectorId, value, creatureBase));
		}

		public void AddToLog(LinkedList<EffectorLogStruct> effectorLogStructs, EffectorLogStruct effectorLogStruct)
		{
			effectorLogStructs.AddFirst(effectorLogStruct);
			for (int num = effectorLogStructs.Count - 30; num > 0; num--)
			{
				effectorLogStructs.RemoveLast();
			}
		}

		public void OnWorkerSpawn(HumanoidInstance humanoidInstance)
		{
			CreateWorkerAffection(humanoidInstance);
		}

		private void TryLogAffectionChange(HumanoidInstance targetInstance, float value, string effectorId)
		{
			humanoid.AffectionDictionary.TryAdd(targetInstance.UniqueId, 0f);
			float value2 = humanoid.AffectionDictionary[targetInstance.UniqueId];
			float num = Mathf.Clamp(humanoid.AffectionDictionary[targetInstance.UniqueId] + value, -100f, 100f);
			AffectionLevel affectionLevel = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().GetAffectionLevel(value2);
			AffectionLevel affectionLevel2 = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().GetAffectionLevel(num);
			if (affectionLevel2.Equals(affectionLevel))
			{
				AddAffectionTowards(targetInstance, num);
				return;
			}
			float num2 = 5f;
			LifeEventLogStruct lifeEventLogStruct = default(LifeEventLogStruct);
			switch (affectionLevel2)
			{
			case AffectionLevel.Rival:
				lifeEventLogStruct = LifeEventUtils.GetEventLog("affection_status_rival_start", humanoid, targetInstance);
				num += num2;
				break;
			case AffectionLevel.Neutral:
				if (affectionLevel.Equals(AffectionLevel.Rival))
				{
					lifeEventLogStruct = LifeEventUtils.GetEventLog("affection_status_rival_stop", humanoid, targetInstance);
					AddAffectionTowards(targetInstance, num + num2);
				}
				else
				{
					lifeEventLogStruct = LifeEventUtils.GetEventLog("affection_status_friend_stop", humanoid, targetInstance);
					num -= num2;
				}
				break;
			case AffectionLevel.Friend:
				lifeEventLogStruct = LifeEventUtils.GetEventLog("affection_status_friend_start", humanoid, targetInstance);
				num += num2;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			AddAffectionTowards(targetInstance, num);
			if (!string.IsNullOrEmpty(effectorId))
			{
				lifeEventLogStruct = LifeEventUtils.AppendEffectorReasonToLog(lifeEventLogStruct, effectorId, targetInstance.Info.BodyType);
			}
			humanoid.LogLifeEvent(lifeEventLogStruct);
			MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(lifeEventLogStruct.LocalizedLog, humanoid.GetGoapAgent().GetView(), follow: true);
		}
	}
}
