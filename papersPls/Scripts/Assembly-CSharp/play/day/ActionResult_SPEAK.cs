namespace play.day
{
	public sealed class ActionResult_SPEAK : ActionResult
	{
		public readonly string text;

		public readonly bool fromTraveler;

		public readonly bool pauseAfter;

		public ActionResult_SPEAK(string text, bool fromTraveler, bool pauseAfter)
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
