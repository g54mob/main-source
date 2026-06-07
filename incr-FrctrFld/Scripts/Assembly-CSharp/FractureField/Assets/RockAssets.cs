using System;
using System.Collections.Generic;
using FractureField.Rocks;

namespace FractureField.Assets
{
	[Serializable]
	public class RockAssets
	{
		public List<RockLayerData> RockLayerData;

		public Dictionary<RockLayerType, RockLayerData> LayerDataCache { get; private set; }

		public void Init()
		{
		}

		public RockLayerData GetLayerData(RockLayerType type)
		{
			return null;
		}
	}
}
