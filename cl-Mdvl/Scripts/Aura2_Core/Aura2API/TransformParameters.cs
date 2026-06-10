using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	public struct TransformParameters
	{
		public Space space;

		public Vector3 position;

		public Vector3 rotation;

		public Vector3 scale;

		public Matrix4x4 Matrix => Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
	}
}
