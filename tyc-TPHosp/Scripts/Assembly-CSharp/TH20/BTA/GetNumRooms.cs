using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	public class GetNumRooms : GetNumBase
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_RoomDefinition _room;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			int numRooms = 0;
			base.Owner.Level.WorldState.IterateRoomsOfType((_room != null) ? _room.Instance : null, includeClosed: true, delegate
			{
				int num = numRooms + 1;
				numRooms = num;
			});
			if (!CompareValues(numRooms))
			{
				if (!_waitForSuccess)
				{
					return TaskStatus.Failure;
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
