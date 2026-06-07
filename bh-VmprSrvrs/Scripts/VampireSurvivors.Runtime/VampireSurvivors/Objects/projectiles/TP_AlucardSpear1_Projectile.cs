using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AlucardSpear1_Projectile : Projectile
	{
		private MultiTargetTween _alphaTween;

		private MultiTargetTween _angleTween;

		private bool _flipToCheck;

		private float _flipSwitch;

		private Timer _attackDelay;

		private int _turnCount;

		private TP_AlucardSpear1_Weapon _trueWeapon;

		private float horizontalOffset;

		private Vector2 _attackOffset;

		private List<Projectile> _tips;

		private float _ownerOffsetX;

		private float _ownerOffsetY;

		private float offsetPx;

		private List<float> _randomSpearOffsets;

		private float2 _startingPosition;

		private Tween _positionTween;

		protected virtual string FrameName => null;

		protected virtual int AutoFlip => 0;

		protected virtual Vector2 ImageHalfSize => default(Vector2);

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Forward()
		{
		}

		private void CheckForFlip()
		{
		}

		private void FadeOut()
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
