using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class AssetItem
	{
		public const string AddressableFolder = "UMA/";

		private Type _TheType;

		public string _BaseTypeName;

		public string _Name;

		public UnityEngine.Object _SerializedItem;

		public string _Path;

		public string _Guid;

		public string _Address;

		public bool IsResource;

		public bool IsAssetBundle;

		public bool IsAddressable;

		public bool IsAlwaysLoaded;

		public bool Ignore;

		public string AddressableGroup;

		public int Index;

		public string AddressableLabels;

		public int ReferenceCount;

		public string AddressableAddress
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type _Type => null;

		public UnityEngine.Object Item => null;

		public string _AssetBaseName => null;

		public string EvilName => null;

		public bool IsLoaded => false;

		public bool IsOverlayDataAsset => false;

		public bool IsSlotDataAsset => false;

		public AssetItem CreateSerializedItem(bool ForceItemSave)
		{
			return null;
		}

		public T GetItem<T>() where T : UnityEngine.Object
		{
			return null;
		}

		private UnityEngine.Object GetItem()
		{
			return null;
		}

		public UnityEngine.Object CacheSerializedItem()
		{
			return null;
		}

		public static string TranslatedName(string Name)
		{
			return null;
		}

		public static string GetEvilName(UnityEngine.Object o)
		{
			return null;
		}

		public void AddReference()
		{
		}

		public void FreeReference()
		{
		}

		public void ReleaseItem()
		{
		}

		public AssetItem(Type Type, string Name, string Path, UnityEngine.Object Item)
		{
		}

		public void Update()
		{
		}

		public AssetItem(Type Type, UnityEngine.Object Item)
		{
		}
	}
}
