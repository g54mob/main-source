using BehaviorDesigner.Runtime.Tasks;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTC
{
	[TaskCategory(" TH20/UI")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/GrabbedIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IsItemGrabbed : LevelConditional
	{
		[SerializeField]
		private SharedInstance<RoomItemDefinition> _itemDefinition;

		public override TaskStatus OnUpdate()
		{
			if (!base.Owner.Level.CursorManager.TryGetActiveMode<CursorRoomItem>(out var activeMode))
			{
				return TaskStatus.Failure;
			}
			if (activeMode.RoomItem == null)
			{
				return TaskStatus.Failure;
			}
			if (_itemDefinition.IsNull())
			{
				return TaskStatus.Success;
			}
			if (activeMode.RoomItem.Definition != _itemDefinition.Instance)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
