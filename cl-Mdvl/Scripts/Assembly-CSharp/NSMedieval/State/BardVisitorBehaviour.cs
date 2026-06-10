using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("BardVisitorBehaviour", "")]
	public class BardVisitorBehaviour : RoleVisitorBehaviour
	{
		public override BehaviourType BehaviourType => BehaviourType.BardVisitor | base.BehaviourType;

		public BardVisitorBehaviour()
		{
		}

		protected override Agent CreateGoapAgent()
		{
			return new BardVisitorAgent(base.Humanoid);
		}

		protected override void OnBeforeFirstActivate()
		{
			base.OnBeforeFirstActivate();
			if (base.HumanoidRoleOwner.RoleInstance == null)
			{
				base.HumanoidRoleOwner.SetRole("bard");
			}
		}

		public BardVisitorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
