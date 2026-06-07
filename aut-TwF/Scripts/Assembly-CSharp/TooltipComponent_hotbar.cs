using System.Collections.Generic;

public class TooltipComponent_hotbar : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		GameplayObjectData hotbarAction = LTFunctionLibrary.GetLTPlayerController().GetHotbarAction(GetComponent<HotbarActionUI>().HotbarActionIdx);
		if ((bool)hotbarAction)
		{
			return new Dictionary<string, object> { { "gameplayObjectData", hotbarAction } };
		}
		return null;
	}
}
