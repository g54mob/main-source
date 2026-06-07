using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarDistanceCondition : AQuickTutorialCondition
	{
		private Transform car;

		private float range = 10f;

		public CarDistanceCondition(float range, TrainCar car = null)
		{
			this.range = range;
			if ((bool)car)
			{
				this.car = car.transform;
			}
		}

		public override void Start()
		{
			if (car == null && PlayerManager.Car != null)
			{
				car = PlayerManager.Car.transform;
			}
		}

		public override string Check()
		{
			if (car != null && Vector3.Distance(PlayerManager.PlayerTransform.position, car.transform.position) > range)
			{
				return "tutorial/fail/abandoned";
			}
			return string.Empty;
		}
	}
}
