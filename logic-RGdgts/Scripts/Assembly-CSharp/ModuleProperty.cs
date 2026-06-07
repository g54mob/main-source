using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ModuleProperty
{
	public class Storage
	{
		public Data data;
	}

	public GCHandle gcHandle;

	private Data _data;

	private bool _isRuntime;

	private ModuleGestalt.Property _definition;

	private int _id;

	public FloatRange limits;

	public Module module { get; private set; }

	public ModuleGestalt.Property definition => default(ModuleGestalt.Property);

	public int id => 0;

	public int ownedAssetIndex { get; set; }

	public bool dontCopyAsset { get; set; }

	public ModuleProperty(ModuleGestalt.Property definition, Module module, int id, bool isRuntime)
	{
	}

	public void CleanUp()
	{
	}

	private void RunPostUpdateSteps()
	{
	}

	public FloatRange GetLimits()
	{
		return default(FloatRange);
	}

	public Data.Container GetDataContainer()
	{
		return default(Data.Container);
	}

	public Data.Types GetDataType()
	{
		return default(Data.Types);
	}

	private bool IsLegal(Data value)
	{
		return false;
	}

	public Data GetValue()
	{
		return null;
	}

	public bool GetValueBoolean()
	{
		return false;
	}

	public Color32 GetValueColor()
	{
		return default(Color32);
	}

	public uint GetValueColorAsInt()
	{
		return 0u;
	}

	public Vector2 GetValueVector2()
	{
		return default(Vector2);
	}

	public Vector3 GetValueVector3()
	{
		return default(Vector3);
	}

	public float GetValueNumberAsFloat()
	{
		return 0f;
	}

	public float GetValueNumberAsAngle()
	{
		return 0f;
	}

	public int GetValueNumberAsInteger()
	{
		return 0;
	}

	public float GetValueNumberFromPercentage()
	{
		return 0f;
	}

	public Data.NumberDecorators GetValueNumberDecorator()
	{
		return default(Data.NumberDecorators);
	}

	public Data.Selection GetValueSelection()
	{
		return default(Data.Selection);
	}

	public AssetReference GetValueAssetReference()
	{
		return default(AssetReference);
	}

	public Asset GetValueAsset()
	{
		return null;
	}

	public string GetValueString()
	{
		return null;
	}

	public ModuleId GetValueModuleId()
	{
		return default(ModuleId);
	}

	public InputSource GetValueInputSource()
	{
		return default(InputSource);
	}

	public bool[] GetValueBooleanArray()
	{
		return null;
	}

	public bool GetValueBooleanArray(int index)
	{
		return false;
	}

	public Color32[] GetValueColorArray()
	{
		return null;
	}

	public uint[] GetValueColorArrayAsInt()
	{
		return null;
	}

	public Color32 GetValueColorArray(int index)
	{
		return default(Color32);
	}

	public uint GetValueColorArrayAsInt(int index)
	{
		return 0u;
	}

	public Vector2[] GetValueVector2Array()
	{
		return null;
	}

	public Vector2 GetValueVector2Array(int index)
	{
		return default(Vector2);
	}

	public Vector3[] GetValueVector3Array()
	{
		return null;
	}

	public Vector3 GetValueVector3Array(int index)
	{
		return default(Vector3);
	}

	public float[] GetValueNumberArray()
	{
		return null;
	}

	public float GetValueNumberArray(int index)
	{
		return 0f;
	}

	public Data.Selection[] GetValueSelectionArray()
	{
		return null;
	}

	public Data.Selection GetValueSelectionArray(int index)
	{
		return default(Data.Selection);
	}

	public ModuleId[] GetValueModuleIdArray()
	{
		return null;
	}

	public ModuleId GetValueModuleIdArray(int index)
	{
		return default(ModuleId);
	}

	public AssetReference[] GetValueAssetArray()
	{
		return null;
	}

	public AssetReference GetValueAssetArray(int index)
	{
		return default(AssetReference);
	}

	public string[] GetValueStringArray()
	{
		return null;
	}

	public string GetValueStringArray(int index)
	{
		return null;
	}

	public InputSource[] GetValueInputSourceArray()
	{
		return null;
	}

	public InputSource GetValueInputSourceArray(int index)
	{
		return default(InputSource);
	}

	public bool[,] GetValueBooleanMatrix2D()
	{
		return null;
	}

	public bool GetValueBooleanMatrix2D(int x, int y)
	{
		return false;
	}

	public Color32[,] GetValueColorMatrix2D()
	{
		return null;
	}

	public Color GetValueColorMatrix2D(int x, int y)
	{
		return default(Color);
	}

	public uint GetValueColorMatrix2DAsInt(int x, int y)
	{
		return 0u;
	}

	public Vector2[,] GetValueVector2Matrix2D()
	{
		return null;
	}

	public Vector2 GetValueVector2Matrix2D(int x, int y)
	{
		return default(Vector2);
	}

	public Vector3[,] GetValueVector3Matrix2D()
	{
		return null;
	}

	public Vector3 GetValueVector3Matrix2D(int x, int y)
	{
		return default(Vector3);
	}

	public float[,] GetValueNumberMatrix2D()
	{
		return null;
	}

	public float GetValueNumberMatrix2D(int x, int y)
	{
		return 0f;
	}

	public Data.Selection[,] GetValueSelectionMatrix2D()
	{
		return null;
	}

	public Data.Selection GetValueSelectionMatrix2D(int x, int y)
	{
		return default(Data.Selection);
	}

	public string[,] GetValueStringMatrix2D()
	{
		return null;
	}

	public string GetValueStringMatrix2D(int x, int y)
	{
		return null;
	}

	public InputSource[,] GetValueInputSOurceMatrix2D()
	{
		return null;
	}

	public InputSource GetValueInputSourceMatrix2D(int x, int y)
	{
		return default(InputSource);
	}

	public Dictionary<string, bool> GetValueBooleanDictionary()
	{
		return null;
	}

	public bool GetValueBooleanDictionary(string key)
	{
		return false;
	}

	public Dictionary<string, Color32> GetValueColorDictionary()
	{
		return null;
	}

	public Color GetValueColorDictionary(string key)
	{
		return default(Color);
	}

	public uint GetValueColorDictionaryAsInt(string key)
	{
		return 0u;
	}

	public Dictionary<string, Vector2> GetValueVector2Dictionary()
	{
		return null;
	}

	public Vector2 GetValueVector2Dictionary(string key)
	{
		return default(Vector2);
	}

	public Dictionary<string, Vector3> GetValueVector3Dictionary()
	{
		return null;
	}

	public Vector3 GetValueVector3Dictionary(string key)
	{
		return default(Vector3);
	}

	public Dictionary<string, float> GetValueNumberDictionary()
	{
		return null;
	}

	public float GetValueNumberDictionary(string key)
	{
		return 0f;
	}

	public Dictionary<string, Data.Selection> GetValueSelectionDictionary()
	{
		return null;
	}

	public Data.Selection GetValueSelectionDictionary(string key)
	{
		return default(Data.Selection);
	}

	public Dictionary<string, AssetReference> GetValueAssetDictionary()
	{
		return null;
	}

	public AssetReference GetValueAssetDictionary(string key)
	{
		return default(AssetReference);
	}

	public Dictionary<string, string> GetValueStringDictionary()
	{
		return null;
	}

	public string GetValueStringDictionary(string key)
	{
		return null;
	}

	public Dictionary<string, InputSource> GetValueInputSourceDictionary()
	{
		return null;
	}

	public InputSource GetValueInputSourceDictionary(string key)
	{
		return default(InputSource);
	}

	public int GetArrayLenght()
	{
		return 0;
	}

	public int GetMatrix2DLength(int i)
	{
		return 0;
	}

	public int GetDictionaryCount()
	{
		return 0;
	}

	public ICollection<string> GetDictionaryKeys()
	{
		return null;
	}

	public bool SetValue(Data value, bool forcePostUpdateSteps = false, bool copyDecorator = true)
	{
		return false;
	}

	public bool SetValueBoolean(bool value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBoolean(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColor(Color32 value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorAsInt(uint value, bool forcePostUpdateSteps)
	{
		return false;
	}

	public void SetValueColorAsInt(uint value)
	{
	}

	public bool SetValueColor(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2(Vector2 value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3(Vector3 value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumber(float value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumber(int value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberAsPercentage(float value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumber(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDecorator(Data.NumberDecorators decorator, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelection(Data.Selection value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelection(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAsset(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAsset(AssetReference value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueString(string value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueString(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueModuleId(ModuleId value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueModuleId(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSource(InputSource value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSource(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanArray(bool[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanArray(bool value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorArray(Color32[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorArray(Color value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public void SetValueColorArrayAsInt(uint value, int index)
	{
	}

	public bool SetValueColorArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Array(Vector2[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Array(Vector2 value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Array(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Array(Vector3[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Array(Vector3 value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Array(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberArray(float[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberArray(float value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberArray(int[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberArray(int value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionArray(Data.Selection[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionArray(Data.Selection value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueModuleIdArray(ModuleId[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueModuleIdArray(ModuleId value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueModuleIdArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAssetArray(AssetReference[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAssetArray(AssetReference value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAssetArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringArray(string[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringArray(string value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceArray(InputSource[] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceArray(InputSource value, int index, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceArray(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanMatrix2D(bool[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanMatrix2D(bool value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorMatrix2D(Color32[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorMatrix2D(Color value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public void SetValueColorMatrix2DAsInt(uint value, int x, int y)
	{
	}

	public bool SetValueColorMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Matrix2D(Vector2[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Matrix2D(Vector2 value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Matrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Matrix2D(Vector3[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Matrix2D(Vector3 value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Matrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberMatrix2D(float[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberMatrix2D(float value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberMatrix2D(int[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberMatrix2D(int value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionMatrix2D(Data.Selection[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionMatrix2D(Data.Selection value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringMatrix2D(string[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringMatrix2D(string value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceMatrix2D(InputSource[,] value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceMatrix2D(InputSource value, int x, int y, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceMatrix2D(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public void AddDictionaryKey(string key)
	{
	}

	public void RemoveDictionaryKey(string key)
	{
	}

	public bool SetValueBooleanDictionary(Dictionary<string, bool> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanDictionary(bool value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueBooleanDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorDictionary(Dictionary<string, Color32> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueColorDictionary(Color value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public void SetValueColorDictionaryAsInt(uint value, string key)
	{
	}

	public bool SetValueColorDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Dictionary(Dictionary<string, Vector2> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Dictionary(Vector2 value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector2Dictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Dictionary(Dictionary<string, Vector3> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Dictionary(Vector3 value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueVector3Dictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDictionary(Dictionary<string, float> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDictionary(float value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDictionary(Dictionary<string, int> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDictionary(int value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueNumberDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueSelectionDictionary(Dictionary<string, Data.Selection> value, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueSelectionDictionary(Data.Selection value, string key, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueSelectionDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueAssetDictionary(Dictionary<string, AssetReference> value, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueAssetDictionary(AssetReference value, string key, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueAssetDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueStringDictionary(Dictionary<string, string> value, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueStringDictionary(string value, string key, bool forcePostUpdateSteps = true)
	{
		return false;
	}

	public bool SetValueStringDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceDictionary(Dictionary<string, InputSource> value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceDictionary(InputSource value, string key, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public bool SetValueInputSourceDictionary(Data value, bool forcePostUpdateSteps = false)
	{
		return false;
	}

	public Storage ComposeStorage()
	{
		return null;
	}

	public void ApplyStorage(Storage storage)
	{
	}
}
