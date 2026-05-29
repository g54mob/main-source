using System;
using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<Name>k__BackingField", "<MapInfo>k__BackingField" })]
	public class ES3UserType_FreemodeProfile : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_FreemodeProfile()
			: base(typeof(FreemodeProfile))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			FreemodeProfile freemodeProfile = (FreemodeProfile)obj;
			writer.WriteProperty("Name", freemodeProfile.Name);
			writer.WriteProperty("MapInfo", AssetReferences.GetOrCreateReferenceId(freemodeProfile.MapInfo), ES3Type_long.Instance);
			writer.WriteProperty("SaveTime", freemodeProfile.SaveTime);
			writer.WriteProperty("PlayTime", freemodeProfile.PlayTime);
			writer.WriteProperty("Money", freemodeProfile.Money);
			writer.WriteProperty("Settings", freemodeProfile.Settings, ES3.ReferenceMode.ByValue);
			writer.WriteProperty("Difficulty", freemodeProfile.DifficultyData, ES3.ReferenceMode.ByValue);
			_ = (bool)freemodeProfile.Screenshot;
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			FreemodeProfile objectContainingField = (FreemodeProfile)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<Name>k__BackingField":
				case "Name":
					reader.SetPrivateField("Name".ToBackingField(), reader.Read<string>(), objectContainingField);
					break;
				case "MapInfo":
				{
					MapInfoSO reference = AssetReferences.GetReference<MapInfoSO>(reader.Read<long>());
					reader.SetPrivateField("MapInfo".ToBackingField(), reference, objectContainingField);
					break;
				}
				case "SaveTime":
					reader.SetPrivateField("SaveTime".ToBackingField(), reader.Read<DateTime>(), objectContainingField);
					break;
				case "PlayTime":
					reader.SetPrivateField("PlayTime".ToBackingField(), reader.Read<float>(), objectContainingField);
					break;
				case "Money":
					reader.SetPrivateField("Money".ToBackingField(), reader.Read<int>(), objectContainingField);
					break;
				case "Settings":
					reader.SetPrivateField("Settings".ToBackingField(), reader.Read<LevelSettingsList>(), objectContainingField);
					break;
				case "Difficulty":
					reader.SetPrivateField("DifficultyData".ToBackingField(), reader.Read<DifficultyData>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			FreemodeProfile freemodeProfile = (FreemodeProfile)Activator.CreateInstance(typeof(FreemodeProfile), nonPublic: true);
			ReadObject<T>(reader, freemodeProfile);
			return freemodeProfile;
		}
	}
}
