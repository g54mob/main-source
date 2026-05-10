public class HotbarAction_building : HotbarAction
{
	public HotbarAction_building(object data)
		: base(data)
	{
	}

	public override bool DoAction()
	{
		GameplayObjectData objectToBuy = base.Data as GameplayObjectData;
		LTFunctionLibrary.GetLTPlayerController().StartBuyingObject(objectToBuy);
		return true;
	}
}
