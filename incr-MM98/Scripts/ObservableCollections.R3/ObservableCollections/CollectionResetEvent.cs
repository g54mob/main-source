using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ObservableCollections
{
	public readonly struct CollectionResetEvent<T>
	{
		private readonly SortOperation<T> sortOperation;

		public bool IsClear => sortOperation.IsClear;

		public bool IsSort => sortOperation.IsSort;

		public bool IsReverse => sortOperation.IsReverse;

		public int Index => sortOperation.Index;

		public int Count => sortOperation.Count;

		public IComparer<T>? Comparer => sortOperation.Comparer;

		public CollectionResetEvent(SortOperation<T> sortOperation)
		{
			this.sortOperation = sortOperation;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CollectionResetEvent");
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
			builder.Append("IsClear = ");
			builder.Append(IsClear.ToString());
			builder.Append(", IsSort = ");
			builder.Append(IsSort.ToString());
			builder.Append(", IsReverse = ");
			builder.Append(IsReverse.ToString());
			builder.Append(", Index = ");
			builder.Append(Index.ToString());
			builder.Append(", Count = ");
			builder.Append(Count.ToString());
			builder.Append(", Comparer = ");
			builder.Append(Comparer);
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(CollectionResetEvent<T> left, CollectionResetEvent<T> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(CollectionResetEvent<T> left, CollectionResetEvent<T> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return EqualityComparer<SortOperation<T>>.Default.GetHashCode(sortOperation);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is CollectionResetEvent<T>)
			{
				return Equals((CollectionResetEvent<T>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(CollectionResetEvent<T> other)
		{
			return EqualityComparer<SortOperation<T>>.Default.Equals(sortOperation, other.sortOperation);
		}
	}
}
