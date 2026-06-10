using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("BlankBehaviour", "BlankBehavior")]
	public class BlankBehaviour : HumanoidBehaviour
	{
		protected override string HumanTypeId => "enemy";

		public override BehaviourType BehaviourType => BehaviourType.Blank;

		public BlankBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelFriendly);
			base.Humanoid.SetCombatAiAgent("BlankNPCAgent");
		}

		protected override Agent CreateGoapAgent()
		{
			return new NPCBlankGoapAgent(base.Humanoid);
		}

		public override string GetMultiselectName()
		{
			return "blank";
		}

		public override string GetGoapAgentId()
		{
			return "enemy";
		}

		public override void Serialize(FVSerializer serializer)
		{
		}

		public BlankBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
