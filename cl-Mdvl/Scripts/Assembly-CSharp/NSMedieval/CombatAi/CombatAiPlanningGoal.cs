using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.Goap.Actions;

namespace NSMedieval.CombatAi
{
	public abstract class CombatAiPlanningGoal : CombatAiGoal
	{
		protected CombatAiPlanningGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
			: base(id, selfAgent, interruptMode)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GeneralActions.Instant();
			goapAction.OnInit = OnStart;
			goapAction.OnComplete = delegate
			{
				OnEnd();
			};
			yield return goapAction;
		}
	}
}
