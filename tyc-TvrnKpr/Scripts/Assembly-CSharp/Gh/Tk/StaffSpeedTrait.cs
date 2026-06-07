namespace Gh.Tk
{
	public abstract class StaffSpeedTrait : StaffTrait
	{
		protected float _workSpeedModifier;

		protected float _moveSpeedModifier;

		protected StaffSpeedTrait(float workSpeedModifier, float moveSpeedModifier)
		{
		}

		protected StaffSpeedTrait(Staff owner, float workSpeedModifier, float moveSpeedModifier)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
