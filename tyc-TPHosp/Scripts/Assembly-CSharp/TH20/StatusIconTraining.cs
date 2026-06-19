using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconTraining : StatusIcon
	{
		private Staff _staff;

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_staff = emitter as Staff;
		}

		public override bool HasTimedOut()
		{
			if (_staff == null)
			{
				return true;
			}
			if (_staff.CurrentMode != Staff.Mode.Training && _staff.CurrentMode != Staff.Mode.Trained)
			{
				return true;
			}
			if (_staff.RoomUsing != null && _staff.RoomUsing.Definition._type == RoomDefinition.Type.Training)
			{
				return true;
			}
			return false;
		}
	}
}
