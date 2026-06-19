using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetNextInQueue : CharacterAction
	{
		[Tooltip("Item")]
		public SharedItemRef _item;

		[Tooltip("Next in queue")]
		public SharedCharacterRef _nextInQueue;

		public override void OnStart()
		{
			base.OnStart();
			_nextInQueue.Value = new CharacterRef(null);
		}

		public override TaskStatus OnUpdate()
		{
			if (_item.IsValid())
			{
				RoomItem get = _item.Get;
				if (!get.HasBeenDestroyed())
				{
					foreach (ObjectInteraction interaction in get.Interactions)
					{
						Character interactor = interaction.Interactor;
						if (interactor != null && interactor != base.Character)
						{
							_nextInQueue.Value = new CharacterRef(interactor);
							return TaskStatus.Success;
						}
					}
					return TaskStatus.Running;
				}
			}
			return TaskStatus.Failure;
		}
	}
}
