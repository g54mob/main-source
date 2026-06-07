using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class IsShieldActive : NimbatusCondition
	{
		public override bool IsTrue()
		{
			ShieldBehaviour coreBehaviour = OwnWorldObject.Behaviour.GetCoreBehaviour<ShieldBehaviour>();
			if (coreBehaviour != null)
			{
				return coreBehaviour.IsActive;
			}
			return false;
		}
	}
}
