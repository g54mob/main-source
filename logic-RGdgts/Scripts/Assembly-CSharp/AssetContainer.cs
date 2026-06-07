using System.Collections.Generic;

public class AssetContainer
{
	public interface IListener
	{
		void OnAssetAddedToContainer(AssetContainer container, AssetSelector assetSelector);

		void OnAssetRemovedFromContainer(AssetContainer container, AssetSelector assetSelector);
	}

	public const string builtinNamePrefix = "Builtin/";

	private Dictionary<ModuleId, Dictionary<uint, Asset>> assets;

	private List<IListener> listeners;

	public uint lastEditableId;

	private static Dictionary<uint, Asset> emptyResult;

	public void AddListener(IListener listener)
	{
	}

	public void RemoveListener(IListener listener)
	{
	}

	public void AddEditable(Asset asset)
	{
	}

	public void AddBuiltinAsset(uint mainId, Asset asset)
	{
	}

	public void Add(ModuleId moduleId, uint mainId, Asset asset)
	{
	}

	public void Remove(AssetSelector assetSelector, bool dispose = true)
	{
	}

	public void Remove(ModuleId moduleId, uint mainId, bool dispose = true)
	{
	}

	public Asset Get(AssetSelector assetSelector)
	{
		return null;
	}

	public T Get<T>(AssetSelector assetSelector) where T : Asset
	{
		return null;
	}

	public T Get<T>(string name) where T : Asset
	{
		return null;
	}

	public Dictionary<uint, Asset> GetAssets<T>() where T : Asset
	{
		return null;
	}

	public List<Asset> GetAssets(AssetType assetType)
	{
		return null;
	}

	public List<Asset> GetAssets(IEnumerable<AssetType> assetTypes)
	{
		return null;
	}

	public Dictionary<uint, Asset> GetEditableAssets()
	{
		return null;
	}

	public Dictionary<uint, Asset> GetBuiltinAssets()
	{
		return null;
	}

	public Dictionary<uint, Asset> GetModuleAssets(ModuleId moduleId)
	{
		return null;
	}
}
