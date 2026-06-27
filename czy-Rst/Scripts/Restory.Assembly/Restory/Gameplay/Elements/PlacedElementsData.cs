using System;
using System.Collections.Generic;

namespace Restory.Gameplay.Elements
{
	[Serializable]
	public class PlacedElementsData
	{
		public bool IsEmpty
		{
			get
			{
				if (ElementsOnSurface.Count == 0)
				{
					return ElementsInBin.Count == 0;
				}
				return false;
			}
		}

		public List<ElementTransformData> ElementsOnSurface { get; set; } = new List<ElementTransformData>();

		public List<ElementTransformData> ElementsInBin { get; set; } = new List<ElementTransformData>();
	}
}
