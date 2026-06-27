using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathMaterialsHandler : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer sonicBathMeshRenderer;

		[SerializeField]
		private Material animationLightsMaterialSample;

		[SerializeField]
		private Material environmentSonicBathUVMaterialSample;

		[SerializeField]
		private Material waterMaterialSample;

		public Material AnimationLightsMaterialInstance { get; private set; }

		public Material EnvironmentSonicBathUVMaterialInstance { get; private set; }

		public Material WaterMaterialInstance { get; private set; }

		private void Awake()
		{
			Material[] sharedMaterials = sonicBathMeshRenderer.sharedMaterials;
			Material[] materials = sonicBathMeshRenderer.materials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i] == animationLightsMaterialSample)
				{
					AnimationLightsMaterialInstance = materials[i];
				}
				else if (sharedMaterials[i] == waterMaterialSample)
				{
					WaterMaterialInstance = materials[i];
				}
				else if (sharedMaterials[i] == environmentSonicBathUVMaterialSample)
				{
					EnvironmentSonicBathUVMaterialInstance = materials[i];
				}
			}
			ValidateMaterial(AnimationLightsMaterialInstance, "animationLightsMaterialSample");
			ValidateMaterial(WaterMaterialInstance, "waterMaterialSample");
			ValidateMaterial(EnvironmentSonicBathUVMaterialInstance, "environmentSonicBathUVMaterialSample");
		}

		private static void ValidateMaterial(Material material, string fieldName)
		{
			if (!material)
			{
				Debug.LogError("[SonicBathMaterialsHandler] Material '" + fieldName + "' was not found. Check that the sample material is assigned in the inspector and present on the mesh.");
			}
		}
	}
}
