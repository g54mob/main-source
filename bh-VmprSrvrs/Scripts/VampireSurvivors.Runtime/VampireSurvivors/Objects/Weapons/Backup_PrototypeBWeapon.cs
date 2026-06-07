using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Backup_PrototypeBWeapon : FB_QuantisedAngleWeapon
	{
		private List<PhaserSprite> _planeSprites;

		private List<float2> _planeVectors;

		private Timer _planeTimer;

		private MultiTargetTween _moveTween;

		private Timer[] _explosionTimers;

		private Timer[] _explosionDelays;

		private BulletPool _explosionPool;

		private float2 _playerPos;

		public float planesOffsetY;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void startPlanes()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void dropexplosion(int explosionIndex)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
