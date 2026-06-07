using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct CollectionAddEvent<T>
	{
		public int Index { get; init; }

		public T Value { get; init; }

		public CollectionAddEvent(int Index, T Value)
		{
			this.Index = Index;
			this.Value = Value;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CollectionAddEvent");
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
			builder.Append(", Value = ");
			builder.Append(Value);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(CollectionAddEvent<T> left, CollectionAddEvent<T> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(CollectionAddEvent<T> left, CollectionAddEvent<T> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return EqualityComparer<int>.Default.GetHashCode(Index) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is CollectionAddEvent<T>)
			{
				return Equals((CollectionAddEvent<T>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(CollectionAddEvent<T> other)
		{
			if (EqualityComparer<int>.Default.Equals(Index, other.Index))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}

		[CompilerGenerated]
		public void Deconstruct(out int Index, out T Value)
		{
			Index = this.Index;
			Value = this.Value;
		}
	}
}
