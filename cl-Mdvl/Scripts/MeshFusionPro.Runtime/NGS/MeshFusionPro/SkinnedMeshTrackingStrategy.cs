using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	[Serializable]
	public class SkinnedMeshTrackingStrategy : ISourceTrackingStrategy
	{
		[SerializeField]
		[HideInInspector]
		private Transform _target;

		[Min(0.01f)]
		[SerializeField]
		private float _positionThreshold = 0.2f;

		private HashSet<SkinnedCombinedObject> _combinedObjects;

		private Vector3 _savedPosition;

		private float _sqrThreshold;

		public float PositionThreshold
		{
			get
			{
				return _positionThreshold;
			}
			set
			{
				_positionThreshold = Mathf.Max(0.001f, value);
			}
		}

		public bool GatherComponents(MeshFusionSource source, out string reason)
		{
			if (!(source is SkinnedMeshFusionSource))
			{
				reason = "Source should be SkinnedMeshFusionSource";
				return false;
			}
			if (_target == null)
			{
				SkinnedMeshRenderer component = source.GetComponent<SkinnedMeshRenderer>();
				if (component == null)
				{
					reason = "SkinnedMeshRenderer";
					return false;
				}
				_target = ((component.rootBone != null) ? component.rootBone : component.transform);
			}
			reason = "";
			return true;
		}

		public void OnCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			_combinedObjects = new HashSet<SkinnedCombinedObject>();
			foreach (ICombinedObjectPart part in parts)
			{
				_combinedObjects.Add((SkinnedCombinedObject)part.Root);
			}
			_savedPosition = _target.position;
			_sqrThreshold = _positionThreshold * _positionThreshold;
		}

		public void Track(out bool changed)
		{
			changed = (_target.position - _savedPosition).sqrMagnitude > _sqrThreshold;
			if (!changed)
			{
				return;
			}
			foreach (SkinnedCombinedObject combinedObject in _combinedObjects)
			{
				combinedObject.RecalculateBounds();
			}
			_savedPosition = _target.position;
		}
	}
}
