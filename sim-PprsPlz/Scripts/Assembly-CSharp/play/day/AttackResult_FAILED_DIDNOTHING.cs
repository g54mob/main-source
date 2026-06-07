namespace play.day
{
	public sealed class AttackResult_FAILED_DIDNOTHING : AttackResult
	{
		public AttackResult_FAILED_DIDNOTHING()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
