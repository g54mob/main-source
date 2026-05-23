namespace play.day
{
	public sealed class AttackResult_NONE : AttackResult
	{
		public AttackResult_NONE()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
