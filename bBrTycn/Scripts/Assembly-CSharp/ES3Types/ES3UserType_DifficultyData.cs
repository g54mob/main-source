using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_DifficultyData : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_DifficultyData()
			: base(typeof(DifficultyData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			DifficultyData obj2 = (DifficultyData)obj;
			Dictionary<StringKey, float> dictionary = new Dictionary<StringKey, float>();
			foreach (KeyValuePair<StringKey, float> item in obj2.Difficulty)
			{
				item.Deconstruct(out var key, out var value);
				StringKey key2 = key;
				float value2 = value;
				dictionary[key2] = value2;
			}
			writer.WriteProperty("Difficulty", dictionary);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			DifficultyData difficultyData = (DifficultyData)obj;
			difficultyData.Clear();
			foreach (string property in reader.Properties)
			{
				if (property == "Difficulty")
				{
					foreach (var (key, value) in reader.Read<Dictionary<StringKey, float>>())
					{
						difficultyData.SetValue(key, value);
					}
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
