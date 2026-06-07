using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarSpeedCondition : AQuickTutorialCondition
	{
		private TrainCar car;

		private string message;

		private float minAcceptableSpeed;

		private float maxAcceptableSpeed;

		private bool absolute;

		public CarSpeedCondition(float minAcceptableSpeed, float maxAcceptableSpeed, bool absolute, string message = null, TrainCar car = null)
		{
			this.minAcceptableSpeed = minAcceptableSpeed;
			this.maxAcceptableSpeed = maxAcceptableSpeed;
			this.absolute = absolute;
			if (string.IsNullOrEmpty(message))
			{
				this.message = "Inadequate speed.";
			}
			else
			{
				this.message = message;
			}
			this.car = car;
		}

		public override void Start()
		{
			base.Start();
			if (car == null)
			{
				car = PlayerManager.Car;
			}
		}

		public override string Check()
		{
			if (car == null)
			{
				return string.Empty;
			}
			float num = car.GetForwardSpeed();
			if (absolute)
			{
				num = Mathf.Abs(num);
			}
			if (num < minAcceptableSpeed || num > maxAcceptableSpeed)
			{
				return message;
			}
			return string.Empty;
		}
	}
}
