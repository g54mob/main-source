using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace PugMod
{
	public class ScriptableDataLoader : IScriptableDataLoader
	{
		private AssetBundle _assetBundle;

		private AssetBundleRequest _loadRequest;

		private bool _isLoaded;

		public bool HasDataBlockChanges => false;

		public bool LoadCompleted => _isLoaded;

		public float LoadCompletedPercentage => _loadRequest?.progress ?? 0f;

		public ScriptableDataLoader(AssetBundle assetBundle)
		{
			_assetBundle = assetBundle;
		}

		public async Task<IEnumerable<ScriptableDataBlock>> LoadAsync()
		{
			if (_isLoaded)
			{
				Debug.LogError("already loaded");
				return null;
			}
			_loadRequest = _assetBundle.LoadAllAssetsAsync<ScriptableDataBlock>();
			await _loadRequest;
			_isLoaded = true;
			return _loadRequest.allAssets.Cast<ScriptableDataBlock>();
		}

		public IEnumerable<ScriptableDataBlock> Load()
		{
			if (_isLoaded)
			{
				Debug.LogError("already loaded");
				return null;
			}
			_isLoaded = true;
			return _assetBundle.LoadAllAssets<ScriptableDataBlock>();
		}

		public void Unload()
		{
			_isLoaded = false;
		}
	}
}
