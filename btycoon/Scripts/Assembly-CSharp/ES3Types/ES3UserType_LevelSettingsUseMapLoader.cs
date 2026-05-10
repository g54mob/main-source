using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<UseMap>k__BackingField" })]
	public class ES3UserType_LevelSettingsUseMapLoader : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsUseMapLoader()
			: base(typeof(LevelSettingsUseMapLoader))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			LevelSettingsUseMapLoader objectContainingField = (LevelSettingsUseMapLoader)obj;
			writer.WritePrivateField("<UseMap>k__BackingField", objectContainingField);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			LevelSettingsUseMapLoader objectContainingField = (LevelSettingsUseMapLoader)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "<UseMap>k__BackingField")
				{
					objectContainingField = (LevelSettingsUseMapLoader)reader.SetPrivateField("<UseMap>k__BackingField", reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
