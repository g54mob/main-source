using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct CollectionMoveEvent<T>
	{
		public int OldIndex { get; init; }

		public int NewIndex { get; init; }

		public T Value { get; init; }

		public CollectionMoveEvent(int OldIndex, int NewIndex, T Value)
		{
			this.OldIndex = OldIndex;
			this.NewIndex = NewIndex;
			this.Value = Value;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CollectionMoveEvent");
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
			builder.Append("OldIndex = ");
			builder.Append(OldIndex.ToString());
			builder.Append(", NewIndex = ");
			builder.Append(NewIndex.ToString());
			builder.Append(", Value = ");
			builder.Append(Value);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(CollectionMoveEvent<T> left, CollectionMoveEvent<T> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(CollectionMoveEvent<T> left, CollectionMoveEvent<T> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return (EqualityComparer<int>.Default.GetHashCode(OldIndex) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(NewIndex)) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is CollectionMoveEvent<T>)
			{
				return Equals((CollectionMoveEvent<T>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(CollectionMoveEvent<T> other)
		{
			if (EqualityComparer<int>.Default.Equals(OldIndex, other.OldIndex) && EqualityComparer<int>.Default.Equals(NewIndex, other.NewIndex))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out int OldIndex, out int NewIndex, out T Value)
		{
			OldIndex = this.OldIndex;
			NewIndex = this.NewIndex;
			Value = this.Value;
		}
	}
}
