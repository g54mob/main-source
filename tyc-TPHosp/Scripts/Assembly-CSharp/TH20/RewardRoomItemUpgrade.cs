using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardRoomItemUpgrade : IRewardMetagame
	{
		[SerializeField]
		private SharedInstance<RoomItemUpgradeDefinition> _definition;

		public SharedInstance<RoomItemUpgradeDefinition> Definition => _definition;

		public override void Apply(Metagame metagame)
		{
			metagame.UnlockItem(_definition.Instance, spendSilver: false, showMessage: true);
		}

		public override string Description(Objective objective)
		{
			return _definition.Instance.LocalisedName.Translation;
		}
	}
}
