using System;
using UnityEngine;

namespace FSG.MeshAnimator
{
	[Serializable]
	public class MeshFrameDataBase
	{
		public Matrix4x4[] exposedTransforms;

		[NonSerialized]
		public Vector3 rootMotionPosition;

		[NonSerialized]
		public Quaternion rootMotionRotation;
	}
}
