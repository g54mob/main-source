using Mandragora.PWS;
using UnityEngine;

namespace Restory.Gameplay.Cleaning
{
	public struct CleaningProgressWeights
	{
		private const int SOOT_WEIGHT_MULTIPLIER = 5;

		public readonly float RedAndGreenChannelsWeight;

		public readonly float SootWeight;

		public CleaningProgressWeights(DirtyPixelsCount dirtyPixelsCount, int solderPointsCount = 0)
		{
			if (dirtyPixelsCount == null)
			{
				Debug.LogError("Failed to init CleaningProgressWeights, dirtyPixelsCount is null");
				RedAndGreenChannelsWeight = 0f;
				SootWeight = 0f;
				return;
			}
			int num = dirtyPixelsCount.R + dirtyPixelsCount.G + solderPointsCount * 5;
			if (num == 0)
			{
				RedAndGreenChannelsWeight = 0f;
				SootWeight = 0f;
			}
			else
			{
				RedAndGreenChannelsWeight = (float)(dirtyPixelsCount.R + dirtyPixelsCount.G) / (float)num;
				SootWeight = (float)solderPointsCount * 5f / (float)num;
			}
		}
	}
}
