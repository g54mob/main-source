using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public readonly struct YieldAwaitable
	{
		public readonly struct Awaiter : ICriticalNotifyCompletion
		{
			private readonly PlayerLoopTiming timing;

			public bool IsCompleted => false;

			public Awaiter(PlayerLoopTiming timing)
			{
				this.timing = default(PlayerLoopTiming);
			}

			public void GetResult()
			{
			}

			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		private readonly PlayerLoopTiming timing;

		public YieldAwaitable(PlayerLoopTiming timing)
		{
			this.timing = default(PlayerLoopTiming);
		}

		public Awaiter GetAwaiter()
		{
			return default(Awaiter);
		}
	}
}
