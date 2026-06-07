using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class ToLookup
	{
		private class Lookup<TKey, TElement> : ILookup<TKey, TElement>, IEnumerable<IGrouping<TKey, TElement>>, IEnumerable
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CCreateAsync_003Ed__6 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder<Lookup<TKey, TElement>> _003C_003Et__builder;

				public IEqualityComparer<TKey> comparer;

				public ArraySegment<TElement> source;

				public Func<TElement, UniTask<TKey>> keySelector;

				private Dictionary<TKey, Grouping<TKey, TElement>> _003Cdict_003E5__2;

				private TElement[] _003Carr_003E5__3;

				private int _003Cc_003E5__4;

				private int _003Ci_003E5__5;

				private UniTask<TKey>.Awaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CCreateAsync_003Ed__7<TSource> : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder<Lookup<TKey, TElement>> _003C_003Et__builder;

				public IEqualityComparer<TKey> comparer;

				public ArraySegment<TSource> source;

				public Func<TSource, UniTask<TKey>> keySelector;

				public Func<TSource, UniTask<TElement>> elementSelector;

				private Dictionary<TKey, Grouping<TKey, TElement>> _003Cdict_003E5__2;

				private TSource[] _003Carr_003E5__3;

				private int _003Cc_003E5__4;

				private int _003Ci_003E5__5;

				private TKey _003Ckey_003E5__6;

				private UniTask<TKey>.Awaiter _003C_003Eu__1;

				private UniTask<TElement>.Awaiter _003C_003Eu__2;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CCreateAsync_003Ed__8 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder<Lookup<TKey, TElement>> _003C_003Et__builder;

				public IEqualityComparer<TKey> comparer;

				public ArraySegment<TElement> source;

				public Func<TElement, CancellationToken, UniTask<TKey>> keySelector;

				public CancellationToken cancellationToken;

				private Dictionary<TKey, Grouping<TKey, TElement>> _003Cdict_003E5__2;

				private TElement[] _003Carr_003E5__3;

				private int _003Cc_003E5__4;

				private int _003Ci_003E5__5;

				private UniTask<TKey>.Awaiter _003C_003Eu__1;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CCreateAsync_003Ed__9<TSource> : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder<Lookup<TKey, TElement>> _003C_003Et__builder;

				public IEqualityComparer<TKey> comparer;

				public ArraySegment<TSource> source;

				public Func<TSource, CancellationToken, UniTask<TKey>> keySelector;

				public CancellationToken cancellationToken;

				public Func<TSource, CancellationToken, UniTask<TElement>> elementSelector;

				private Dictionary<TKey, Grouping<TKey, TElement>> _003Cdict_003E5__2;

				private TSource[] _003Carr_003E5__3;

				private int _003Cc_003E5__4;

				private int _003Ci_003E5__5;

				private TKey _003Ckey_003E5__6;

				private UniTask<TKey>.Awaiter _003C_003Eu__1;

				private UniTask<TElement>.Awaiter _003C_003Eu__2;

				private void MoveNext()
				{
				}

				void IAsyncStateMachine.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					this.MoveNext();
				}

				[DebuggerHidden]
				private void SetStateMachine(IAsyncStateMachine stateMachine)
				{
				}

				void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
				{
					//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
					this.SetStateMachine(stateMachine);
				}
			}

			private static readonly Lookup<TKey, TElement> empty;

			private readonly Dictionary<TKey, Grouping<TKey, TElement>> dict;

			public IEnumerable<TElement> this[TKey key] => null;

			public int Count => 0;

			private Lookup(Dictionary<TKey, Grouping<TKey, TElement>> dict)
			{
			}

			public static Lookup<TKey, TElement> CreateEmpty()
			{
				return null;
			}

			public static Lookup<TKey, TElement> Create(ArraySegment<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer)
			{
				return null;
			}

			public static Lookup<TKey, TElement> Create<TSource>(ArraySegment<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
			{
				return null;
			}

			[AsyncStateMachine(typeof(Lookup<, >._003CCreateAsync_003Ed__6))]
			public static UniTask<Lookup<TKey, TElement>> CreateAsync(ArraySegment<TElement> source, Func<TElement, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer)
			{
				return default(UniTask<Lookup<TKey, TElement>>);
			}

			[AsyncStateMachine(typeof(_003CCreateAsync_003Ed__7<>))]
			public static UniTask<Lookup<TKey, TElement>> CreateAsync<TSource>(ArraySegment<TSource> source, Func<TSource, UniTask<TKey>> keySelector, Func<TSource, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer)
			{
				return default(UniTask<Lookup<TKey, TElement>>);
			}

			[AsyncStateMachine(typeof(Lookup<, >._003CCreateAsync_003Ed__8))]
			public static UniTask<Lookup<TKey, TElement>> CreateAsync(ArraySegment<TElement> source, Func<TElement, CancellationToken, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
			{
				return default(UniTask<Lookup<TKey, TElement>>);
			}

			[AsyncStateMachine(typeof(_003CCreateAsync_003Ed__9<>))]
			public static UniTask<Lookup<TKey, TElement>> CreateAsync<TSource>(ArraySegment<TSource> source, Func<TSource, CancellationToken, UniTask<TKey>> keySelector, Func<TSource, CancellationToken, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
			{
				return default(UniTask<Lookup<TKey, TElement>>);
			}

			public bool Contains(TKey key)
			{
				return false;
			}

			public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IEnumerable<TElement>, IEnumerable
		{
			private readonly List<TElement> elements;

			public TKey Key { get; private set; }

			public Grouping(TKey key)
			{
			}

			public void Add(TElement value)
			{
			}

			public IEnumerator<TElement> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			public IUniTaskAsyncEnumerator<TElement> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAsync_003Ed__0<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TSource>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, TKey> keySelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TSource> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAsync_003Ed__1<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TElement>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, TKey> keySelector;

			public Func<TSource, TElement> elementSelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TElement> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAwaitAsync_003Ed__2<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TSource>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<TKey>> keySelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TSource> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<Lookup<TKey, TSource>>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAwaitAsync_003Ed__3<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TElement>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<TKey>> keySelector;

			public Func<TSource, UniTask<TElement>> elementSelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TElement> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<Lookup<TKey, TElement>>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAwaitWithCancellationAsync_003Ed__4<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TSource>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<TKey>> keySelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TSource> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<Lookup<TKey, TSource>>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToLookupAwaitWithCancellationAsync_003Ed__5<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<ILookup<TKey, TElement>> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<TKey>> keySelector;

			public Func<TSource, CancellationToken, UniTask<TElement>> elementSelector;

			public IEqualityComparer<TKey> comparer;

			private ArrayPool<TSource> _003Cpool_003E5__2;

			private TSource[] _003Carray_003E5__3;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__4;

			private object _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

			private ILookup<TKey, TElement> _003C_003E7__wrap6;

			private int _003Ci_003E5__8;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask<Lookup<TKey, TElement>>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[AsyncStateMachine(typeof(_003CToLookupAsync_003Ed__0<, >))]
		internal static UniTask<ILookup<TKey, TSource>> ToLookupAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToLookupAsync_003Ed__1<, , >))]
		internal static UniTask<ILookup<TKey, TElement>> ToLookupAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TElement>>);
		}

		[AsyncStateMachine(typeof(_003CToLookupAwaitAsync_003Ed__2<, >))]
		internal static UniTask<ILookup<TKey, TSource>> ToLookupAwaitAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToLookupAwaitAsync_003Ed__3<, , >))]
		internal static UniTask<ILookup<TKey, TElement>> ToLookupAwaitAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<TKey>> keySelector, Func<TSource, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TElement>>);
		}

		[AsyncStateMachine(typeof(_003CToLookupAwaitWithCancellationAsync_003Ed__4<, >))]
		internal static UniTask<ILookup<TKey, TSource>> ToLookupAwaitWithCancellationAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToLookupAwaitWithCancellationAsync_003Ed__5<, , >))]
		internal static UniTask<ILookup<TKey, TElement>> ToLookupAwaitWithCancellationAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<TKey>> keySelector, Func<TSource, CancellationToken, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<ILookup<TKey, TElement>>);
		}
	}
}
