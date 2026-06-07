using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class RenderData : IDisposable, ITransform
	{
		private HashSet<ClothProcess> useProcessSet;

		private bool isSkipWriting;

		internal RenderSetupData setupData;

		internal RenderSetupData.UniqueSerializationData preBuildUniqueSerializeData;

		private Renderer renderer;

		private SkinnedMeshRenderer skinnedMeshRendere;

		private MeshFilter meshFilter;

		public int ReferenceCount { get; private set; }

		internal string Name => null;

		internal bool HasSkinnedMesh => false;

		internal bool HasBoneWeight => false;

		internal Mesh originalMesh { get; private set; }

		internal List<Transform> transformList { get; private set; }

		internal Mesh customMesh { get; private set; }

		internal int renderDataWorkIndex { get; private set; }

		internal ResultCode Result => default(ResultCode);

		public void Dispose()
		{
		}

		public void GetUsedTransform(HashSet<Transform> transformSet)
		{
		}

		public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
		{
		}

		internal void Initialize(Renderer ren, RenderSetupData referenceSetupData, RenderSetupData.UniqueSerializationData referencePreBuildUniqueSetupData, RenderSetupSerializeData referenceInitSetupData)
		{
		}

		internal int AddReferenceCount()
		{
			return 0;
		}

		internal int RemoveReferenceCount()
		{
			return 0;
		}

		private void SwapCustomMesh(ClothProcess process)
		{
		}

		private void ResetCustomMeshWorkData()
		{
		}

		private void SwapOriginalMesh(ClothProcess process)
		{
		}

		private void SetMesh(Mesh mesh)
		{
		}

		public void StartUse(ClothProcess cprocess)
		{
		}

		public void EndUse(ClothProcess cprocess)
		{
		}

		internal void UpdateUse(ClothProcess cprocess, int add)
		{
		}

		internal void UpdateSkipWriting()
		{
		}

		internal void WriteMesh()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
