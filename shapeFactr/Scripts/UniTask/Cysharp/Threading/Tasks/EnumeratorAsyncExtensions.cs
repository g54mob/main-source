using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace Cysharp.Threading.Tasks
{
	public static class EnumeratorAsyncExtensions
	{
		private sealed class EnumeratorPromise : IUniTaskSource, IPlayerLoopItem, ITaskPoolNode<EnumeratorPromise>
		{
			[CompilerGenerated]
			private sealed class _003CConsumeEnumerator_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public IEnumerator enumerator;

				private CustomYieldInstruction _003Ccyi_003E5__2;

				private IEnumerator _003CinnerCoroutine_003E5__3;

				object IEnumerator<object>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public _003CConsumeEnumerator_003Ed__19(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			[CompilerGenerated]
			private sealed class _003CUnwrapWaitAsyncOperation_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public AsyncOperation asyncOperation;

				object IEnumerator<object>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public _003CUnwrapWaitAsyncOperation_003Ed__22(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			[CompilerGenerated]
			private sealed class _003CUnwrapWaitForSeconds_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public WaitForSeconds waitForSeconds;

				private float _003Csecond_003E5__2;

				private float _003Celapsed_003E5__3;

				object IEnumerator<object>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public _003CUnwrapWaitForSeconds_003Ed__21(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			private static TaskPool<EnumeratorPromise> pool;

			private EnumeratorPromise nextNode;

			private IEnumerator innerEnumerator;

			private CancellationToken cancellationToken;

			private int initialFrame;

			private bool loopRunning;

			private bool calledGetResult;

			private UniTaskCompletionSourceCore<object> core;

			private static readonly FieldInfo waitForSeconds_Seconds;

			public ref EnumeratorPromise NextNode
			{
				get
				{
					throw null;
				}
			}

			static EnumeratorPromise()
			{
			}

			private EnumeratorPromise()
			{
			}

			public static IUniTaskSource Create(IEnumerator innerEnumerator, PlayerLoopTiming timing, CancellationToken cancellationToken, out short token)
			{
				token = default(short);
				return null;
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

			public bool MoveNext()
			{
				return false;
			}

			private bool TryReturn()
			{
				return false;
			}

			[IteratorStateMachine(typeof(_003CConsumeEnumerator_003Ed__19))]
			private static IEnumerator ConsumeEnumerator(IEnumerator enumerator)
			{
				return null;
			}

			[IteratorStateMachine(typeof(_003CUnwrapWaitForSeconds_003Ed__21))]
			private static IEnumerator UnwrapWaitForSeconds(WaitForSeconds waitForSeconds)
			{
				return null;
			}

			[IteratorStateMachine(typeof(_003CUnwrapWaitAsyncOperation_003Ed__22))]
			private static IEnumerator UnwrapWaitAsyncOperation(AsyncOperation asyncOperation)
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCore_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MonoBehaviour coroutineRunner;

			public IEnumerator inner;

			public AutoResetUniTaskCompletionSource source;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CCore_003Ed__4(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static UniTask.Awaiter GetAwaiter<T>(this T enumerator) where T : IEnumerator
		{
			return default(UniTask.Awaiter);
		}

		public static UniTask WithCancellation(this IEnumerator enumerator, CancellationToken cancellationToken)
		{
			return default(UniTask);
		}

		public static UniTask ToUniTask(this IEnumerator enumerator, PlayerLoopTiming timing = PlayerLoopTiming.Update, CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask);
		}

		public static UniTask ToUniTask(this IEnumerator enumerator, MonoBehaviour coroutineRunner)
		{
			return default(UniTask);
		}

		[IteratorStateMachine(typeof(_003CCore_003Ed__4))]
		private static IEnumerator Core(IEnumerator inner, MonoBehaviour coroutineRunner, AutoResetUniTaskCompletionSource source)
		{
			return null;
		}
	}
}
