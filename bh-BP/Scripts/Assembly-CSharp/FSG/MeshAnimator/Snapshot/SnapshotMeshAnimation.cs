using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSG.MeshAnimator.Snapshot
{
	[Serializable]
	public class SnapshotMeshAnimation : MeshAnimationBase
	{
		private sealed class VertexEntry
		{
			private int _reserved;

			public int[] TriangleIndex;

			public int[] VertexIndex;

			private int _count;

			public int Count => 0;

			public void Add(int vertIndex, int triIndex)
			{
			}

			public void PopulateArrays()
			{
			}

			public void Clear()
			{
			}
		}

		public static readonly Dictionary<Mesh, Dictionary<SnapshotMeshAnimation, Mesh[]>> GeneratedFrames;

		[Header("Preload all animation frames")]
		public bool preGenerateFrames;

		public MeshNormalMode meshNormalMode;

		[Header("Only valid for Recalculated mode")]
		public bool recalculateNormalsOnRotation;

		[HideInInspector]
		public DeltaCompressedFrameData compressedFrameData;

		private Mesh[] frames;

		private int totalFrames;

		private bool[] generatedMeshes;

		private bool completelyGenerated;

		private SnapshotMeshFrameData[] decompressedFrameData;

		private Quaternion lastRotation;

		private Queue<Action> mainThreadActions;

		private Dictionary<Mesh, KeyValuePair<int[], Vector3[]>> meshInfoCache;

		public static IEqualityComparer<Vector3> VectorComparer;

		public override MeshFrameDataBase[] Frames => null;

		public override int TotalFrames => 0;

		private SnapshotMeshFrameData[] frameData => null;

		private void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		public override void SetFrameData(int frame, MeshFrameDataBase frameData)
		{
		}

		public override void SetFrameData(MeshFrameDataBase[] frameData)
		{
		}

		public override void DisplayFrame(IMeshAnimator meshAnimator, int frame, int previousFrame)
		{
		}

		public override void GenerateFrames(Mesh baseMesh)
		{
		}

		public override void GenerateFrame(Mesh baseMesh, int frame)
		{
		}

		public Vector3[] GetFrame(int frame)
		{
			return null;
		}

		public override void Reset()
		{
		}

		private void DisplayFrame(MeshFilter meshFilter, int frame, int previousFrame)
		{
		}

		private void CheckFullGeneration(int newFrame)
		{
		}

		private Mesh GenerateFrameInternal(Mesh baseMesh, int frame)
		{
			return null;
		}

		private void RecalculateNormals(Mesh mesh)
		{
		}

		private void RecalculateNormals(Mesh mesh, float angle, int[] triangles, Vector3[] vertices, bool instant = false)
		{
		}
	}
}
