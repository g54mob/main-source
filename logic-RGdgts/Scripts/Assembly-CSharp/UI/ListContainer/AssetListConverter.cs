using System.Collections.Generic;
using UI.Elements;

namespace UI.ListContainer
{
	public class AssetListConverter
	{
		private Gadget gadget => null;

		public List<ButtonsParametersAndPrefabIndex> GetParametersFromAssetDict(Dictionary<uint, Asset> assetsDict)
		{
			return null;
		}

		public List<string> GetExtentionFromAssetsDict(Dictionary<uint, Asset> assetsDict)
		{
			return null;
		}

		public ElementColoredButtonParameters GetParametersFromAsset(Asset asset)
		{
			return null;
		}

		public List<ButtonsParametersAndPrefabIndex> GetParametersFromAssetList(List<Asset> assets)
		{
			return null;
		}

		public string GetIdFromAsset(Asset asset)
		{
			return null;
		}

		private string GetDictIdFromMetadata(SerializedGadgetMetaData metadata)
		{
			return null;
		}

		private string GetDictIdFromSampleMetadata(SerializedGadgetMetaData metadata)
		{
			return null;
		}

		public ElementColoredButtonParameters GetParametersFromGadget(SerializedGadgetMetaData gadget)
		{
			return null;
		}
	}
}
