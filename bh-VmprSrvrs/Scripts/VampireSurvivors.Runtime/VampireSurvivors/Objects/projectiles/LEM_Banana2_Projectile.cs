using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Banana2_Projectile : LEM_Banana1_Projectile
	{
		protected override float Radius => 0f;

		protected override SpriteTextureData BananaSprite => default(SpriteTextureData);

		protected override SpriteTextureData TrailSprite => default(SpriteTextureData);

		protected override float BananaSpriteScale => 0f;

		protected override float LaunchAngleOffset => 0f;

		protected override void AimInDirection(Vector2 playerDir)
		{
		}

		protected override void PlayThrowSfx()
		{
		}
	}
}
