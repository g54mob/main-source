using System.Collections.Generic;
using UnityEngine;

public class MultitoolInspectorProperty
{
	public struct Indexer
	{
		public int x;

		public int y;

		public string key;
	}

	public ModuleProperty configuredProperty;

	public ModuleProperty runtimeProperty;

	public Indexer? indexer;

	public string name => null;

	public ModuleGestalt.Property definition => default(ModuleGestalt.Property);

	public MultitoolInspectorProperty(ModuleProperty configuredProperty, ModuleProperty runtimeProperty)
	{
	}

	public MultitoolInspectorProperty(MultitoolInspectorProperty property, Indexer indexer)
	{
	}

	public Data.Types GetDataType()
	{
		return default(Data.Types);
	}

	public Data.Container GetDataContainer()
	{
		return default(Data.Container);
	}

	public string GetDataTypeString()
	{
		return null;
	}

	public Indexer[] GetContainerIndexers()
	{
		return null;
	}

	public bool GetValueBoolean()
	{
		return false;
	}

	public void SetValueBoolean(bool value)
	{
	}

	public float GetValueNumber()
	{
		return 0f;
	}

	public void SetValueNumber(float value)
	{
	}

	public string GetValueString()
	{
		return null;
	}

	public void SetValueString(string value)
	{
	}

	public Color32 GetValueColor()
	{
		return default(Color32);
	}

	public void SetValueColor(Color32 value)
	{
	}

	public Data.Selection GetValueSelection()
	{
		return default(Data.Selection);
	}

	public void SetValueSelection(Data.Selection value)
	{
	}

	public string GetValueSelectionName()
	{
		return null;
	}

	public ModuleId GetValueModuleId()
	{
		return default(ModuleId);
	}

	public void SetValueModuleId(ModuleId value)
	{
	}

	public string GetValueModuleIdName()
	{
		return null;
	}

	public AssetReference GetValueAssetReference()
	{
		return default(AssetReference);
	}

	public void SetValueAsset(AssetReference value)
	{
	}

	public string GetValueAssetReferenceName()
	{
		return null;
	}

	public ICollection<Module> GetValueModuleIdOptions()
	{
		return null;
	}

	public Dictionary<int, string> GetValueSelectionOptions()
	{
		return null;
	}

	public ICollection<Asset> GetValueAssetReferenceOptions()
	{
		return null;
	}

	public InputSource GetValueInputSource()
	{
		return default(InputSource);
	}

	public void SetValueInputSource(InputSource value)
	{
	}

	public ICollection<IInputChip> GetValueInputChipOptions()
	{
		return null;
	}

	public string GetValueInputSourceName(bool shortName)
	{
		return null;
	}
}
