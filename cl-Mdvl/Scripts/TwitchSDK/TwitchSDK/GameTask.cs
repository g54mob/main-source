using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TwitchSDK.GameTaskMethodBuilders;

namespace TwitchSDK
{
	[AsyncMethodBuilder(typeof(GameTaskMethodBuilder<>))]
	public class GameTask<T> : GameTask
	{
		public new Task<T> Task { get; }

		public T MaybeResult
		{
			get
			{
				if (!Task.IsCompleted)
				{
					return default(T);
				}
				return Task.Result;
			}
		}

		public AggregateException Exception => Task.Exception;

		public GameTask(Task<T> task)
			: base(task)
		{
			Task = task;
		}

		public new TaskAwaiter<T> GetAwaiter()
		{
			return Task.GetAwaiter();
		}

		public static implicit operator GameTask<T>(Task<T> task)
		{
			return new GameTask<T>(task);
		}
	}
	[AsyncMethodBuilder(typeof(GameTaskMethodBuilder))]
	public class GameTask
	{
		public Task Task { get; }

		public bool IsCompleted => Task.IsCompleted;

		public GameTask(Task task)
		{
			Task = task;
		}

		public TaskAwaiter GetAwaiter()
		{
			return Task.GetAwaiter();
		}

		public static implicit operator GameTask(Task task)
		{
			return new GameTask(task);
		}
	}
}
