using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UI.Common;
using UI.Elements;
using UnityEngine;

public abstract class Asset : IElementColoredButtonParameters, ILogOrigin
{
	[NonSerialized]
	[HideInInspector]
	public GCHandle gcHandle;

	public AssetSelector selector;

	public string name;

	public DateTime creationDate;

	public DateTime lastEditDate;

	public bool securityLock;

	public Dictionary<uint, Asset> subAssets;

	public Action<Asset> onParametersChange;

	public bool isSubAsset => false;

	public bool isBuiltin => false;

	public Asset parentAsset { get; private set; }

	public abstract AssetType GetAssetType();

	public abstract bool LoadFromFile(string path, Asset[] additionalInitAssets);

	public abstract SerializedAsset ToSerializedAsset();

	public Asset()
	{
	}

	public virtual void OnAddToContainer(AssetContainer container, ModuleId moduleId, uint mainId)
	{
	}

	public virtual void OnRemoveFromContainer()
	{
	}

	public Asset GetSubAsset(uint subId)
	{
		return null;
	}

	protected void AddSubAsset(uint subId, Asset asset)
	{
	}

	protected void RemoveSubAsset(uint subId)
	{
	}

	public T GetSubAsset<T>(uint subId) where T : Asset
	{
		return null;
	}

	public IntPtr GetPtr()
	{
		return (IntPtr)0;
	}

	public virtual void InitDefaultEditorAsset()
	{
	}

	public virtual void Dispose()
	{
	}

	public void OnChange()
	{
	}

	public void Rename(string name)
	{
	}

	public virtual Sprite GetAssetIcon()
	{
		return null;
	}

	public virtual GameObject GetAssetInspector()
	{
		return null;
	}

	public string GetButtonName()
	{
		return null;
	}

	public Sprite GetButtonIcon()
	{
		return null;
	}

	public Sprite GetButtonSprite(ElementParameters name)
	{
		return null;
	}

	public string GetButtonString(ElementParameters name)
	{
		return null;
	}

	public bool IsSecondaryColor()
	{
		return false;
	}

	public void AddOnButtonChangeAction(UnityEngine.Object owner, Action<IElementColoredButtonParameters> onChange)
	{
	}
}
