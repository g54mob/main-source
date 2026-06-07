using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_BigFuzzyFistWeapon : Weapon
	{
		private class FistState
		{
			public enum Phase
			{
				Waiting = 0,
				FadingIn = 1,
				PunchingDown = 2,
				Retracting = 3,
				FadingOut = 4
			}

			public PhaserSprite _fist;

			public float _alpha;

			public float _punchProgress;

			public EnemyController _punchTarget;

			public Phase _phase;

			public int _punchesLeft;

			public float2 _fistOffset;

			public float2 _punchTargetPos;

			public Vector2 _fistVelocity;
		}

		private PhaserSprite _leftFist;

		private PhaserSprite _rightFist;

		private FistState[] _fistStates;

		private int _nextFist;

		private float _rage;

		private float maxCooldownOffset;

		private float cooldownOffset;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		private void RetaliateOnPlayerDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
		{
		}

		private void RetaliateOnPlayerShield(GameplaySignals.CharacterLostShieldSignal signal)
		{
		}

		private void Retaliate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateFist(FistState fist)
		{
		}

		private bool SwitchToNewFistTarget(FistState fist)
		{
			return false;
		}

		private void DoNextPunch(float speedMultiplier = 1f)
		{
		}

		private EnemyController GetNextTarget(FistState fist)
		{
			return null;
		}

		private float2 GetTargetSearchCenter(FistState fist)
		{
			return default(float2);
		}

		private EnemyController ClosestEnemyInSet(List<EnemyController> set, float2 queryPos)
		{
			return null;
		}

		protected override void OnUpdate()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
