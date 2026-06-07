using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CorridorProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _CorridorBg;

		[SerializeField]
		private SpriteRenderer _CorridorLight;

		private Tween _angleTween;

		private Tween _scaleTween;

		private Tween _alphaTweenBg;

		private Tween _alphaTweenLight;

		private float _worldScreenHeight;

		private float _targetScale;

		private float _targetAlpha;

		private float _startAlpha;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void InAnim()
		{
		}

		private void OutAnim()
		{
		}
	}
}
