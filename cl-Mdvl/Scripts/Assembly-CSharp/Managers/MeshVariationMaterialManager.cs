using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
	public static class MeshVariationMaterialManager
	{
		private static bool dictionaryInit;

		private static Dictionary<string, Dictionary<string, List<Material>>> materialsPerMeshVariation;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			dictionaryInit = false;
			if (materialsPerMeshVariation == null)
			{
				return;
			}
			foreach (Dictionary<string, List<Material>> value in materialsPerMeshVariation.Values)
			{
				if (value == null)
				{
					continue;
				}
				foreach (List<Material> value2 in value.Values)
				{
					value2?.Clear();
				}
				value.Clear();
			}
			materialsPerMeshVariation.Clear();
			materialsPerMeshVariation = null;
		}

		public static List<Material> GetMaterials(Renderer renderer, string materialVariationsApplied)
		{
			if (!dictionaryInit)
			{
				materialsPerMeshVariation = new Dictionary<string, Dictionary<string, List<Material>>>();
				dictionaryInit = true;
			}
			if (!materialsPerMeshVariation.TryGetValue(materialVariationsApplied, out var value))
			{
				value = new Dictionary<string, List<Material>>();
				materialsPerMeshVariation.Add(materialVariationsApplied, value);
			}
			string name = renderer.name;
			if (!value.TryGetValue(name, out var value2))
			{
				List<Material> list = new List<Material>();
				value.Add(name, list);
				Material[] sharedMaterials = renderer.sharedMaterials;
				for (int i = 0; i < sharedMaterials.Length; i++)
				{
					Material item = new Material(sharedMaterials[i]);
					list.Add(item);
				}
				return list;
			}
			return value2;
		}
	}
}
