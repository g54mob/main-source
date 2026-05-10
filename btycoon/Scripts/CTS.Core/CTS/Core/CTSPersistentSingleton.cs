namespace CTS.Core
{
	public abstract class CTSPersistentSingleton<TSelf> : CTSSingleton<TSelf> where TSelf : CTSSingleton<TSelf>
	{
	}
}
