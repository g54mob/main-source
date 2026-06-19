namespace Items
{
	public interface IConsumeProgressable : IConsumeChangeProgressable
	{
		float MaxProgress { get; }
	}
}
