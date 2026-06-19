using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasResearchProject : Conditional
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		public override TaskStatus OnUpdate()
		{
			bool valid = false;
			if (_room.IsValid())
			{
				RoomAlgorithms.IterateRoomItemsWithComponent(_room.Get, delegate(ResearchProjectComponent component)
				{
					if (component.Project != null)
					{
						valid = true;
					}
				});
			}
			if (!valid)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
