using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Confodere3_Special_Projectile : Projectile
	{
		private Timer expireTimer;

		private bool _isDespawning;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private SpriteMask _posterMask;

		private Tween posterTween;

		private Material material;

		private static readonly int _matColor;

		private static readonly int _matAlpha;

		private List<Vector3> colors;

		private TP_Confodere1_Weapon trueWeapon;

		private Tween angleTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
