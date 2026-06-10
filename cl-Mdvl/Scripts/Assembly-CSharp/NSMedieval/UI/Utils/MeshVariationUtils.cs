using System.Collections.Generic;
using NSMedieval.Construction;

namespace NSMedieval.UI.Utils
{
	public static class MeshVariationUtils
	{
		private const string CountVariationsName = "CountVariations";

		private const string QualityVariationsName = "QualityVariations";

		private const string MaterialParametersName = "MaterialParameters";

		private const string ParticleMaterialParametersName = "ParticleMaterialParameters";

		private const string MeshVariationsName = "MeshVariations";

		public static bool GetMeshVariations(Dictionary<string, MeshVariationList> variationsById, out MeshVariationList variationList)
		{
			return variationsById.TryGetValue("MeshVariations", out variationList);
		}

		public static bool GetCountVariations(Dictionary<string, MeshVariationList> variationsById, out MeshVariationList variationList)
		{
			return variationsById.TryGetValue("CountVariations", out variationList);
		}

		public static bool GetQualityVariations(Dictionary<string, MeshVariationList> variationsById, out MeshVariationList variationList)
		{
			return variationsById.TryGetValue("QualityVariations", out variationList);
		}

		public static bool GetMaterialParameters(Dictionary<string, MeshVariationList> variationsById, out MeshVariationList variationList)
		{
			return variationsById.TryGetValue("MaterialParameters", out variationList);
		}

		public static bool GetParticleMaterialParameters(Dictionary<string, MeshVariationList> variationsById, out MeshVariationList variationList)
		{
			return variationsById.TryGetValue("ParticleMaterialParameters", out variationList);
		}
	}
}
