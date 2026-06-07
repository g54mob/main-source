using System.Collections.Generic;
using UnityEngine;

public struct ProductionGraphColorConfig
{
	public List<Color> ProducedColors { get; }

	public List<Color> DeliveredColors { get; }

	public ProductionGraphColorConfig(List<Color> producedColors = null, List<Color> deliveredColors = null)
	{
		ProducedColors = producedColors;
		DeliveredColors = deliveredColors;
	}
}
