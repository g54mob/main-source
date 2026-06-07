using System;

namespace UniRx.Operators
{
	internal class CastObservable<TSource, TResult> : OperatorObservableBase<TResult>
	{
		private class Cast : OperatorObserverBase<TSource, TResult>
		{
			public Cast(IObserver<TResult> observer, IDisposable cancel)
				: base(observer, cancel)
			{
			}

			public override void OnNext(TSource value)
			{
				TResult val = default(TResult);
				try
				{
					val = (TResult)(object)value;
				}
				catch (Exception error)
				{
					try
					{
						observer.OnError(error);
						return;
					}
					finally
					{
						Dispose();
					}
				}
				observer.OnNext(val);
			}

			public override void OnError(Exception error)
			{
				try
				{
					observer.OnError(error);
				}
				finally
				{
					Dispose();
				}
			}

			public override void OnCompleted()
			{
				try
				{
					observer.OnCompleted();
				}
				finally
				{
					Dispose();
				}
			}
		}

		private readonly IObservable<TSource> source;

		public CastObservable(IObservable<TSource> source)
			: base(source.IsRequiredSubscribeOnCurrentThread())
		{
			this.source = source;
		}

		protected override IDisposable SubscribeCore(IObserver<TResult> observer, IDisposable cancel)
		{
			return source.Subscribe(new Cast(observer, cancel));
		}
	}
}
