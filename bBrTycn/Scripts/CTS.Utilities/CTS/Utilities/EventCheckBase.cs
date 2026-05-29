namespace CTS.Utilities
{
	public abstract class EventCheckBase
	{
		protected bool? LastValue;

		~EventCheckBase()
		{
			UnregisterTick();
		}

		public void ResetValue()
		{
			LastValue = null;
		}

		protected abstract void RegisterTick();

		protected abstract void UnregisterTick();

		protected virtual void OnTick()
		{
			UnregisterTick();
			LastValue = null;
		}
	}
}
