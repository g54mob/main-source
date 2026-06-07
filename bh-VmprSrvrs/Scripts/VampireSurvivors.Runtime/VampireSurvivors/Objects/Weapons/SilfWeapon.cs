using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class SilfWeapon : Weapon
	{
		[SerializeField]
		protected SpriteRenderer _TargetZone;

		public List<Vector2> _Targets;

		public int _EnemyIndex;

		public SpriteRenderer _Bird;

		public float _RayDuration;

		public float _TotalTime;

		public float _AngleTime;

		protected float _damageZoneDistance;

		protected float _damageZoneDefaultRadius;

		protected bool _blockFire;

		protected float _delayBasedOnDuration;

		protected Vector2 _currentDirection;

		protected float _runSpeed;

		protected Circle _damageZone;

		protected float _targetZoneAngle;

		protected float _damageZoneAngle;

		private const bool IsPortrait = false;

		private const float GameplayPixelWidth = 3.42f;

		private const float GameplayPixelHeight = 4.56f;

		protected Color _targetZoneCol;

		protected float _targetZoneStroke;

		protected float _targetZoneAlphaOn;

		protected float _targetZoneAlphaOff;

		protected float _offsetY;

		protected string _birdSprite;

		protected string _birdAnimPrefix;

		protected int _birdAnimStartFrame;

		protected int _birdAnimFrameCount;

		private static readonly int ColorId;

		private static readonly int ThicknessId;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
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

		public override void HandlePlayerTeleport(float2 destinationPos)
		{
		}

		protected virtual float OffsetX()
		{
			return 0f;
		}

		protected virtual void AddTargets()
		{
		}

		protected virtual void BlockFire()
		{
		}

		protected virtual void UnblockFire()
		{
		}

		protected virtual void UpdateTargetZonePos(SpriteRenderer targetZone, float angle)
		{
		}

		protected virtual void UpdateDamageZonePos(Circle damageZone, float angle)
		{
		}

		private void MakeBirb()
		{
		}

		private float DistanceSquared(Vector2 vec1, Vector2 vec2)
		{
			return 0f;
		}

		protected void SetupTargetZone(SpriteRenderer targetZone)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
