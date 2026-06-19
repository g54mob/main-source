using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Modular Material Selection", order = 1026)]
	public class ModularMaterialSelection : ScriptableObjectWithID
	{
		public enum Mode
		{
			Simple = 0,
			MeshBindings = 1
		}

		[Serializable]
		public class PossibleMaterial
		{
			[Range(0f, 1f)]
			public float Weight = 1f;

			public Mode Mode;

			public Material Material;

			public ModularMeshMaterialBindings MeshMaterialBindings;
		}

		public List<PossibleMaterial> Materials = new List<PossibleMaterial>();

		public Material GetRandomMaterial()
		{
			PossibleMaterial possibleMaterial = Materials.WeightedRandomItem((PossibleMaterial x) => x.Weight);
			if (possibleMaterial == null || possibleMaterial.Mode == Mode.MeshBindings)
			{
				return null;
			}
			return possibleMaterial.Material;
		}
	}
}
