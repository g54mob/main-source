using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StatusIconInvalidItem : StatusIcon
	{
		private RoomItem _item;

		public bool MessageSent { get; private set; }

		public override void Initialise(IStatusIconEmitter emitter, Level level, int priority)
		{
			base.Initialise(emitter, level, priority);
			_item = emitter as RoomItem;
		}

		private void Update()
		{
			if (base.HasTimedOut() && !MessageSent)
			{
				MessageSent = true;
				_level.BuildEvents.OnRoomItemInvalid.InvokeSafe(_item);
			}
		}

		public override bool HasTimedOut()
		{
			if (_item == null || _item.IsValid || _item.FloorPlan is BlueprintFloorPlan)
			{
				MessageSent = false;
				return true;
			}
			return false;
		}
	}
}
