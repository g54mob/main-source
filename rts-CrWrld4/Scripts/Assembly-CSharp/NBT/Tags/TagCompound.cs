using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using mattmc3.dotmore.Collections.Generic;

namespace NBT.Tags
{
	public sealed class TagCompound : Tag, IEnumerable<KeyValuePair<string, Tag>>, IEnumerable, IEquatable<TagCompound>
	{
		private OrderedDictionary2<string, Tag> value;

		public override byte tagID => 0;

		public int Count => 0;

		public ICollection<Tag> Values => null;

		public ICollection<string> Keys => null;

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

		public TagCompound()
		{
		}

		internal TagCompound(Stream stream)
		{
		}

		public TagCompound(IEnumerable<KeyValuePair<string, Tag>> values)
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

		public IEnumerator<KeyValuePair<string, Tag>> GetEnumerator()
		{
			return null;
		}

		public override object Clone()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Add(string key, Tag value)
		{
		}

		public void AddRange(IEnumerable<KeyValuePair<string, Tag>> items)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(string key)
		{
			return false;
		}

		public bool Remove(string key)
		{
			return false;
		}

		public void Rename(string oldKeyName, string newKeyName)
		{
		}

		public Tag TryGet(string key, Tag defaultValue)
		{
			return null;
		}

		public static explicit operator TagCompound(Dictionary<string, Tag> value)
		{
			return null;
		}

		public override Type getType()
		{
			return null;
		}

		public bool Equals(TagCompound other)
		{
			return false;
		}

		public override bool Equals(Tag other)
		{
			return false;
		}
	}
}
