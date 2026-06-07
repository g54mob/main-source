using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NBT.Tags
{
	public sealed class TagList : Tag, IList<Tag>, ICollection<Tag>, IEnumerable<Tag>, IEnumerable, IEquatable<TagList>
	{
		private List<Tag> value;

		private byte typeOfList;

		public override Tag Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public byte Type
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int Count => 0;

		public bool IsReadOnly => false;

		public override object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override byte tagID => 0;

		public TagList(byte idTagType)
		{
		}

		internal TagList(Stream stream)
		{
		}

		public void Add(Tag item)
		{
		}

		public void AddRange(IEnumerable<Tag> items)
		{
		}

		public IEnumerator<Tag> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Clear()
		{
		}

		public bool Contains(Tag item)
		{
			return false;
		}

		public void CopyTo(Tag[] array, int arrayIndex)
		{
		}

		public bool Remove(Tag item)
		{
			return false;
		}

		public int IndexOf(Tag item)
		{
			return 0;
		}

		public void Insert(int index, Tag item)
		{
		}

		public void InsertRange(int index, IEnumerable<Tag> items)
		{
		}

		public void Move(Tag item, int index)
		{
		}

		public void Move(int fromIndex, int toIndex)
		{
		}

		public void RemoveAt(int index)
		{
		}

		public void RemoveRange(int index, int count)
		{
		}

		public void Reverse()
		{
		}

		public void Reverse(int index, int count)
		{
		}

		public override string toString()
		{
			return null;
		}

		internal override void readTag(Stream stream)
		{
		}

		internal override void writeTag(Stream stream)
		{
		}

		public override object Clone()
		{
			return null;
		}

		public static TagList operator +(TagList list, Tag tag)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public string getNamedTypeOfList()
		{
			return null;
		}

		public bool Equals(TagList other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
