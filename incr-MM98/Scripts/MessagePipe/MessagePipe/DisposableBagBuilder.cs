using System;
using System.Collections.Generic;

namespace MessagePipe
{
	public class DisposableBagBuilder
	{
		private readonly List<IDisposable> disposables;

		internal DisposableBagBuilder()
		{
			disposables = new List<IDisposable>();
		}

		internal DisposableBagBuilder(int initialCapacity)
		{
			disposables = new List<IDisposable>(initialCapacity);
		}

		public void Add(IDisposable disposable)
		{
			disposables.Add(disposable);
		}

		public void Clear()
		{
			foreach (IDisposable disposable in disposables)
			{
				disposable.Dispose();
			}
			disposables.Clear();
		}

		public IDisposable Build()
		{
			return disposables.Count switch
			{
				0 => DisposableBag.Empty, 
				1 => DisposableBag.Create(disposables[0]), 
				2 => DisposableBag.Create(disposables[0], disposables[1]), 
				3 => DisposableBag.Create(disposables[0], disposables[1], disposables[2]), 
				4 => DisposableBag.Create(disposables[0], disposables[1], disposables[2], disposables[3]), 
				5 => DisposableBag.Create(disposables[0], disposables[1], disposables[2], disposables[3], disposables[4]), 
				6 => DisposableBag.Create(disposables[0], disposables[1], disposables[2], disposables[3], disposables[4], disposables[5]), 
				7 => DisposableBag.Create(disposables[0], disposables[1], disposables[2], disposables[3], disposables[4], disposables[5], disposables[6]), 
				_ => DisposableBag.Create(disposables.ToArray()), 
			};
		}
	}
}
