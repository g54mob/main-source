using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Data.ProductionHistory
{
	[Serializable]
	public class ProductionHistoryNode
	{
		[JsonProperty("fo")]
		public readonly List<int> FactoryObjectAmounts = new List<int>();

		[JsonProperty("rp")]
		public readonly List<int> ResourceProducedDeltas = new List<int>();

		[JsonProperty("rd")]
		public readonly List<int> ResourceDeliveredDeltas = new List<int>();

		public ProductionHistoryNode()
		{
		}

		public ProductionHistoryNode(ProductionHistoryNode previousNode)
		{
			FactoryObjectAmounts = new List<int>(previousNode.FactoryObjectAmounts);
			while (ResourceProducedDeltas.Count < previousNode.ResourceProducedDeltas.Count)
			{
				ResourceProducedDeltas.Add(0);
			}
			while (ResourceDeliveredDeltas.Count < previousNode.ResourceDeliveredDeltas.Count)
			{
				ResourceDeliveredDeltas.Add(0);
			}
		}

		public void Add(ProductionHistoryNode other)
		{
			for (int i = 0; i < other.FactoryObjectAmounts.Count; i++)
			{
				if (i >= FactoryObjectAmounts.Count)
				{
					FactoryObjectAmounts.Add(other.FactoryObjectAmounts[i]);
				}
				else
				{
					FactoryObjectAmounts[i] += other.FactoryObjectAmounts[i];
				}
			}
			for (int j = 0; j < other.ResourceProducedDeltas.Count; j++)
			{
				if (j >= ResourceProducedDeltas.Count)
				{
					ResourceProducedDeltas.Add(other.ResourceProducedDeltas[j]);
				}
				else
				{
					ResourceProducedDeltas[j] += other.ResourceProducedDeltas[j];
				}
			}
			for (int k = 0; k < other.ResourceDeliveredDeltas.Count; k++)
			{
				if (k >= ResourceDeliveredDeltas.Count)
				{
					ResourceDeliveredDeltas.Add(other.ResourceDeliveredDeltas[k]);
				}
				else
				{
					ResourceDeliveredDeltas[k] += other.ResourceDeliveredDeltas[k];
				}
			}
		}

		public void Divide(float value)
		{
			for (int i = 0; i < FactoryObjectAmounts.Count; i++)
			{
				FactoryObjectAmounts[i] = Mathf.RoundToInt((float)FactoryObjectAmounts[i] / value);
			}
			for (int j = 0; j < ResourceProducedDeltas.Count; j++)
			{
				ResourceProducedDeltas[j] = Mathf.RoundToInt((float)ResourceProducedDeltas[j] / value);
			}
			for (int k = 0; k < ResourceDeliveredDeltas.Count; k++)
			{
				ResourceDeliveredDeltas[k] = Mathf.RoundToInt((float)ResourceDeliveredDeltas[k] / value);
			}
		}
	}
}
