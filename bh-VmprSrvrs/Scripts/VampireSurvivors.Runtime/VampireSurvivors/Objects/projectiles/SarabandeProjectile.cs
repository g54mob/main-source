using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SarabandeProjectile : Projectile
	{
		private Tween _alphaTween;

		private Tween _scaleTween;

		private Transform _cachedOwnerTransform;

		private float _radius;

		private float _standardPxSize;

		private PhaserSprite _juliaSprite;

		private Transform _juliaTransform;

		private List<string> _doilies;

		private SarabandeWeapon _trueWeapon;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void NormalAttack()
		{
		}

		public void JuliaAttack()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
