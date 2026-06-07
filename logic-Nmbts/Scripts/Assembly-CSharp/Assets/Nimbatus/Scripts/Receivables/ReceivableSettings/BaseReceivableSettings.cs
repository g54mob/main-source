namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public abstract class BaseReceivableSettings
	{
		public abstract BaseReceivable CreateReceivable(int seed, int amount);
	}
}
