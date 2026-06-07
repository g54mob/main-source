namespace DV.Tutorial.QT
{
	public class PlayerInLocoCondition : AQuickTutorialCondition
	{
		private string message;

		private TrainCar loco;

		public PlayerInLocoCondition(string message = null)
		{
			if (string.IsNullOrEmpty(message))
			{
				this.message = "You have to be inside a locomotive for this tutorial.";
			}
			else
			{
				this.message = message;
			}
		}

		public override void Start()
		{
			if (PlayerManager.Car != null && PlayerManager.Car.IsLoco)
			{
				loco = PlayerManager.Car;
			}
			else
			{
				loco = null;
			}
		}

		public override string Check()
		{
			if (loco == null || PlayerManager.Car != loco)
			{
				return message;
			}
			return string.Empty;
		}

		public override void Deactivate()
		{
			loco = null;
		}
	}
}
