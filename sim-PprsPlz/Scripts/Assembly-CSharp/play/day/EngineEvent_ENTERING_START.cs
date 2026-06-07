namespace play.day
{
	public sealed class EngineEvent_ENTERING_START : EngineEvent
	{
		public readonly bool before6PM;

		public EngineEvent_ENTERING_START(bool before6PM)
			: base(0)
		{
		}

		public override Array getParams()
		{
			return null;
		}

		public override string getTag()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object other)
		{
			return false;
		}

		public override string toString()
		{
			return null;
		}
	}
}
