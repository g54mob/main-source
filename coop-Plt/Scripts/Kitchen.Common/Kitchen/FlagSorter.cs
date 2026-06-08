namespace Kitchen
{
	public struct FlagSorter
	{
		public Priority Priority;

		public TransferFlags ProposalFlag;

		public TransferFlags AcceptFlag;

		private int SortIndex;

		public FlagSorter(TransferFlags proposal_flag, TransferFlags accept_flag)
		{
			Priority = 0;
			ProposalFlag = proposal_flag;
			AcceptFlag = accept_flag;
			SortIndex = 30;
		}

		public bool Sort(TransferFlags target)
		{
			return Sort(ProposalFlag, target);
		}

		public bool SortReversed(TransferFlags target)
		{
			return SortReversed(ProposalFlag, target);
		}

		public bool SortAccept(TransferFlags target)
		{
			return Sort(AcceptFlag, target);
		}

		public bool SortAcceptReversed(TransferFlags target)
		{
			return SortReversed(AcceptFlag, target);
		}

		public bool SortEither(TransferFlags target)
		{
			return Sort(AcceptFlag | ProposalFlag, target);
		}

		public bool SortEitherReversed(TransferFlags target)
		{
			return SortReversed(AcceptFlag | ProposalFlag, target);
		}

		public bool Sort(TransferFlags flag_set, TransferFlags target_flag)
		{
			bool flag = (flag_set & target_flag) == target_flag;
			Priority = (flag ? Priority.AddPriority(SortIndex) : Priority.RemovePriority(SortIndex));
			SortIndex--;
			return flag;
		}

		public bool SortReversed(TransferFlags flag_set, TransferFlags target_flag)
		{
			bool flag = (flag_set & target_flag) != target_flag;
			Priority = (flag ? Priority.AddPriority(SortIndex) : Priority.RemovePriority(SortIndex));
			SortIndex--;
			return !flag;
		}

		public static implicit operator int(FlagSorter p)
		{
			return p.Priority.Value;
		}
	}
}
