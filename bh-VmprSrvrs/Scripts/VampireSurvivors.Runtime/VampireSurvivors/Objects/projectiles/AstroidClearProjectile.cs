using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class AstroidClearProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _baseSpriteRenderer;

		[SerializeField]
		private SpriteRenderer _ringRenderer;

		[SerializeField]
		private SpriteRenderer _rainbowRenderer;

		[SerializeField]
		private SpriteRenderer _raysRenderer;

		private MultiTargetTween _ttween6;

		private MultiTargetTween _ttween5;

		private MultiTargetTween _ttween3;

		private MultiTargetTween _ttween4;

		private MultiTargetTween _ttween4Alpha;

		private MultiTargetTween _ttween2;

		private MultiTargetTween _ttween1;

		private AstroidClearWeapon _trueWeapon;

		private bool _alreadyRecycled;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Detonate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
