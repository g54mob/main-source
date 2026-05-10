using System.Collections.Generic;
using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_seats", "_itemSlots", "<InUse>k__BackingField", "<User>k__BackingField" })]
	public class ES3UserType_Table : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Table()
			: base(typeof(Table))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Table table = (Table)obj;
			writer.WritePrivateField("_seats", table);
			writer.WriteList("ItemSlots", table.ItemSlots, ES3.ReferenceMode.ByRef);
			writer.WritePrivateField("<InUse>k__BackingField", table);
			writer.WritePrivateFieldByRef("<User>k__BackingField", table);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Table table = (Table)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_seats":
					reader.SetPrivateField("_seats", reader.Read<List<Seat>>(), table);
					continue;
				case "<InUse>k__BackingField":
					table = (Table)reader.SetPrivateField("<InUse>k__BackingField", reader.Read<bool>(), table);
					continue;
				case "<User>k__BackingField":
					table = (Table)reader.SetPrivateField("<User>k__BackingField", reader.Read<Agent>(), table);
					continue;
				}
				if (!reader.TryReadIntoArray(property, "ItemSlots", table.ItemSlots))
				{
					reader.Skip();
				}
			}
		}
	}
}
