using System;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	[AddComponentMenu("UniversalInventorySystem/Recipe")]
	[CreateAssetMenu(fileName = "Recipe", menuName = "UniversalInventorySystem/Recipe", order = 1)]
	public class Recipe : ScriptableObject
	{
		public int numberOfFactors;

		public Item[] factors;

		public int[] amountFactors;

		public int numberOfProducts;

		public Item[] products;

		public int[] amountProducts;

		public int id;

		public string key;
	}
}
