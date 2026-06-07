using System.Collections.Generic;

public class TooltipComponent_processor : TooltipComponent_pooled
{
	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { 
		{
			"processor",
			GetComponent<Processor>()
		} };
	}
}
