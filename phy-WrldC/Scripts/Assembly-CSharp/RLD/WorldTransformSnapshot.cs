using UnityEngine;

namespace RLD
{
	public class WorldTransformSnapshot
	{
		private Vector3 _worldPosition;

		private Quaternion _worldRotation;

		private Vector3 _worldScale;

		public Vector3 WorldPosition => _worldPosition;

		public Quaternion WorldRotation => _worldRotation;

		public Vector3 WorldScale => _worldScale;

		public void Snaphot(Transform transform)
		{
			if (!(transform == null))
			{
				_worldPosition = transform.position;
				_worldRotation = transform.rotation;
				_worldScale = transform.lossyScale;
			}
		}

		public bool SameAs(Transform transform)
		{
			if (_worldPosition == transform.position && _worldRotation == transform.rotation)
			{
				return _worldScale == transform.lossyScale;
			}
			return false;
		}
	}
}
