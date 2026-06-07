namespace DV.Tutorial.QT
{
	public class CarDamageCondition : AQuickTutorialCondition
	{
		private string message;

		private float minAcceptableDamage;

		private float maxAcceptableDamage;

		public CarDamageCondition(float minAcceptableDamage, float maxAcceptableDamage, string message = null)
		{
			this.minAcceptableDamage = minAcceptableDamage;
			this.maxAcceptableDamage = maxAcceptableDamage;
			if (string.IsNullOrEmpty(message))
			{
				this.message = "Locomotive is too damaged.";
			}
			else
			{
				this.message = message;
			}
		}

		public override string Check()
		{
			if (PlayerManager.Car == null)
			{
				return string.Empty;
			}
			if (PlayerManager.Car.CarDamage.DamagePercentage < minAcceptableDamage || PlayerManager.Car.CarDamage.DamagePercentage > maxAcceptableDamage)
			{
				return message;
			}
			return string.Empty;
		}
	}
}
