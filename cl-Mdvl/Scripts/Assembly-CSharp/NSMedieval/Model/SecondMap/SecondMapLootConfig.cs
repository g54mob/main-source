using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.UI;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.Model.SecondMap
{
	[Serializable]
	public class SecondMapLootConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<TraderStock> stocks;

		public override string GetID()
		{
			return id;
		}

		public List<ResourceInstance> GenerateResourceInstances(Unity.Mathematics.Random random)
		{
			List<ResourceInstance> list = new List<ResourceInstance>();
			foreach (TraderStock stock in stocks)
			{
				if (stock != null && (!(stock.Chance < 1f) || !(random.NextDouble() > (double)stock.Chance)))
				{
					stock.AddToList(list, random);
				}
			}
			return list;
		}
	}
}
