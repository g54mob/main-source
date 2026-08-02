using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "itemID", "count", "inventoryID", "itemMagazineCount", "itemDurability" })]
	public class ES3UserType_InventorySaveData : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_InventorySaveData()
			: base(typeof(InventorySaveData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			InventorySaveData inventorySaveData = (InventorySaveData)obj;
			writer.WriteProperty("itemID", inventorySaveData.itemID, ES3Type_string.Instance);
			writer.WriteProperty("count", inventorySaveData.count, ES3Type_int.Instance);
			writer.WriteProperty("inventoryID", inventorySaveData.inventoryID, ES3Type_int.Instance);
			writer.WriteProperty("itemMagazineCount", inventorySaveData.itemMagazineCount, ES3Type_int.Instance);
			writer.WriteProperty("itemDurability", inventorySaveData.itemDurability, ES3Type_float.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			InventorySaveData inventorySaveData = (InventorySaveData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "itemID":
					inventorySaveData.itemID = reader.Read<string>(ES3Type_string.Instance);
					break;
				case "count":
					inventorySaveData.count = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "inventoryID":
					inventorySaveData.inventoryID = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "itemMagazineCount":
					inventorySaveData.itemMagazineCount = reader.Read<int>(ES3Type_int.Instance);
					break;
				case "itemDurability":
					inventorySaveData.itemDurability = reader.Read<float>(ES3Type_float.Instance);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			InventorySaveData inventorySaveData = new InventorySaveData();
			ReadObject<T>(reader, inventorySaveData);
			return inventorySaveData;
		}
	}
}
