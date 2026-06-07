using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class MeshCombinerSimpleSTD : MeshCombinerBase
	{
		private MeshSeparatorSimple _meshSeparator;

		public MeshCombinerSimpleSTD()
		{
			_meshSeparator = new MeshSeparatorSimple();
		}

		protected override void CombineInternal(Mesh mesh, IList<MeshCombineInfo> infos)
		{
			CombineInstance[] array = new CombineInstance[infos.Count + 1];
			Mesh mesh2 = Object.Instantiate(mesh);
			array[0] = CreateCombineInstance(new MeshCombineInfo(mesh2));
			for (int i = 0; i < infos.Count; i++)
			{
				array[i + 1] = CreateCombineInstance(infos[i]);
			}
			mesh.CombineMeshes(array, mergeSubMeshes: true, useMatrices: true, hasLightmapData: true);
		}

		private CombineInstance CreateCombineInstance(MeshCombineInfo info)
		{
			Mesh mesh = info.mesh;
			if (mesh.subMeshCount > 1)
			{
				mesh = _meshSeparator.GetSubmesh(mesh, info.submeshIndex);
			}
			return new CombineInstance
			{
				mesh = mesh,
				subMeshIndex = 0,
				transform = info.transformMatrix,
				lightmapScaleOffset = info.lightmapScaleOffset,
				realtimeLightmapScaleOffset = info.realtimeLightmapScaleOffset
			};
		}
	}
}
