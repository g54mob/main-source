using data;

namespace test.auto
{
	public sealed class AutoStepTraveler_StampSequence : AutoStepTraveler
	{
		public readonly string deskItemId;

		public readonly StampApprovalKind approvalKind;

		public AutoStepTraveler_StampSequence(string deskItemId, StampApprovalKind approvalKind)
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
