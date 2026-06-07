using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct DictionaryReplaceEvent<TKey, TValue>
	{
		public TKey Key { get; init; }

		public TValue OldValue { get; init; }

		public TValue NewValue { get; init; }

		public DictionaryReplaceEvent(TKey Key, TValue OldValue, TValue NewValue)
		{
			this.Key = Key;
			this.OldValue = OldValue;
			this.NewValue = NewValue;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DictionaryReplaceEvent");
			stringBuilder.Append(" { ");
			if (PrintMembers(stringBuilder))
			{
				stringBuilder.Append(' ');
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		[CompilerGenerated]
		private bool PrintMembers(StringBuilder builder)
		{
			builder.Append("Key = ");
			builder.Append(Key);
			builder.Append(", OldValue = ");
			builder.Append(OldValue);
			builder.Append(", NewValue = ");
			builder.Append(NewValue);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(DictionaryReplaceEvent<TKey, TValue> left, DictionaryReplaceEvent<TKey, TValue> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(DictionaryReplaceEvent<TKey, TValue> left, DictionaryReplaceEvent<TKey, TValue> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return (EqualityComparer<TKey>.Default.GetHashCode(Key) * -1521134295 + EqualityComparer<TValue>.Default.GetHashCode(OldValue)) * -1521134295 + EqualityComparer<TValue>.Default.GetHashCode(NewValue);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is DictionaryReplaceEvent<TKey, TValue>)
			{
				return Equals((DictionaryReplaceEvent<TKey, TValue>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(DictionaryReplaceEvent<TKey, TValue> other)
		{
			if (EqualityComparer<TKey>.Default.Equals(Key, other.Key) && EqualityComparer<TValue>.Default.Equals(OldValue, other.OldValue))
			{
				return EqualityComparer<TValue>.Default.Equals(NewValue, other.NewValue);
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out TKey Key, out TValue OldValue, out TValue NewValue)
		{
			Key = this.Key;
			OldValue = this.OldValue;
			NewValue = this.NewValue;
		}
	}
}
