using System;
using System.Runtime.CompilerServices;

namespace TwitchSDK.GameTaskMethodBuilders
{
	public struct GameTaskMethodBuilder<T>
	{
		private AsyncTaskMethodBuilder<T> Underlying;

		public GameTask<T> Task => new GameTask<T>(Underlying.Task);

		public static GameTaskMethodBuilder<T> Create()
		{
			return default(GameTaskMethodBuilder<T>);
		}

		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
			Underlying.Start(ref stateMachine);
		}

		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			Underlying.SetStateMachine(stateMachine);
		}

		public void SetException(Exception exception)
		{
			Underlying.SetException(exception);
		}

		public void SetResult(T result)
		{
			Underlying.SetResult(result);
		}

		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			Underlying.AwaitOnCompleted(ref awaiter, ref stateMachine);
		}

		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			Underlying.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
		}
	}
	public struct GameTaskMethodBuilder
	{
		private AsyncTaskMethodBuilder Underlying;

		public GameTask Task => new GameTask(Underlying.Task);

		public static GameTaskMethodBuilder Create()
		{
			return default(GameTaskMethodBuilder);
		}

		public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
		{
			Underlying.Start(ref stateMachine);
		}

		public void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			Underlying.SetStateMachine(stateMachine);
		}

		public void SetException(Exception exception)
		{
			Underlying.SetException(exception);
		}

		public void SetResult()
		{
			Underlying.SetResult();
		}

		public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			Underlying.AwaitOnCompleted(ref awaiter, ref stateMachine);
		}

		public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
		{
			Underlying.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
		}
	}
}
