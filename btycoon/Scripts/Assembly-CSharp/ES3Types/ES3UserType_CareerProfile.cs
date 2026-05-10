using System.Collections.Generic;
using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_levels", "<PlayedOnce>k__BackingField", "<ProfileIndex>k__BackingField" })]
	public class ES3UserType_CareerProfile : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_CareerProfile()
			: base(typeof(CareerProfile))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			CareerProfile careerProfile = (CareerProfile)obj;
			Dictionary<long, CareerProfile.LevelSave> dictionary = new Dictionary<long, CareerProfile.LevelSave>();
			foreach (var (obj2, value) in careerProfile.LevelProgress)
			{
				dictionary[AssetReferences.GetOrCreateReferenceId(obj2)] = value;
			}
			writer.WriteProperty("Progress", dictionary);
			writer.WritePrivateField("<PlayedOnce>k__BackingField", careerProfile);
			writer.WritePrivateField("<ProfileIndex>k__BackingField", careerProfile);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			CareerProfile objectContainingField = (CareerProfile)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "Progress":
				{
					Dictionary<long, CareerProfile.LevelSave> dictionary = reader.Read<Dictionary<long, CareerProfile.LevelSave>>();
					Dictionary<MapInfoSO, CareerProfile.LevelSave> dictionary2 = new Dictionary<MapInfoSO, CareerProfile.LevelSave>();
					foreach (KeyValuePair<long, CareerProfile.LevelSave> item in dictionary)
					{
						item.Deconstruct(out var key, out var value);
						long id = key;
						CareerProfile.LevelSave value2 = value;
						MapInfoSO reference = AssetReferences.GetReference<MapInfoSO>(id);
						if ((bool)reference)
						{
							dictionary2[reference] = value2;
						}
					}
					reader.SetPrivateField("_levelProgress", dictionary2, objectContainingField);
					break;
				}
				case "<PlayedOnce>k__BackingField":
					reader.SetPrivateField("<PlayedOnce>k__BackingField", reader.Read<bool>(), objectContainingField);
					break;
				case "<ProfileIndex>k__BackingField":
					reader.SetPrivateField("<ProfileIndex>k__BackingField", reader.Read<int>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			CareerProfile careerProfile = new CareerProfile();
			ReadObject<T>(reader, careerProfile);
			return careerProfile;
		}
	}
}
