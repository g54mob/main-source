using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
				this.startIndex = startIndex;
				this.orderAtIndex = orderAtIndex;
			}

			public int CompareTo(TMPEffectTagIndices other)
			{
				int num = startIndex.CompareTo(other.StartIndex);
				if (num == 0)
				{
					return orderAtIndex.CompareTo(other.OrderAtIndex);
				}
				return num;
			}
		}

		protected struct StartIndexOnly : IComparable<TMPEffectTagIndices>
		{
			public readonly int startIndex;

			public StartIndexOnly(int startIndex)
			{
				this.startIndex = startIndex;
			}

			public int CompareTo(TMPEffectTagIndices other)
			{
				return startIndex.CompareTo(other.StartIndex);
			}
		}

		protected IList<TMPEffectTagTuple> tags;

		protected readonly ITMPTagValidator validator;

		public int TagCount => tags.Count;

		public TagCollection(IList<TMPEffectTagTuple> tags, ITMPTagValidator validator = null)
		{
			this.validator = validator;
			this.tags = tags;
		}

		public TagCollection(ITMPTagValidator validator = null)
		{
			this.validator = validator;
			tags = new List<TMPEffectTagTuple>();
		}

		public virtual bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
		{
			if (validator != null && !validator.ValidateTag(tag))
			{
				return false;
			}
			int num;
			if ((num = BinarySearchIndexOf(indices)) > 0)
			{
				AdjustOrderAtIndexAt(num, indices);
			}
			else
			{
				num = ~num;
			}
			tags.Insert(num, new TMPEffectTagTuple(tag, indices));
			return true;
		}

		public virtual bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
		{
			if (validator != null && !validator.ValidateTag(tag))
			{
				return false;
			}
			int num;
			TMPEffectTagIndices indices;
			if (!orderAtIndex.HasValue)
			{
				num = BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex));
				if (num < 0)
				{
					num = ~num;
					indices = new TMPEffectTagIndices(startIndex, endIndex, 0);
				}
				else
				{
					indices = new TMPEffectTagIndices(startIndex, endIndex, tags[num].Indices.OrderAtIndex - 1);
				}
			}
			else
			{
				num = BinarySearchIndexOf(new TempIndices(startIndex, orderAtIndex.Value));
				indices = new TMPEffectTagIndices(startIndex, endIndex, orderAtIndex.Value);
				if (num < 0)
				{
					num = ~num;
				}
				else
				{
					AdjustOrderAtIndexAt(num, indices);
				}
			}
			tags.Insert(num, new TMPEffectTagTuple(tag, indices));
			return true;
		}

		protected void AdjustOrderAtIndexAt(int listIndex, TMPEffectTagIndices indices)
		{
			TMPEffectTagIndices tMPEffectTagIndices = indices;
			while (true)
			{
				TMPEffectTagTuple tMPEffectTagTuple2;
				TMPEffectTagTuple tMPEffectTagTuple = (tMPEffectTagTuple2 = tags[listIndex]);
				if (tMPEffectTagTuple.Indices.StartIndex == tMPEffectTagIndices.StartIndex && tMPEffectTagTuple2.Indices.OrderAtIndex == tMPEffectTagIndices.OrderAtIndex)
				{
					tags[listIndex++] = new TMPEffectTagTuple(tMPEffectTagTuple2.Tag, new TMPEffectTagIndices(tMPEffectTagTuple2.Indices.StartIndex, tMPEffectTagTuple2.Indices.EndIndex, tMPEffectTagTuple2.Indices.OrderAtIndex + 1));
					tMPEffectTagIndices = tMPEffectTagTuple2.Indices;
					continue;
				}
				break;
			}
		}

		public virtual int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			int num = BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex));
			if (num < 0)
			{
				return 0;
			}
			int num2 = num;
			do
			{
				num2++;
			}
			while (num2 < tags.Count && tags[num2].Indices.StartIndex == startIndex);
			int num3 = num2 - num;
			if (buffer != null)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (bufferIndex < 0)
				{
					throw new ArgumentOutOfRangeException("bufferIndex");
				}
				int num4 = Mathf.Min(num3, buffer.Length - bufferIndex);
				for (int i = 0; i < num4; i++)
				{
					buffer[bufferIndex + i] = tags[num];
					tags.RemoveAt(num);
				}
			}
			for (int j = 0; j < num3; j++)
			{
				tags.RemoveAt(num);
			}
			return num3;
		}

		public virtual bool RemoveAt(int startIndex, int? order = null)
		{
			int num = (order.HasValue ? BinarySearchIndexOf(new TempIndices(startIndex, order.Value)) : BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex)));
			if (num < 0)
			{
				return false;
			}
			tags.RemoveAt(num);
			return true;
		}

		public virtual void Clear()
		{
			tags.Clear();
		}

		public virtual bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			int num;
			if (!indices.HasValue)
			{
				num = FindIndex(tag);
				if (num < 0)
				{
					return false;
				}
				tags.RemoveAt(num);
				return true;
			}
			num = BinarySearchIndexOf(indices);
			if (num < 0)
			{
				return false;
			}
			if (tags[num].Tag != tag)
			{
				return false;
			}
			tags.RemoveAt(num);
			return true;
		}

		public void CopyTo(TMPEffectTag[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			if (array.Length - arrayIndex < tags.Count)
			{
				throw new ArgumentException("array");
			}
			for (int i = 0; i < tags.Count; i++)
			{
				array[arrayIndex + i] = tags[i].Tag;
			}
		}

		public bool Contains(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			_ = indices.HasValue;
			return FindIndex(tag) >= 0;
		}

		public IEnumerator<TMPEffectTagTuple> GetEnumerator()
		{
			return tags.GetEnumerator();
		}

		public TMPEffectTag TagAt(int startIndex, int? order = null)
		{
			int num = (order.HasValue ? BinarySearchIndexOf(new TempIndices(startIndex, order.Value)) : BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex)));
			if (num < 0)
			{
				return null;
			}
			return tags[num].Tag;
		}

		public int TagsAt(int startIndex, TMPEffectTagTuple[] buffer, int bufferIndex = 0)
		{
			int num = BinarySearchIndexOf(new StartIndexOnly(startIndex));
			if (num < 0)
			{
				return 0;
			}
			int num2 = num;
			do
			{
				num2++;
			}
			while (num2 < tags.Count && tags[num2].Indices.StartIndex != startIndex);
			int num3 = num2 - num;
			if (buffer != null)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (bufferIndex < 0)
				{
					throw new ArgumentOutOfRangeException("bufferIndex");
				}
				int num4 = Mathf.Min(num3, buffer.Length - bufferIndex);
				for (int i = 0; i < num4; i++)
				{
					buffer[bufferIndex + i] = tags[num];
				}
			}
			return num3;
		}

		public IEnumerable<TMPEffectTagTuple> TagsAt(int startIndex)
		{
			int num = BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex));
			if (num >= 0)
			{
				int lastIndex = num;
				do
				{
					yield return tags[lastIndex++];
				}
				while (lastIndex < tags.Count && tags[lastIndex].Indices.StartIndex == startIndex);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public TMPEffectTagIndices? IndicesOf(TMPEffectTag tag)
		{
			for (int i = 0; i < tags.Count; i++)
			{
				if (tags[i].Tag == tag)
				{
					return tags[i].Indices;
				}
			}
			return null;
		}

		protected int FindIndex(TMPEffectTag tag)
		{
			for (int i = 0; i < tags.Count; i++)
			{
				if (tag == tags[i].Tag)
				{
					return i;
				}
			}
			return -1;
		}

		protected int BinarySearchIndexOf(IComparable<TMPEffectTagIndices> indices)
		{
			int num = 0;
			int num2 = tags.Count - 1;
			while (num <= num2)
			{
				int num3 = num + (num2 - num) / 2;
				int num4 = indices.CompareTo(tags[num3].Indices);
				if (num4 == 0)
				{
					return num3;
				}
				if (num4 < 0)
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
			}
			return ~num;
		}

		protected int BinarySearchIndexFirstIndexOf(StartIndexOnly indices)
		{
			int num = BinarySearchIndexOf(indices);
			if (num < 0)
			{
				return num;
			}
			while (num >= 0 && tags[num].Indices.StartIndex == indices.startIndex)
			{
				num--;
			}
			return num + 1;
		}
	}
}
