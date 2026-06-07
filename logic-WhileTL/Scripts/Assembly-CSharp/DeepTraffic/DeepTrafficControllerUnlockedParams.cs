using System;
using App.Data;

namespace DeepTraffic
{
	public class DeepTrafficControllerUnlockedParams : BaseKeyData, ICloneable
	{
		public bool seed;

		public bool trainSteps;

		public DeepTrafficControllerUnlockedParams()
		{
		}

		public DeepTrafficControllerUnlockedParams(bool seed, bool trainSteps)
		{
			this.seed = seed;
			this.trainSteps = trainSteps;
		}

		public object Clone()
		{
			return new DeepTrafficControllerUnlockedParams(seed, trainSteps)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
