using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EX_Gaea_Circle_Projectile : Projectile
	{
		private Timer expireTimer;

		private bool _isDespawning;

		private Vector2 _collisionPos;

		private Vector2 _spritePos;

		private Transform _cachedSpriteTransform;

		private Material material;

		private static readonly int _matColor;

		private static readonly int _matAlpha;

		private static readonly int _matCutout;

		private Tween angleTween;

		private MultiTargetTween _tween1;

		private Timer hitboxTimer;

		private Tween cutoutTween;

		private List<Vector3> colors;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
