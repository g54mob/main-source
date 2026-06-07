using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class NovaProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _displaySprite;

		private float _displaySpritePxSize;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private float SelfRadius;

		private Transform _cachedSpriteTransform;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetNovaTint(uint tintValue)
		{
		}

		public void SetBaseRadius(float value)
		{
		}
	}
}
