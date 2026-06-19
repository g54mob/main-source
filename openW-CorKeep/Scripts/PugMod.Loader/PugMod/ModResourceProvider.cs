using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace PugMod
{
	public class ModResourceProvider : ResourceProviderBase, IResourceLocator, IDisposable
	{
		private struct AssetLocation
		{
			public UnityEngine.Object asset;

			public IResourceLocation location;

			public string[] labels;
		}

		private string _locatorId;

		private Dictionary<string, AssetLocation> _assets = new Dictionary<string, AssetLocation>();

		private Dictionary<string, List<IResourceLocation>> _labels = new Dictionary<string, List<IResourceLocation>>();

		private Dictionary<string, int> _refCount = new Dictionary<string, int>();

		public string LocatorId => _locatorId;

		public IEnumerable<object> Keys => _assets.Keys;

		public IEnumerable<IResourceLocation> AllLocations => _assets.Select((KeyValuePair<string, AssetLocation> x) => x.Value.location);

		public ModResourceProvider()
		{
			_locatorId = Guid.NewGuid().ToString("N");
			Initialize(_locatorId, null);
			Addressables.ResourceManager.ResourceProviders.Add(this);
			Addressables.AddResourceLocator(this);
		}

		public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
		{
			locations = null;
			if (!(key is string key2))
			{
				return false;
			}
			if (_labels.TryGetValue(key2, out var value))
			{
				locations = value;
				return true;
			}
			if (_assets.TryGetValue(key2, out var value2) && (type == null || type.IsAssignableFrom(value2.asset.GetType())))
			{
				locations = new List<IResourceLocation> { value2.location };
				return true;
			}
			return false;
		}

		public void AddAsset(string key, UnityEngine.Object asset, params string[] labels)
		{
			if (_assets.ContainsKey(key))
			{
				AssetLocation assetLocation = _assets[key];
				Debug.LogError("Added second asset " + asset.name + " (existing: " + assetLocation.asset.name + ") with guid " + key + ", ignored");
				return;
			}
			ResourceLocationBase location = new ResourceLocationBase(asset.name, key, m_ProviderId, asset.GetType());
			AssetLocation value = new AssetLocation
			{
				asset = asset,
				location = location,
				labels = labels
			};
			_assets.Add(key, value);
			foreach (string key2 in labels)
			{
				if (!_labels.TryGetValue(key2, out var value2))
				{
					value2 = new List<IResourceLocation>();
					_labels.Add(key2, value2);
				}
				value2.Add(value.location);
			}
		}

		public void RemoveAsset(string key, UnityEngine.Object asset)
		{
			if (!_assets.TryGetValue(key, out var value))
			{
				Debug.LogError(asset.name + " with key " + key + ", wasn't added, can't remove");
				return;
			}
			if (value.asset != asset)
			{
				Debug.LogError("tried to remove asset " + asset.name + ", but doesn't match existing asset " + value.asset.name);
				return;
			}
			if (_refCount.TryGetValue(key, out var value2) && value2 > 0)
			{
				Debug.LogError("Released asset with key " + key + " while in use by addressables. This might result in crashes and/or bugs.");
			}
			else if (value2 < 0)
			{
				Debug.LogError($"Released asset with key {key}, got ref count < 0: {value2} (double release?)");
			}
			_assets.Remove(key);
		}

		public override bool CanProvide(Type t, IResourceLocation location)
		{
			return true;
		}

		public override void Provide(ProvideHandle provideHandle)
		{
			string internalId = provideHandle.Location.InternalId;
			if (!_assets.TryGetValue(internalId, out var value))
			{
				provideHandle.Complete<UnityEngine.Object>(null, status: false, new Exception("ModResourceProvider: Asset not found with key: " + internalId));
				return;
			}
			if (!_refCount.TryAdd(internalId, 1))
			{
				_refCount[internalId]++;
			}
			provideHandle.Complete(value.asset, status: true, null);
		}

		public override void Release(IResourceLocation location, object asset)
		{
			string internalId = location.InternalId;
			_refCount[internalId]--;
		}

		public void Dispose()
		{
			Addressables.RemoveResourceLocator(this);
			Addressables.ResourceManager.ResourceProviders.Remove(this);
		}
	}
}
