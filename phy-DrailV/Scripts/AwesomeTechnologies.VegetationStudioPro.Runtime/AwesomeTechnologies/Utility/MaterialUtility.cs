using System;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	public class MaterialUtility
	{
		public static void EnableMaterialInstancing(GameObject go)
		{
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material[] sharedMaterials = componentsInChildren[i].sharedMaterials;
				foreach (Material material in sharedMaterials)
				{
					if (!material.enableInstancing)
					{
						try
						{
							material.enableInstancing = true;
						}
						catch (Exception value)
						{
							Console.WriteLine(value);
							throw;
						}
					}
				}
			}
		}

		public static void ChangeShader(GameObject go, Shader shader)
		{
			MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				Material[] array = new Material[meshRenderer.sharedMaterials.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = new Material(meshRenderer.sharedMaterials[j]);
					array[j].shader = shader;
				}
				meshRenderer.sharedMaterials = array;
			}
		}

		public static void ChangeShader(Material[] materials, Shader shader)
		{
			for (int i = 0; i < materials.Length; i++)
			{
				if ((bool)materials[i])
				{
					materials[i].shader = shader;
				}
			}
		}
	}
}
