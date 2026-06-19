using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardRoomItemMetagame : IRewardMetagame
	{
		[SerializeField]
		private SharedInstance<RoomItemDefinition> _definition;

		public SharedInstance<RoomItemDefinition> Definition => _definition;

		public override void Apply(Metagame metagame)
		{
			if (!_definition.IsNull())
			{
				metagame.UnlockItem(_definition.Instance, spendSilver: false, showMessage: false);
				if (metagame.App.Level != null)
				{
					metagame.App.Level.BuildEvents.OnAddRoomItemDefinition(_definition.Instance, arg2: true, arg3: false, arg4: false);
				}
			}
		}

		public override string Description(Objective objective)
		{
			return _definition.Instance.GetLocalisedName();
		}

		public static RewardRoomItemMetagame Create(SharedInstance<RoomItemDefinition> roomItemDefinition)
		{
			return new RewardRoomItemMetagame
			{
				_definition = roomItemDefinition
			};
		}
	}
}
