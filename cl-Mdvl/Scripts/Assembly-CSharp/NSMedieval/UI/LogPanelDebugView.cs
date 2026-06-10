using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using Social;

namespace NSMedieval.UI
{
	internal class LogPanelDebugView
	{
		public void GenerateDebugLogs(StringBuilder sb)
		{
			if (MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Count < 2 || !MonoSingleton<CreatureManager>.Instance.Creatures.Any((CreatureBase c) => c is AnimalInstance))
			{
				sb.AppendLine("\n ------ [dev] <color=red>Please load save with at least two settlers and one animal. </color> ------ ");
				return;
			}
			HumanoidInstance humanoidInstance = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.ToArray()[0];
			HumanoidInstance humanoidInstance2 = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.ToArray()[1];
			CreatureBase dealAgent = MonoSingleton<CreatureManager>.Instance.Creatures.FirstOrDefault((CreatureBase c) => c is AnimalInstance);
			new HashSet<string>();
			sb.AppendLine();
			sb.AppendLine("\n ------ [dev] Generated Log START ------ ");
			sb.AppendLine();
			sb.AppendLine(" ------ CONVERSATION ------ ");
			foreach (ConversationTopic allItem in Repository<ConversationTopicRepository, ConversationTopic>.Instance.GetAllItems())
			{
				foreach (string affectionEffector in allItem.AffectionEffectors)
				{
					sb.AppendLine(("[" + allItem.GetID() + "-" + affectionEffector + "]").ToStyled(TooltipStyles.DefaultGrey));
					sb.AppendLine(LifeEventUtils.GetConversationEventLog(humanoidInstance, humanoidInstance2, allItem.GetID(), affectionEffector).LocalizedLog);
				}
			}
			sb.AppendLine();
			sb.AppendLine("------ LIFE EVENT ------ ");
			Dictionary<string, string> replacePairs = new Dictionary<string, string>
			{
				{
					"<agent_name>",
					UiUtils.GetWorkerLink(humanoidInstance)
				},
				{
					"<target_name>",
					UiUtils.GetWorkerLink(humanoidInstance2)
				},
				{
					"<last_words>",
					Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("lastwords")
				},
				{
					"<village_name>",
					TextFormatting.HighlightOrange(GlobalSaveController.CurrentVillageData.Name)
				},
				{
					"<healing>",
					Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("healing")
				},
				{
					"<wound_name>",
					UiUtils.Localize.GetText(LocKeyUtils.GetName(Repository<WoundsRepository, StatEffectorWound>.Instance.GetByID("broken_arm").LocKeys))
				},
				{
					"<wounding>",
					Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("wounding")
				},
				{
					"<carrying_verb>",
					Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("carrying", "verb")
				},
				{
					"<carrying_adjective>",
					Repository<HealthLogDataRepository, PersonalLogData>.Instance.GetRandomVariantLocalized("carrying", "adjective")
				}
			};
			foreach (LifeEventLog allItem2 in Repository<LifeEventLogRepository, LifeEventLog>.Instance.GetAllItems())
			{
				if (allItem2.LifeEventType != LifeEventType.Conversation && allItem2.LifeEventType != LifeEventType.Combat)
				{
					sb.AppendLine(("[" + allItem2.GetID() + "]").ToStyled(TooltipStyles.DefaultGrey));
					sb.AppendLine(LifeEventUtils.GetEventLog(allItem2.GetID(), replacePairs, humanoidInstance, humanoidInstance2).LocalizedLog);
				}
			}
			sb.AppendLine();
			sb.AppendLine("------ COMBAT ------ ");
			sb.AppendLine(LifeEventUtils.GetCombatHitEventLog(humanoidInstance, humanoidInstance2).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatHitEventLog(humanoidInstance, humanoidInstance2, isFatal: true).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatHitEventLog(humanoidInstance, dealAgent).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatHitEventLog(humanoidInstance, dealAgent, isFatal: true).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatBlockEventLog(humanoidInstance, humanoidInstance2).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatMissEventLog(humanoidInstance, humanoidInstance2).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetCombatEvadeEventLog(humanoidInstance, humanoidInstance2).LocalizedLog);
			sb.AppendLine();
			sb.AppendLine("------ HEALTH ------ ");
			sb.AppendLine(LifeEventUtils.GetHealthKilledEventLog(humanoidInstance).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetHealthDeathEventLog(humanoidInstance).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetHealthFaintEventLog(humanoidInstance).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetHealthCarryingEventLog(humanoidInstance, humanoidInstance2).LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetHealthHealingEventLog(humanoidInstance, humanoidInstance2, "broken_arm").LocalizedLog);
			sb.AppendLine(LifeEventUtils.GetHealthWoundingEventLog(humanoidInstance, "broken_arm").LocalizedLog);
			sb.AppendLine();
			sb.AppendLine("------ BELIEF ------ ");
			sb.AppendLine(LifeEventUtils.GetBeliefChangeLog(humanoidInstance, "religious_align_treshold_02", "religious_align_treshold_03").LocalizedLog);
			sb.AppendLine();
			sb.AppendLine("\n ------ [dev] Generated Log END ------ ");
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine();
		}
	}
}
