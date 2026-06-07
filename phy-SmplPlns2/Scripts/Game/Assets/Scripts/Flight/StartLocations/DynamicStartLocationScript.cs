using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.StartLocations
{
	public class DynamicStartLocationScript : MonoBehaviour
	{
		[SerializeField]
		private string _id;

		[SerializeField]
		private Rigidbody _body;

		[SerializeField]
		private Bounds _bounds;

		[SerializeField]
		private DynamicStartLocationVelocityMode _startVelocityMode = DynamicStartLocationVelocityMode.InheritBodyVelocityOnGround;

		private Transform _transform;

		public Rigidbody Body => _body;

		public Bounds Bounds => _bounds;

		public Vector3 FramePosition => _transform.position;

		public Vector3 GlobalPosition => Utility.ConvertFloatingOriginToAbsolutePosition(_transform.position);

		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				if (!(_id == value))
				{
					UnregisterDynamicLocation();
					_id = value;
					RegisterDynamicLocation();
				}
			}
		}

		public DynamicStartLocationVelocityMode StartVelocityMode => _startVelocityMode;

		public Transform Transform => _transform;

		public bool IsPositionInBounds(Vector3 position)
		{
			Vector3 point = _transform.InverseTransformPoint(position);
			return _bounds.Contains(point);
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
			RegisterDynamicLocation();
			NetworkFlightObject componentInParent = GetComponentInParent<NetworkFlightObject>();
			if (componentInParent != null)
			{
				if (componentInParent.Initialized)
				{
					OnNetworkFlightObjectInitialized(componentInParent);
				}
				else
				{
					componentInParent.LocalClientInitialized += OnNetworkFlightObjectInitialized;
				}
			}
		}

		protected virtual void OnDestroy()
		{
			UnregisterDynamicLocation();
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.cyan;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(_bounds.center, _bounds.size);
		}

		private void OnNetworkFlightObjectInitialized(object sender, NetworkFlightObjectEventArgs e)
		{
			e.Object.LocalClientInitialized -= OnNetworkFlightObjectInitialized;
			OnNetworkFlightObjectInitialized(e.Object);
		}

		private void OnNetworkFlightObjectInitialized(NetworkFlightObject obj)
		{
			if (obj.SpawnData.TryGetValue("LocationId", out var value))
			{
				Id = value;
			}
		}

		private void RegisterDynamicLocation()
		{
			if (!string.IsNullOrWhiteSpace(_id))
			{
				FlightSceneScript.Instance?.StartLocationManager.RegisterDynamicLocation(this);
			}
		}

		private void UnregisterDynamicLocation()
		{
			if (!string.IsNullOrWhiteSpace(_id))
			{
				FlightSceneScript.Instance?.StartLocationManager.UnregisterDynamicLocation(this);
			}
		}
	}
}
