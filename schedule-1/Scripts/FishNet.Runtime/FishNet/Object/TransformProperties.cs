using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FishNet.Object
{
	[Serializable]
	public struct TransformProperties
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public Vector3 LocalScale;

		public TransformProperties(Vector3 position, Quaternion rotation, Vector3 localScale)
		{
			Position = default(Vector3);
			Rotation = default(Quaternion);
			LocalScale = default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(Transform t)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(TransformProperties tp)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(Vector3 position, Quaternion rotation)
		{
		}

		public void Update(Vector3 position, Quaternion rotation, Vector3 localScale)
		{
		}
	}
}
