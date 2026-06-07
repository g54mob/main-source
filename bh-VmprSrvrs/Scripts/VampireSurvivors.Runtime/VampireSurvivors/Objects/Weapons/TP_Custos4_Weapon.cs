using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Custos4_Weapon : TP_Custos_Weapon
	{
		[SerializeField]
		private Transform _DummyTarget;

		private const int AnimFPS = 20;

		private PhaserSprite _custos1;

		private PhaserSprite _custos2;

		private PhaserSprite _custos3;

		private Vector2 _offset1;

		private Vector2 _offset2;

		private Vector2 _offset3;

		private int _firingCounter;

		private const int MinBites = 6;

		private int _numBites;

		private const int MinFireballs = 16;

		private int _numFireballs;

		private const float HeadFadeTime = 500f;

		private const float GapBetweenFireballandBiteAttacks = 250f;

		private Timer _animTimer;

		private MultiTargetTween _alphaTween;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void StartFireballAttack()
		{
		}

		private void ShootFireballs()
		{
		}

		private void FireFireballProjectiles(int index)
		{
		}

		private Transform GetFireballTarget()
		{
			return null;
		}

		private void EndFireballAttack()
		{
		}

		private void BiteAttack()
		{
		}

		private void FireOneBiteProjectile(List<BulletPool> sequence, List<Vector2> offsets, int index)
		{
		}

		private List<BulletPool> GenerateBiteSequence()
		{
			return null;
		}

		private List<Vector2> GetBiteOffsets(List<BulletPool> sequence)
		{
			return null;
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		private float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
		{
			return 0f;
		}
	}
}
