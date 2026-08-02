using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[CreateAssetMenu(menuName = "Rendering/GPU Instancer Pro/Material Variation Definition", order = 811)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:BestPractices#Prefab_Manager_Material_Variations")]
	public class GPUIMaterialVariationDefinition : ScriptableObject
	{
		[SerializeField]
		public Material material;

		[SerializeField]
		public Shader replacementShader;

		[SerializeField]
		public string bufferName = "variationBuffer";

		[SerializeField]
		public GPUIMVDefinitionItem[] items;

		public void AddVariation(int renderKey, int bufferIndex, Vector4 value)
		{
			GPUIMaterialVariationDataProvider.GetMaterialVariationData(this, renderKey).AddVariation(renderKey, bufferIndex, value);
		}
	}
}
