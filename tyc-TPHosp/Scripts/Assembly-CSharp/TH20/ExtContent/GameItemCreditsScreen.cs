using System.IO;

namespace TH20.ExtContent
{
	public class GameItemCreditsScreen : GameItemBase
	{
		public const string cKey_AssetBundleFileName = "AssetBundleFileName";

		public const string cKey_RootAssetName = "RootAssetName";

		private GameItemDataAssetBundle _itemDataAssetBundle;

		private string _assetBundleFileName;

		private string _rootAssetName;

		public GameItemDataAssetBundle ItemDataAssetBundle => _itemDataAssetBundle;

		public string AssetBundleFileName => _assetBundleFileName;

		public string RootAssetName => _rootAssetName;

		public override void Init(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			base.Init(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
			_itemDataAssetBundle = new GameItemDataAssetBundle();
		}

		public override void DeInit()
		{
			_itemDataAssetBundle?.DeInit();
			_itemDataAssetBundle = null;
			base.DeInit();
		}

		public void SetData(string assetBundleFileName, string rootAssetName)
		{
			_assetBundleFileName = assetBundleFileName;
			_rootAssetName = rootAssetName;
			OnDataUpdated();
		}

		public void UnloadDataAssetBundle()
		{
			_itemDataAssetBundle.UnloadAllAssets();
		}

		private void UpdateDataAssetBundle()
		{
			_itemDataAssetBundle.UnloadAllAssets();
			_itemDataAssetBundle.Init(base.ContentID, base.InstalledFolderPathSpec, _assetBundleFileName, _rootAssetName);
		}

		protected override bool UpdateFromMetaData()
		{
			bool result = false;
			if (base.UpdateFromMetaData())
			{
				result = base.GameItemMetaData.Get("AssetBundleFileName", ref _assetBundleFileName) && base.GameItemMetaData.Get("RootAssetName", ref _rootAssetName);
			}
			return result;
		}

		public override void UpdateMetaData()
		{
			base.UpdateMetaData();
			base.GameItemMetaData.Add("AssetBundleFileName", _assetBundleFileName);
			base.GameItemMetaData.Add("RootAssetName", _rootAssetName);
		}

		public override void OnDataUpdated()
		{
			base.OnDataUpdated();
			UpdateDataAssetBundle();
		}

		public override string GetLogInfoString()
		{
			string logInfoString = base.GetLogInfoString();
			string arg = ".../" + Path.GetFileName(_rootAssetName);
			return string.Concat(logInfoString + ", ", string.Format(ExtContentUtils.HiliteParams("Bundle:'{0}', Root:'{1}'"), _assetBundleFileName, arg));
		}

		public override GameItemDataBase GetGameItemDataBase()
		{
			return _itemDataAssetBundle;
		}
	}
}
