using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	internal class PositionValidator
	{
		private readonly float _minDistanceToAdd;

		private readonly bool _debugDensity;

		private Collider[] _results;

		private Transform[] _activeCameras;

		private LayerMask _trafficLayer;

		private LayerMask _playerLayer;

		private LayerMask _buildingsLayers;

		internal PositionValidator(Transform[] activeCameras, LayerMask trafficLayer, LayerMask playerLayer, LayerMask buildingsLayers, float minDistanceToAdd, bool debugDensity)
		{
		}

		internal bool IsValid(Vector3 position, float vehicleLength, float vehicleHeight, float vehicleWidth, bool ignoreLineOfSight, float frontWheelOffset, Quaternion rotation)
		{
			return false;
		}

		internal bool IsPositionFree(Vector3 position, float length, float height, float width, Quaternion rotation)
		{
			return false;
		}

		internal bool CheckTrailerPosition(Vector3 position, Quaternion vehicleRotation, Quaternion trailerRotation, VehicleComponent vehicle)
		{
			return false;
		}

		internal void UpdateCamera(Transform[] activeCameras)
		{
		}
	}
}
