using System;
using System.Runtime.CompilerServices;
using GameKit.Utilities;
using UnityEngine;

namespace FishNet.Object
{
	[Serializable]
	public class TransformPropertiesCls : IResettable
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public Vector3 LocalScale;

		public TransformPropertiesCls()
		{
		}

		public TransformPropertiesCls(Vector3 position, Quaternion rotation, Vector3 localScale)
		{
		}

		public void InitializeState()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ResetState()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(Transform t)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(TransformPropertiesCls tp)
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

		public TransformProperties ToStruct()
		{
			return default(TransformProperties);
		}
	}
}
