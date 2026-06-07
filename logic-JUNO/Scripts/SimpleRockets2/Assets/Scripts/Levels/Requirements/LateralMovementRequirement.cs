using ModApi.Levels;
using ModApi.Levels.Requirements;
using UnityEngine;

namespace Assets.Scripts.Levels.Requirements
{
	public class LateralMovementRequirement : LevelRequirement
	{
		private Vector3d _initialPosition;

		private double _lateralMovement;

		private double _maximumLateralMovement;

		public LateralMovementRequirement(ILevel level, double maximumLateralMovement)
			: base(level)
		{
			_maximumLateralMovement = maximumLateralMovement;
			_initialPosition = base.Level.PlayerCraft.CraftNode.Parent.PlanetVectorToSurfaceVector(base.Level.PlayerCraft.CraftNode.Position);
			UpdateName();
		}

		protected override void OnFlightUpdate()
		{
			base.OnFlightUpdate();
			Vector3d vector3d = base.Level.PlayerCraft.CraftNode.Parent.PlanetVectorToSurfaceVector(base.Level.PlayerCraft.CraftNode.Position);
			_lateralMovement = (vector3d - _initialPosition.normalized * Vector3d.Dot(_initialPosition.normalized, vector3d)).magnitude;
			base.DisplayValue = _lateralMovement.ToString("0.0") + "m";
			if (_lateralMovement <= _maximumLateralMovement)
			{
				base.Status = LevelRequirementStatus.Pass;
			}
			else
			{
				base.Status = LevelRequirementStatus.Fail;
			}
		}

		private void UpdateName()
		{
			base.Name = $"Lateral Movement < {_maximumLateralMovement}m";
		}
	}
}
