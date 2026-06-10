using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using Social;

namespace NSMedieval
{
	public class BeliefChanged : EventInteraction
	{
		public BeliefChanged()
		{
			base.InteractionType = EventInteractionType.BeliefChanged;
		}

		public override bool IsPossible(CreatureBase agent)
		{
			return agent is HumanoidInstance;
		}

		public override bool Execute(CreatureBase agent, EventInteractionData eventInteractionData)
		{
			if (!(agent is HumanoidInstance humanoidInstance))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour == null)
			{
				return false;
			}
			if (!HasChanceToFireEvent(eventInteractionData))
			{
				return false;
			}
			string iD = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(humanoidInstance.Stats.GetStat(StatType.ReligiousAlignment).Current).GetID();
			if (!GetBeliefOutcome(eventInteractionData, iD, out var weightedOutcome))
			{
				return false;
			}
			LifeEventLogStruct eventLog = LifeEventUtils.GetEventLog(weightedOutcome.LogId, humanoidInstance);
			humanoidInstance.LogLifeEvent(eventLog);
			foreach (string item in weightedOutcome.EffectorId)
			{
				humanoidInstance.HumanoidBelief.FireBeliefEffector(item);
			}
			return true;
		}
	}
}
