namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Light2_Projectile : TP_Light1_Projectile
	{
		public override float BodyRadius => 0f;

		public override float Scale => 0f;

		public override bool HasOrbiters => false;

		public override int InvertMotion => 0;

		protected override void InitAlpha()
		{
		}

		public override void MakeSpriteAnimation()
		{
		}

		protected override void PlayFiringSfx()
		{
		}
	}
}
