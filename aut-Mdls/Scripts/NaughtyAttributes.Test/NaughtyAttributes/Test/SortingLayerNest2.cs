using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public struct SortingLayerNest2
	{
		[SortingLayer]
		public int layerNumber2;

		[SortingLayer]
		public string layerName2;
	}
}
