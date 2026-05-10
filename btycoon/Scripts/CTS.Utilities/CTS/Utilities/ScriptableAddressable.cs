using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS.Utilities
{
	[CreateAssetMenu(menuName = "CTS/Scriptable Addressable")]
	public class ScriptableAddressable : ScriptableObject
	{
		private abstract class AddressableLoader
		{
			protected Object _asset;

			private bool _loaded;

			public T Load<T>() where T : Object
			{
				if (!_loaded)
				{
					_loaded = true;
					_asset = LoadObject<T>();
				}
				return _asset as T;
			}

			protected abstract T LoadObject<T>();

			public abstract void ReleaseAsset();
		}

		private class AddressablePathLoader : AddressableLoader
		{
			private readonly string _path;

			public AddressablePathLoader(string path)
			{
				_path = path;
			}

			protected override T LoadObject<T>()
			{
				if (typeof(T).IsAssignableFrom(typeof(Component)))
				{
					return Addressables.LoadAssetAsync<GameObject>(_path).WaitForCompletion().GetComponent<T>();
				}
				return Addressables.LoadAssetAsync<T>(_path).WaitForCompletion();
			}

			public override void ReleaseAsset()
			{
				Addressables.Release((_asset is Component component) ? component.gameObject : _asset);
			}
		}

		private class AddressableRefLoader : AddressableLoader
		{
			private new readonly AssetReference _asset;

			public AddressableRefLoader(AssetReference asset)
			{
				_asset = asset;
			}

			protected override T LoadObject<T>()
			{
				if (typeof(T).IsAssignableFrom(typeof(Component)))
				{
					return Addressables.LoadAssetAsync<GameObject>(_asset).WaitForCompletion().GetComponent<T>();
				}
				return _asset.LoadAssetAsync<T>().WaitForCompletion();
			}

			public override void ReleaseAsset()
			{
				_asset.ReleaseAsset();
			}
		}

		[SerializeField]
		private bool _usePath;

		[SerializeField]
		[HideIf("_usePath")]
		private AssetReference _asset;

		[SerializeField]
		[ShowIf("_usePath")]
		private string _path;

		private AddressableLoader _loader;

		private AddressableLoader GetLoader()
		{
			return _loader ?? (_loader = (_usePath ? ((AddressableLoader)new AddressablePathLoader(_path)) : ((AddressableLoader)new AddressableRefLoader(_asset))));
		}

		private void OnDestroy()
		{
			_loader?.ReleaseAsset();
		}

		public T Load<T>() where T : Object
		{
			return GetLoader().Load<T>();
		}
	}
}
