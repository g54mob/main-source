using System.Collections.Generic;

public class TooltipComponent_snowfallInfo : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		SnowfallControllerUI componentInParent = GetComponentInParent<SnowfallControllerUI>();
		return new Dictionary<string, object> { { "snowfallController", componentInParent.SnowfallController } };
	}
}
