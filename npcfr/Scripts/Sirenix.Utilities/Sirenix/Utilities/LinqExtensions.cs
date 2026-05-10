using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sirenix.Utilities
{
	public static class LinqExtensions
	{
		[CompilerGenerated]
		private sealed class _003CAppendIf_003Ed__20<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private bool condition;

			public bool _003C_003E3__condition;

			private Func<T> append;

			public Func<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CAppendIf_003Ed__21<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private bool condition;

			public bool _003C_003E3__condition;

			private T append;

			public T _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__21(int _003C_003E1__state)
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
		private sealed class _003CAppendIf_003Ed__22<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private bool condition;

			public bool _003C_003E3__condition;

			private IEnumerable<T> append;

			public IEnumerable<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__22(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CAppendIf_003Ed__23<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private Func<T> append;

			public Func<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__23(int _003C_003E1__state)
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
		private sealed class _003CAppendIf_003Ed__24<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private T append;

			public T _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__24(int _003C_003E1__state)
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
		private sealed class _003CAppendIf_003Ed__25<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private IEnumerable<T> append;

			public IEnumerable<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendIf_003Ed__25(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CAppendWith_003Ed__17<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Func<T> append;

			public Func<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendWith_003Ed__17(int _003C_003E1__state)
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
		private sealed class _003CAppendWith_003Ed__18<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private T append;

			public T _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendWith_003Ed__18(int _003C_003E1__state)
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
		private sealed class _003CAppendWith_003Ed__19<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerable<T> append;

			public IEnumerable<T> _003C_003E3__append;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CAppendWith_003Ed__19(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CConvert_003Ed__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable source;

			public IEnumerable _003C_003E3__source;

			private Func<object, T> converter;

			public Func<object, T> _003C_003E3__converter;

			private IEnumerator _003C_003E7__wrap1;

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
			public _003CConvert_003Ed__3(int _003C_003E1__state)
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
		private sealed class _003CExamine_003Ed__0<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Action<T> action;

			public Action<T> _003C_003E3__action;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CExamine_003Ed__0(int _003C_003E1__state)
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
		private sealed class _003CFilterCast_003Ed__26<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable source;

			public IEnumerable _003C_003E3__source;

			private IEnumerator _003C_003E7__wrap1;

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
			public _003CFilterCast_003Ed__26(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__10<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private bool condition;

			public bool _003C_003E3__condition;

			private IEnumerable<T> prepend;

			public IEnumerable<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__10(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CPrependIf_003Ed__11<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private Func<T> prepend;

			public Func<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__11(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__12<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private T prepend;

			public T _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__12(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__13<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<bool> condition;

			public Func<bool> _003C_003E3__condition;

			private IEnumerable<T> prepend;

			public IEnumerable<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__13(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CPrependIf_003Ed__14<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<IEnumerable<T>, bool> condition;

			public Func<IEnumerable<T>, bool> _003C_003E3__condition;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private Func<T> prepend;

			public Func<T> _003C_003E3__prepend;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__14(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__15<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<IEnumerable<T>, bool> condition;

			public Func<IEnumerable<T>, bool> _003C_003E3__condition;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private T prepend;

			public T _003C_003E3__prepend;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__15(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__16<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<IEnumerable<T>, bool> condition;

			public Func<IEnumerable<T>, bool> _003C_003E3__condition;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerable<T> prepend;

			public IEnumerable<T> _003C_003E3__prepend;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__16(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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
		private sealed class _003CPrependIf_003Ed__8<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private bool condition;

			public bool _003C_003E3__condition;

			private Func<T> prepend;

			public Func<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__8(int _003C_003E1__state)
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
		private sealed class _003CPrependIf_003Ed__9<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private bool condition;

			public bool _003C_003E3__condition;

			private T prepend;

			public T _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependIf_003Ed__9(int _003C_003E1__state)
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
		private sealed class _003CPrependWith_003Ed__5<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Func<T> prepend;

			public Func<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependWith_003Ed__5(int _003C_003E1__state)
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
		private sealed class _003CPrependWith_003Ed__6<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private T prepend;

			public T _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependWith_003Ed__6(int _003C_003E1__state)
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
		private sealed class _003CPrependWith_003Ed__7<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IDisposable, IEnumerator
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> prepend;

			public IEnumerable<T> _003C_003E3__prepend;

			private IEnumerable<T> source;

			public IEnumerable<T> _003C_003E3__source;

			private IEnumerator<T> _003C_003E7__wrap1;

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
			public _003CPrependWith_003Ed__7(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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

		[IteratorStateMachine(typeof(_003CExamine_003Ed__0<>))]
		public static IEnumerable<T> Examine<T>(this IEnumerable<T> source, Action<T> action)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			return null;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CConvert_003Ed__3<>))]
		public static IEnumerable<T> Convert<T>(this IEnumerable source, Func<object, T> converter)
		{
			return null;
		}

		public static ImmutableList<T> ToImmutableList<T>(this IEnumerable<T> source)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependWith_003Ed__5<>))]
		public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> source, Func<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependWith_003Ed__6<>))]
		public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> source, T prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependWith_003Ed__7<>))]
		public static IEnumerable<T> PrependWith<T>(this IEnumerable<T> source, IEnumerable<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__8<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, bool condition, Func<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__9<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, bool condition, T prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__10<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, bool condition, IEnumerable<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__11<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<bool> condition, Func<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__12<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<bool> condition, T prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__13<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<bool> condition, IEnumerable<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__14<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<IEnumerable<T>, bool> condition, Func<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__15<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<IEnumerable<T>, bool> condition, T prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPrependIf_003Ed__16<>))]
		public static IEnumerable<T> PrependIf<T>(this IEnumerable<T> source, Func<IEnumerable<T>, bool> condition, IEnumerable<T> prepend)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendWith_003Ed__17<>))]
		public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> source, Func<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendWith_003Ed__18<>))]
		public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> source, T append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendWith_003Ed__19<>))]
		public static IEnumerable<T> AppendWith<T>(this IEnumerable<T> source, IEnumerable<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__20<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, bool condition, Func<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__21<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, bool condition, T append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__22<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, bool condition, IEnumerable<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__23<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, Func<bool> condition, Func<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__24<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, Func<bool> condition, T append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAppendIf_003Ed__25<>))]
		public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> source, Func<bool> condition, IEnumerable<T> append)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFilterCast_003Ed__26<>))]
		public static IEnumerable<T> FilterCast<T>(this IEnumerable source)
		{
			return null;
		}

		public static void AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> range)
		{
		}

		public static bool IsNullOrEmpty<T>(this IList<T> list)
		{
			return false;
		}

		public static void Populate<T>(this IList<T> list, T item)
		{
		}

		public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
		{
		}

		public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
		{
		}

		public static void Sort<T>(this IList<T> list)
		{
		}
	}
}
