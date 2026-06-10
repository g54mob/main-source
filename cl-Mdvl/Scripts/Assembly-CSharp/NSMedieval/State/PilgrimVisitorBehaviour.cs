using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("PilgrimVisitorBehaviour", "")]
	public class PilgrimVisitorBehaviour : RoleVisitorBehaviour
	{
		protected override string CombatAiAgentId => "FriendlyNPCAgent";

		public override BehaviourType BehaviourType => BehaviourType.PilgrimVisitor | base.BehaviourType;

		public PilgrimVisitorBehaviour()
		{
		}

		protected override Agent CreateGoapAgent()
		{
			return new PilgrimVisitorAgent(base.Humanoid);
		}

		public PilgrimVisitorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
