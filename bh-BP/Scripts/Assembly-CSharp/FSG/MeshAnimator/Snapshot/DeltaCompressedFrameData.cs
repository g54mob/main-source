using System;
using UnityEngine;

namespace FSG.MeshAnimator.Snapshot
{
	[Serializable]
	public class DeltaCompressedFrameData
	{
		public static float compressionAccuracy;

		public float accuracy;

		public int sizeOffset;

		public int vertLength;

		public int exposedLength;

		[HideInInspector]
		public short[] positionsUShort;

		[HideInInspector]
		public int[] positions;

		[HideInInspector]
		public int[] frameIndexes;

		[HideInInspector]
		public Matrix4x4[] exposedTransforms;

		[HideInInspector]
		public Vector3[] rootMotionPositions;

		[HideInInspector]
		public Quaternion[] rootMotionRotations;

		[HideInInspector]
		public Vector3[] normals;

		[HideInInspector]
		public Vector3[] rawPositions;

		public static implicit operator SnapshotMeshFrameData[](DeltaCompressedFrameData s)
		{
			return null;
		}

		public static implicit operator DeltaCompressedFrameData(SnapshotMeshFrameData[] frames)
		{
			return null;
		}
	}
}
