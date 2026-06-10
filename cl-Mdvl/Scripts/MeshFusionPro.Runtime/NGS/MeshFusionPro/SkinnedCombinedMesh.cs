using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class SkinnedCombinedMesh : IDisposable
	{
		private CombinedMesh _combinedMesh;

		private SkinnedMeshAdditionalCombiner _additionalCombiner;

		public Mesh Mesh => _combinedMesh.Mesh;

		public List<Transform> Bones => _additionalCombiner.Bones;

		public SkinnedCombinedMesh()
		{
			_combinedMesh = new CombinedMesh(new MeshCombinerSimpleSTD(), new MeshCutterSimpleSTD());
			_additionalCombiner = new SkinnedMeshAdditionalCombiner();
		}

		public CombinedMeshPart[] Combine(IList<SkinnedMeshCombineInfo> skinnedMeshCombineInfos)
		{
			MeshCombineInfo[] array = new MeshCombineInfo[skinnedMeshCombineInfos.Count];
			for (int i = 0; i < skinnedMeshCombineInfos.Count; i++)
			{
				array[i] = skinnedMeshCombineInfos[i].MeshCombineInfo;
			}
			CombinedMeshPart[] result = _combinedMesh.Combine(array);
			_additionalCombiner.Combine(skinnedMeshCombineInfos);
			_additionalCombiner.Apply(Mesh);
			return result;
		}

		public void Cut(IList<CombinedMeshPart> parts)
		{
			_additionalCombiner.Cut(parts);
			_combinedMesh.Cut(parts);
			_additionalCombiner.Apply(Mesh);
		}

		public void Dispose()
		{
			_combinedMesh.Dispose();
		}
	}
}
