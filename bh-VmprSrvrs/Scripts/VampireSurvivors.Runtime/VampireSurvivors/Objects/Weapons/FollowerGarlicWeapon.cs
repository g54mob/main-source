using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FollowerGarlicWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _Renderer;

		private Tween _rotateTweenHandle;

		private Sequence _fadeTween;

		private bool _cooldownAffectedByMovement;

		private const float Mul = 166.66667f;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void CheckArcanas()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		private void UpdateRendererScaleToArea()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
