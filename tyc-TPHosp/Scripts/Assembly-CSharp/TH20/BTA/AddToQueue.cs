using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AddToQueue : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("The index this character wants to join the queue at")]
		public SharedInt _queueIndex;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				Room get = _room.Get;
				if (!get.Definition.IsHospitalOrBay)
				{
					get.AddToQueue(base.Character, _queueIndex.Value);
				}
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
