namespace play.day
{
	public sealed class ActionResult_NONE : ActionResult
	{
		public ActionResult_NONE()
			: base(0)
		{
		}

		public override string getTag()
		{
			return null;
		}
	}
}
