namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class ThreatReceivableSettings : BaseReceivableSettings
	{
		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			return new ThreatReceivable
			{
				Amount = amount
			};
		}
	}
}
