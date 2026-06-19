public class InventoryExitButton : StandardGUIElementLoader
{
	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		GetComponent<Clickable>().Unload();
		base.Unload(unloadCallback);
	}

	protected override void OnLoadComplete()
	{
		base.OnLoadComplete();
	}
}
