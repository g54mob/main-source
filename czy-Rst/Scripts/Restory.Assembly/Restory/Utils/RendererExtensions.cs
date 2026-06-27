using UnityEngine;

namespace Restory.Utils
{
	public static class RendererExtensions
	{
		public static int GetMaterialIndex(this Renderer renderer, Material originalMaterial)
		{
			Material[] sharedMaterials = renderer.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i].shader == originalMaterial.shader)
				{
					return i;
				}
			}
			return -1;
		}

		public static Material GetMaterialInstance(this Renderer renderer, Material originalMaterial)
		{
			int materialIndex = renderer.GetMaterialIndex(originalMaterial);
			if (materialIndex == -1)
			{
				return null;
			}
			return renderer.materials[materialIndex];
		}
	}
}
