using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[Serializable]
	public class SettingData
	{
		public enum DataType
		{
			Unknown = 0,
			Int = 1,
			Float = 2,
			Bool = 3,
			String = 4,
			Color = 5,
			KeyCombination = 6,
			Option = 7,
			ColorOption = 8
		}

		public string ID;

		public DataType Type;

		[SerializeField]
		public int[] IntValues;

		[SerializeField]
		public float[] FloatValues;

		[SerializeField]
		public string[] StringValues;

		public SettingData(string path, DataType type, int[] intValues, float[] floatValues, string[] stringValues)
			: this(path, type)
		{
			IntValues = intValues;
			FloatValues = floatValues;
			StringValues = stringValues;
		}

		public SettingData(string path, DataType type)
		{
			ID = path;
			Type = type;
		}
	}
}
