using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct DictionaryRemoveEvent<TKey, TValue>
	{
		public TKey Key { get; init; }

		public TValue Value { get; init; }

		public DictionaryRemoveEvent(TKey Key, TValue Value)
		{
			this.Key = Key;
			this.Value = Value;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("DictionaryRemoveEvent");
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
			builder.Append(", Value = ");
			builder.Append(Value);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(DictionaryRemoveEvent<TKey, TValue> left, DictionaryRemoveEvent<TKey, TValue> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(DictionaryRemoveEvent<TKey, TValue> left, DictionaryRemoveEvent<TKey, TValue> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return EqualityComparer<TKey>.Default.GetHashCode(Key) * -1521134295 + EqualityComparer<TValue>.Default.GetHashCode(Value);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is DictionaryRemoveEvent<TKey, TValue>)
			{
				return Equals((DictionaryRemoveEvent<TKey, TValue>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(DictionaryRemoveEvent<TKey, TValue> other)
		{
			if (EqualityComparer<TKey>.Default.Equals(Key, other.Key))
			{
				return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out TKey Key, out TValue Value)
		{
			Key = this.Key;
			Value = this.Value;
		}
	}
}
