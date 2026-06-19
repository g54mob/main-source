using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardRoomItem : IReward
	{
		[SerializeField]
		private SharedInstance<RoomItemDefinition> _definition;

		public SharedInstance<RoomItemDefinition> Definition => _definition;

		public void Apply(Objective objective, Level level)
		{
			level.BuildEvents.OnAddRoomItemDefinition.InvokeSafe(_definition.Instance, param2: true, param3: false, param4: true);
		}

		public string Description(Objective objective)
		{
			if (objective is LevelObjective levelObjective && levelObjective.Level.Metagame.HasUnlocked(_definition.Instance))
			{
				return string.Empty;
			}
			return _definition.Instance.GetLocalisedName();
		}
	}
}
