using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_settingList", "_fallbackList" })]
	public class ES3UserType_LevelSettingsList : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsList()
			: base(typeof(LevelSettingsList))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			LevelSettingsList objectContainingField = (LevelSettingsList)obj;
			writer.WritePrivateField("_settingList", objectContainingField, ES3.ReferenceMode.ByValue);
			writer.WritePrivateField("_fallbackList", objectContainingField, ES3.ReferenceMode.ByValue);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			LevelSettingsList objectContainingField = (LevelSettingsList)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_settingList"))
				{
					if (property == "_fallbackList")
					{
						objectContainingField = (LevelSettingsList)reader.SetPrivateField("_fallbackList", reader.Read<List<LevelSettingsList>>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingField = (LevelSettingsList)reader.SetPrivateField("_settingList", reader.Read<List<LevelSetting>>(), objectContainingField);
				}
			}
		}
	}
}
