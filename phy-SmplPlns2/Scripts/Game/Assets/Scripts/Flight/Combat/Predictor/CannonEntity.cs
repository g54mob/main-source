using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public class CannonEntity : PredictorEntity
	{
		public override void ResetSim(PartModifierScript weapon)
		{
			base.ResetSim(weapon);
			if (weapon is CannonScript cannonScript)
			{
				base.Velocity = cannonScript.PartScript.Body.RigidBody.GetPointVelocity(cannonScript.TipPosition);
				base.Velocity += cannonScript.transform.forward * cannonScript.ProjectileVelocity;
			}
		}
	}
}
