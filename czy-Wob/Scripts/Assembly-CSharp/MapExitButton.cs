public class MapExitButton : StandardGUIElementLoader
{
	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		GetComponent<Clickable>().Unload();
		base.Unload(unloadCallback);
	}

	protected override void OnLoadComplete()
	{
		base.OnLoadComplete();
		base.gameObject.AddComponent<Clickable>().SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
	}
}
