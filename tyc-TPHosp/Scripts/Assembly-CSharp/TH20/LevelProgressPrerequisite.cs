namespace TH20
{
	public abstract class LevelProgressPrerequisite
	{
		public abstract bool IsComplete(Metagame metagame);

		public abstract string RequiredDescription();
	}
}
