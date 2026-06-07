using System;
using System.Collections.Generic;
using Simulator;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_MiniatureProducts : ISaveClass
	{
		public List<int> miniatureProducts;

		public List<float> unpaintedMarketPricePercentages;

		public List<float> paintedMarketPricePercentages;

		public void StartSaveProcess()
		{
			miniatureProducts = new List<int>();
			unpaintedMarketPricePercentages = new List<float>();
			paintedMarketPricePercentages = new List<float>();
		}

		public void SaveMiniatureProductMarketPricePercentages(int miniatureProductUID, float unpaintedMarketPricePercentage, float paintedMarketPricePercentage)
		{
			miniatureProducts.Add(miniatureProductUID);
			unpaintedMarketPricePercentages.Add(unpaintedMarketPricePercentage);
			paintedMarketPricePercentages.Add(paintedMarketPricePercentage);
		}
	}
}
