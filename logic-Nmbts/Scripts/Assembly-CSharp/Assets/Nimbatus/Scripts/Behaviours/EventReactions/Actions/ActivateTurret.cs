using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ActivateTurret : NimbatusAction
	{
		public List<RotatingTurret> Turrets = new List<RotatingTurret>();

		public bool Activate;

		public override void Execute()
		{
			Turrets.ForEach(delegate(RotatingTurret t)
			{
				t.ActivateTurret(Activate);
			});
		}
	}
}
