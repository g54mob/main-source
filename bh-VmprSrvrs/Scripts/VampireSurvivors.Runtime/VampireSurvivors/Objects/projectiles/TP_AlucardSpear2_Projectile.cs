using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AlucardSpear2_Projectile : TP_AlucardSpear1_Projectile
	{
		protected override string FrameName => null;

		protected override int AutoFlip => 0;

		protected override Vector2 ImageHalfSize => default(Vector2);
	}
}
