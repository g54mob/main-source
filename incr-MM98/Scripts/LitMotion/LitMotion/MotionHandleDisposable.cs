using System;

namespace LitMotion
{
	internal sealed class MotionHandleDisposable : IDisposable
	{
		public readonly MotionHandle handle;

		public readonly DisposeBehavior disposeBehavior;

		public MotionHandleDisposable(MotionHandle handle, DisposeBehavior disposeBehavior)
		{
			this.handle = handle;
			this.disposeBehavior = disposeBehavior;
		}

		public void Dispose()
		{
			switch (disposeBehavior)
			{
			case DisposeBehavior.Cancel:
				handle.TryCancel();
				break;
			case DisposeBehavior.Complete:
				handle.TryComplete();
				break;
			}
		}
	}
}
