using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AlucardSword2_Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _AlucardSprite;

		[SerializeField]
		private SpriteRenderer _AlucardGlowSprite;

		[SerializeField]
		private SpriteRenderer _SwordSprite;

		private SpriteAnimation _alucardAnim;

		private SpriteAnimation _alucardGlowAnim;

		private SpriteAnimation _swordAnim;

		private const float SwordOffsetX = 0.16f;

		private const float SwordOffsetY = 0.08f;

		private int _evoCount;

		private List<string> _swordSpriteNames;

		private List<uint> _glowTints;

		private bool _initSpriteTrail;

		private bool _cachedFlipX;

		private const float DashDuration = 750f;

		private int _numSlashes;

		private float _slashesRemaining;

		private List<float> _ghostYOffsets;

		private float _ghostYOffsetMul;

		private TP_AlucardSword2_Weapon _trueWeapon;

		private Tween _posTween;

		private MultiTargetTween _alphaTween;

		private Timer _slashTimer;

		private Timer _bodyTimer;

		private float ScaledAlpha => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void LateUpdate()
		{
		}

		private void InitAnimations()
		{
		}

		private void StartFadeIn()
		{
		}

		private void DashToPosition(Vector3 pos)
		{
		}

		private void SlashAttack()
		{
		}

		private void OnSlashComplete()
		{
		}

		private void StartDespawn()
		{
		}

		private void SetBodyForAlucard()
		{
		}

		private void SetBodyForSlash()
		{
		}

		private void SetSwordOffset()
		{
		}
	}
}
