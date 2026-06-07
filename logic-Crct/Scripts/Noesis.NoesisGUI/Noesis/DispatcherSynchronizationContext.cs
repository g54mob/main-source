using System.Threading;

namespace Noesis
{
	public sealed class DispatcherSynchronizationContext : SynchronizationContext
	{
		private Dispatcher _dispatcher;

		public DispatcherSynchronizationContext()
		{
		}

		public DispatcherSynchronizationContext(Dispatcher dispatcher)
		{
		}

		public override void Send(SendOrPostCallback d, object state)
		{
		}

		public override void Post(SendOrPostCallback d, object state)
		{
		}

		public override SynchronizationContext CreateCopy()
		{
			return null;
		}
	}
}
