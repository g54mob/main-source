using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class Data
{
	public enum Container
	{
		None = 0,
		Dictionary = 1,
		Array = 2,
		Matrix2D = 3
	}

	public enum Types
	{
		None = -1,
		Boolean = 0,
		Number = 1,
		Color = 2,
		String = 4,
		Selection = 5,
		ModuleId = 6,
		Asset = 7,
		InputSource = 8,
		Vector2 = 9,
		Vector3 = 10
	}

	public enum NumberDecorators
	{
		Generic = 0,
		Percentage = 1,
		Time = 2,
		Integer = 3
	}

	public interface IDataOwner
	{
		string GetDynamicDataSelectionName(int valueId, Selection selection);

		Dictionary<int, string> GetDynamicDataSelectionValues(int valueId);
	}

	public struct Selection
	{
		public DataSelectionGestaltEnum dataSelectionGestalt;

		public int id;

		public override bool Equals(object obj)
		{
			return false;
		}

		public static bool operator ==(Selection s1, Selection s2)
		{
			return false;
		}

		public static bool operator !=(Selection s1, Selection s2)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		private IList<ValueDropdownItem<int>> GetSelectionGestaltsDropdown()
		{
			return null;
		}

		private IList<ValueDropdownItem<int>> GetSelectionValuesDropdown()
		{
			return null;
		}
	}

	public Container container;

	public Types type;

	public bool booleanValue;

	public Color32 colorValue;

	public Vector2 vector2Value;

	public Vector3 vector3Value;

	public float numberValue;

	public NumberDecorators numberDecorator;

	public Selection selectionValue;

	[HideInInspector]
	public AssetReference assetValue;

	public string stringValue;

	[HideInInspector]
	public ModuleId moduleIdValue;

	[HideInInspector]
	public InputSource inputSourceValue;

	public bool[] arrayBooleanValue;

	public Color32[] arrayColorValue;

	public Vector2[] arrayVector2Value;

	public Vector3[] arrayVector3Value;

	public float[] arrayNumberValue;

	public Selection[] arraySelectionValue;

	public ModuleId[] arrayModuleIdValue;

	public AssetReference[] arrayAssetValue;

	public string[] arrayStringValue;

	[HideInInspector]
	public InputSource[] arrayInputSourceValue;

	public bool[,] matrix2DBooleanValue;

	public Color32[,] matrix2DColorValue;

	public Vector2[,] matrix2DVector2Value;

	public Vector3[,] matrix2DVector3Value;

	public float[,] matrix2DNumberValue;

	public Selection[,] matrix2DSelectionValue;

	public string[,] matrix2DStringValue;

	public InputSource[,] matrix2DInputSourceValue;

	public Dictionary<string, bool> dictionaryBooleanValue;

	public Dictionary<string, Color32> dictionaryColorValue;

	public Dictionary<string, Vector2> dictionaryVector2Value;

	public Dictionary<string, Vector3> dictionaryVector3Value;

	public Dictionary<string, float> dictionaryNumberValue;

	public Dictionary<string, Selection> dictionarySelectionValue;

	public Dictionary<string, AssetReference> dictionaryAssetValue;

	public Dictionary<string, string> dictionaryStringValue;

	[HideInInspector]
	public Dictionary<string, InputSource> dictionaryInputSourceValue;

	public ModuleGestaltEnum moduleIdType;

	public bool sameMotherboard;

	public AssetType assetValueType;

	public InputBinding.Type inputSourceType;

	private IList<ValueDropdownItem<Types>> ValidTypes()
	{
		return null;
	}

	private IList<ValueDropdownItem<Type>> ModuleList()
	{
		return null;
	}

	public Data()
	{
	}

	public Data(Data data)
	{
	}

	public void SetValue(bool value)
	{
	}

	public void SetValue(Color32 value)
	{
	}

	public void SetValue(Vector2 value)
	{
	}

	public void SetValue(Vector3 value)
	{
	}

	public void SetValue(float value)
	{
	}

	public void SetValue(int value)
	{
	}

	public void SetValue(Selection value)
	{
	}

	public void SetValue(AssetReference value)
	{
	}

	public void SetValue(string value)
	{
	}

	public void SetValue(ModuleId value)
	{
	}

	public void SetValue(InputSource value)
	{
	}

	public void SetValue(bool[] value)
	{
	}

	public void SetValue(Color32[] value)
	{
	}

	public void SetValue(Vector2[] value)
	{
	}

	public void SetValue(Vector3[] value)
	{
	}

	public void SetValue(float[] value)
	{
	}

	public void SetValue(int[] value)
	{
	}

	public void SetValue(Selection[] value)
	{
	}

	public void SetValue(ModuleId[] value)
	{
	}

	public void SetValue(AssetReference[] value)
	{
	}

	public void SetValue(string[] value)
	{
	}

	public void SetValue(InputSource[] value)
	{
	}

	public void SetValue(bool[,] value)
	{
	}

	public void SetValue(Color32[,] value)
	{
	}

	public void SetValue(Vector2[,] value)
	{
	}

	public void SetValue(Vector3[,] value)
	{
	}

	public void SetValue(float[,] value)
	{
	}

	public void SetValue(int[,] value)
	{
	}

	public void SetValue(Selection[,] value)
	{
	}

	public void SetValue(string[,] value)
	{
	}

	public void SetValue(InputSource[,] value)
	{
	}

	public void SetValue(Dictionary<string, bool> value)
	{
	}

	public void SetValue(Dictionary<string, Color32> value)
	{
	}

	public void SetValue(Dictionary<string, Vector2> value)
	{
	}

	public void SetValue(Dictionary<string, Vector3> value)
	{
	}

	public void SetValue(Dictionary<string, float> value)
	{
	}

	public void SetValue(Dictionary<string, int> value)
	{
	}

	public void SetValue(Dictionary<string, Selection> value)
	{
	}

	public void SetValue(Dictionary<string, AssetReference> value)
	{
	}

	public void SetValue(Dictionary<string, string> value)
	{
	}

	public void SetValue(Dictionary<string, InputSource> value)
	{
	}

	public void Copy(Data data)
	{
	}

	public bool IsEqualTo(bool value)
	{
		return false;
	}

	public bool IsEqualTo(Color32 value)
	{
		return false;
	}

	public bool IsEqualTo(Vector2 value)
	{
		return false;
	}

	public bool IsEqualTo(Vector3 value)
	{
		return false;
	}

	public bool IsEqualTo(float value, NumberDecorators valueDecorator, bool compareDecorators)
	{
		return false;
	}

	public static bool CompareNumbers(float value1, NumberDecorators value1Decorator, float value2, NumberDecorators value2Decorator, bool compareDecorators)
	{
		return false;
	}

	public bool IsEqualTo(Selection value)
	{
		return false;
	}

	public bool IsEqualTo(string value)
	{
		return false;
	}

	public bool IsEqualTo(ModuleId value)
	{
		return false;
	}

	public bool IsEqualTo(InputSource value)
	{
		return false;
	}

	public bool IsEqualTo(bool[] value)
	{
		return false;
	}

	public bool IsEqualTo(Color32[] value)
	{
		return false;
	}

	public bool IsEqualTo(Vector2[] value)
	{
		return false;
	}

	public bool IsEqualTo(Vector3[] value)
	{
		return false;
	}

	public bool IsEqualTo(float[] value, NumberDecorators valueDecorator, bool compareDecorators)
	{
		return false;
	}

	public bool IsEqualTo(Selection[] value)
	{
		return false;
	}

	public bool IsEqualTo(ModuleId[] value)
	{
		return false;
	}

	public bool IsEqualTo(AssetReference[] value)
	{
		return false;
	}

	public bool IsEqualTo(string[] value)
	{
		return false;
	}

	public bool IsEqualTo(InputSource[] value)
	{
		return false;
	}

	public bool IsEqualTo(bool[,] value)
	{
		return false;
	}

	public bool IsEqualTo(Color32[,] value)
	{
		return false;
	}

	public bool IsEqualTo(Vector2[,] value)
	{
		return false;
	}

	public bool IsEqualTo(Vector3[,] value)
	{
		return false;
	}

	public bool IsEqualTo(float[,] value, NumberDecorators valueDecorator, bool compareDecorators)
	{
		return false;
	}

	public bool IsEqualTo(Selection[,] value)
	{
		return false;
	}

	public bool IsEqualTo(string[,] value)
	{
		return false;
	}

	public bool IsEqualTo(InputSource[,] value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, bool> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, Color32> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, Vector2> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, Vector3> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, float> value, NumberDecorators valueDecorator, bool compareDecorators)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, Selection> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, AssetReference> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, string> value)
	{
		return false;
	}

	public bool IsEqualTo(Dictionary<string, InputSource> value)
	{
		return false;
	}

	public bool IsEqualTo(Data data, bool compareDecorators = true)
	{
		return false;
	}

	public bool CheckCompatibility(Data other)
	{
		return false;
	}

	public int GetArrayLength()
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

	public DocumentationType GetDocumentationType()
	{
		return default(DocumentationType);
	}

	public string GetTypeString()
	{
		return null;
	}

	public string ToString(IDataOwner owner, int valueId, bool includeType, int decimalDigits = 2)
	{
		return null;
	}
}
