using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Cysharp.Threading.Tasks
{
	public struct CancellationTokenAwaitable
	{
		public struct Awaiter : ICriticalNotifyCompletion, INotifyCompletion
		{
			private CancellationToken cancellationToken;

			public bool IsCompleted => false;

			public Awaiter(CancellationToken cancellationToken)
			{
				this.cancellationToken = default(CancellationToken);
			}

			public void GetResult()
			{
			}

			public void OnCompleted(Action continuation)
			{
			}

			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		private CancellationToken cancellationToken;

		public CancellationTokenAwaitable(CancellationToken cancellationToken)
		{
			this.cancellationToken = default(CancellationToken);
		}

		public Awaiter GetAwaiter()
		{
			return default(Awaiter);
		}
	}
}
