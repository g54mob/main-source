using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class ShroudProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _InversionVFX;

		[SerializeField]
		private SpriteRenderer _Bubble;

		public bool _ShroudActive;

		private Timer _expireTimer;

		private Tween _scaleTween;

		private Tween _inversionTween;

		private Tween _bubbleAlphaTween;

		private Vector3 _parentTransformPos;

		private const float Radius = 16f;

		private bool _enableBodyOnNextFrame;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private bool HasSoleSolution()
		{
			return false;
		}

		public override void Despawn()
		{
		}

		private void PlaySound()
		{
		}

		private void InversionVFX(float radius, float duration)
		{
		}
	}
}
