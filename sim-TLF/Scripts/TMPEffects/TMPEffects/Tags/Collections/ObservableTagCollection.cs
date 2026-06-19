using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace TMPEffects.Tags.Collections
{
	public class ObservableTagCollection : TagCollection, INotifyCollectionChanged
	{
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public ObservableTagCollection(IList<TMPEffectTagTuple> tags, ITMPTagValidator validator = null)
			: base(tags, validator)
		{
		}

		public ObservableTagCollection(ITMPTagValidator validator = null)
			: base(validator)
		{
		}

		protected void InvokeEvent(NotifyCollectionChangedEventArgs e)
		{
			this.CollectionChanged?.Invoke(this, e);
		}

		public override bool TryAdd(TMPEffectTag tag, TMPEffectTagIndices indices)
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
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, tags[num], num));
			return true;
		}

		public override bool TryAdd(TMPEffectTag tag, int startIndex = 0, int endIndex = -1, int? orderAtIndex = null)
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
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, tags[num], num));
			return true;
		}

		public override bool Remove(TMPEffectTag tag, TMPEffectTagIndices? indices = null)
		{
			int num;
			TMPEffectTagTuple tMPEffectTagTuple;
			if (!indices.HasValue)
			{
				num = FindIndex(tag);
				if (num < 0)
				{
					return false;
				}
				tMPEffectTagTuple = tags[num];
				tags.RemoveAt(num);
				this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, tMPEffectTagTuple, num));
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
			tMPEffectTagTuple = tags[num];
			tags.RemoveAt(num);
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, tMPEffectTagTuple, num));
			return true;
		}

		public override bool RemoveAt(int startIndex, int? order = null)
		{
			int num = (order.HasValue ? BinarySearchIndexOf(new TempIndices(startIndex, order.Value)) : BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex)));
			if (num < 0)
			{
				return false;
			}
			TMPEffectTagTuple tMPEffectTagTuple = tags[num];
			tags.RemoveAt(num);
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, tMPEffectTagTuple, num));
			return true;
		}

		public override int RemoveAllAt(int startIndex, TMPEffectTagTuple[] buffer = null, int bufferIndex = 0)
		{
			List<TMPEffectTagTuple> list = new List<TMPEffectTagTuple>();
			int num = BinarySearchIndexFirstIndexOf(new StartIndexOnly(startIndex));
			if (num < 0)
			{
				return 0;
			}
			if (buffer != null)
			{
				int num2 = 0;
				int num3 = Mathf.Min(tags.Count, buffer.Length - bufferIndex);
				num2 = num;
				while (num2 < num3)
				{
					TMPEffectTagTuple tMPEffectTagTuple = tags[num2];
					if (tMPEffectTagTuple.Indices.StartIndex != startIndex)
					{
						break;
					}
					buffer[num2] = tMPEffectTagTuple;
					list.Add(tMPEffectTagTuple);
					tags.RemoveAt(num2);
				}
				while (num2 < tags.Count)
				{
					TMPEffectTagTuple item = tags[num2];
					if (item.Indices.StartIndex != startIndex)
					{
						break;
					}
					list.Add(item);
					tags.RemoveAt(num2);
				}
			}
			else
			{
				int num4 = num;
				while (num4 < tags.Count)
				{
					TMPEffectTagTuple item2 = tags[num4];
					if (item2.Indices.StartIndex != startIndex)
					{
						break;
					}
					list.Add(item2);
					tags.RemoveAt(num4);
				}
			}
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, list, num));
			return list.Count;
		}

		public override void Clear()
		{
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			tags.Clear();
		}
	}
}
