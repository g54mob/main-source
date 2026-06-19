using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/ObjectiveIconUnlock.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasUnlocked : LevelConditional
	{
		[SerializeField]
		private SharedInstance_TH20TH20_RoomDefinition _room;

		[SerializeField]
		private SharedInstance_TH20TH20_RoomItemDefinition _item;

		[SerializeField]
		private SharedInstance_TH20TH20_RoomItemUpgradeDefinition _upgrade;

		public override TaskStatus OnUpdate()
		{
			Metagame metagame = base.Owner.Level.Metagame;
			if (_room.NotNull() && metagame.HasUnlocked(_room.Instance))
			{
				return TaskStatus.Success;
			}
			if (_item.NotNull() && metagame.HasUnlocked(_item.Instance))
			{
				return TaskStatus.Success;
			}
			if (_upgrade.NotNull() && metagame.HasUnlocked(_upgrade.Instance))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
