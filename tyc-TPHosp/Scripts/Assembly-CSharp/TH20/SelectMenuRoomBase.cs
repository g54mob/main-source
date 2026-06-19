using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuRoomBase : SelectMenuBase
	{
		protected Room _room;

		public virtual void Setup(Room room, Level level)
		{
			Setup((ICursorSelectable)room, level);
			_room = room;
		}
	}
}
