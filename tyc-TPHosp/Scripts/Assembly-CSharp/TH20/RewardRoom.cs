using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardRoom : IReward
	{
		[SerializeField]
		private SharedInstance<RoomDefinition> _definition;

		public SharedInstance<RoomDefinition> Definition => _definition;

		public void Apply(Objective objective, Level level)
		{
			level.BuildEvents.OnAddRoomDefinition.InvokeSafe(_definition.Instance, param2: true, param3: false, param4: true);
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
