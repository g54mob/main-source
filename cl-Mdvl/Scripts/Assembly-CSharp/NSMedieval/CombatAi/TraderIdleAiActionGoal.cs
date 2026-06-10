using NSMedieval.Goap;

namespace NSMedieval.CombatAi
{
	public class TraderIdleAiActionGoal : CombatAiActionGoal
	{
		public TraderIdleAiActionGoal(Agent selfAgent)
			: base("TraderIdleAiActionGoal", selfAgent)
		{
		}

		public override bool CanStart(bool isForced = false)
		{
			return !base.CombatAi.IsStateSet(CombatAiState.IsDamaged);
		}

		protected override void OnEnd()
		{
			base.OnEnd();
		}
	}
}
