using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Billboards
{
	public class BillboardShaderDetector
	{
		public static Shader GetDiffuceBillboardAtlasShader(GameObject prefab)
		{
			string shaderName = GetShaderName(prefab);
			if (shaderName.ToLower().Contains("speedtree"))
			{
				return Shader.Find("AwesomeTechnologies/Billboards/RenderDiffuseAtlasSpeedtree");
			}
			if (shaderName.ToLower().Contains("tree creator"))
			{
				return Shader.Find("AwesomeTechnologies/Billboards/RenderDiffuseAtlasTreeCreator");
			}
			if (shaderName.Contains("CTI"))
			{
				return Shader.Find("AwesomeTechnologies/Billboards/RenderDiffuseAtlasCTI");
			}
			return Shader.Find("AwesomeTechnologies/Billboards/RenderDiffuseAtlasNormal");
		}

		public static Shader GetNormalBillboardAtlasShader(GameObject prefab)
		{
			string shaderName = GetShaderName(prefab);
			if (shaderName.ToLower().Contains("tree creator"))
			{
				return Shader.Find("AwesomeTechnologies/Billboards/RenderNormalsAtlasTreeCreator");
			}
			if (shaderName.Contains("CTI"))
			{
				return Shader.Find("AwesomeTechnologies/Billboards/RenderNormalsAtlasCTI");
			}
			return Shader.Find("AwesomeTechnologies/Billboards/RenderNormalsAtlas");
		}

		private static string GetShaderName(GameObject prefab)
		{
			MeshRenderer componentInChildren = MeshUtils.SelectMeshObject(prefab, LODLevel.LOD0).GetComponentInChildren<MeshRenderer>();
			if (!componentInChildren || !componentInChildren.sharedMaterial)
			{
				return "";
			}
			return componentInChildren.sharedMaterial.shader.name;
		}
	}
}
