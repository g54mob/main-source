using System;
using System.Collections.Generic;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class RandomBallsPoolSystemBaseSaveData
	{
		public int[] InitialBalls;

		public Dictionary<int, int> RemainingBalls;
	}
}
