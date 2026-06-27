using System;

namespace NSubstitute.Core
{
	internal class ReturnObservable<T> : IObservable<T?>
	{
		public ReturnObservable(T? value)
		{
			_003Cvalue_003EP = value;
			base._002Ector();
		}

		public ReturnObservable()
			: this(default(T))
		{
		}

		public IDisposable Subscribe(IObserver<T?> observer)
		{
			observer.OnNext(_003Cvalue_003EP);
			observer.OnCompleted();
			return EmptyDisposable.Instance;
		}
	}
}
