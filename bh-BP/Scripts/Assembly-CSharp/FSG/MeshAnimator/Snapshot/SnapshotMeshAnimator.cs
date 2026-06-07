using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace FSG.MeshAnimator.Snapshot
{
	[AddComponentMenu("Miscellaneous/Mesh Animator")]
	[RequireComponent(typeof(MeshFilter))]
	public class SnapshotMeshAnimator : MeshAnimatorBase
	{
		private struct LerpVector3Job : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<Vector3> from;

			[ReadOnly]
			public NativeArray<Vector3> to;

			[ReadOnly]
			public float delta;

			public NativeArray<Vector3> output;

			public void Execute(int i)
			{
			}
		}

		private struct CalculateBoundsJob : IJob
		{
			[ReadOnly]
			public NativeArray<Vector3> positions;

			public Bounds bounds;

			public void Execute()
			{
			}
		}

		private struct CrossfadeJobData
		{
			public int framesNeeded;

			public int currentFrame;

			public bool isFading;

			public float endTime;

			public SnapshotMeshFrameData fromFrame;

			public SnapshotMeshFrameData toFrame;

			public LerpVector3Job[] positionJobs;

			public CalculateBoundsJob[] boundsJobs;

			public JobHandle[] positionJobHandles;

			public JobHandle[] boundsJobHandles;

			public NativeArray<Vector3> from;

			public NativeArray<Vector3> to;

			public NativeArray<Vector3>[] output;

			private bool isReset;

			public void Reset(bool destroying)
			{
			}

			public void StartCrossfade(SnapshotMeshFrameData fromFrame, SnapshotMeshFrameData toFrame)
			{
			}

			public void ReturnFrame(bool destroying)
			{
			}
		}

		private static Dictionary<Mesh, int> _meshCount;

		private static List<Stack<Mesh>> _crossFadePool;

		private static Dictionary<Mesh, int> _crossFadeIndex;

		public SnapshotMeshAnimation defaultMeshAnimation;

		public SnapshotMeshAnimation[] meshAnimations;

		public bool syncCrossfadeMeshCount;

		public bool recalculateCrossfadeNormals;

		[SerializeField]
		[HideInInspector]
		private MeshTriangleData[] meshTriangleData;

		[SerializeField]
		[HideInInspector]
		private Vector2[] uv1Data;

		[SerializeField]
		[HideInInspector]
		private Vector2[] uv2Data;

		[SerializeField]
		[HideInInspector]
		private Vector2[] uv3Data;

		[SerializeField]
		[HideInInspector]
		private Vector2[] uv4Data;

		private Mesh crossfadeMesh;

		private CrossfadeJobData currentCrossFade;

		private int crossFadePoolIndex;

		public override IMeshAnimation defaultAnimation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override IMeshAnimation[] animations => null;

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private Mesh GetCrossfadeFromPool()
		{
			return null;
		}

		protected override void ReturnCrossfadeToPool(bool destroying)
		{
		}

		protected override bool DisplayFrame(int previousFrame)
		{
			return false;
		}

		public override void Crossfade(int index, float speed)
		{
		}

		public override void PrepopulateCrossfadePool(int count)
		{
		}

		protected override void OnCurrentAnimationChanged(IMeshAnimation meshAnimation)
		{
		}

		public override void SetAnimations(IMeshAnimation[] meshAnimations)
		{
		}

		public override void StoreAdditionalMeshData(Mesh mesh)
		{
		}
	}
}
