namespace TH20
{
	public interface ResearchPrerequisite
	{
		bool IsValid(Level level);

		string Description();
	}
}
