using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class SortingLayerNest1
	{
		[SortingLayer]
		public int layerNumber1;

		[SortingLayer]
		public string layerName1;

		public SortingLayerNest2 nest2;
	}
}
