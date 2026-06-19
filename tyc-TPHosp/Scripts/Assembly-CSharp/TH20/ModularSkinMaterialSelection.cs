using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Modular Skin Material Selection", order = 1027)]
	public class ModularSkinMaterialSelection : ScriptableObjectWithID
	{
		public enum Mode
		{
			Material = 0,
			MaterialSelection = 1
		}

		[Serializable]
		public class MaterialPair
		{
			public Material SkinMaterial;

			public Mode Mode;

			public Material Material;

			public ModularMaterialSelection MaterialSelection;
		}

		public List<MaterialPair> Materials = new List<MaterialPair>();

		public Material FindMatchingMaterial(Material skinMaterial)
		{
			foreach (MaterialPair material in Materials)
			{
				switch (material.Mode)
				{
				case Mode.Material:
					if (material.SkinMaterial == skinMaterial)
					{
						return material.Material;
					}
					break;
				case Mode.MaterialSelection:
					return material.MaterialSelection.GetRandomMaterial();
				}
			}
			return null;
		}
	}
}
