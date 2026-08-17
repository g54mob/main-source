using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Cysharp.Threading.Tasks;

public struct YieldAwaitable(PlayerLoopTiming timing)
{
	public struct Awaiter(PlayerLoopTiming timing) : ICriticalNotifyCompletion, INotifyCompletion
	{
		private readonly PlayerLoopTiming timing = timing;

		public bool IsCompleted => false;

		public void GetResult()
		{
		}

		public void OnCompleted(Action continuation)
		{
			PlayerLoopHelper.AddContinuation(timing, continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			PlayerLoopHelper.AddContinuation(timing, continuation);
		}
	}

	private readonly PlayerLoopTiming timing = timing;

	public Awaiter GetAwaiter()
	{
		//IL_0007: Expected O, but got I4
		return (Awaiter)timing;
	}

	public unsafe UniTask ToUniTask()
	{
		//IL_001f: Expected O, but got I4
		//IL_0030: Expected native int or pointer, but got O
		UniTask uniTask = default(UniTask);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, UniTask.Yield(timing, (CancellationToken)0).source);
		return uniTask;
	}
}
