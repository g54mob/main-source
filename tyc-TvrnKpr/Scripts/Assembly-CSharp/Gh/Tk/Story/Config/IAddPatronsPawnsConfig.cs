namespace Gh.Tk.Story.Config
{
	public interface IAddPatronsPawnsConfig
	{
		int minTier { get; }

		int maxTier { get; }

		int amountPerTier { get; }

		int amountPerTierMargin { get; }

		int targetHour { get; }

		int targetHourMargin { get; }

		int hourSpread { get; }
	}
}
