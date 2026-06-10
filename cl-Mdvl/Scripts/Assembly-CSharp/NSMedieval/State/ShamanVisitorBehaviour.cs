using NSMedieval.Goap;
using NSMedieval.Serialization;

namespace NSMedieval.State
{
	[FVSerializableKey("ShamanVisitorBehaviour", "")]
	public class ShamanVisitorBehaviour : RoleVisitorBehaviour
	{
		public override BehaviourType BehaviourType => BehaviourType.ShamanVisitor | base.BehaviourType;

		public ShamanVisitorBehaviour()
		{
		}

		protected override Agent CreateGoapAgent()
		{
			return new ShamanVisitorAgent(base.Humanoid);
		}

		protected override void OnBeforeFirstActivate()
		{
			base.OnBeforeFirstActivate();
			if (base.HumanoidRoleOwner.RoleInstance == null)
			{
				base.HumanoidRoleOwner.SetRole("shaman");
			}
		}

		public ShamanVisitorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
