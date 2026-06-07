using System;
using App.Data;

namespace DeepTraffic
{
	public class CarCondition : BaseCondition, ICloneable
	{
		public string carControllerKeyName;

		public string carConstraintKeyName;

		public string carMedalConditionKeyName;

		public DeepTrafficControllerPresets carController;

		public CarConstraint carConstraint;

		public CarMedalCondition carMedalCondition;

		public DeepTrafficControllerPresets CarController => carController ?? (carController = (DeepTrafficControllerPresets)Logic.GetCarControllerByKeyName(carControllerKeyName).Clone());

		public CarConstraint CarConstraint => carConstraint ?? (carConstraint = (CarConstraint)Logic.GetCarConstraintByKeyName(carConstraintKeyName).Clone());

		public CarMedalCondition CarMedalCondition => carMedalCondition ?? (carMedalCondition = (CarMedalCondition)Logic.GetCarMedalConditionByKeyName(carMedalConditionKeyName).Clone());

		public CarCondition()
		{
		}

		public CarCondition(int extraMoney = 0, string carControllerKeyName = "-", string carConstraintKeyName = "-", string carMedalConditionKeyName = "-")
		{
			ExtraMoney = extraMoney;
			this.carControllerKeyName = carControllerKeyName;
			this.carConstraintKeyName = carConstraintKeyName;
			this.carMedalConditionKeyName = carMedalConditionKeyName;
		}

		public object Clone()
		{
			return new CarCondition(ExtraMoney, (carControllerKeyName == null) ? null : ((string)carControllerKeyName.Clone()), (carConstraintKeyName == null) ? null : ((string)carConstraintKeyName.Clone()), (carMedalConditionKeyName == null) ? null : ((string)carMedalConditionKeyName.Clone()))
			{
				KeyName = (string)KeyName.Clone()
			};
		}
	}
}
