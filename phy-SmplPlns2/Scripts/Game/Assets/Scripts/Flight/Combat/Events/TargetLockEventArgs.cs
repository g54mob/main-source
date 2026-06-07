using System;
using Jundroo.Common.Pool;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class TargetLockEventArgs : EventArgs
	{
		private static ObjectPool<TargetLockEventArgs> _pool = new ObjectPool<TargetLockEventArgs>(() => new TargetLockEventArgs(), null, ResetPooledObject, ResetPooledObject);

		public bool Locked { get; private set; }

		public ITargetLockSource Source { get; private set; }

		public TrackedTarget Target { get; private set; }

		public TargetLockEventArgs(TrackedTarget target, bool locked, ITargetLockSource source)
		{
			Target = target;
			Locked = locked;
			Source = source;
		}

		private TargetLockEventArgs()
		{
		}

		public static PooledObject<TargetLockEventArgs> GetFromPool(TrackedTarget target, bool locked, ITargetLockSource source)
		{
			TargetLockEventArgs e = _pool.Get();
			e.Target = target;
			e.Locked = locked;
			e.Source = source;
			return new PooledObject<TargetLockEventArgs>(e, _pool);
		}

		private static void ResetPooledObject(TargetLockEventArgs args)
		{
			args.Target = null;
			args.Locked = false;
			args.Source = null;
		}
	}
}
