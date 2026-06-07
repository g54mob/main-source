using System;
using System.Collections.Generic;
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

		[SerializeField]
		public bool isCrowdAnimations;

		[NonSerialized]
		private Dictionary<int, int> _hashDict;

		public void AddVariation(int renderKey, int bufferIndex, Vector4 value)
		{
			if (_hashDict == null)
			{
				_hashDict = new Dictionary<int, int>();
			}
			if (!_hashDict.TryGetValue(renderKey, out var value2))
			{
				value2 = GPUIUtility.GenerateHash(GetInstanceID(), renderKey);
				_hashDict.Add(renderKey, value2);
			}
			GPUIMaterialVariationDataProvider.GetMaterialVariationDataWithHash(this, value2).AddVariation(renderKey, bufferIndex, value);
		}
	}
}
