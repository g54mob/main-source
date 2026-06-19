using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuRoomItemBase : SelectMenuBase
	{
		protected RoomItem _roomItem;

		public virtual void Setup(RoomItem roomItem, Level level)
		{
			Setup((ICursorSelectable)roomItem, level);
			_roomItem = roomItem;
		}
	}
}
