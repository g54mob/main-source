using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class MeshVariationList
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private bool isRandom;

		[SerializeField]
		private bool hideInUI;

		[SerializeField]
		private List<MeshVariation> variations;

		private HashSet<string> variationsCache;

		public string Name => name;

		public List<MeshVariation> Variations => variations;

		private HashSet<string> VariationsCache
		{
			get
			{
				if (variationsCache == null)
				{
					variationsCache = new HashSet<string>();
					foreach (MeshVariation variation in variations)
					{
						variationsCache.Add(variation.Name);
					}
				}
				return variationsCache;
			}
		}

		public bool IsRandom => isRandom;

		public bool HideInUI => hideInUI;

		public bool ContainsVariation(string variation)
		{
			return VariationsCache.Contains(variation);
		}
	}
}
