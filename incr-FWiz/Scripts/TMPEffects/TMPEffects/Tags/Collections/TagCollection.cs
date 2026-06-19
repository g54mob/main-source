using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMPEffects.Tags.Collections
{
	public class TagCollection : ITagCollection, IReadOnlyTagCollection, IReadOnlyCollection<TMPEffectTagTuple>, IEnumerable<TMPEffectTagTuple>, IEnumerable
	{
		protected struct TempIndices : IComparable<TMPEffectTagIndices>
		{
			private readonly int startIndex;

			private readonly int orderAtIndex;

			public TempIndices(int startIndex, int orderAtIndex)
			{
				this.startIndex = 0;
				this.orderAtIndex = 0;
			}

			public int CompareTo(TMPEffectTagIndices other)
			{
				return 0;
			}
		}

		protected struct StartIndexOnly : IComparable<TMPEffectTagIndices>
		{
			public readonly int startIndex;

			public StartIndexOnly(int startIndex)
			{
				this.startIndex = 0;
			}

			public int CompareTo(TMPEffectTagIndices other)
			{
				return 0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CTagsAt_003Ed__16 : IEnumerable<TMPEffectTagTuple>, IEnumerable, IEnumerator<TMPEffectTagTuple>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TMPEffectTagTuple _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TagCollection _003C_003E4__this;

			private int startIndex;

			public int _003C_003E3__startIndex;

			private int _003ClastIndex_003E5__2;

			TMPEffectTagTuple IEnumerator<TMPEffectTagTuple>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(TMPEffectTagTuple);
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
			public _003CTagsAt_003Ed__16(int _003C_003E1__state)
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
			IEnumerator<TMPEffectTagTuple> IEnumerable<TMPEffectTagTuple>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		protected IList<TMPEffectTagTuple> tags;

		protected readonly ITMPTagValidator validator;

		public int TagCount => 0;

		public TagCollection(IList<TMPEffectTagTuple> tags, ITMPTagValidator validator = null)
		{
		}

		public TagCollection(ITMPTagValidator validator = null)
		{
		}

		public virtual bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			return false;
		}

		public virtual bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
		{
			return false;
		}

		protected void AdjustOrderAtIndexAt(int listIndex, TMPEffectTagIndices indices)
		{
		}

		public virtual int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			return 0;
		}

		public virtual bool RemoveAt(int startIndex, int? order = null)
		{
			return false;
		}

		public virtual void Clear()
		{
		}

		public virtual bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public void CopyTo(TMPEffectTag[] array, int arrayIndex)
		{
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			return false;
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return null;
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			return null;
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			return 0;
		}

		[IteratorStateMachine(typeof(_003CTagsAt_003Ed__16))]
		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			return null;
		}

		protected int FindIndex(TMPEffectTag tag)
		{
			return 0;
		}

		protected int BinarySearchIndexOf(IComparable<TMPEffectTagIndices> indices)
		{
			return 0;
		}

		protected int BinarySearchIndexFirstIndexOf(StartIndexOnly indices)
		{
			return 0;
		}
	}
}
