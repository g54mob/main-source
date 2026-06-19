using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class RemoveRoomDefinition : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_RoomDefinition[] _rooms;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			BuildEvents buildEvents = base.Owner.Level.BuildEvents;
			SharedInstance_TH20TH20_RoomDefinition[] rooms = _rooms;
			foreach (SharedInstance_TH20TH20_RoomDefinition sharedInstance_TH20TH20_RoomDefinition in rooms)
			{
				buildEvents.OnRemoveRoomDefinition.InvokeSafe(sharedInstance_TH20TH20_RoomDefinition.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
