using System;
using UnityEngine;

namespace CTS
{
	public readonly struct TemporaryMove : IDisposable
	{
		private readonly Transform _transform;

		private readonly Vector3 _oldPosition;

		private readonly Quaternion _oldRotation;

		private TemporaryMove(Transform transform)
		{
			_transform = transform;
			_oldPosition = transform.position;
			_oldRotation = transform.rotation;
		}

		public TemporaryMove(Transform transform, Vector3 position)
			: this(transform)
		{
			_transform.position = position;
		}

		public TemporaryMove(Transform transform, Quaternion rotation)
			: this(transform)
		{
			_transform.rotation = rotation;
		}

		public TemporaryMove(Transform transform, Vector3 position, Quaternion rotation)
			: this(transform)
		{
			_transform.SetPositionAndRotation(position, rotation);
		}

		public TemporaryMove(Transform transform, Transform target)
			: this(transform, target.position, target.rotation)
		{
		}

		public void Dispose()
		{
			_transform.SetPositionAndRotation(_oldPosition, _oldRotation);
		}
	}
}
