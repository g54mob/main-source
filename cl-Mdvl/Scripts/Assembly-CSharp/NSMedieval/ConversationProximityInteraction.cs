using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using Social;
using UnityEngine;

namespace NSMedieval
{
	public class ConversationProximityInteraction : ProximityInteraction
	{
		private readonly Dictionary<string, float> topicWeightMultipliers = new Dictionary<string, float>();

		public ConversationProximityInteraction()
		{
			base.InteractionType = ProximityInteractionType.Conversation;
		}

		public override bool IsPossible(CreatureBase agent, CreatureBase target)
		{
			if (!(agent is HumanoidInstance humanoidInstance) || !(target is HumanoidInstance humanoidInstance2))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour == null || humanoidInstance2.WorkerBehaviour == null)
			{
				return false;
			}
			if (!humanoidInstance.AvailableForInteraction || !humanoidInstance2.AvailableForInteraction)
			{
				return false;
			}
			if (humanoidInstance.IsSleeping || humanoidInstance2.IsSleeping)
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.IsDrafting || humanoidInstance2.WorkerBehaviour.IsDrafting)
			{
				return false;
			}
			if (humanoidInstance.HasFainted || humanoidInstance2.HasFainted)
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.IsResting || humanoidInstance2.WorkerBehaviour.IsResting)
			{
				return false;
			}
			float value = humanoidInstance2.Stats.GetAttributeInstance(AttributeType.ConversationAvailabilityChance).Value;
			if (Random.Range(0f, 1f) > value)
			{
				return false;
			}
			humanoidInstance.AvailableForInteraction = false;
			humanoidInstance2.AvailableForInteraction = false;
			return true;
		}

		public override bool Execute(CreatureBase agent, CreatureBase target)
		{
			if (!(agent is HumanoidInstance humanoidInstance) || !(target is HumanoidInstance humanoidInstance2))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour == null || humanoidInstance2.WorkerBehaviour == null)
			{
				return false;
			}
			string topic = GetTopic(humanoidInstance, humanoidInstance2);
			string affectionEffectorById = Repository<ConversationTopicRepository, ConversationTopic>.Instance.GetAffectionEffectorById(topic, GetSocialCompatibility(humanoidInstance, humanoidInstance2));
			humanoidInstance.Stats.StartAffectionEffector(affectionEffectorById, target);
			humanoidInstance.Stats.StartEffector("InteractionAffectSocial");
			humanoidInstance2.Stats.StartAffectionEffector(affectionEffectorById, agent);
			humanoidInstance2.Stats.StartEffector("InteractionAffectSocial");
			if (Repository<ConversationTopicRepository, ConversationTopic>.Instance.HasBeliefEffectors(topic))
			{
				HumanoidInstance affectedHumanoid;
				string text = Repository<ConversationTopicRepository, ConversationTopic>.Instance.GetBeliefEffectorById(topic, GetBeliefThresholdValue(humanoidInstance, humanoidInstance2, out affectedHumanoid));
				if (text != string.Empty)
				{
					if (!text.Equals("BeliefNeutral"))
					{
						string iD = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(affectedHumanoid.Stats.GetStat(StatType.ReligiousAlignment).Current).GetID();
						text += iD.CapitalizeFirst();
					}
					HumanoidInstance targetInstance = (affectedHumanoid.Equals(humanoidInstance) ? humanoidInstance2 : humanoidInstance);
					affectedHumanoid.HumanoidBelief.FireBeliefEffector(text, targetInstance);
				}
			}
			LifeEventLogStruct conversationEventLog = LifeEventUtils.GetConversationEventLog(humanoidInstance, humanoidInstance2, topic, affectionEffectorById);
			humanoidInstance.LogLifeEvent(conversationEventLog);
			humanoidInstance2.LogLifeEvent(conversationEventLog);
			humanoidInstance.AddExperience(SkillType.Speechcraft, Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().ConversationSpeechcraftXp);
			humanoidInstance2.AddExperience(SkillType.Speechcraft, Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings().ConversationSpeechcraftXp);
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				agent.AvailableForInteraction = true;
				target.AvailableForInteraction = true;
			});
			return base.Execute(agent, target);
		}

		private string GetTopic(HumanoidInstance agentInstance, HumanoidInstance targetInstance)
		{
			topicWeightMultipliers.Clear();
			topicWeightMultipliers.Add("belief", agentInstance.Stats.GetAttributeInstance(AttributeType.ChanceForBeliefSocInteraction).Value);
			return Repository<ConversationTopicRepository, ConversationTopic>.Instance.GetRandomTopicId(topicWeightMultipliers);
		}

		private float GetBeliefThresholdValue(HumanoidInstance agentInstance, HumanoidInstance targetInstance, out HumanoidInstance affectedHumanoid)
		{
			float num = 0f;
			float num2 = agentInstance.Stats.GetStat(StatType.ReligiousAlignment).Current;
			float attributeValue = agentInstance.GetAttributeValue(AttributeType.BeliefConversionPower);
			bool flag = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(agentInstance.Stats.GetStat(StatType.ReligiousAlignment).Current).GetID().Equals("pagan");
			float num3 = targetInstance.Stats.GetStat(StatType.ReligiousAlignment).Current;
			float attributeValue2 = targetInstance.GetAttributeValue(AttributeType.BeliefConversionPower);
			bool flag2 = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(targetInstance.Stats.GetStat(StatType.ReligiousAlignment).Current).GetID().Equals("pagan");
			float num4 = attributeValue - attributeValue2 + Random.Range(-0.001f, 0.001f);
			if (num4 > 0f)
			{
				affectedHumanoid = targetInstance;
				num = agentInstance.GetAttributeValue(AttributeType.BeliefConversionFailChance);
				if (flag && flag2 && num2 > num3)
				{
					num4 = 0f - num4;
				}
				if (!flag && !flag2 && num2 < num3)
				{
					num4 = 0f - num4;
				}
				if (flag != flag2)
				{
					num4 = 0f - num4;
					agentInstance.Stats.StartEffector("BeliefPowerFatigue");
				}
			}
			else
			{
				affectedHumanoid = agentInstance;
				num = targetInstance.GetAttributeValue(AttributeType.BeliefConversionFailChance);
				if (flag && flag2 && num3 < num2)
				{
					num4 = Mathf.Abs(num4);
				}
				if (!flag && !flag2 && num3 > num2)
				{
					num4 = Mathf.Abs(num4);
				}
				if (flag != flag2)
				{
					targetInstance.Stats.StartEffector("BeliefPowerFatigue");
				}
			}
			if (Random.Range(0f, 1f) < num)
			{
				num4 = ((!(num4 < 0f)) ? (0f - num4) : Mathf.Abs(num4));
			}
			return num4;
		}

		private float GetSocialCompatibility(HumanoidInstance agentInstance, HumanoidInstance targetInstance)
		{
			SocialCompatibilitySettings socialCompatibilitySettings = Repository<SocialCompatibilitySettingsRepository, SocialCompatibilitySettings>.Instance.Settings();
			float speechCraftValue = socialCompatibilitySettings.GetSpeechCraftValue(agentInstance.Skills.GetSkill(SkillType.Speechcraft).Level);
			float ageValue = socialCompatibilitySettings.GetAgeValue(agentInstance.Info.Age, targetInstance.Info.Age);
			float beliefValue = socialCompatibilitySettings.GetBeliefValue(agentInstance.Stats.GetStat(StatType.ReligiousAlignment).Current, targetInstance.Stats.GetStat(StatType.ReligiousAlignment).Current);
			float affectionValue = socialCompatibilitySettings.GetAffectionValue(agentInstance.WorkerBehaviour.WorkerSocial.GetAffectionTowards(targetInstance));
			float random = socialCompatibilitySettings.GetRandom();
			float num = speechCraftValue + ageValue + beliefValue + affectionValue + random;
			float num2 = agentInstance.WorkerBehaviour.WorkerSocial.GetSocialCompatibilityAttributeValue() + targetInstance.WorkerBehaviour.WorkerSocial.GetSocialCompatibilityAttributeValue();
			return num + num2;
		}
	}
}
