using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Backup_PrototypeAWeapon : FB_QuantisedAngleWeapon
	{
		private SpriteRenderer _muzzleFlash;

		private bool _muzzleFlashLastRotated;

		private int _frameCount;

		private float _sinPhase;

		private List<PhaserSprite> _planeSprites;

		private List<float2> _planeVectors;

		private Timer _planeTimer;

		private bool _planeFiring;

		private int _planeCounter;

		private Timer _planeFiringTimer;

		private MultiTargetTween _moveTween;

		private BulletPool _planeBulletPool;

		private float2 _playerPos;

		public float planesOffsetX;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void startPlanes()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
