using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution.VM;

namespace MoonSharp.Interpreter
{
	public class Coroutine : RefIdObject, IScriptPrivateResource
	{
		public enum CoroutineType
		{
			Coroutine = 0,
			ClrCallback = 1,
			ClrCallbackDead = 2
		}

		[CompilerGenerated]
		private sealed class _003CAsEnumerable_003Ed__11 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Coroutine _003C_003E4__this;

			private IEnumerator<DynValue> _003C_003E7__wrap1;

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
			public _003CAsEnumerable_003Ed__11(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAsEnumerable_003Ed__12<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Coroutine _003C_003E4__this;

			private IEnumerator<DynValue> _003C_003E7__wrap1;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
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
			public _003CAsEnumerable_003Ed__12(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAsTypedEnumerable_003Ed__10 : IEnumerable<DynValue>, IEnumerable, IEnumerator<DynValue>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private DynValue _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public Coroutine _003C_003E4__this;

			DynValue IEnumerator<DynValue>.Current
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
			public _003CAsTypedEnumerable_003Ed__10(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<DynValue> IEnumerable<DynValue>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAsUnityCoroutine_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Coroutine _003C_003E4__this;

			private IEnumerator<DynValue> _003C_003E7__wrap1;

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
			public _003CAsUnityCoroutine_003Ed__13(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private CallbackFunction m_ClrCallback;

		private Processor m_Processor;

		public CoroutineType Type { get; private set; }

		public CoroutineState State => default(CoroutineState);

		public Script OwnerScript { get; private set; }

		public long AutoYieldCounter
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		internal Coroutine(CallbackFunction function)
		{
		}

		internal Coroutine(Processor proc)
		{
		}

		internal void MarkClrCallbackAsDead()
		{
		}

		[IteratorStateMachine(typeof(_003CAsTypedEnumerable_003Ed__10))]
		public IEnumerable<DynValue> AsTypedEnumerable()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAsEnumerable_003Ed__11))]
		public IEnumerable<object> AsEnumerable()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAsEnumerable_003Ed__12<>))]
		public IEnumerable<T> AsEnumerable<T>()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAsUnityCoroutine_003Ed__13))]
		public IEnumerator AsUnityCoroutine()
		{
			return null;
		}

		public DynValue Resume(params DynValue[] args)
		{
			return null;
		}

		public DynValue Resume(ScriptExecutionContext context, params DynValue[] args)
		{
			return null;
		}

		public DynValue Resume()
		{
			return null;
		}

		public DynValue Resume(ScriptExecutionContext context)
		{
			return null;
		}

		public DynValue Resume(params object[] args)
		{
			return null;
		}

		public DynValue Resume(ScriptExecutionContext context, params object[] args)
		{
			return null;
		}

		public WatchItem[] GetStackTrace(int skip, SourceRef entrySourceRef = null)
		{
			return null;
		}
	}
}
