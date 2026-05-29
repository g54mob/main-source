using CTS.BBT.AI;
using CTS.Core;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class NoInvestigatorsGoal : QuestNumericGoal
	{
		private int _investigatorsCountToSpawn;

		public NoInvestigatorsGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName, ENumericGoalType.LowerOrEqual)
		{
			_investigatorsCountToSpawn = DialogueLua.GetVariable(variableName).AsInt;
		}

		public override void StopObserving()
		{
			HostileCharacterSpawner.InvestigatorsCountChanged -= OnInvestigatorsCountChanged;
		}

		public override void StartObserving()
		{
			foreach (Customer item in CTSSingleton<HostileCharacterSpawner>.Instance.SpawnInvestigators(_investigatorsCountToSpawn, forceEnterBar: true))
			{
				item.Tags.AddTag(EAgentTag.CannotLeave);
				item.ActionPlayer.ForceAction(new AgentActionEnterBar(forceEnter: true), EActionPriority.Forced);
			}
			HostileCharacterSpawner.InvestigatorsCountChanged += OnInvestigatorsCountChanged;
			OnInvestigatorsCountChanged(CTSSingleton<HostileCharacterSpawner>.Instance.CurrentInvestigators.Count);
		}

		private void OnInvestigatorsCountChanged(int count)
		{
			SetGoalVariable(count);
		}
	}
}
