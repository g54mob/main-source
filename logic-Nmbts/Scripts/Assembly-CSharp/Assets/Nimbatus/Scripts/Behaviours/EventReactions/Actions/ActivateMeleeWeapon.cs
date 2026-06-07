using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Weapons;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ActivateMeleeWeapon : NimbatusAction
	{
		public List<EnemyMeleeWeapon> MeleeWeapons = new List<EnemyMeleeWeapon>();

		public bool Activate;

		public override void Execute()
		{
			MeleeWeapons.ForEach(delegate(EnemyMeleeWeapon w)
			{
				w.Init(Activate, OwnWorldObject);
			});
		}
	}
}
