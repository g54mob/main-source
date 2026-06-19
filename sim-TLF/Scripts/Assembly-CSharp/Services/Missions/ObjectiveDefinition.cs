namespace Services.Missions
{
	public class ObjectiveDefinition
	{
		public string ObjectiveId;

		public string Description;

		public ObjectiveType Type;

		public string TargetId;

		public int RequiredAmount = 1;
	}
}
