using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	[Serializable]
	public class RigidbodyTrackingStrategy : ISourceTrackingStrategy
	{
		[Min(0.01f)]
		[SerializeField]
		private float _velocityThreshold = 0.5f;

		[Min(0.01f)]
		[SerializeField]
		private float _angularVelocityThreshold = 0.3f;

		[SerializeField]
		[HideInInspector]
		private Transform _transform;

		[SerializeField]
		[HideInInspector]
		private Rigidbody _rigidbody;

		private DynamicCombinedObjectPart[] _parts;

		public float VelocityThreshold
		{
			get
			{
				return _velocityThreshold;
			}
			set
			{
				_velocityThreshold = Mathf.Max(0f, value);
			}
		}

		public float AngularVelocityThreshold
		{
			get
			{
				return _angularVelocityThreshold;
			}
			set
			{
				_angularVelocityThreshold = Mathf.Max(0f, value);
			}
		}

		public bool GatherComponents(MeshFusionSource source, out string reason)
		{
			if (!(source is DynamicMeshFusionSource))
			{
				reason = "Source should be DynamicMeshFusionSource";
				return false;
			}
			if ((object)_transform == null)
			{
				_transform = source.transform;
			}
			if (_transform == null)
			{
				reason = "Transform is missed";
				return false;
			}
			if ((object)_rigidbody == null)
			{
				_rigidbody = source.GetComponent<Rigidbody>();
			}
			if (_rigidbody == null)
			{
				reason = "Rigidbody is missed";
				return false;
			}
			reason = "";
			return true;
		}

		public void OnCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			_parts = parts.Select((ICombinedObjectPart p) => (DynamicCombinedObjectPart)p).ToArray();
		}

		public void Track(out bool changed)
		{
			float magnitude = UnityAPI.GetRigidbodyVelocity(_rigidbody).magnitude;
			float magnitude2 = _rigidbody.angularVelocity.magnitude;
			changed = magnitude > _velocityThreshold || magnitude2 > _angularVelocityThreshold;
			if (changed)
			{
				for (int i = 0; i < _parts.Length; i++)
				{
					_parts[i].Move(_transform.localToWorldMatrix);
				}
			}
		}
	}
}
