using FishNet.Object;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class RelativeVelocityZoneScript : MonoBehaviour
	{
		[SerializeField]
		private Bounds _bounds;

		[SerializeField]
		private Rigidbody _rigidbody;

		public Bounds Bounds => _bounds;

		public NetworkObject NetworkObject { get; private set; }

		public Rigidbody Rigidbody
		{
			get
			{
				return _rigidbody;
			}
			set
			{
				_rigidbody = value;
			}
		}

		public bool IsWithinBounds(Vector3 position)
		{
			Vector3 point = base.transform.InverseTransformPoint(base.transform.position);
			return _bounds.Contains(point);
		}

		protected virtual void Awake()
		{
			NetworkObject = base.transform.GetComponentInParent<NetworkObject>();
			if (NetworkObject == null)
			{
				Debug.LogError("RelativeVelocityZoneScript on " + base.gameObject.name + " requires a NetworkObject component in its parent hierarchy. This zone will not function properly.", base.gameObject);
			}
			if (GetComponentsInParent<RelativeVelocityZoneScript>(includeInactive: true).Length > 1)
			{
				Debug.LogWarning("Multiple RelativeVelocityZoneScript components detected in hierarchy of " + base.gameObject.name + ". Only one zone script should exist per network object.", base.gameObject);
			}
		}
	}
}
