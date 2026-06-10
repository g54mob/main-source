using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.CombatAi
{
	public class AnimalCombatAiAgent : CombatAiAgent
	{
		private AnimalInstance animal;

		public AnimalCombatAiAgent(IGoapAgentOwner owner, string blueprintId)
			: base(owner, blueprintId)
		{
			animal = (AnimalInstance)owner;
			if (GetState<bool>(CombatAiState.IsAggressive))
			{
				SetState(CombatAiState.IsSingleAttackSwingMode, true);
			}
		}

		public override AnimatedAgentView GetView()
		{
			return animal.GetAgentView<AnimatedAgentView>();
		}

		public override void Dispose()
		{
			base.Dispose();
			animal = null;
		}
	}
}
