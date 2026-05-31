using CTS;
using CTS.BBT;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_currentTable", "_currentSlot", "ItemSlot" })]
	public class ES3UserType_Seat : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Seat()
			: base(typeof(Seat))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Seat seat = (Seat)obj;
			writer.WritePrivateFieldByRef("_currentTable", seat);
			writer.WritePrivatePropertyByRef("ItemSlot", seat);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Seat seat = (Seat)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_currentTable"))
				{
					if (property == "ItemSlot")
					{
						reader.SetPrivateProperty("ItemSlot", reader.Read<ItemSlot>(), seat);
						if ((bool)seat.ItemSlot)
						{
							reader.SetPrivateField("InUse".ToBackingField(), true, seat.ItemSlot);
						}
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					seat = (Seat)reader.SetPrivateField("_currentTable", reader.Read<Table>(), seat);
				}
			}
		}
	}
}
