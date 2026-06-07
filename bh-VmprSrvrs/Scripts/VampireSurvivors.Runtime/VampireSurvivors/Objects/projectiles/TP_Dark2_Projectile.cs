using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Dark2_Projectile : TP_Light1_Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private int _gravityFrameCounter;

		public override float BodyRadius => 0f;

		public override float Scale => 0f;

		public override float Depth => 0f;

		public override bool HasOrbiters => false;

		public override int InvertMotion => 0;

		public override void MakeSpriteAnimation()
		{
		}

		protected override void InitAlpha()
		{
		}

		protected override void PlayFiringSfx()
		{
		}

		public void createGravityWell(float2 pos, float radius)
		{
		}
	}
}
