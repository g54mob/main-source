using System;
using System.Linq;
using System.Reflection;
using AwesomeTechnologies.Extensions;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Shaders
{
	public class ShaderSelector
	{
		public static IShaderController GetShaderControler(string shaderName)
		{
			Type interfaceType = typeof(IShaderController);
			foreach (IShaderController item in (from x in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly x) => x.GetLoadableTypes())
				where interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract
				select x).Select(Activator.CreateInstance))
			{
				if (item != null && item.MatchShader(shaderName))
				{
					return item;
				}
			}
			return new DefaultShaderController();
		}

		public static string GetShaderName(GameObject prefab)
		{
			MeshRenderer componentInChildren = MeshUtils.SelectMeshObject(prefab, LODLevel.LOD0).GetComponentInChildren<MeshRenderer>();
			if (!componentInChildren || !componentInChildren.sharedMaterial)
			{
				return "";
			}
			return componentInChildren.sharedMaterial.shader.name;
		}

		public static Material GetVegetationItemMaterial(GameObject prefab)
		{
			MeshRenderer componentInChildren = MeshUtils.SelectMeshObject(prefab, LODLevel.LOD0).GetComponentInChildren<MeshRenderer>();
			if (!componentInChildren || !componentInChildren.sharedMaterial)
			{
				return null;
			}
			return componentInChildren.sharedMaterial;
		}

		public static Material[] GetVegetationItemMaterials(GameObject prefab)
		{
			MeshRenderer componentInChildren = MeshUtils.SelectMeshObject(prefab, LODLevel.LOD0).GetComponentInChildren<MeshRenderer>();
			if (!componentInChildren || !componentInChildren.sharedMaterial)
			{
				return null;
			}
			return componentInChildren.sharedMaterials;
		}
	}
}
