using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class NPCBlankGoapAgent : Agent
	{
		private HumanoidInstance humanoid;

		public NPCBlankGoapAgent(HumanoidInstance humanoid)
			: base(humanoid, new NPCGoalExecutionManager(humanoid))
		{
			this.humanoid = humanoid;
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}

		public override void Dispose()
		{
			base.Dispose();
			humanoid = null;
		}
	}
}
