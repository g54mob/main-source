using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ObservableCollections
{
	[StructLayout(LayoutKind.Auto)]
	public readonly struct CollectionChangedEvent<T>
	{
		public readonly NotifyCollectionChangedAction Action;

		public readonly T NewItem;

		public readonly T OldItem;

		public readonly int NewStartingIndex;

		public readonly int OldStartingIndex;

		public readonly SortOperation<T> SortOperation;

		public CollectionChangedEvent(NotifyCollectionChangedAction action, T newItem, T oldItem, int newStartingIndex, int oldStartingIndex, SortOperation<T> sortOperation)
		{
			Action = action;
			NewItem = newItem;
			OldItem = oldItem;
			NewStartingIndex = newStartingIndex;
			OldStartingIndex = oldStartingIndex;
			SortOperation = sortOperation;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("CollectionChangedEvent");
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
			builder.Append("Action = ");
			builder.Append(Action.ToString());
			builder.Append(", NewItem = ");
			builder.Append(NewItem);
			builder.Append(", OldItem = ");
			builder.Append(OldItem);
			builder.Append(", NewStartingIndex = ");
			builder.Append(NewStartingIndex.ToString());
			builder.Append(", OldStartingIndex = ");
			builder.Append(OldStartingIndex.ToString());
			builder.Append(", SortOperation = ");
			builder.Append(SortOperation.ToString());
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(CollectionChangedEvent<T> left, CollectionChangedEvent<T> right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(CollectionChangedEvent<T> left, CollectionChangedEvent<T> right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return ((((EqualityComparer<NotifyCollectionChangedAction>.Default.GetHashCode(Action) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(NewItem)) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(OldItem)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(NewStartingIndex)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(OldStartingIndex)) * -1521134295 + EqualityComparer<SortOperation<T>>.Default.GetHashCode(SortOperation);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is CollectionChangedEvent<T>)
			{
				return Equals((CollectionChangedEvent<T>)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(CollectionChangedEvent<T> other)
		{
			if (EqualityComparer<NotifyCollectionChangedAction>.Default.Equals(Action, other.Action) && EqualityComparer<T>.Default.Equals(NewItem, other.NewItem) && EqualityComparer<T>.Default.Equals(OldItem, other.OldItem) && EqualityComparer<int>.Default.Equals(NewStartingIndex, other.NewStartingIndex) && EqualityComparer<int>.Default.Equals(OldStartingIndex, other.OldStartingIndex))
			{
				return EqualityComparer<SortOperation<T>>.Default.Equals(SortOperation, other.SortOperation);
			}
			return false;
		}
	}
}
