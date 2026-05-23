using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "partTimeRequest", "cookingDeliveryRequest", "wantedFood", "haveMet" })]
	public class ES3UserType_NPC : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_NPC()
			: base(typeof(NPC))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			NPC nPC = (NPC)obj;
			writer.WriteProperty("partTimeRequest", nPC.partTimeRequest, ES3Type_bool.Instance);
			writer.WriteProperty("cookingDeliveryRequest", nPC.cookingDeliveryRequest, ES3Type_bool.Instance);
			writer.WritePropertyByRef("wantedFood", nPC.wantedFood);
			writer.WriteProperty("haveMet", nPC.haveMet, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			NPC nPC = (NPC)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "partTimeRequest":
					nPC.partTimeRequest = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "cookingDeliveryRequest":
					nPC.cookingDeliveryRequest = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "wantedFood":
					nPC.wantedFood = reader.Read<Food>(ES3UserType_Food.Instance);
					break;
				case "haveMet":
					nPC.haveMet = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
