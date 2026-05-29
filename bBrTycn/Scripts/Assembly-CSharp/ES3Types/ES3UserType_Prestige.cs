using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_prestigeData", "<TotalFurnituresValue>k__BackingField", "<TotalReviewsValue>k__BackingField", "<TotalSuperficyValue>k__BackingField", "<TotalPaintValue>k__BackingField", "<TotalRewardValue>k__BackingField" })]
	public class ES3UserType_Prestige : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Prestige()
			: base(typeof(Prestige))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Prestige prestige = (Prestige)obj;
			writer.WritePrivateFieldByRef("_prestigeData", prestige);
			writer.WritePrivateField("<TotalFurnituresValue>k__BackingField", prestige);
			writer.WritePrivateField("<TotalReviewsValue>k__BackingField", prestige);
			writer.WritePrivateField("<TotalSuperficyValue>k__BackingField", prestige);
			writer.WritePrivateField("<TotalPaintValue>k__BackingField", prestige);
			writer.WritePrivateField("<TotalRewardValue>k__BackingField", prestige);
			writer.WriteProperty("TotalVampiresKilled", prestige.TotalVampiresKilled);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Prestige objectContainingField = (Prestige)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_prestigeData":
					objectContainingField = (Prestige)reader.SetPrivateField("_prestigeData", reader.Read<PrestigeLevelsData>(), objectContainingField);
					break;
				case "<TotalFurnituresValue>k__BackingField":
					objectContainingField = (Prestige)reader.SetPrivateField("<TotalFurnituresValue>k__BackingField", reader.Read<float>(), objectContainingField);
					break;
				case "<TotalReviewsValue>k__BackingField":
					objectContainingField = (Prestige)reader.SetPrivateField("<TotalReviewsValue>k__BackingField", reader.Read<float>(), objectContainingField);
					break;
				case "<TotalSuperficyValue>k__BackingField":
					objectContainingField = (Prestige)reader.SetPrivateField("<TotalSuperficyValue>k__BackingField", reader.Read<float>(), objectContainingField);
					break;
				case "<TotalPaintValue>k__BackingField":
					objectContainingField = (Prestige)reader.SetPrivateField("<TotalPaintValue>k__BackingField", reader.Read<float>(), objectContainingField);
					break;
				case "<TotalRewardValue>k__BackingField":
					objectContainingField = (Prestige)reader.SetPrivateField("<TotalRewardValue>k__BackingField", reader.Read<float>(), objectContainingField);
					break;
				case "TotalVampiresKilled":
					reader.SetPrivateField("TotalVampiresKilled".ToBackingField(), reader.Read<float>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
