using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarSpeedStep : AQuickTutorialStep
	{
		private TrainCar car;

		private float target;

		private bool aboveTarget;

		public CarSpeedStep(TrainCar car, float targetKmh, bool aboveTarget)
			: base("", null, Vector3.zero, shouldRecheck: false)
		{
			this.car = car;
			target = targetKmh * (5f / 18f);
			this.aboveTarget = aboveTarget;
		}

		protected override bool InternalCheck()
		{
			float absSpeed = car.GetAbsSpeed();
			if (!aboveTarget)
			{
				return absSpeed < target;
			}
			return absSpeed > target;
		}
	}
}
