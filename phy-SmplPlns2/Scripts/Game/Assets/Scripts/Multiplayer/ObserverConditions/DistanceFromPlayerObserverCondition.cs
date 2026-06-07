using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects;
using FishNet.Connection;
using FishNet.Observing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ObserverConditions
{
	[CreateAssetMenu(menuName = "FishNet/Observers/Custom/Distance From Player Condition", fileName = "New Distance From Player Condition")]
	public class DistanceFromPlayerObserverCondition : ObserverCondition
	{
		[SerializeField]
		private float _hideDistance;

		[SerializeField]
		private float _observeDistance;

		public float HideDistance
		{
			get
			{
				return _hideDistance;
			}
			set
			{
				_hideDistance = value;
			}
		}

		public float ObserveDistance
		{
			get
			{
				return _observeDistance;
			}
			set
			{
				_observeDistance = value;
			}
		}

		public override bool ConditionMet(NetworkConnection connection, bool currentlyAdded, out bool notProcessed)
		{
			notProcessed = false;
			if (NetworkObject.IsServerInitialized && !currentlyAdded && NetworkObject.TryGetComponent<NetworkFlightObject>(out var component) && !component.Initialized)
			{
				return true;
			}
			Vector3? vector = connection.GetPlayer()?.FlightScenePlayer?.FramePosition;
			if (vector == Vector3.zero)
			{
				return true;
			}
			if (!vector.HasValue)
			{
				return false;
			}
			Vector3 position = NetworkObject.transform.position;
			float num = (currentlyAdded ? (_hideDistance * _hideDistance) : (_observeDistance * _observeDistance));
			if (Vector3.SqrMagnitude(vector.Value - position) <= num)
			{
				return true;
			}
			return false;
		}

		public override ObserverConditionType GetConditionType()
		{
			return ObserverConditionType.Timed;
		}
	}
}
