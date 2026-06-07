using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class SelfCollisionConstraint : IDisposable
	{
		public enum SelfCollisionMode
		{
			None = 0,
			FullMesh = 2
		}

		[Serializable]
		public class SerializeData : IDataValidate
		{
			public SelfCollisionMode selfMode;

			public CurveSerializeData surfaceThickness;

			public SelfCollisionMode syncMode;

			public MagicaCloth syncPartner;

			[Range(0f, 1f)]
			public float clothMass;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}

			public MagicaCloth GetSyncPartner()
			{
				return null;
			}
		}

		public struct SelfCollisionConstraintParams
		{
			public SelfCollisionMode selfMode;

			public float4x4 surfaceThicknessCurveData;

			public SelfCollisionMode syncMode;

			public float clothMass;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		internal struct Primitive : IComparable<Primitive>
		{
			public uint flag;

			public int3 particleIndices;

			public float3 invMass;

			public AABB aabb;

			public int3 grid;

			public float depth;

			public float thickness;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool IsIgnore()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool IsAllFix()
			{
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool AnyParticle(ref Primitive pri)
			{
				return false;
			}

			public int CompareTo(Primitive other)
			{
				return 0;
			}
		}

		internal struct GridInfo : IComparable<GridInfo>
		{
			public int hash;

			public int start;

			public int count;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int CompareTo(GridInfo other)
			{
				return 0;
			}
		}

		internal struct ContactInfo
		{
			public int primitiveIndex0;

			public int primitiveIndex1;

			public byte contactType;

			public byte enable;

			public half thickness;

			public half s;

			public half t;

			public half3 n;
		}

		internal struct IntersectInfo
		{
			public int2 edgeParticeIndices;

			public int3 triangleParticleIndices;
		}

		[BurstCompile]
		private struct InitPrimitiveJob : IJobParallelFor
		{
			public int teamId;

			public TeamManager.TeamData tdata;

			public uint kind;

			public int startPrimitive;

			[ReadOnly]
			public NativeArray<int2> edges;

			[ReadOnly]
			public NativeArray<int3> triangles;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> vertexDepths;

			[NativeDisableParallelForRestriction]
			public NativeArray<Primitive> primitiveArrayB;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_UpdatePrimitiveJob : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			public float4 simulationPower;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> oldPosArray;

			[ReadOnly]
			public NativeArray<float> frictionArray;

			public bool useIntersect;

			[NativeDisableParallelForRestriction]
			public NativeArray<Primitive> primitiveArrayB;

			[ReadOnly]
			public NativeArray<byte> intersectFlagArray;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_UpdateGridJob : IJobParallelFor
		{
			public int kindCount;

			public int updateIndex;

			public float4 simulationPower;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<Primitive> primitiveArrayB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<GridInfo> uniformGridStartCountBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_DetectionContactJob : IJobParallelFor
		{
			public int updateIndex;

			public int workerCount;

			public int teamCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> oldPosArray;

			[ReadOnly]
			public NativeArray<Primitive> primitiveArrayB;

			[ReadOnly]
			public NativeArray<GridInfo> uniformGridStartCountBuffer;

			[NativeDisableParallelForRestriction]
			public NativeQueue<ContactInfo>.ParallelWriter contactQueue;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_ConvertContactListJob : IJob
		{
			[ReadOnly]
			public NativeQueue<ContactInfo> contactQueue;

			[NativeDisableParallelForRestriction]
			public NativeList<ContactInfo> contactList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_UpdateContactJob : IJobParallelForDefer
		{
			public bool first;

			[NativeDisableParallelForRestriction]
			public NativeList<ContactInfo> contactList;

			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> oldPosArray;

			[ReadOnly]
			public NativeArray<Primitive> primitiveArrayB;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_SolverContactJob : IJobParallelForDefer
		{
			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<Primitive> primitiveArrayB;

			[ReadOnly]
			public NativeList<ContactInfo> contactList;

			[NativeDisableParallelForRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			public NativeArray<int> tempCountBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfStep_SumContactJob : IJobParallelFor
		{
			public int updateIndex;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			public NativeArray<int> tempCountBuffer;

			public void Execute(int localIndex)
			{
			}
		}

		[BurstCompile]
		internal struct SelfDetectionIntersectJob : IJobParallelFor
		{
			public int updateIndex;

			public int workerCount;

			public int frameIndex;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<Primitive> primitiveArrayB;

			[ReadOnly]
			public NativeArray<GridInfo> uniformGridStartCountBuffer;

			[NativeDisableParallelForRestriction]
			public NativeQueue<IntersectInfo>.ParallelWriter intersectQueue;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfConvertIntersectListJob : IJob
		{
			[ReadOnly]
			public NativeQueue<IntersectInfo> intersectQueue;

			[NativeDisableParallelForRestriction]
			public NativeList<IntersectInfo> intersectList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		internal struct SelfClearIntersectJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<byte> intersectFlagArray;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		internal struct SelfSolverIntersectJob : IJobParallelForDefer
		{
			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeList<IntersectInfo> intersectList;

			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<byte> intersectFlagArray;

			public void Execute(int index)
			{
			}
		}

		public const uint KindPoint = 0u;

		public const uint KindEdge = 1u;

		public const uint KindTriangle = 2u;

		public const uint Flag_KindMask = 50331648u;

		public const uint Flag_Fix0 = 67108864u;

		public const uint Flag_Fix1 = 134217728u;

		public const uint Flag_Fix2 = 268435456u;

		public const uint Flag_AllFix = 536870912u;

		public const uint Flag_Ignore = 1073741824u;

		public const uint Flag_Enable = 2147483648u;

		public const uint Flag_Intersect0 = 1u;

		public const uint Flag_Intersect1 = 2u;

		public const uint Flag_Intersect2 = 4u;

		public const uint Flag_FixIntersect0 = 67108865u;

		public const uint Flag_FixIntersect1 = 134217730u;

		public const uint Flag_FixIntersect2 = 268435460u;

		internal ExNativeArray<Primitive> primitiveArrayB;

		internal ExNativeArray<GridInfo> uniformGridStartCountBuffer;

		internal const byte ContactType_EdgeEdge = 0;

		internal const byte ContactType_PointTriangle = 1;

		internal const byte ContactType_TrianglePoint = 2;

		internal NativeQueue<ContactInfo> contactQueue;

		internal NativeList<ContactInfo> contactList;

		internal NativeQueue<IntersectInfo> intersectQueue;

		internal NativeList<IntersectInfo> intersectList;

		internal NativeArray<byte> intersectFlagArray;

		public int PointPrimitiveCount { get; private set; }

		public int EdgePrimitiveCount { get; private set; }

		public int TrianglePrimitiveCount { get; private set; }

		internal int IntersectCount { get; private set; }

		public void Dispose()
		{
		}

		public bool HasPrimitive()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		internal void Register(ClothProcess cprocess)
		{
		}

		internal void Exit(ClothProcess cprocess)
		{
		}

		internal void UpdateTeam(int teamId)
		{
		}

		private void InitPrimitive(int teamId, TeamManager.TeamData tdata, uint kind, int startPrimitive, int length)
		{
		}

		internal void WorkBufferUpdate()
		{
		}

		private static void UpdatePrimitive(int k, int teamId, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> oldPosArray, ref NativeArray<float> frictionArray, bool useIntersect, ref NativeArray<Primitive> primitiveArrayB, ref NativeArray<byte> intersectFlagArray)
		{
		}

		private static void UpdateGrid(int k, int teamId, ref TeamManager.TeamData tdata, ref NativeArray<Primitive> primitiveArrayB, ref NativeArray<GridInfo> uniformGridStartCountBuffer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static int3 GetGrid(float3 pos, float gridSize)
		{
			return default(int3);
		}

		private static void DetectionContacts(int workerCount, int workerIndex, int myTeamId, ref TeamManager.TeamData myTeam, uint myKind, int targetTeamId, ref TeamManager.TeamData targetTeam, uint targetKind, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> oldPosArray, ref NativeArray<Primitive> primitiveArrayB, ref NativeArray<GridInfo> uniformGridStartCountBuffer, ref NativeQueue<ContactInfo>.ParallelWriter contactQueue)
		{
		}

		private unsafe static void UpdateContactInfo(ref ContactInfo contact, Primitive* pt, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> oldPosArray, float scrScale, bool first)
		{
		}

		private static void DetectionIntersect(int workerCount, int workerIndex, int frameIndex, int myTeamId, ref TeamManager.TeamData myTeam, uint myKind, int targetTeamId, ref TeamManager.TeamData targetTeam, uint targetKind, ref NativeArray<Primitive> primitiveArrayB, ref NativeArray<GridInfo> uniformGridStartCountBuffer, ref NativeQueue<IntersectInfo>.ParallelWriter intersectQueue)
		{
		}
	}
}
