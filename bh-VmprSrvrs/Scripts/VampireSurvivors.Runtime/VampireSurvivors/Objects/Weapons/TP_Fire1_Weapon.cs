using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Fire1_Weapon : Weapon
	{
		private float GroundRadiusX;

		private float GroundRadiusY;

		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private bool _lockCursor;

		private EnemyController _lockOnTarget;

		private bool _canLockOn;

		private Timer _lockOnTimer;

		[NonSerialized]
		public static float staticTotalTime;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual bool IsPrimaryWeapon => false;

		public bool CanFireNormally { get; set; }

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void OnMirrorData(Vector2 position)
		{
		}

		protected float CalcRadAngle(float x1, float y1, float x2, float y2)
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireProjectiles(Vector2 pos)
		{
		}

		protected void Fire_FireCounter(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
