using System.Collections.Generic;
using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "InSlot", "CurrentHolder" })]
	public class ES3UserType_OrderPlate : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_OrderPlate()
			: base(typeof(OrderPlate))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			OrderPlate orderPlate = (OrderPlate)obj;
			writer.WriteProperty("Drinks", orderPlate.Drinks, ES3.ReferenceMode.ByRef);
			writer.WriteClassRefProperty("GroupOrder", orderPlate.Order);
			writer.WritePrivatePropertyByRef("CurrentHolder", orderPlate);
			writer.WriteList("PlateSlots", orderPlate.DrinkSlots, ES3.ReferenceMode.ByRef);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			OrderPlate orderPlate = (OrderPlate)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "Drinks":
					reader.SetPrivateField("Drinks".ToBackingField(), reader.Read<List<Drink>>(), orderPlate);
					break;
				case "GroupOrder":
				{
					GroupOrder order = reader.ReadClassRef<GroupOrder>();
					orderPlate.Order = order;
					break;
				}
				case "CurrentHolder":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent)
					{
						agent.ObjectHolding.TryGrabObject(orderPlate);
					}
					break;
				}
				default:
					if (!reader.TryReadIntoArray(property, "PlateSlots", orderPlate.DrinkSlots))
					{
						reader.Skip();
					}
					break;
				}
			}
		}
	}
}
