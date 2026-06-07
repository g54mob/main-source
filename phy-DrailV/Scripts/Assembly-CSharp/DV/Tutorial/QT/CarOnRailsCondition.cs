namespace DV.Tutorial.QT
{
	public class CarOnRailsCondition : AQuickTutorialCondition
	{
		private string message;

		private TrainCar car;

		public CarOnRailsCondition(string message = null, TrainCar car = null)
		{
			if (string.IsNullOrEmpty(message))
			{
				this.message = "Your loco must be on rails.";
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
			if (car != null && car.derailed)
			{
				return message;
			}
			return string.Empty;
		}
	}
}
