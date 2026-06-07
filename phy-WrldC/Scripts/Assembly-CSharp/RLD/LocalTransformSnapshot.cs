using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class LocalTransformSnapshot
	{
		private Transform _transform;

		private Transform _parentTransform;

		private Vector3 _localPosition;

		private Quaternion _localRotation;

		private Vector3 _localScale;

		public Transform Transform => _transform;

		public static List<LocalTransformSnapshot> GetSnapshotCollection(IEnumerable<GameObject> gameObjects)
		{
			if (gameObjects == null)
			{
				return new List<LocalTransformSnapshot>();
			}
			List<LocalTransformSnapshot> list = new List<LocalTransformSnapshot>(20);
			foreach (GameObject gameObject in gameObjects)
			{
				if (gameObject != null)
				{
					LocalTransformSnapshot localTransformSnapshot = new LocalTransformSnapshot();
					localTransformSnapshot.Snapshot(gameObject.transform);
					list.Add(localTransformSnapshot);
				}
			}
			return list;
		}

		public void Snapshot(Transform transform)
		{
			if (!(transform == null))
			{
				_transform = transform;
				_parentTransform = transform.parent;
				_localPosition = transform.localPosition;
				_localRotation = transform.localRotation;
				_localScale = transform.localScale;
			}
		}

		public bool SameAs(Transform transform)
		{
			if (_parentTransform == transform.parent && _localPosition == transform.localPosition && _localRotation == transform.localRotation)
			{
				return _localScale == transform.localScale;
			}
			return false;
		}

		public void Apply()
		{
			if (!(_transform == null))
			{
				if (_parentTransform != null)
				{
					_transform.localPosition = _localPosition;
					_transform.localRotation = _localRotation;
					_transform.localScale = _localScale;
				}
				else
				{
					_transform.position = _localPosition;
					_transform.rotation = _localRotation;
					_transform.localScale = _localScale;
				}
			}
		}
	}
}
