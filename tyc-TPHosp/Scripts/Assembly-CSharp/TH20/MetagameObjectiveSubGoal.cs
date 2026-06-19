namespace TH20
{
	public abstract class MetagameObjectiveSubGoal : ObjectiveSubGoal
	{
		protected Metagame Metagame;

		protected MetagameObjectiveSubGoal(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
			MetagameObjective metagameObjective = (MetagameObjective)owner;
			Metagame = metagameObjective.Metagame;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			UpdateProgress();
		}

		public void SetMetagame(Metagame metagame)
		{
			Metagame metagame2 = Metagame;
			Metagame = metagame;
			OnMetagameChanged(metagame2, Metagame);
		}

		protected abstract void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame);
	}
}
