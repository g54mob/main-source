namespace CTS.Core
{
	public abstract class MonoPersistentSingleton<TSelf> : MonoSingleton<TSelf> where TSelf : MonoSingleton<TSelf>
	{
	}
}
