using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace Utf8Json.Internal
{
	public class AutomataDictionary : IEnumerable<KeyValuePair<string, int>>, IEnumerable
	{
		private class AutomataNode : IComparable<AutomataNode>
		{
			[CompilerGenerated]
			private sealed class _003CYieldChildren_003Ed__17 : IEnumerable<AutomataNode>, IEnumerable, IEnumerator<AutomataNode>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private AutomataNode _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public AutomataNode _003C_003E4__this;

				private int _003Ci_003E5__2;

				AutomataNode IEnumerator<AutomataNode>.Current
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
				public _003CYieldChildren_003Ed__17(int _003C_003E1__state)
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
				IEnumerator<AutomataNode> IEnumerable<AutomataNode>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private static readonly AutomataNode[] emptyNodes;

			private static readonly ulong[] emptyKeys;

			public ulong Key;

			public int Value;

			public string originalKey;

			private AutomataNode[] nexts;

			private ulong[] nextKeys;

			private int count;

			public bool HasChildren => false;

			public AutomataNode(ulong key)
			{
			}

			public AutomataNode Add(ulong key)
			{
				return null;
			}

			public AutomataNode Add(ulong key, int value, string originalKey)
			{
				return null;
			}

			public unsafe AutomataNode SearchNext(ref byte* p, ref int rest)
			{
				return null;
			}

			public AutomataNode SearchNextSafe(byte[] p, ref int offset, ref int rest)
			{
				return null;
			}

			internal static int BinarySearch(ulong[] array, int index, int length, ulong value)
			{
				return 0;
			}

			public int CompareTo(AutomataNode other)
			{
				return 0;
			}

			[IteratorStateMachine(typeof(_003CYieldChildren_003Ed__17))]
			public IEnumerable<AutomataNode> YieldChildren()
			{
				return null;
			}

			public void EmitSearchNext(ILGenerator il, LocalBuilder p, LocalBuilder rest, LocalBuilder key, Action<KeyValuePair<string, int>> onFound, Action onNotFound)
			{
			}

			private static void EmitSearchNextCore(ILGenerator il, LocalBuilder p, LocalBuilder rest, LocalBuilder key, Action<KeyValuePair<string, int>> onFound, Action onNotFound, AutomataNode[] nexts, int count)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CYieldCore_003Ed__11 : IEnumerable<KeyValuePair<string, int>>, IEnumerable, IEnumerator<KeyValuePair<string, int>>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyValuePair<string, int> _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<AutomataNode> nexts;

			public IEnumerable<AutomataNode> _003C_003E3__nexts;

			private IEnumerator<AutomataNode> _003C_003E7__wrap1;

			private AutomataNode _003Citem_003E5__3;

			private IEnumerator<KeyValuePair<string, int>> _003C_003E7__wrap3;

			KeyValuePair<string, int> IEnumerator<KeyValuePair<string, int>>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(KeyValuePair<string, int>);
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
			public _003CYieldCore_003Ed__11(int _003C_003E1__state)
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
			IEnumerator<KeyValuePair<string, int>> IEnumerable<KeyValuePair<string, int>>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private readonly AutomataNode root;

		public void Add(string str, int value)
		{
		}

		public void Add(byte[] bytes, int value)
		{
		}

		public bool TryGetValue(ArraySegment<byte> bytes, out int value)
		{
			value = default(int);
			return false;
		}

		public bool TryGetValue(byte[] bytes, int offset, int count, out int value)
		{
			value = default(int);
			return false;
		}

		public bool TryGetValueSafe(ArraySegment<byte> key, out int value)
		{
			value = default(int);
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		private static void ToStringCore(IEnumerable<AutomataNode> nexts, StringBuilder sb, int depth)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public IEnumerator<KeyValuePair<string, int>> GetEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CYieldCore_003Ed__11))]
		private static IEnumerable<KeyValuePair<string, int>> YieldCore(IEnumerable<AutomataNode> nexts)
		{
			return null;
		}

		public void EmitMatch(ILGenerator il, LocalBuilder p, LocalBuilder rest, LocalBuilder key, Action<KeyValuePair<string, int>> onFound, Action onNotFound)
		{
		}
	}
}
