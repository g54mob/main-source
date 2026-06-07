using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_PrismCutlassProjectile : Projectile
	{
		private MultiTargetTween _scaleTween;

		private float2 _lastOwnerPosition;

		private SpriteAnimation _anim;

		private int _directionID;

		private Timer[] _timers;

		public bool MirrorFacingAngle;

		private static float2[] _directionVectors;

		private static string[] _directionNames;

		private static string[] _spriteNames;

		private static List<Sprite>[] s_directionSpritesCache;

		public static void ClearDirectionSpritesCache()
		{
		}

		public int GetDirectionID(Vector2 direction)
		{
			return 0;
		}

		public List<Sprite> GetFramesForDirection(int directionID)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void FadeOut()
		{
		}

		private void DoSweepHit()
		{
		}

		private void StopSweepHit()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
