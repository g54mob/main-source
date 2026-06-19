using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetNextCharacterInQueue : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Next Character")]
		public SharedCharacterRef _nextCharacter;

		[Tooltip("Call into room?")]
		public bool _callIntoRoom = true;

		[Tooltip("Check patient can use room?")]
		public bool _checkCanUseRoom = true;

		public override void OnStart()
		{
			base.OnStart();
			_nextCharacter.Value = new CharacterRef(null);
		}

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				Room get = _room.Get;
				if (get.QueueLength != 0 && (!(base.Character is Staff staff) || staff.CanCallPeopleIntoRoom()))
				{
					Character frontOfQueue = get.GetFrontOfQueue();
					if (frontOfQueue != null && (!_checkCanUseRoom || (get.IsFunctional() && get.IsStaffed() && !get.IsAtMaxCapacity())))
					{
						_nextCharacter.Value = new CharacterRef(frontOfQueue);
						get.RemoveFromQueue(frontOfQueue);
						if (_callIntoRoom)
						{
							frontOfQueue.CalledIntoRoom = true;
							get.CharacterEntering = frontOfQueue;
						}
						return TaskStatus.Success;
					}
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}
	}
}
