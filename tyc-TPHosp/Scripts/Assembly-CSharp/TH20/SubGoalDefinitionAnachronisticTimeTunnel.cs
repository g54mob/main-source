namespace TH20
{
	public abstract class SubGoalDefinitionAnachronisticTimeTunnel : SubGoalDefinition
	{
		public int Target;

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public bool IsValid(IllnessDefinition illness, Room room)
		{
			bool num = room != null;
			bool flag = illness != null;
			return num && flag;
		}
	}
}
