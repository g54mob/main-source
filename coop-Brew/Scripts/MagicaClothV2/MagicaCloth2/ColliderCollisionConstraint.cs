using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class ColliderCollisionConstraint : IDisposable
	{
		public enum Mode
		{
			None = 0,
			Point = 1,
			Edge = 2
		}

		[Serializable]
		public class SerializeData : IDataValidate, ITransform
		{
			public Mode mode;

			[Range(0f, 0.5f)]
			public float friction;

			public List<ColliderComponent> colliderList;

			public List<Transform> collisionBones;

			public CurveSerializeData limitDistance;

			public int ColliderLength => 0;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public void GetUsedTransform(HashSet<Transform> transformSet)
			{
			}

			public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
			{
			}
		}

		public struct ColliderCollisionConstraintParams
		{
			public Mode mode;

			public float dynamicFriction;

			public float staticFriction;

			public float4x4 limitDistance;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		public void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal static void SolverPointConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> vertexDepths, ref NativeArray<float3> nextPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> collisionNormalArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float3> basePosArray, ref NativeArray<ExBitFlag16> colliderFlagArray, ref NativeArray<ColliderManager.WorkData> colliderWorkDataArray)
		{
		}

		private static float PointSphereColliderDetection(ref float3 nextpos, in float3 basePos, float radius, in AABB aabb, in ColliderManager.WorkData cwork, bool isSpring, float maxLength, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}

		private static float PointPlaneColliderDetction(ref float3 nextpos, float radius, in ColliderManager.WorkData cwork, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}

		private static float PointCapsuleColliderDetection(ref float3 nextpos, float radius, in AABB aabb, in ColliderManager.WorkData cwork, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}

		internal static void SolverEdgeConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> vertexDepths, ref NativeArray<int2> edges, ref NativeArray<float3> nextPosArray, ref NativeArray<ExBitFlag16> colliderFlagArray, ref NativeArray<ColliderManager.WorkData> colliderWorkDataArray, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<float3> tempVectorBufferB, ref NativeArray<int> tempCountBuffer, ref NativeArray<float> tempFloatBufferA)
		{
		}

		internal static void SumEdgeConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<float3> nextPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> collisionNormalArray, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<float3> tempVectorBufferB, ref NativeArray<int> tempCountBuffer, ref NativeArray<float> tempFloatBufferA)
		{
		}

		private static float EdgeSphereColliderDetection(ref float3x2 nextPosE, in float2 radiusE, in AABB aabbE, float cfr, in ColliderManager.WorkData cwork, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}

		private static float EdgeCapsuleColliderDetection(ref float3x2 nextPosE, in float2 radiusE, in AABB aabbE, float cfr, in ColliderManager.WorkData cwork, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}

		private static float EdgePlaneColliderDetection(ref float3x2 nextPosE, in float2 radiusE, in ColliderManager.WorkData cwork, out float3 normal)
		{
			normal = default(float3);
			return 0f;
		}
	}
}
