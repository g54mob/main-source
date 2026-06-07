using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Collections
{
	public class AssetCollection<T> : ScriptableObject
	{
		[Serializable]
		protected struct AssetCollectionEntry
		{
			[SerializeField]
			private string _assetId;

			[SerializeField]
			private T _assetReference;

			public T Asset => _assetReference;

			public string Id => _assetId;
		}

		[SerializeField]
		private string _assetCollectionName;

		private Dictionary<string, T> _assetDictionary;

		[SerializeField]
		private List<AssetCollectionEntry> _assets;

		public T GetAsset(string id, bool logErrors = true)
		{
			if (_assetDictionary == null)
			{
				_assetDictionary = new Dictionary<string, T>();
				if (_assets != null)
				{
					foreach (AssetCollectionEntry asset in _assets)
					{
						_assetDictionary.Add(asset.Id, asset.Asset);
					}
				}
			}
			if (_assetDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			if (logErrors)
			{
				Debug.LogError("The asset with id '" + id + "' could not be found in the asset collection '" + _assetCollectionName + "'.");
			}
			return default(T);
		}
	}
}
