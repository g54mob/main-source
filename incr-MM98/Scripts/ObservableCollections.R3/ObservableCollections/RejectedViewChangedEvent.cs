using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ObservableCollections
{
	[StructLayout(LayoutKind.Auto)]
	public readonly struct RejectedViewChangedEvent
	{
		public readonly RejectedViewChangedAction Action;

		public readonly int NewIndex;

		public readonly int OldIndex;

		public RejectedViewChangedEvent(RejectedViewChangedAction action, int newIndex, int oldIndex)
		{
			Action = action;
			NewIndex = newIndex;
			OldIndex = oldIndex;
		}

		[CompilerGenerated]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("RejectedViewChangedEvent");
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
			builder.Append(", NewIndex = ");
			builder.Append(NewIndex.ToString());
			builder.Append(", OldIndex = ");
			builder.Append(OldIndex.ToString());
			return true;
		}

		[CompilerGenerated]
		public static bool operator !=(RejectedViewChangedEvent left, RejectedViewChangedEvent right)
		{
			return !(left == right);
		}

		[CompilerGenerated]
		public static bool operator ==(RejectedViewChangedEvent left, RejectedViewChangedEvent right)
		{
			return left.Equals(right);
		}

		[CompilerGenerated]
		public override int GetHashCode()
		{
			return (EqualityComparer<RejectedViewChangedAction>.Default.GetHashCode(Action) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(NewIndex)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(OldIndex);
		}

		[CompilerGenerated]
		public override bool Equals(object obj)
		{
			if (obj is RejectedViewChangedEvent)
			{
				return Equals((RejectedViewChangedEvent)obj);
			}
			return false;
		}

		[CompilerGenerated]
		public bool Equals(RejectedViewChangedEvent other)
		{
			if (EqualityComparer<RejectedViewChangedAction>.Default.Equals(Action, other.Action) && EqualityComparer<int>.Default.Equals(NewIndex, other.NewIndex))
			{
				return EqualityComparer<int>.Default.Equals(OldIndex, other.OldIndex);
			}
			return false;
		}
	}
}
