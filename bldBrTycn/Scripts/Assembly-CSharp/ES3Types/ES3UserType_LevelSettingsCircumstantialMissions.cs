using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_LevelSettingsCircumstantialMissions : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsCircumstantialMissions()
			: base(typeof(LevelSettingsCircumstantialMissions))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			LevelSettingsCircumstantialMissions levelSettingsCircumstantialMissions = (LevelSettingsCircumstantialMissions)obj;
			writer.WriteProperty("UseMission", levelSettingsCircumstantialMissions.UseMissions);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			LevelSettingsCircumstantialMissions objectContainingField = (LevelSettingsCircumstantialMissions)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "UseMission")
				{
					reader.SetPrivateField("UseMissions".ToBackingField(), reader.Read<bool>(), objectContainingField);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
