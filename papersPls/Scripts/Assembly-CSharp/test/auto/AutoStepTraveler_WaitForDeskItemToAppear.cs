namespace test.auto
{
	public sealed class AutoStepTraveler_WaitForDeskItemToAppear : AutoStepTraveler
	{
		public readonly string deskItemId;

		public AutoStepTraveler_WaitForDeskItemToAppear(string deskItemId)
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
