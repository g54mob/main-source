namespace ScriptHelpers
{
	public readonly struct NodeChanges
	{
		public readonly int Position;

		public readonly int Amount;

		public NodeChanges(int pos, int amount)
		{
			Position = pos;
			Amount = amount;
		}
	}
}
