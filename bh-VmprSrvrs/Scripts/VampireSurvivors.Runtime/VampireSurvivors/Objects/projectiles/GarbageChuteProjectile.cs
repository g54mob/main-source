using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GarbageChuteProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private GarbageChuteWeapon _trueWeapon;

		private Timer _bounceTimer;

		private float _grav;

		private float2 _initialVelocity;

		private int _chuteIndex;

		private int _itemSpriteIndex;

		private List<Sprite> _itemSprites;

		private MultiTargetTween _rotationTween;

		private bool _despawned;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void CustomFire(int chuteIndex)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		public Sprite GetNextSprite()
		{
			return null;
		}

		public Sprite GetRandomSprite()
		{
			return null;
		}

		public override void Despawn()
		{
		}
	}
}
