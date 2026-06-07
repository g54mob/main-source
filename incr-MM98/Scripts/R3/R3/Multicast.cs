using System;

namespace R3
{
	internal sealed class Multicast<T> : ConnectableObservable<T>
	{
		private sealed class Connection : IDisposable
		{
			public Connection(Multicast<T> parent, IDisposable? subscription)
			{
				_003Cparent_003EP = parent;
				_003Csubscription_003EP = subscription;
				base._002Ector();
			}

			public void Dispose()
			{
				lock (_003Cparent_003EP.gate)
				{
					if (_003Csubscription_003EP != null)
					{
						_003Csubscription_003EP.Dispose();
						_003Csubscription_003EP = null;
						_003Cparent_003EP.connection = null;
					}
				}
			}
		}

		private readonly object gate;

		private Connection? connection;

		public Multicast(Observable<T> source, ISubject<T> subject)
		{
			_003Csource_003EP = source;
			_003Csubject_003EP = subject;
			gate = new object();
			base._002Ector();
		}

		public override IDisposable Connect()
		{
			lock (gate)
			{
				if (connection == null)
				{
					IDisposable subscription = _003Csource_003EP.Subscribe(_003Csubject_003EP.AsObserver());
					connection = new Connection(this, subscription);
				}
				return connection;
			}
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csubject_003EP.Subscribe(observer.Wrap());
		}
	}
}
