using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<UseSecondaryMissions>k__BackingField" })]
	public class ES3UserType_LevelSettingsSecondaryMissions : ES3ScriptableObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSettingsSecondaryMissions()
			: base(typeof(LevelSettingsSecondaryMissions))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			LevelSettingsSecondaryMissions levelSettingsSecondaryMissions = (LevelSettingsSecondaryMissions)obj;
			writer.WriteProperty("UseMission", levelSettingsSecondaryMissions.UseMissions);
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			LevelSettingsSecondaryMissions objectContainingField = (LevelSettingsSecondaryMissions)obj;
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
