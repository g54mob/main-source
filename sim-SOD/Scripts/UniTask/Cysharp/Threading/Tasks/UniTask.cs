using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	[StructLayout((LayoutKind)3)]
	[AsyncMethodBuilder(typeof(AsyncUniTaskMethodBuilder))]
	public readonly struct UniTask
	{
		public readonly struct Awaiter : ICriticalNotifyCompletion
		{
			private readonly UniTask task;

			public bool IsCompleted
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[DebuggerHidden]
				get
				{
					return false;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public Awaiter(in UniTask task)
			{
				this.task = default(UniTask);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public void GetResult()
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public void UnsafeOnCompleted(Action continuation)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public void SourceOnCompleted(Action<object> continuation, object state)
			{
			}
		}

		private static class CanceledUniTaskCache<T>
		{
			public static readonly UniTask<T> Task;

			static CanceledUniTaskCache()
			{
			}
		}

		private sealed class ExceptionResultSource : IUniTaskSource
		{
			private readonly ExceptionDispatchInfo exception;

			private bool calledGet;

			public ExceptionResultSource(Exception exception)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			~ExceptionResultSource()
			{
			}
		}

		private sealed class ExceptionResultSource<T> : IUniTaskSource<T>, IUniTaskSource
		{
			private readonly ExceptionDispatchInfo exception;

			private bool calledGet;

			public ExceptionResultSource(Exception exception)
			{
			}

			public T GetResult(short token)
			{
				return default(T);
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			~ExceptionResultSource()
			{
			}
		}

		private sealed class CanceledResultSource : IUniTaskSource
		{
			private readonly CancellationToken cancellationToken;

			public CanceledResultSource(CancellationToken cancellationToken)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}
		}

		private sealed class CanceledResultSource<T> : IUniTaskSource<T>, IUniTaskSource
		{
			private readonly CancellationToken cancellationToken;

			public CanceledResultSource(CancellationToken cancellationToken)
			{
			}

			public T GetResult(short token)
			{
				return default(T);
			}

			void IUniTaskSource.GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}
		}

		private readonly IUniTaskSource source;

		private readonly short token;

		private static readonly UniTask CanceledUniTask;

		public static readonly UniTask CompletedTask;

		public UniTaskStatus Status
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return default(UniTaskStatus);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public UniTask(IUniTaskSource source, short token)
		{
			this.source = null;
			this.token = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public Awaiter GetAwaiter()
		{
			return default(Awaiter);
		}

		public override string ToString()
		{
			return null;
		}

		public static YieldAwaitable Yield()
		{
			return default(YieldAwaitable);
		}

		public static UniTask FromException(Exception ex)
		{
			return default(UniTask);
		}

		public static UniTask<T> FromException<T>(Exception ex)
		{
			return default(UniTask<T>);
		}

		public static UniTask<T> FromResult<T>(T value)
		{
			return default(UniTask<T>);
		}

		public static UniTask FromCanceled(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask<T> FromCanceled<T>(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<T>);
		}
	}
	[StructLayout((LayoutKind)3)]
	[AsyncMethodBuilder(typeof(AsyncUniTaskMethodBuilder<>))]
	public readonly struct UniTask<T>
	{
		public readonly struct Awaiter : ICriticalNotifyCompletion
		{
			private readonly UniTask<T> task;

			public bool IsCompleted
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[DebuggerHidden]
				get
				{
					return false;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public Awaiter(in UniTask<T> task)
			{
				this.task = default(UniTask<T>);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public T GetResult()
			{
				return default(T);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			public void UnsafeOnCompleted(Action continuation)
			{
			}
		}

		private readonly IUniTaskSource<T> source;

		private readonly T result;

		private readonly short token;

		public UniTaskStatus Status
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[DebuggerHidden]
			get
			{
				return default(UniTaskStatus);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public UniTask(T result)
		{
			source = null;
			this.result = default(T);
			token = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public UniTask(IUniTaskSource<T> source, short token)
		{
			this.source = null;
			result = default(T);
			this.token = 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerHidden]
		public Awaiter GetAwaiter()
		{
			return default(Awaiter);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
