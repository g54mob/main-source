using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_AlchemyWhipTween_Weapon : Weapon
	{
		private int _iterations;

		private int _totalNodes;

		private VerletTweenNode[] _nodes;

		private Projectile[] _whipProjectiles;

		private List<List<Vector2>> _splineList;

		private float _flipNum;

		private float _tempArea;

		private bool _applyTipControl;

		private float2 _gravity;

		private float _nodeDistance;

		private int _splineIndex;

		private MultiTargetTween _lerpTween;

		private float _waypointTotalDist;

		private float2 _characterOffset;

		private Timer _resetTimer;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void updateScale()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void ShiftWhipForce(int index)
		{
		}

		private void bodyEnabled(bool enable)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Simulate()
		{
		}

		private void ApplyConstraints()
		{
		}

		public float2 MultiLerp(List<Vector2> waypoints, float ratio)
		{
			return default(float2);
		}

		public static int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
		{
			return 0;
		}

		public float MultiDistance(List<Vector2> waypoints)
		{
			return 0f;
		}
	}
}
