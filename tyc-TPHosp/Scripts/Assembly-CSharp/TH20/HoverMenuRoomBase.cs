using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuRoomBase : HoverMenuBase
	{
		protected Room _room;

		public virtual void Setup(Room room, Level level)
		{
			_room = room;
			Setup((ICursorSelectable)room, level);
		}
	}
}
