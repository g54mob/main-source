using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Aggro.Core
{
	[Serializable]
	public class TagList : IEquatable<TagList>
	{
		[SerializeField]
		private List<Tag> _tags = new List<Tag>();

		[NonSerialized]
		private bool _isDirty = true;

		[NonSerialized]
		private TagMask _lastTagMask = TagMask.invalid;

		public bool IsEmpty()
		{
			for (int i = 0; i < _tags.Count; i++)
			{
				if (_tags[i].isValid)
				{
					return false;
				}
			}
			return true;
		}

		public TagMask GetTagMask(TagContext context)
		{
			if (_lastTagMask.context == context)
			{
				return _lastTagMask;
			}
			TagMask tagMask = new TagMask(context, 0);
			int count = _tags.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = _tags[i];
				if (tag.context == context)
				{
					tagMask |= tag.GetMask();
				}
			}
			_lastTagMask = tagMask;
			return tagMask;
		}

		public bool Has(Tag tag)
		{
			return HasAny(tag.GetMask());
		}

		public bool HasNone(TagMask mask)
		{
			return GetTagMask(mask.context).HasNone(mask);
		}

		public bool DoesNotHave(Tag tag)
		{
			return HasNone(tag.GetMask());
		}

		public bool HasAny(TagMask mask)
		{
			return GetTagMask(mask.context).HasAny(mask);
		}

		public bool HasAny(IList<Tag> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = list[i];
				if (tag.isValid && Has(tag))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAny(TagList list)
		{
			return HasAny(list._tags);
		}

		public bool HasAll(TagMask mask)
		{
			return GetTagMask(mask.context).HasAll(mask);
		}

		public bool HasAll(IList<Tag> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = list[i];
				if (tag.isValid && !Has(tag))
				{
					return false;
				}
			}
			return true;
		}

		public bool HasAll(TagList list)
		{
			return HasAll(list._tags);
		}

		public bool HasNone(IList<Tag> list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = list[i];
				if (tag.isValid && !DoesNotHave(tag))
				{
					return false;
				}
			}
			return true;
		}

		public bool HasNone(TagList list)
		{
			return HasNone(list._tags);
		}

		public void GetTags(List<Tag> tags)
		{
			tags.AddRangeNoGarbage(_tags);
		}

		public Tag[] GetTags()
		{
			return _tags.ToArray();
		}

		public void SetTags(IList<Tag> set)
		{
			SetDirty();
			_tags.Clear();
			int count = set.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = set[i];
				if (!Has(tag))
				{
					_tags.Add(tag);
					_lastTagMask = TagMask.invalid;
				}
			}
		}

		public void SetTags(TagList tags)
		{
			if (tags != null)
			{
				SetDirty();
				_tags.Clear();
				_tags.AddRangeNoGarbage(tags._tags);
				_lastTagMask = tags._lastTagMask;
			}
		}

		public void ClearTags()
		{
			_tags.Clear();
		}

		public void AddTag(Tag tag)
		{
			if (!Has(tag))
			{
				SetDirty();
				_tags.Add(tag);
			}
		}

		public void AddTags(TagList other)
		{
			int count = other._tags.Count;
			for (int i = 0; i < count; i++)
			{
				Tag tag = other._tags[i];
				if (!Has(tag))
				{
					SetDirty();
					_tags.Add(tag);
				}
			}
		}

		public void RemoveTag(Tag tag)
		{
			if (_tags.Remove(tag))
			{
				SetDirty();
			}
		}

		public void RemoveTags(TagList tags)
		{
			SetDirty();
			int count = tags._tags.Count;
			for (int i = 0; i < count; i++)
			{
				_tags.Remove(tags._tags[i]);
			}
		}

		public void Clear()
		{
			SetDirty();
			_tags.Clear();
		}

		public override string ToString()
		{
			CheckSort();
			string text = "";
			for (int i = 0; i < _tags.Count; i++)
			{
				if (i > 0)
				{
					text += ", ";
				}
				text += _tags[i].ToString();
			}
			return text;
		}

		public void CheckSort()
		{
			if (_isDirty)
			{
				_isDirty = false;
				_tags.Sort();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetDirty()
		{
			_isDirty = true;
			_lastTagMask = TagMask.invalid;
		}

		public bool Equals(TagList other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			int count = _tags.Count;
			int count2 = other._tags.Count;
			if (count != count2)
			{
				return false;
			}
			CheckSort();
			other.CheckSort();
			for (int i = 0; i < count; i++)
			{
				if (_tags[i] != other._tags[i])
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((TagList)obj);
		}

		public override int GetHashCode()
		{
			CheckSort();
			int count = _tags.Count;
			int num = count;
			for (int i = 0; i < count; i++)
			{
				num = HashCode.Combine(num, _tags[i].GetHashCode());
			}
			return num;
		}
	}
}
