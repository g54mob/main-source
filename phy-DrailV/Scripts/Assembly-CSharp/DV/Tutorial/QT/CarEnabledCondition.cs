namespace DV.Tutorial.QT
{
	public class CarEnabledCondition : AQuickTutorialCondition
	{
		private TrainCar car;

		public CarEnabledCondition()
		{
		}

		public CarEnabledCondition(TrainCar car)
		{
			this.car = car;
		}

		public override void Start()
		{
			if (car == null)
			{
				car = PlayerManager.Car;
			}
		}

		public override string Check()
		{
			if (car == null || !car.gameObject.activeInHierarchy)
			{
				return "tutorial/fail/despawned";
			}
			return string.Empty;
		}
	}
}
