using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/UnlockIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AddRoomDefinition : ExpiringLevelAction
	{
		[SerializeField]
		private SharedInstance_TH20TH20_RoomDefinition[] _rooms;

		[SerializeField]
		private bool _unlockItem = true;

		[SerializeField]
		private bool _showAdvisorMessage = true;

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
				buildEvents.OnAddRoomDefinition.InvokeSafe(sharedInstance_TH20TH20_RoomDefinition.Instance, _unlockItem, param3: false, _showAdvisorMessage);
			}
			return TaskStatus.Success;
		}
	}
}
