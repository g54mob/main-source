using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	public class Materials : SingletonScriptableObject<Materials>
	{
		[Serializable]
		public class MaterialInfo
		{
			public string Name;

			public Material Material;

			public VertexMaterialData Properties;

			public MaterialEffect Effect;

			public override string ToString()
			{
				return null;
			}
		}

		private const string STANDARD = "Standard";

		private const string GRAYSCALE = "Grayscale";

		private const string HUE_SATURATION_BRIGHTNESS = "Hue Saturation Brightness";

		private static readonly List<string> materialOrder;

		[SerializeField]
		private List<MaterialInfo> materials;

		private static string FilePath => null;

		private void OnEnable()
		{
		}

		private void EnsurePredefinedMaterials()
		{
		}

		private void AddIfNotPresent(string name, Func<MaterialEffect, MaterialInfo> CreateMaterial, params MaterialEffect[] preservedLayerEffects)
		{
		}

		private IEnumerator SetTogglePropertyDelayed(Material material, string toggleName, bool toggle)
		{
			return null;
		}

		public MaterialInfo GetMaterialInfo(string name, MaterialEffect e)
		{
			return null;
		}

		public Material GetMaterial(string name)
		{
			return null;
		}

		public List<string> GetAllMaterialNames()
		{
			return null;
		}

		public HashSet<MaterialEffect> GetAllMaterialEffects(string name)
		{
			return null;
		}
	}
}
