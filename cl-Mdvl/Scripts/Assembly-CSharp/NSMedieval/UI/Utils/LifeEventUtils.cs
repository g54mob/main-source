using System.Collections.Generic;
using System.Text;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.Types;
using Social;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class LifeEventUtils
	{
		private static readonly StringBuilder StringBuilder = new StringBuilder();

		private static readonly Dictionary<string, string> ReplacePairs = new Dictionary<string, string>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			StringBuilder.Clear();
			ReplacePairs.Clear();
		}

		public static LifeEventLogStruct GetConversationEventLog(HumanoidInstance agentInstance, HumanoidInstance targetInstance, string topicVariantId, string affectionEffectorId)
		{
			string lifeEventLogId = Repository<ConversationTopicRepository, ConversationTopic>.Instance.GetByID(topicVariantId).GetLifeEventLogId(affectionEffectorId);
			string variantId = affectionEffectorId.Replace("Affection", string.Empty).ToLower();
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(targetInstance);
			string randomVariantLocalized = Repository<ConversationLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("action", variantId);
			string randomVariantLocalized2 = Repository<ConversationLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("reaction_verb");
			string randomVariantLocalized3 = Repository<ConversationLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("reaction", variantId);
			string text = UiUtils.Localize.GetText("log_who");
			ReplacePairs.Clear();
			ReplacePairs.Add("<action>", randomVariantLocalized);
			ReplacePairs.Add("<topic>", Repository<ConversationLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("topic", topicVariantId));
			ReplacePairs.Add("<reaction_verb>", randomVariantLocalized2);
			ReplacePairs.Add("<reaction>", randomVariantLocalized3);
			ReplacePairs.Add("<who>", text);
			ReplacePairs.Add("<agent_name>", creatureLink);
			ReplacePairs.Add("<target_name>", creatureLink2);
			return GetEventLog(lifeEventLogId, ReplacePairs, targetInstance, agentInstance);
		}

		public static LifeEventLogStruct GetCombatHitEventLog(CreatureBase takeAgent, CreatureBase dealAgent)
		{
			return GetCombatHitEventLog(takeAgent, dealAgent, isFatal: false);
		}

		public static LifeEventLogStruct GetCombatHitEventLog(CreatureBase takeAgent, CreatureBase dealAgent, bool isFatal)
		{
			string lifeEventLogId = "combat_hit";
			string creatureLink = CreatureBaseUtils.GetCreatureLink(takeAgent);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(dealAgent);
			string value = string.Empty;
			string value2 = string.Empty;
			string value3 = string.Empty;
			string value4;
			if (dealAgent is AnimalInstance animalInstance)
			{
				value4 = Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetBeastHitAction(animalInstance.Blueprint.AnimalAttackType);
				lifeEventLogId = "combat_hit_beast";
			}
			else
			{
				EquipmentInstance equipmentInstance = dealAgent?.Inventory?.GetItem(ItemType.Weapon);
				if (equipmentInstance != null)
				{
					value2 = " " + Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("with");
					value = " " + ResourceUtils.GetLocalizedResourceName(equipmentInstance.Blueprint.Resource, showQuality: false);
				}
				else
				{
					lifeEventLogId = "combat_hit_unarmed";
				}
				value4 = Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("hit_action");
				value3 = (isFatal ? (" " + Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("hit_description", "fatal")) : (" " + Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("hit_description")));
			}
			ReplacePairs.Clear();
			ReplacePairs.Add("<hit_action>", value4);
			ReplacePairs.Add("<hit_description>", value3);
			ReplacePairs.Add("<with>", value2);
			ReplacePairs.Add("<weapon_name>", value);
			ReplacePairs.Add("<defender_name>", creatureLink);
			ReplacePairs.Add("<attacker_name>", creatureLink2);
			return GetEventLog(lifeEventLogId, ReplacePairs, takeAgent, dealAgent);
		}

		public static LifeEventLogStruct GetCombatBlockEventLog(CreatureBase takeAgent, CreatureBase dealAgent)
		{
			string randomVariantLocalized = Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("block_description");
			randomVariantLocalized = TextFormatting.FormatTextForGender(randomVariantLocalized, new List<BodyType>
			{
				takeAgent.GetInfo().BodyType,
				dealAgent.GetInfo().BodyType
			});
			string creatureLink = CreatureBaseUtils.GetCreatureLink(takeAgent);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(dealAgent);
			string value = string.Empty;
			if (takeAgent.Inventory != null)
			{
				Resource resource = takeAgent.Inventory.GetItem(ItemType.Armor)?.Blueprint.Resource;
				value = ((resource != null) ? ResourceUtils.GetLocalizedResourceName(resource, showQuality: false) : string.Empty);
			}
			ReplacePairs.Clear();
			ReplacePairs.Add("<block_description>", randomVariantLocalized);
			ReplacePairs.Add("<armor_name>", value);
			ReplacePairs.Add("<defender_name>", creatureLink);
			ReplacePairs.Add("<attacker_name>", creatureLink2);
			string text = ReplaceInPattern(UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetByID("combat_block").LocKeys)), ReplacePairs);
			text = TextFormatting.FormatTextForGender(text, takeAgent.GetInfo().BodyType);
			return new LifeEventLogStruct(LifeEventType.Combat, GetCombatHitEventLog(takeAgent, dealAgent).LocalizedLog + " " + text);
		}

		public static LifeEventLogStruct GetCombatMissEventLog(CreatureBase takeAgent, CreatureBase dealAgent)
		{
			string creatureLink = CreatureBaseUtils.GetCreatureLink(takeAgent);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(dealAgent);
			string randomVariantLocalized = Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("miss_description");
			ReplacePairs.Clear();
			ReplacePairs.Add("<defender_name>", creatureLink);
			ReplacePairs.Add("<attacker_name>", creatureLink2);
			return GetEventLog(LifeEventType.Combat, randomVariantLocalized, ReplacePairs, takeAgent, dealAgent);
		}

		public static LifeEventLogStruct GetCombatEvadeEventLog(CreatureBase takeAgent, CreatureBase dealAgent)
		{
			string randomVariantLocalized = Repository<CombatLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("evade_description");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(takeAgent);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(dealAgent);
			ReplacePairs.Clear();
			ReplacePairs.Add("<defender_name>", creatureLink);
			ReplacePairs.Add("<attacker_name>", creatureLink2);
			return GetEventLog(LifeEventType.Combat, randomVariantLocalized, ReplacePairs, takeAgent, dealAgent);
		}

		public static LifeEventLogStruct GetLastWordsEventLog(CreatureBase agentInstance)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("lastwords");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<last_words>", randomVariantLocalized);
			ReplacePairs.Add("<agent_name>", creatureLink);
			return GetEventLog("last_words", ReplacePairs, null, agentInstance);
		}

		public static LifeEventLogStruct GetHealthKilledEventLog(CreatureBase agentInstance)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("killed_by");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<other_name>", creatureLink);
			return GetEventLog(LifeEventType.Health, randomVariantLocalized, ReplacePairs, agentInstance);
		}

		public static LifeEventLogStruct GetHealthDeathEventLog(CreatureBase agentInstance)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("death", "human");
			if (agentInstance is AnimalInstance)
			{
				randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("death");
			}
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<agent_name>", creatureLink);
			return GetEventLog(LifeEventType.Health, randomVariantLocalized, ReplacePairs, null, agentInstance);
		}

		public static LifeEventLogStruct GetHealthCarryingEventLog(HumanoidInstance agentInstance, HumanoidInstance targetInstance)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("carrying", "verb");
			string randomVariantLocalized2 = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("carrying", "adjective");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(targetInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<carrying_verb>", randomVariantLocalized);
			ReplacePairs.Add("<carrying_adjective>", randomVariantLocalized2);
			ReplacePairs.Add("<agent_name>", creatureLink);
			ReplacePairs.Add("<target_name>", creatureLink2);
			return GetEventLog("health_carrying", ReplacePairs, targetInstance, agentInstance);
		}

		public static LifeEventLogStruct GetHealthFaintEventLog(CreatureBase agentInstance)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("unconscious");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<agent_name>", creatureLink);
			return GetEventLog(LifeEventType.Health, randomVariantLocalized, ReplacePairs, null, agentInstance);
		}

		public static LifeEventLogStruct GetHealthHealingEventLog(HumanoidInstance agentInstance, HumanoidInstance targetInstance, string woundId)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("healing");
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<WoundsRepository, StatEffectorWound>.Instance.GetByID(woundId).LocKeys));
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			string creatureLink2 = CreatureBaseUtils.GetCreatureLink(targetInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<healing>", randomVariantLocalized);
			ReplacePairs.Add("<wound_name>", text);
			ReplacePairs.Add("<agent_name>", creatureLink);
			ReplacePairs.Add("<target_name>", creatureLink2);
			return GetEventLog("health_healing", ReplacePairs, targetInstance, agentInstance);
		}

		public static LifeEventLogStruct GetHealthWoundingEventLog(CreatureBase agentInstance, string woundId)
		{
			string randomVariantLocalized = Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("wounding");
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<WoundsRepository, StatEffectorWound>.Instance.GetByID(woundId).LocKeys));
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			ReplacePairs.Clear();
			ReplacePairs.Add("<wounding>", randomVariantLocalized);
			ReplacePairs.Add("<wound_name>", text);
			ReplacePairs.Add("<agent_name>", creatureLink);
			return GetEventLog("health_wounding", ReplacePairs, null, agentInstance);
		}

		public static LifeEventLogStruct GetBeliefChangeLog(HumanoidInstance agentInstance, string beliefThreshold, string previousThreshold)
		{
			string text = UiUtils.Localize.GetText("status_belief_change");
			string creatureLink = CreatureBaseUtils.GetCreatureLink(agentInstance);
			string text2 = UiUtils.Localize.GetText(beliefThreshold);
			string text3 = UiUtils.Localize.GetText(previousThreshold);
			ReplacePairs.Clear();
			ReplacePairs.Add("<belief_status>", text2);
			ReplacePairs.Add("<previous_belief_status>", text3);
			ReplacePairs.Add("<agent_name>", creatureLink);
			return GetEventLog(LifeEventType.Misc, text, ReplacePairs, null, agentInstance);
		}

		public static LifeEventLogStruct AppendEffectorReasonToLog(LifeEventLogStruct log, string reasonEffectorId, BodyType targetBodyType = BodyType.None)
		{
			return new LifeEventLogStruct(log.Type, AppendEffectorReason(log.LocalizedLog, reasonEffectorId, targetBodyType));
		}

		public static string AppendEffectorReason(string message, string reasonEffectorId, BodyType targetBodyType = BodyType.None)
		{
			StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(reasonEffectorId);
			if (byID == null)
			{
				return string.Empty;
			}
			StringBuilder.Clear();
			StringBuilder.AppendFormat("{0} {1}", message, UiUtils.Localize.GetText("status_change_reason", targetBodyType));
			StringBuilder.Replace("<event>", UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys), targetBodyType));
			return StringBuilder.ToString();
		}

		public static LifeEventLogStruct GetMiscLog(string message)
		{
			message = LogInsert(GetLifeEventTypeIcon(LifeEventType.Misc), message);
			return new LifeEventLogStruct(LifeEventType.Misc, message);
		}

		public static LifeEventLogStruct GetProducedItemEventLog(string lifeEventLogId, HumanoidInstance agentInstance, HumanoidInstance targetInstance, string localizedItemName)
		{
			ReplacePairs.Clear();
			ReplacePairs.Add("<agent_name>", CreatureBaseUtils.GetCreatureLink(agentInstance));
			ReplacePairs.Add("<target_name>", CreatureBaseUtils.GetCreatureLink(targetInstance));
			ReplacePairs.Add("<item_name>", localizedItemName);
			LifeEventLog byID = Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetByID(lifeEventLogId);
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
			return GetEventLog(byID.LifeEventType, text, ReplacePairs, targetInstance, agentInstance);
		}

		public static LifeEventLogStruct GetEventLog(string lifeEventLogId, HumanoidInstance agentInstance, HumanoidInstance targetInstance)
		{
			ReplacePairs.Clear();
			ReplacePairs.Add("<agent_name>", CreatureBaseUtils.GetCreatureLink(agentInstance));
			ReplacePairs.Add("<target_name>", CreatureBaseUtils.GetCreatureLink(targetInstance));
			LifeEventLog byID = Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetByID(lifeEventLogId);
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
			return GetEventLog(byID.LifeEventType, text, ReplacePairs, targetInstance, agentInstance);
		}

		public static LifeEventLogStruct GetEventLog(string lifeEventLogId, HumanoidInstance agentInstance)
		{
			ReplacePairs.Clear();
			ReplacePairs.Add("<agent_name>", CreatureBaseUtils.GetCreatureLink(agentInstance));
			LifeEventLog byID = Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetByID(lifeEventLogId);
			string text = UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys));
			return GetEventLog(byID.LifeEventType, text, ReplacePairs, agentInstance);
		}

		public static LifeEventLogStruct GetEventLog(string lifeEventLogId, Dictionary<string, string> replacePairs, CreatureBase target, CreatureBase agent)
		{
			LifeEventLog byID = Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetByID(lifeEventLogId);
			string log = GetLog(UiUtils.Localize.GetText(LocKeyUtils.GetName(byID.LocKeys)), replacePairs, target, agent);
			return new LifeEventLogStruct(byID.LifeEventType, LogInsert(AssetUtils.GetSpriteAsset(byID.Icon), log));
		}

		private static LifeEventLogStruct GetEventLog(LifeEventType eventType, string pattern, Dictionary<string, string> replacePairs, CreatureBase target, CreatureBase agent)
		{
			string log = GetLog(pattern, replacePairs, target, agent);
			return new LifeEventLogStruct(eventType, LogInsert(GetLifeEventTypeIcon(eventType), log));
		}

		private static LifeEventLogStruct GetEventLog(LifeEventType eventType, string pattern, Dictionary<string, string> replacePairs, CreatureBase agent)
		{
			string log = GetLog(pattern, replacePairs, agent);
			return new LifeEventLogStruct(eventType, LogInsert(GetLifeEventTypeIcon(eventType), log));
		}

		private static string GetLog(string pattern, Dictionary<string, string> replacePairs, CreatureBase target, CreatureBase agent)
		{
			return GetGenderFormatted(ReplaceInPattern(pattern, replacePairs), target, agent);
		}

		private static string GetLog(string pattern, Dictionary<string, string> replacePairs, CreatureBase agent)
		{
			return GetGenderFormatted(ReplaceInPattern(pattern, replacePairs), agent);
		}

		private static string LogInsert(string icon, string log)
		{
			StringBuilder.Clear().Append(icon).Append(" ")
				.Append(GetDate())
				.Append(" ")
				.Append(log);
			return StringBuilder.ToString();
		}

		private static string ReplaceInPattern(string pattern, Dictionary<string, string> replacePairs)
		{
			StringBuilder.Clear();
			StringBuilder.Append(pattern);
			foreach (KeyValuePair<string, string> replacePair in replacePairs)
			{
				StringBuilder.Replace(replacePair.Key, replacePair.Value);
			}
			return StringBuilder.ToString();
		}

		private static string GetLifeEventTypeIcon(LifeEventType type)
		{
			return AssetUtils.GetSpriteAsset("life_event_" + type.ToString().ToLower() + "_icon");
		}

		private static string GetDate()
		{
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			return string.Format("<style=AltColor>{0} {1}, {2}</style>", UiUtils.Localize.GetText("general_" + dateAndTime.Season.Name), dateAndTime.Day, dateAndTime.Year);
		}

		private static string GetGenderFormatted(string text, CreatureBase agent)
		{
			BodyType item = agent?.GetInfo().BodyType ?? BodyType.None;
			return TextFormatting.FormatTextForGender(text, new List<BodyType> { item, item });
		}

		private static string GetGenderFormatted(string text, CreatureBase target, CreatureBase agent)
		{
			BodyType item = target?.GetInfo().BodyType ?? BodyType.None;
			BodyType item2 = agent?.GetInfo().BodyType ?? BodyType.None;
			return TextFormatting.FormatTextForGender(text, new List<BodyType> { item, item2 });
		}
	}
}
