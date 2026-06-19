using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetRoom : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Type of room to find")]
		public RoomDefinition.Type _roomType;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Room")]
		public SharedRoomRef _room;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Should we start waiting for this room type?")]
		[SerializeField]
		private bool _shouldWait;

		[SerializeField]
		private float _waitTime;

		public override TaskStatus OnUpdate()
		{
			Room bestRoomOfType = GameAlgorithms.GetBestRoomOfType(base.Character.Level.WorldState, _roomType, RoomUseType.Any, base.Character);
			if (bestRoomOfType != null)
			{
				_room.Value = new RoomRef(bestRoomOfType);
				return TaskStatus.Success;
			}
			if (_shouldWait && base.Character.GetComponent<WaitForRoomToBeBuiltComponent>() == null)
			{
				base.Character.AddComponent<WaitForRoomToBeBuiltComponent>().Initialise(new List<RoomDefinition.Type> { _roomType }, _waitTime);
			}
			_room.Value = null;
			return TaskStatus.Failure;
		}
	}
}
