namespace ModApi.Flight.MapView
{
	public interface ITargetingOptions
	{
		double CraftSoiDistance { get; set; }

		double PeriodsInFutureToBegin { get; }

		bool SearchWholeOrbit { get; set; }

		double SoiEntryLocalMinimaModifier { get; set; }

		bool UseBinarySearch { get; set; }
	}
}
