using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	public class SpriteAnims
	{
		[Title("Melee Attack")]
		public MeleeAttack meleeAttack { get; set; }

		[Title("Melee Attack 2")]
		public MeleeAttack meleeAttack2 { get; set; }

		[Title("Ranged Attack")]
		public MeleeAttack rangedAttack { get; set; }

		[Title("Magic Attack")]
		public MeleeAttack magicAttack { get; set; }

		[Title("Special Animation")]
		public MeleeAttack specialAnimation { get; set; }

		[Title("Idle Animation")]
		public MeleeAttack idleAnimation { get; set; }
	}
}
