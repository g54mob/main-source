using System;
using System.Collections.Generic;
using System.Text;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace MagicaCloth2
{
	public class RenderManager : IManager, IDisposable, IValid
	{
		public struct RenderDataWork : IValid
		{
			public BitField32 flag;

			public DataChunk renderMeshPositionAndNormalChunk;

			public DataChunk renderMeshTangentChunk;

			public DataChunk renderMeshBoneWeightChunk;

			public BoneWeight centerBoneWeight;

			public FixedList32Bytes<short> mappingDataIndexList;

			public bool UseCustomMesh => false;

			public bool HasMeshTangent => false;

			public bool HasTangent => false;

			public bool HasBoneWeight => false;

			public bool IsValid()
			{
				return false;
			}

			public void AddMappingIndex(int mindex)
			{
			}

			public void RemoveMappingIndex(int mindex)
			{
			}
		}

		private Dictionary<MagicaObjectId, RenderData> renderDataDict;

		public const int RenderDataFlag_UseCustomMesh = 0;

		public const int RenderDataFlag_WritePositionNormal = 1;

		public const int RenderDataFlag_WriteBoneWeight = 2;

		public const int RenderDataFlag_HasMeshTangent = 4;

		public const int RenderDataFlag_HasTangent = 5;

		public const int RenderDataFlag_WriteTangent = 6;

		public const int RenderDataFlag_HasSkinnedMesh = 7;

		public const int RenderDataFlag_HasBoneWeight = 8;

		public ExNativeArray<RenderDataWork> renderDataWorkArray;

		public ExNativeArray<float3> renderMeshPositions;

		public ExNativeArray<float3> renderMeshNormals;

		public ExNativeArray<float4> renderMeshTangents;

		public ExNativeArray<BoneWeight> renderMeshBoneWeights;

		private bool isValid;

		private static readonly ProfilerMarker writeMeshTimeProfiler;

		public int RenderDataWorkCount => 0;

		public void Initialize()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Dispose()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public MagicaObjectId AddRenderer(Renderer ren, RenderSetupData referenceSetupData, RenderSetupData.UniqueSerializationData referenceUniqueSetupData, RenderSetupSerializeData referenceInitSetupData)
		{
			return default(MagicaObjectId);
		}

		public bool RemoveRenderer(MagicaObjectId handle)
		{
			return false;
		}

		public RenderData GetRendererData(MagicaObjectId handle)
		{
			return null;
		}

		public int AddRenderDataWork(RenderData rdata)
		{
			return 0;
		}

		public void RemoveRenderDataWork(int index)
		{
		}

		public ref RenderDataWork GetRenderDataWorkRef(int index)
		{
			throw null;
		}

		public bool IsSetRenderDataWorkFlag(int index, int flag)
		{
			return false;
		}

		public void SetBitsRenderDataWorkFlag(int index, int flag, bool sw)
		{
		}

		public void StartUse(ClothProcess cprocess, MagicaObjectId handle)
		{
		}

		public void EndUse(ClothProcess cprocess, MagicaObjectId handle)
		{
		}

		private void PreRenderingUpdate()
		{
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
