using Mandragora.PWS;
using Restory.Gameplay.Soldering;

namespace Restory.Gameplay.Cleaning
{
	public class InitialCleaningData
	{
		public CleaningProgressInPercentage CleaningProgress { get; set; }

		public SolderingProgressInPercentage SolderingProgress { get; set; }

		public DirtyPixelsCount DirtyPixelsCount { get; set; }

		public int SolderPointsCount { get; set; }

		public CleaningProgressWeights GetWeights()
		{
			return new CleaningProgressWeights(DirtyPixelsCount, SolderPointsCount);
		}

		public bool CanBeCleaned()
		{
			if (CleaningProgress.IsFullyCleaned())
			{
				return SolderingProgress.Soot < 1f;
			}
			return true;
		}
	}
}
