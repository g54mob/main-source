using System;
using System.Collections.Generic;

namespace PlayFab.Multiplayer
{
	public class DisposableCollection : IDisposable
	{
		private readonly List<IDisposable> disposables;

		public DisposableCollection()
		{
			disposables = new List<IDisposable>();
		}

		~DisposableCollection()
		{
			Dispose(isDisposing: false);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		public T Add<T>(T disposable) where T : IDisposable
		{
			disposables.Add(disposable);
			return disposable;
		}

		private void Dispose(bool isDisposing)
		{
			foreach (DisposableBuffer disposable in disposables)
			{
				disposable?.Dispose();
			}
		}
	}
}
