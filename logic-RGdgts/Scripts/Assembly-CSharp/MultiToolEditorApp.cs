using UI.Apps;

public abstract class MultiToolEditorApp : MultiToolApp
{
	private Asset asset;

	protected void SetAsset(Asset asset)
	{
	}

	public virtual void EditAsset(Asset asset)
	{
	}

	public void OnAssetChange()
	{
	}
}
