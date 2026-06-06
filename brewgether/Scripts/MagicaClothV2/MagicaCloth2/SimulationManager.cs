using System;
using System.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class SimulationManager : IManager, IDisposable, IValid
	{
		[BurstCompile]
		private struct SimulationNormalJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeList<int> batchNormalTeamList;

			public float4 simulationPower;

			public float simulationDeltaTime;

			public int mappingCount;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamWindData> teamWindArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			public int windZoneCount;

			[ReadOnly]
			public NativeArray<WindManager.WindData> windDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> transformPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			[ReadOnly]
			public NativeArray<float4x4> transformLocalToWorldMatrixArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> transformLocalPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> transformLocalRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformLocalScaleArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<int> skinBoneTransformIndices;

			[ReadOnly]
			public NativeArray<float4x4> skinBoneBindPoses;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<quaternion> vertexBindPoseRotations;

			[ReadOnly]
			public NativeArray<float> vertexDepths;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[ReadOnly]
			public NativeArray<int> vertexParentIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineStartDataIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineDataCounts;

			[ReadOnly]
			public NativeArray<ushort> baseLineData;

			[ReadOnly]
			public NativeArray<float3> vertexLocalPositions;

			[ReadOnly]
			public NativeArray<quaternion> vertexLocalRotations;

			[ReadOnly]
			public NativeArray<uint> vertexChildIndexArray;

			[ReadOnly]
			public NativeArray<ushort> vertexChildDataArray;

			[ReadOnly]
			public NativeArray<ExBitFlag8> baseLineFlags;

			[ReadOnly]
			public NativeArray<int3> triangles;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> triangleNormals;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> triangleTangents;

			[ReadOnly]
			public NativeArray<float2> uvs;

			[ReadOnly]
			public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

			[ReadOnly]
			public NativeArray<quaternion> normalAdjustmentRotations;

			[ReadOnly]
			public NativeArray<quaternion> vertexToTransformRotations;

			[ReadOnly]
			public NativeArray<int2> edges;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> oldRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> basePosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> baseRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> oldRotationArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> dispPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> realVelocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> staticFrictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> collisionNormalArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<ExBitFlag16> colliderFlagArray;

			[ReadOnly]
			public NativeArray<float3> colliderCenterArray;

			[ReadOnly]
			public NativeArray<float3> colliderSizeArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderFramePositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderFrameScales;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldFramePositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderNowPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderNowRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<ColliderManager.WorkData> colliderWorkDataArray;

			[ReadOnly]
			public NativeArray<int> colliderMainColliderIndices;

			[ReadOnly]
			public NativeArray<ushort> fixedArray;

			[ReadOnly]
			public NativeArray<uint> distanceIndexArray;

			[ReadOnly]
			public NativeArray<ushort> distanceDataArray;

			[ReadOnly]
			public NativeArray<float> distanceDistanceArray;

			[ReadOnly]
			public NativeArray<ulong> bendingTrianglePairArray;

			[ReadOnly]
			public NativeArray<float> bendingRestAngleOrVolumeArray;

			[ReadOnly]
			public NativeArray<sbyte> bendingSignOrVolumeArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> stepBasicPositionBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> stepBasicRotationBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> tempRotationBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> tempRotationBufferB;

			public void Execute(int localIndex)
			{
			}
		}

		[BurstCompile]
		private struct SplitPre_A_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<float4x4> transformLocalToWorldMatrixArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<float3> localNormals;

			[ReadOnly]
			public NativeArray<float3> localTangents;

			[ReadOnly]
			public NativeArray<VirtualMeshBoneWeight> boneWeights;

			[ReadOnly]
			public NativeArray<int> skinBoneTransformIndices;

			[ReadOnly]
			public NativeArray<float4x4> skinBoneBindPoses;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> rotations;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPre_B_Job : IJobParallelFor
		{
			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamWindData> teamWindArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			public int windZoneCount;

			[ReadOnly]
			public NativeArray<WindManager.WindData> windDataArray;

			[ReadOnly]
			public NativeArray<float3> transformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<quaternion> vertexBindPoseRotations;

			[ReadOnly]
			public NativeArray<ushort> fixedArray;

			public void Execute(int localIndex)
			{
			}
		}

		[BurstCompile]
		private struct SplitPre_C_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<float3> transformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			[ReadOnly]
			public NativeArray<float3> transformLocalPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformLocalRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformLocalScaleArray;

			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<float> vertexDepths;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> oldRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> basePosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> baseRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> oldRotationArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> dispPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> realVelocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> staticFrictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> collisionNormalArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<ExBitFlag16> colliderFlagArray;

			[ReadOnly]
			public NativeArray<float3> colliderCenterArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderFramePositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderFrameScales;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldFramePositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderNowPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderNowRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldRotations;

			[ReadOnly]
			public NativeArray<int> colliderMainColliderIndices;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_A_Job : IJobParallelFor
		{
			public int updateIndex;

			public float4 simulationPower;

			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamWindData> teamWindArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<ExBitFlag16> colliderFlagArray;

			[ReadOnly]
			public NativeArray<float3> colliderSizeArray;

			[ReadOnly]
			public NativeArray<float3> colliderFramePositions;

			[ReadOnly]
			public NativeArray<quaternion> colliderFrameRotations;

			[ReadOnly]
			public NativeArray<float3> colliderFrameScales;

			[ReadOnly]
			public NativeArray<float3> colliderOldFramePositions;

			[ReadOnly]
			public NativeArray<quaternion> colliderOldFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderNowPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderNowRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<ColliderManager.WorkData> colliderWorkDataArray;

			public void Execute(int localIndex)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_B_Job : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			public float4 simulationPower;

			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<TeamWindData> teamWindArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			public int windZoneCount;

			[ReadOnly]
			public NativeArray<WindManager.WindData> windDataArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> oldPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> basePosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> baseRotArray;

			[ReadOnly]
			public NativeArray<float3> oldPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> oldRotationArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[ReadOnly]
			public NativeArray<float3> velocityArray;

			[ReadOnly]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> stepBasicPositionBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> stepBasicRotationBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_C_Job : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[ReadOnly]
			public NativeArray<int> vertexParentIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineStartDataIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineDataCounts;

			[ReadOnly]
			public NativeArray<ushort> baseLineData;

			[ReadOnly]
			public NativeArray<float3> vertexLocalPositions;

			[ReadOnly]
			public NativeArray<quaternion> vertexLocalRotations;

			[ReadOnly]
			public NativeArray<float3> basePosArray;

			[ReadOnly]
			public NativeArray<quaternion> baseRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> stepBasicPositionBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> stepBasicRotationBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_D_Job : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			public float4 simulationPower;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> basePosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[ReadOnly]
			public NativeArray<float> frictionArray;

			[ReadOnly]
			public NativeArray<uint> distanceIndexArray;

			[ReadOnly]
			public NativeArray<ushort> distanceDataArray;

			[ReadOnly]
			public NativeArray<float> distanceDistanceArray;

			[ReadOnly]
			public NativeArray<float3> stepBasicPositionBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_Angle_Job : IJobParallelFor
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
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[ReadOnly]
			public NativeArray<int> vertexParentIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineStartDataIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineDataCounts;

			[ReadOnly]
			public NativeArray<ushort> baseLineData;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[ReadOnly]
			public NativeArray<float> frictionArray;

			[ReadOnly]
			public NativeArray<uint> distanceIndexArray;

			[ReadOnly]
			public NativeArray<ushort> distanceDataArray;

			[ReadOnly]
			public NativeArray<float> distanceDistanceArray;

			[ReadOnly]
			public NativeArray<float3> stepBasicPositionBuffer;

			[ReadOnly]
			public NativeArray<quaternion> stepBasicRotationBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> tempRotationBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> tempRotationBufferB;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_Triangle_Job : IJobParallelFor
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
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float> frictionArray;

			[ReadOnly]
			public NativeArray<ulong> bendingTrianglePairArray;

			[ReadOnly]
			public NativeArray<float> bendingRestAngleOrVolumeArray;

			[ReadOnly]
			public NativeArray<sbyte> bendingSignOrVolumeArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_E_Job : IJobParallelFor
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
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> basePosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> collisionNormalArray;

			[ReadOnly]
			public NativeArray<ExBitFlag16> colliderFlagArray;

			[ReadOnly]
			public NativeArray<ColliderManager.WorkData> colliderWorkDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_Edge_Job : IJobParallelFor
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
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<int2> edges;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<ExBitFlag16> colliderFlagArray;

			[ReadOnly]
			public NativeArray<ColliderManager.WorkData> colliderWorkDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_F_Self_Job : IJobParallelFor
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
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[ReadOnly]
			public NativeArray<float3> basePosArray;

			[ReadOnly]
			public NativeArray<quaternion> baseRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> collisionNormalArray;

			[ReadOnly]
			public NativeArray<uint> distanceIndexArray;

			[ReadOnly]
			public NativeArray<ushort> distanceDataArray;

			[ReadOnly]
			public NativeArray<float> distanceDistanceArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_G_Self_Job : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[ReadOnly]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPosArray;

			[ReadOnly]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> realVelocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> staticFrictionArray;

			[ReadOnly]
			public NativeArray<float3> collisionNormalArray;

			[ReadOnly]
			public NativeArray<float3> colliderNowPositions;

			[ReadOnly]
			public NativeArray<quaternion> colliderNowRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldRotations;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitStep_FG_NoSelf_Job : IJobParallelFor
		{
			public int workerCount;

			public int updateIndex;

			public float4 simulationPower;

			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float> depthArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> nextPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPosArray;

			[ReadOnly]
			public NativeArray<float3> basePosArray;

			[ReadOnly]
			public NativeArray<quaternion> baseRotArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> velocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> realVelocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> frictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> staticFrictionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> collisionNormalArray;

			[ReadOnly]
			public NativeArray<float3> colliderNowPositions;

			[ReadOnly]
			public NativeArray<quaternion> colliderNowRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldPositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldRotations;

			[ReadOnly]
			public NativeArray<uint> distanceIndexArray;

			[ReadOnly]
			public NativeArray<ushort> distanceDataArray;

			[ReadOnly]
			public NativeArray<float> distanceDistanceArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferB;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> tempCountBuffer;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float> tempFloatBufferA;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPost_DisplayPos_Job : IJobParallelFor
		{
			public int workerCount;

			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<int> vertexRootIndices;

			[ReadOnly]
			public NativeArray<float3> oldPosArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> oldPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> oldRotationArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> dispPosArray;

			[ReadOnly]
			public NativeArray<float3> realVelocityArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> tempVectorBufferA;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> tempRotationBufferA;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPost_CalcProxy_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<ClothParameters> parameterArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<ushort> baseLineStartDataIndices;

			[ReadOnly]
			public NativeArray<ushort> baseLineDataCounts;

			[ReadOnly]
			public NativeArray<ushort> baseLineData;

			[ReadOnly]
			public NativeArray<float3> vertexLocalPositions;

			[ReadOnly]
			public NativeArray<quaternion> vertexLocalRotations;

			[ReadOnly]
			public NativeArray<uint> vertexChildIndexArray;

			[ReadOnly]
			public NativeArray<ushort> vertexChildDataArray;

			[ReadOnly]
			public NativeArray<ExBitFlag8> baseLineFlags;

			[ReadOnly]
			public NativeArray<float3> tempVectorBufferA;

			[ReadOnly]
			public NativeArray<quaternion> tempRotationBufferB;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPost_CalcProxyTriangle_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeArray<int3> triangles;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> triangleNormals;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> triangleTangents;

			[ReadOnly]
			public NativeArray<float2> uvs;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPost_SumProxyTriangleAndTransform_Job : IJobParallelFor
		{
			public int workerCount;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> transformPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> positions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> rotations;

			[ReadOnly]
			public NativeArray<float3> triangleNormals;

			[ReadOnly]
			public NativeArray<float3> triangleTangents;

			[ReadOnly]
			public NativeArray<FixedList32Bytes<uint>> vertexToTriangles;

			[ReadOnly]
			public NativeArray<quaternion> normalAdjustmentRotations;

			[ReadOnly]
			public NativeArray<quaternion> vertexToTransformRotations;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct SplitPost_TeamCollider_Job : IJobParallelFor
		{
			public float simulationDeltaTime;

			[ReadOnly]
			public NativeList<int> batchSelfTeamList;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<InertiaConstraint.CenterData> centerDataArray;

			[ReadOnly]
			public NativeArray<float3> colliderFramePositions;

			[ReadOnly]
			public NativeArray<quaternion> colliderFrameRotations;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> colliderOldFramePositions;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> colliderOldFrameRotations;

			[ReadOnly]
			public NativeArray<float3> transformPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> transformRotationArray;

			[ReadOnly]
			public NativeArray<float3> transformScaleArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<float3> transformLocalPositionArray;

			[NativeDisableParallelForRestriction]
			[NativeDisableContainerSafetyRestriction]
			public NativeArray<quaternion> transformLocalRotationArray;

			[ReadOnly]
			public NativeArray<VertexAttribute> attributes;

			[ReadOnly]
			public NativeArray<int> vertexParentIndices;

			public void Execute(int localIndex)
			{
			}
		}

		public ExNativeArray<short> teamIdArray;

		public ExNativeArray<float3> nextPosArray;

		public ExNativeArray<float3> oldPosArray;

		public ExNativeArray<quaternion> oldRotArray;

		public ExNativeArray<float3> basePosArray;

		public ExNativeArray<quaternion> baseRotArray;

		public ExNativeArray<float3> oldPositionArray;

		public ExNativeArray<quaternion> oldRotationArray;

		public ExNativeArray<float3> velocityPosArray;

		public ExNativeArray<float3> dispPosArray;

		public ExNativeArray<float3> velocityArray;

		public ExNativeArray<float3> realVelocityArray;

		public ExNativeArray<float> frictionArray;

		public ExNativeArray<float> staticFrictionArray;

		public ExNativeArray<float3> collisionNormalArray;

		public DistanceConstraint distanceConstraint;

		public TriangleBendingConstraint bendingConstraint;

		public TetherConstraint tetherConstraint;

		public AngleConstraint angleConstraint;

		public InertiaConstraint inertiaConstraint;

		public ColliderCollisionConstraint colliderCollisionConstraint;

		public MotionConstraint motionConstraint;

		public SelfCollisionConstraint selfCollisionConstraint;

		public NativeArray<float3> stepBasicPositionBuffer;

		public NativeArray<quaternion> stepBasicRotationBuffer;

		internal NativeArray<float3> tempVectorBufferA;

		internal NativeArray<float3> tempVectorBufferB;

		internal NativeArray<int> tempCountBuffer;

		internal NativeArray<float> tempFloatBufferA;

		internal NativeArray<quaternion> tempRotationBufferA;

		internal NativeArray<quaternion> tempRotationBufferB;

		internal int splitProxyMeshVertexCount;

		private bool isValid;

		public int ParticleCount => 0;

		internal int SimulationStepCount { get; private set; }

		internal int WorkerCount => 0;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		internal void RegisterProxyMesh(ClothProcess cprocess)
		{
		}

		internal void RegisterConstraint(ClothProcess cprocess)
		{
		}

		internal void ExitProxyMesh(ClothProcess cprocess)
		{
		}

		internal void WorkBufferUpdate()
		{
		}

		internal JobHandle ClothSimulationSchedule(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		public void InformationLog(StringBuilder allsb)
		{
		}

		private static void SimulationPreTeamUpdate(DataChunk chunk, ref TeamManager.TeamData tdata, in ClothParameters param, in InertiaConstraint.CenterData cdata, in NativeArray<float3> positions, in NativeArray<quaternion> rotations, in NativeArray<float> vertexDepths, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> oldPosArray, ref NativeArray<quaternion> oldRotArray, ref NativeArray<float3> basePosArray, ref NativeArray<quaternion> baseRotArray, ref NativeArray<float3> oldPositionArray, ref NativeArray<quaternion> oldRotationArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float3> dispPosArray, ref NativeArray<float3> velocityArray, ref NativeArray<float3> realVelocityArray, ref NativeArray<float> frictionArray, ref NativeArray<float> staticFrictionArray, ref NativeArray<float3> collisionNormalArray)
		{
		}

		private static float3 WindBatchJob(int teamId, in WindParams windParams, int vindex, int pindex, float depth, ref NativeArray<int> vertexRootIndices, ref TeamWindData teamWindData, ref NativeArray<WindManager.WindData> windDataArray, ref NativeArray<float> frictionArray)
		{
			return default(float3);
		}

		private static void SimulationStepUpdateParticles(DataChunk chunk, float4 simulationPower, float simulationDeltaTime, int teamId, ref TeamManager.TeamData tdata, ref InertiaConstraint.CenterData cdata, ref ClothParameters param, ref TeamWindData wdata, ref NativeArray<WindManager.WindData> windDataArray, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> depthArray, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations, ref NativeArray<int> vertexRootIndices, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> oldPosArray, ref NativeArray<float3> basePosArray, ref NativeArray<quaternion> baseRotArray, ref NativeArray<float3> oldPositionArray, ref NativeArray<quaternion> oldRotationArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float3> velocityArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> stepBasicPositionBuffer, ref NativeArray<quaternion> stepBasicRotationBuffer, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<float3> tempVectorBufferB, ref NativeArray<int> tempCountBuffer, ref NativeArray<float> tempFloatBufferA)
		{
		}

		private static void SpringBatchJob(in SpringConstraint.SpringConstraintParams springParams, ClothNormalAxis normalAxis, ref float3 nextPos, in float3 basePos, in quaternion baseRot, float noiseTime, float scaleRatio)
		{
		}

		private static void SimulationStepUpdateBaseLinePose(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<VertexAttribute> attributes, ref NativeArray<int> vertexParentIndices, ref NativeArray<ushort> baseLineStartDataIndices, ref NativeArray<ushort> baseLineDataCounts, ref NativeArray<ushort> baseLineData, ref NativeArray<float3> vertexLocalPositions, ref NativeArray<quaternion> vertexLocalRotations, ref NativeArray<float3> basePosArray, ref NativeArray<quaternion> baseRotArray, ref NativeArray<float3> stepBasicPositionBuffer, ref NativeArray<quaternion> stepBasicRotationBuffer)
		{
		}

		private static float3 WindForceBlendBatchJob(in TeamWindInfo windInfo, in WindParams windParams, in float3 windPos, float windTurbulence)
		{
			return default(float3);
		}

		private static void SimulationStepPostTeam(DataChunk chunk, float simulationDeltaTime, int teamId, ref TeamManager.TeamData tdata, ref InertiaConstraint.CenterData cdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> depthArray, ref NativeArray<float3> oldPosArray, ref NativeArray<float3> velocityArray, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float> staticFrictionArray, ref NativeArray<float3> collisionNormalArray, ref NativeArray<float3> realVelocityArray)
		{
		}

		private static void SimulationCalcDisplayPosition(DataChunk chunk, float simulationDeltaTime, ref TeamManager.TeamData tdata, ref NativeArray<float3> oldPosArray, ref NativeArray<float3> realVelocityArray, ref NativeArray<float3> oldPositionArray, ref NativeArray<quaternion> oldRotationArray, ref NativeArray<float3> dispPosArray, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations, ref NativeArray<int> vertexRootIndices, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<quaternion> tempRotationBufferA)
		{
		}

		private static void SimulationClearTempBuffer(DataChunk chunk, ref TeamManager.TeamData tdata, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<float3> tempVectorBufferB, ref NativeArray<int> tempCountBuffer, ref NativeArray<float> tempFloatBufferA)
		{
		}
	}
}
