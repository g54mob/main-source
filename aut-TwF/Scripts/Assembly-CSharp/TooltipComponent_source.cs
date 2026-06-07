using System.Collections.Generic;

public class TooltipComponent_source : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { 
		{
			"source",
			GetComponent<Source>()
		} };
	}
}
