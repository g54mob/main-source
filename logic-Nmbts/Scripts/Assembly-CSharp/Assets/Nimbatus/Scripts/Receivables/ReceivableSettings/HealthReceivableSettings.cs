namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class HealthReceivableSettings : BaseReceivableSettings
	{
		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			return new HealthReceivable
			{
				Amount = amount
			};
		}
	}
}
