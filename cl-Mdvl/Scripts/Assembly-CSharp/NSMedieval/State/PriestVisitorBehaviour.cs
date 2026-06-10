using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("PriestVisitorBehaviour", "")]
	public class PriestVisitorBehaviour : RoleVisitorBehaviour
	{
		public override BehaviourType BehaviourType => BehaviourType.PriestVisitor | base.BehaviourType;

		public PriestVisitorBehaviour()
		{
		}

		protected override Agent CreateGoapAgent()
		{
			return new PriestVisitorAgent(base.Humanoid);
		}

		protected override void OnBeforeFirstActivate()
		{
			base.OnBeforeFirstActivate();
			if (base.HumanoidRoleOwner.RoleInstance == null)
			{
				base.HumanoidRoleOwner.SetRole("priest");
			}
		}

		public PriestVisitorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
