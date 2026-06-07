using System;
using App.Data;

namespace DeepTraffic
{
	public class DeepTrafficControllerPresets : BaseKeyData, ICloneable
	{
		public int seed;

		public int trainSteps;

		public int iterationsToEvaluate;

		public int superEpochSize;

		public int evalEpoch;

		public int iterationBeforeYield;

		public int playerDrivingIterationUpperBound;

		public int? evalSeed;

		public DeepTrafficControllerPresets()
		{
		}

		public DeepTrafficControllerPresets(int seed, int trainSteps, int iterationsToEvaluate, int superEpochSize, int evalEpoch, int iterationBeforeYield, int playerDrivingIterationUpperBound)
		{
			this.seed = seed;
			this.trainSteps = trainSteps;
			this.iterationsToEvaluate = iterationsToEvaluate;
			this.superEpochSize = superEpochSize;
			this.evalEpoch = evalEpoch;
			this.iterationBeforeYield = iterationBeforeYield;
			this.playerDrivingIterationUpperBound = playerDrivingIterationUpperBound;
		}

		public object Clone()
		{
			return new DeepTrafficControllerPresets(seed, trainSteps, iterationsToEvaluate, superEpochSize, evalEpoch, iterationBeforeYield, playerDrivingIterationUpperBound)
			{
				KeyName = (string)KeyName.Clone(),
				evalSeed = evalSeed
			};
		}
	}
}
