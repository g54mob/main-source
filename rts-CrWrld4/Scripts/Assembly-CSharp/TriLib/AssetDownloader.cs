using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace TriLib
{
	public class AssetDownloader : MonoBehaviour
	{
		public bool AutoStart;

		public string AssetURI;

		public int Timeout;

		public string AssetExtension;

		public GameObject WrapperGameObject;

		public bool ShowProgress;

		public bool Async;

		public AssimpInterop.ProgressCallback ProgressCallback;

		private UnityWebRequest _unityWebRequest;

		private GUIStyle _centeredStyle;

		private string _error;

		public bool HasStarted => false;

		public bool IsDone => false;

		public string Error => null;

		public float Progress => 0f;

		protected void Start()
		{
		}

		protected void OnGUI()
		{
		}

		public bool DownloadAsset(string assetURI, string assetExtension, ObjectLoadedHandle onAssetLoaded = null, TexturePreLoadHandle onTexturePreLoad = null, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return false;
		}

		private IEnumerator DoDownloadAsset(string assetUri, string assetExtension, ObjectLoadedHandle onAssetLoaded, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}
	}
}
