using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct CollectionReplaceEvent<T>
	{
		public int Index { get; init; }

		public T OldValue { get; init; }

		public T NewValue { get; init; }

		public CollectionReplaceEvent(int Index, T OldValue, T NewValue)
		{
			this.Index = Index;
			this.OldValue = OldValue;
			this.NewValue = NewValue;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CollectionReplaceEvent");
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
			builder.Append("Index = ");
			builder.Append(Index.ToString());
			builder.Append(", OldValue = ");
			builder.Append(OldValue);
			builder.Append(", NewValue = ");
			builder.Append(NewValue);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(CollectionReplaceEvent<T> left, CollectionReplaceEvent<T> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(CollectionReplaceEvent<T> left, CollectionReplaceEvent<T> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return (EqualityComparer<int>.Default.GetHashCode(Index) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(OldValue)) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(NewValue);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is CollectionReplaceEvent<T>)
			{
				return Equals((CollectionReplaceEvent<T>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(CollectionReplaceEvent<T> other)
		{
			if (EqualityComparer<int>.Default.Equals(Index, other.Index) && EqualityComparer<T>.Default.Equals(OldValue, other.OldValue))
			{
				return EqualityComparer<T>.Default.Equals(NewValue, other.NewValue);
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out int Index, out T OldValue, out T NewValue)
		{
			Index = this.Index;
			OldValue = this.OldValue;
			NewValue = this.NewValue;
		}
	}
}
