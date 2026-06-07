using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class PhaserProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _whiteSprite;

		private bool _alreadyRecycled;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween;

		private PhaserWeapon _trueWeapon;

		private Transform _cachedSpriteTransform;

		protected float _screenScale;

		protected float _scaleDuration;

		protected float _projectileScale;

		protected float heigthScale;

		protected float whiteScale;

		protected uint[] _colors;

		protected override void Awake()
		{
		}

		protected virtual void Setuppo()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public virtual void SetSelfColor()
		{
		}

		public virtual void SetSelfScale()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
