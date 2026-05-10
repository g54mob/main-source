namespace CTS.Core.Pooling
{
	public interface IPoolCallbackReceiver
	{
		protected internal void OnPulled();

		protected internal void OnPushed();
	}
}
