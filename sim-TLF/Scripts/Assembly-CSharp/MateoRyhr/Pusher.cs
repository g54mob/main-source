using UnityEngine;

namespace MateoRyhr
{
	public class Pusher : MonoBehaviour
	{
		[SerializeField]
		private Transform _raycasterOrigin;

		[SerializeField]
		private FloatVariable _interactionDistance;

		[SerializeField]
		private FloatVariable _pushForce;

		[SerializeField]
		private LayerMask _layers;

		[SerializeField]
		private bool _affectedByMass = true;

		private Ray _ray;

		private Rigidbody _rigidbody;

		private Vector3 _force;

		public void Push()
		{
			_ray = new Ray(_raycasterOrigin.position, _raycasterOrigin.forward);
			if (!Physics.Raycast(_ray, out var hitInfo, _interactionDistance.Value, _layers))
			{
				return;
			}
			_rigidbody = hitInfo.collider.GetComponentInParent<Rigidbody>();
			if (_rigidbody != null)
			{
				_force = _raycasterOrigin.forward * _pushForce.Value;
				if (!_affectedByMass)
				{
					_force *= _rigidbody.mass;
				}
				_rigidbody.AddForceAtPosition(_force, hitInfo.point);
			}
		}
	}
}
