using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class SurrogateCoroutine
	{
		[CompilerGenerated]
		private sealed class _003CInvokeInternal_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public Action action;

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
			public _003CInvokeInternal_003Ed__10(int _003C_003E1__state)
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
		private sealed class _003CWaitUntilAndInvokeInternal_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Func<bool> predicate;

			public Action action;

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
			public _003CWaitUntilAndInvokeInternal_003Ed__7(int _003C_003E1__state)
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
		private sealed class _003CWaitUntilAndInvokeInternal_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public IEnumerator coroutine;

			public Action action;

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
			public _003CWaitUntilAndInvokeInternal_003Ed__8(int _003C_003E1__state)
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
		private sealed class _003CWaitUntilAndInvokeInternal_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public YieldInstruction instruction;

			public Action action;

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
			public _003CWaitUntilAndInvokeInternal_003Ed__9(int _003C_003E1__state)
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

		public static void StartCoroutine(IEnumerator routine)
		{
		}

		public static void StopCoroutine(IEnumerator routine)
		{
		}

		public static void WaitUntilAndInvoke(Func<bool> predicate, Action action)
		{
		}

		public static void WaitUntilAndInvoke(IEnumerator coroutine, Action action)
		{
		}

		public static void WaitUntilAndInvoke(YieldInstruction instruction, Action action)
		{
		}

		public static void WaitForEndOfFrameAndInvoke(Action action)
		{
		}

		public static void Invoke(Action action, float delay)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitUntilAndInvokeInternal_003Ed__7))]
		private static IEnumerator WaitUntilAndInvokeInternal(Func<bool> predicate, Action action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitUntilAndInvokeInternal_003Ed__8))]
		private static IEnumerator WaitUntilAndInvokeInternal(IEnumerator coroutine, Action action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitUntilAndInvokeInternal_003Ed__9))]
		private static IEnumerator WaitUntilAndInvokeInternal(YieldInstruction instruction, Action action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CInvokeInternal_003Ed__10))]
		private static IEnumerator InvokeInternal(Action action, float delay)
		{
			return null;
		}
	}
}
