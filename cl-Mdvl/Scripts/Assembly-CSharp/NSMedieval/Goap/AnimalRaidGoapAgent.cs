using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class AnimalRaidGoapAgent : Agent
	{
		private AnimalInstance animal;

		public AnimalRaidGoapAgent(AnimalInstance animal)
			: base(animal)
		{
			this.animal = animal;
			base.GoalScheduler.AddToPool(new AttackGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new AnimalRaidIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FleeGoal(this));
			base.GoalScheduler.AddToPool(new LeaveMapGoal(this));
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
