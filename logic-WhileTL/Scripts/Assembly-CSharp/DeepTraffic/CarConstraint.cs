using System;
using App.Data;

namespace DeepTraffic
{
	public class CarConstraint : BaseKeyData, ICloneable
	{
		public int populationSizeMax;

		public int trainStepsMax;

		public int maxEpoch;

		public CarConstraint()
		{
		}

		public CarConstraint(int populationSizeMax, int trainStepsMax, int maxEpoch)
		{
			this.populationSizeMax = populationSizeMax;
			this.trainStepsMax = trainStepsMax;
			this.maxEpoch = maxEpoch;
		}

		public object Clone()
		{
			return new CarConstraint(populationSizeMax, trainStepsMax, maxEpoch)
			{
				KeyName = (string)KeyName.Clone()
			};
		}

		public bool Check(int curEpoch)
		{
			return curEpoch <= maxEpoch;
		}
	}
}
