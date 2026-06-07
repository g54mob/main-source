using System;
using App.Data;

namespace DeepTraffic
{
	public class CarMedalCondition : BaseKeyData, ICloneable
	{
		public double averageSpeed;

		public CarMedalCondition()
		{
		}

		public CarMedalCondition(double averageSpeed)
		{
			this.averageSpeed = averageSpeed;
		}

		public bool CheckConditions(CarMedalCondition values)
		{
			return averageSpeed <= values.averageSpeed;
		}

		public bool CheckConditions(double averageSpeed)
		{
			return this.averageSpeed <= averageSpeed;
		}

		public object Clone()
		{
			return new CarMedalCondition(averageSpeed)
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
