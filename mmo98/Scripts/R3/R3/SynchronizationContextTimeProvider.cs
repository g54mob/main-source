using System;
using System.Threading;

namespace R3
{
	public sealed class SynchronizationContextTimeProvider : TimeProvider
	{
		private readonly Func<SynchronizationContext?> synchronizationContextAccessor;

		private readonly TimeProvider timeProvider;

		public SynchronizationContextTimeProvider()
			: this(SynchronizationContext.Current)
		{
		}

		public SynchronizationContextTimeProvider(SynchronizationContext? synchronizationContext)
			: this(synchronizationContext, TimeProvider.System)
		{
		}

		public SynchronizationContextTimeProvider(Func<SynchronizationContext?> synchronizationContextAccessor)
			: this(synchronizationContextAccessor, TimeProvider.System)
		{
		}

		public SynchronizationContextTimeProvider(SynchronizationContext? synchronizationContext, TimeProvider timeProvider)
		{
			synchronizationContextAccessor = () => synchronizationContext;
			this.timeProvider = timeProvider;
		}

		public SynchronizationContextTimeProvider(Func<SynchronizationContext?> synchronizationContextAccessor, TimeProvider timeProvider)
		{
			this.synchronizationContextAccessor = synchronizationContextAccessor;
			this.timeProvider = timeProvider;
		}

		public override ITimer CreateTimer(TimerCallback callback, object? state, TimeSpan dueTime, TimeSpan period)
		{
			return new SynchronizationContextTimer(timeProvider, synchronizationContextAccessor(), callback, state, dueTime, period);
		}
	}
}
