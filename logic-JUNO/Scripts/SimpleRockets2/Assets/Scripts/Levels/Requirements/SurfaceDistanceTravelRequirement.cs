using System;
using ModApi.Levels;
using ModApi.Levels.Requirements;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Levels.Requirements
{
	public class SurfaceDistanceTravelRequirement : LevelRequirement
	{
		private double _minimumSurfaceDistance;

		private float _previousStakesDistance;

		private float _surfaceDistanceTraveled;

		private Vector3d _surfaceStake;

		public float DistanceBetweenStakes { get; set; } = 500f;

		public float SurfaceDistanceTraveled => _surfaceDistanceTraveled;

		public SurfaceDistanceTravelRequirement(ILevel level, double minimumSurfaceDistance)
			: base(level)
		{
			_minimumSurfaceDistance = minimumSurfaceDistance;
			_surfaceStake = GetSurfacePosition(base.Level.PlayerCraft.CraftNode.Position);
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			Vector3d surfacePosition = GetSurfacePosition(base.Level.PlayerCraft.CraftNode.Position);
			float num = (float)Vector3d.Distance(_surfaceStake, GetSurfacePosition(base.Level.PlayerCraft.CraftNode.Position));
			Vector3d normalized = _surfaceStake.normalized;
			Vector3d rhs = surfacePosition - _surfaceStake;
			Vector3d vector3d = normalized * Vector3d.Dot(normalized, rhs);
			num = (float)Math.Sqrt(rhs.sqrMagnitude - vector3d.sqrMagnitude);
			if (num > DistanceBetweenStakes)
			{
				_previousStakesDistance += num;
				_surfaceStake = surfacePosition;
				num = 0f;
			}
			_surfaceDistanceTraveled = _previousStakesDistance + num;
			base.DisplayValue = Units.GetDistanceString(_surfaceDistanceTraveled);
			if ((double)_surfaceDistanceTraveled >= _minimumSurfaceDistance)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Incomplete;
			}
		}

		private Vector3d GetSurfacePosition(Vector3d planetPosition)
		{
			return base.Level.PlayerCraft.CraftNode.Parent.PlanetVectorToSurfaceVector(planetPosition);
		}

		private void UpdateName()
		{
			base.Name = $"Distance Traveled > {_minimumSurfaceDistance}m";
		}
	}
}
