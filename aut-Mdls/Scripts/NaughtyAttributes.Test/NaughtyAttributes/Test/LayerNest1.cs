using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class LayerNest1
	{
		[Layer]
		public int layerNumber1;

		[Layer]
		public string layerName1;

		public LayerNest2 nest2;
	}
}
