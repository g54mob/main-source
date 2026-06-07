using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class RigidbodyTrackingStrategy : ISourceTrackingStrategy
	{
		private Rigidbody _rigidbody;

		private Transform _transform;

		private DynamicCombinedObjectPart[] _parts;

		private float _velocityThreashold = 0.5f;

		private float _angularVelocityThreashold = 0.3f;

		public float VelocityThreashold
		{
			get
			{
				return _velocityThreashold;
			}
			set
			{
				_velocityThreashold = Mathf.Max(0f, value);
			}
		}

		public float AngularVelocityThreashold
		{
			get
			{
				return _angularVelocityThreashold;
			}
			set
			{
				_angularVelocityThreashold = Mathf.Max(0f, value);
			}
		}

		public RigidbodyTrackingStrategy(Rigidbody target, DynamicCombinedObjectPart[] parts)
		{
			_rigidbody = target;
			_transform = target.transform;
			_parts = parts;
		}

		public bool OnUpdate()
		{
			float magnitude = _rigidbody.velocity.magnitude;
			float magnitude2 = _rigidbody.angularVelocity.magnitude;
			if (magnitude > _velocityThreashold || magnitude2 > _angularVelocityThreashold)
			{
				for (int i = 0; i < _parts.Length; i++)
				{
					_parts[i].Move(_transform.localToWorldMatrix);
				}
				return true;
			}
			return false;
		}
	}
}
