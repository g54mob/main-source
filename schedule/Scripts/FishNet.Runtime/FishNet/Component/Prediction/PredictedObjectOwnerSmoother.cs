using System.Runtime.CompilerServices;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Component.Prediction
{
	internal class PredictedObjectOwnerSmoother
	{
		private Transform _graphicalObject;

		private NetworkBehaviour _networkBehaviour;

		private float _teleportThreshold;

		private byte _interpolation;

		private Vector3 _graphicalStartPosition;

		private Quaternion _graphicalStartRotation;

		private Vector3 _graphicalInstantiatedOffsetPosition;

		private float _positionMoveRate;

		private Quaternion _graphicalInstantiatedOffsetRotation;

		private float _rotationMoveRate;

		private bool _preTickReceived;

		private bool _smoothPosition;

		private bool _smoothRotation;

		public void SetGraphicalObject(Transform value)
		{
		}

		public void SetInterpolation(byte value)
		{
		}

		public void Initialize(NetworkBehaviour nb, Vector3 instantiatedOffsetPosition, Quaternion instantiatedOffsetRotation, Transform graphicalObject, bool smoothPosition, bool smoothRotation, byte interpolation, float teleportThreshold)
		{
		}

		public void ManualUpdate()
		{
		}

		public void OnPreTick()
		{
		}

		public void OnPostTick()
		{
		}

		private bool CanSmooth()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void MoveToTarget()
		{
		}

		private bool GraphicalObjectMatches(Vector3 position, Quaternion rotation)
		{
			return false;
		}

		private bool SmoothPosition()
		{
			return false;
		}

		private bool SmoothRotation()
		{
			return false;
		}

		private void SetGraphicalMoveRates()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Vector3 GetGraphicalGoalPosition()
		{
			return default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Quaternion GetGraphicalGoalRotation()
		{
			return default(Quaternion);
		}

		private void SetGraphicalPreviousProperties()
		{
		}

		private void ResetGraphicalToPreviousProperties()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ResetGraphicalToInstantiatedProperties(bool position, bool rotation)
		{
		}
	}
}
