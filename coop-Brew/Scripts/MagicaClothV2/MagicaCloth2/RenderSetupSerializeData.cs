using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public class RenderSetupSerializeData : ITransform
	{
		[BurstCompile]
		private struct CalcUseBoneArrayJob2 : IJob
		{
			public int boneCount;

			[ReadOnly]
			public NativeArray<BoneWeight1> boneWeightArray;

			public NativeList<int> useBoneIndexList;

			public void Execute()
			{
			}
		}

		public RenderSetupData.SetupType setupType;

		public int vertexCount;

		public bool hasSkinnedMesh;

		public bool hasBoneWeight;

		public int skinRootBoneIndex;

		public int renderTransformIndex;

		public int skinBoneCount;

		public int transformCount;

		public int useTransformCount;

		public int[] useTransformIndexArray;

		public Transform[] transformArray;

		public float3[] transformPositions;

		public quaternion[] transformRotations;

		public float3[] transformLocalPositions;

		public quaternion[] transformLocalRotations;

		public float3[] transformScales;

		public float4x4 initRenderLocalToWorld;

		public float4x4 initRenderWorldtoLocal;

		public quaternion initRenderRotation;

		public float3 initRenderScale;

		public Mesh originalMesh;

		public bool DataValidateMeshCloth(Renderer ren)
		{
			return false;
		}

		public bool DataValidateBoneCloth(ClothSerializeData sdata, RenderSetupData.SetupType clothType)
		{
			return false;
		}

		public bool DataValidateTransform()
		{
			return false;
		}

		public bool Serialize(RenderSetupData sd)
		{
			return false;
		}

		public int GetLocalHash()
		{
			return 0;
		}

		public int GetGlobalHash()
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
}
