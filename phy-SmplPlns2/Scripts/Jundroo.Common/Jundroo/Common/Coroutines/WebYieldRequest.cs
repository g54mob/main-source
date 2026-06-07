namespace Jundroo.Common.Coroutines
{
	public class WebYieldRequest<T> : YieldRequest<T>
	{
		public bool Canceled { get; private set; }

		public float Delay { get; private set; }

		public WebYieldRequest(float delay = 0f)
		{
			Delay = delay;
		}

		public void Cancel()
		{
			Canceled = true;
		}
	}
}
