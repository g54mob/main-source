using System.Collections.Generic;

public class TooltipComponent_tower : TooltipComponent_pooled
{
	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { 
		{
			"tower",
			GetComponent<Tower>()
		} };
	}
}
