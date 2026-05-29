using CTS;
using CTS.BBT;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_itemSlots" })]
	public class ES3UserType_StationDrink : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_StationDrink()
			: base(typeof(StationDrink))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			StationDrink stationDrink = (StationDrink)obj;
			writer.WriteProperty("Assignation", stationDrink.ServeAllRooms);
			writer.WriteList("ItemSlots", stationDrink.ItemSlots, ES3.ReferenceMode.ByRef);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			StationDrink stationDrink = (StationDrink)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "Assignation")
				{
					stationDrink.SetServeAllRooms(reader.Read<bool>());
				}
				else if (!reader.TryReadIntoArray(property, "ItemSlots", stationDrink.ItemSlots))
				{
					reader.Skip();
				}
			}
		}
	}
}
