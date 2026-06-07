using System;
using System.Threading;

namespace R3
{
	internal sealed class TrackableDisposable : IDisposable
	{
		private int disposed;

		public IDisposable Disposable => _003Cdisposable_003EP;

		public int TrackingId => _003CtrackingId_003EP;

		public TrackableDisposable(IDisposable disposable, int trackingId)
		{
			_003Cdisposable_003EP = disposable;
			_003CtrackingId_003EP = trackingId;
			base._002Ector();
		}

		public void Dispose()
		{
			if (Interlocked.CompareExchange(ref disposed, 1, 0) == 0)
			{
				ObservableTracker.RemoveTracking(this);
			}
			_003Cdisposable_003EP.Dispose();
		}

		public override string? ToString()
		{
			return _003Cdisposable_003EP.ToString();
		}
	}
}
