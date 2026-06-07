namespace Gh.Tk.Story.Config
{
	public interface IPatronPawnModifyingFilterConfig
	{
		int minTier { get; }

		int maxTier { get; }

		int percentageAffected { get; }
	}
}
