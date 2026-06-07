using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_ShaftOrb_Projectile : TP_Light1_Projectile
	{
		private List<SfxType> _sfx;

		public override bool HasOrbiters => false;

		public override int InvertMotion => 0;

		public override void MakeSpriteAnimation()
		{
		}

		protected override void PlayFiringSfx()
		{
		}
	}
}
