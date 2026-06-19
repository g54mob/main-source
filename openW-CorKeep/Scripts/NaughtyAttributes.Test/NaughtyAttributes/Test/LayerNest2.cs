using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public struct LayerNest2
	{
		[Layer]
		public int layerNumber2;

		[Layer]
		public string layerName2;
	}
}
