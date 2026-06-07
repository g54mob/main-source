using System.Collections.Generic;
using UnityEngine;

namespace DV.ShaderStripping
{
	[CreateAssetMenu(fileName = "ShaderStrippingConfig", menuName = "DV/Shader Stripping Config")]
	public class ShaderStrippingConfig : ScriptableObject
	{
		public bool strippingEnabled = true;

		public List<ShaderVariantCollection> sources = new List<ShaderVariantCollection>();

		public List<string> shaderNamesOfInterest = new List<string>();

		public List<string> stripAllVariantsForTheseShaders = new List<string>();

		public List<VariantsForShader> variantsToKeep = new List<VariantsForShader>();

		public bool usePostProcessing = true;

		public PostProcessingKeyword usedPostProcessingEffects;
	}
}
