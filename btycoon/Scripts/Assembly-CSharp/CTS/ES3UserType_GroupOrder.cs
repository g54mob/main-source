using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using ES3Types;

namespace CTS
{
	public class ES3UserType_GroupOrder : ES3ObjectType
	{
		public static ES3Type Instance;

		private List<ClassRef<CustomerOrder>> _orderList = new List<ClassRef<CustomerOrder>>();

		public ES3UserType_GroupOrder()
			: base(typeof(GroupOrder))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			GroupOrder groupOrder = (GroupOrder)obj;
			writer.WritePrivateField("_groupData", obj);
			_orderList.Clear();
			foreach (CustomerOrder order in groupOrder.Orders)
			{
				_orderList.Add(order);
			}
			writer.WriteProperty("Orders", _orderList);
			if ((bool)groupOrder.Station)
			{
				writer.WritePropertyByRef("Station", groupOrder.Station);
			}
			writer.WriteProperty("StationSlots", groupOrder.StationSlots, ES3.ReferenceMode.ByRef);
			if ((bool)groupOrder.Plate)
			{
				writer.WritePropertyByRef("OrderPlate", groupOrder.Plate);
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			GroupOrder groupOrder = (GroupOrder)Activator.CreateInstance(typeof(GroupOrder), nonPublic: true);
			ReadObject<T>(reader, groupOrder);
			return groupOrder;
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			GroupOrder groupOrder = (GroupOrder)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_groupData":
				{
					CustomerGroupData value = reader.Read<CustomerGroupData>();
					reader.SetPrivateField("_groupData", value, groupOrder);
					break;
				}
				case "Orders":
					_orderList = reader.Read<List<ClassRef<CustomerOrder>>>();
					foreach (ClassRef<CustomerOrder> order in _orderList)
					{
						CustomerOrder customerOrder = order.GetClass();
						if (customerOrder != null)
						{
							groupOrder.Orders.Add(customerOrder);
						}
					}
					break;
				case "CurrentChore":
				{
					WorkerChore workerChore = reader.ReadClassRef<WorkerChore>();
					reader.SetPrivateField("_currentChore", workerChore, groupOrder);
					if (workerChore != null)
					{
						MonoSingleton<ChoreList>.Instance.ReinsertChore(workerChore);
					}
					break;
				}
				case "Station":
					groupOrder.Station = reader.Read<StationDrink>();
					break;
				case "StationSlots":
					reader.SetPrivateField("StationSlots".ToBackingField(), reader.Read<List<ItemSlot>>(), groupOrder);
					break;
				case "OrderPlate":
					groupOrder.Plate = reader.Read<OrderPlate>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			foreach (ItemSlot stationSlot in groupOrder.StationSlots)
			{
				stationSlot.SetUsed(null);
			}
		}
	}
}
