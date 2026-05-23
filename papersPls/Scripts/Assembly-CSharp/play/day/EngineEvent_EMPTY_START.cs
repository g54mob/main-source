namespace play.day
{
	public sealed class EngineEvent_EMPTY_START : EngineEvent
	{
		public EngineEvent_EMPTY_START()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
