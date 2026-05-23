using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using UnityEngine;

namespace Data.Variables.Recipes
{
	[Serializable]
	public struct ResourceRecipe
	{
		[Serializable]
		public struct Output
		{
			public ResourceDataSO resourceDataSO;

			[SerializeField]
			private ShapeDataSO shapeData;

			public int OutputBeltIndex;

			[SerializeField]
			private int Amount;

			[SerializeField]
			private IntVariableSO VariableAmount;

			public int OutputAmount
			{
				get
				{
					if (!(VariableAmount == null))
					{
						return VariableAmount.Value;
					}
					return Amount;
				}
			}

			public ShapeData ShapeData
			{
				get
				{
					if (!(shapeData != null))
					{
						return null;
					}
					return shapeData.Data;
				}
			}

			public ShapeHashPair ShapeHash
			{
				get
				{
					if (!(shapeData != null))
					{
						return default(ShapeHashPair);
					}
					return shapeData.GetShapeHash();
				}
			}
		}

		public SerializedDictionary<ResourceDataSO, int> Inputs;

		public List<Output> Outputs;

		public static bool operator ==(ResourceRecipe recipe1, ResourceRecipe recipe2)
		{
			if (recipe1.Outputs.Count != recipe2.Outputs.Count || recipe1.Inputs.Count != recipe2.Inputs.Count)
			{
				return false;
			}
			for (int i = 0; i < recipe1.Outputs.Count; i++)
			{
				Output output = recipe1.Outputs[i];
				Output output2 = recipe2.Outputs[i];
				if (output.resourceDataSO != output2.resourceDataSO || output.ShapeHash != output2.ShapeHash || output.OutputAmount != output2.OutputAmount || output.OutputBeltIndex != output2.OutputBeltIndex)
				{
					return false;
				}
			}
			foreach (KeyValuePair<ResourceDataSO, int> input in recipe1.Inputs)
			{
				if (!recipe2.Inputs.TryGetValue(input.Key, out var value))
				{
					return false;
				}
				if (input.Value != value)
				{
					return false;
				}
			}
			return true;
		}

		public static bool operator !=(ResourceRecipe recipe1, ResourceRecipe recipe2)
		{
			return !(recipe1 == recipe2);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
