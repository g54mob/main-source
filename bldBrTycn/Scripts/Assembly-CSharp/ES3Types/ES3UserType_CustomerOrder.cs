using System;
using System.Collections.Generic;
using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_CustomerOrder : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerOrder()
			: base(typeof(CustomerOrder))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			CustomerOrder customerOrder = (CustomerOrder)obj;
			writer.WritePrivateField("_status", customerOrder);
			if (customerOrder.DrinkData != null)
			{
				writer.WriteAssetReference("DrinkData", customerOrder.DrinkData);
			}
			writer.WriteClassRefProperty("GroupOrder", customerOrder.GroupOrder);
			writer.WriteProperty("Satisfaction", customerOrder.Satisfaction);
			writer.WriteProperty("Drink", customerOrder.PreparedDrink);
			writer.WritePropertyByRef("CustomerRef", customerOrder.CustomerRef);
			if (customerOrder.IngredientList.Count > 0)
			{
				writer.WriteProperty("IngredientList", customerOrder.IngredientList);
			}
			writer.WritePrivateField("_orderPrice", customerOrder);
			writer.WriteProperty("LastStageTime", customerOrder.LastStageTime);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			CustomerOrder customerOrder = (CustomerOrder)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "GroupOrder":
				{
					GroupOrder groupOrder = reader.ReadClassRef<GroupOrder>();
					if (groupOrder != null)
					{
						StaticObjectSet<GroupOrder>.Add(groupOrder);
					}
					reader.SetPrivateField("GroupOrder".ToBackingField(), groupOrder, customerOrder);
					break;
				}
				case "_orderPrice":
					reader.SetPrivateField("_orderPrice", reader.Read<int>(), customerOrder);
					break;
				case "IngredientList":
					reader.SetPrivateField("IngredientList".ToBackingField(), reader.Read<List<StockStack>>(), customerOrder);
					break;
				case "CustomerRef":
					reader.SetPrivateField("CustomerRef".ToBackingField(), reader.Read<Customer>(), customerOrder);
					break;
				case "_status":
					customerOrder = (CustomerOrder)reader.SetPrivateField("_status", reader.Read<CustomerOrder.EStatus>(), customerOrder);
					break;
				case "DrinkData":
					reader.SetPrivateField("DrinkData".ToBackingField(), reader.ReadAssetReference<DrinkSO>(), customerOrder);
					break;
				case "Satisfaction":
					reader.SetPrivateField("Satisfaction".ToBackingField(), reader.Read<EOrderResult>(), customerOrder);
					break;
				case "Drink":
					customerOrder.PreparedDrink = reader.Read<PooledRef<Drink>>();
					break;
				case "LastStageTime":
				{
					GameTime gameTime = reader.Read<GameTime>();
					reader.SetPrivateField("LastStageTime".ToBackingField(), gameTime, customerOrder);
					break;
				}
				default:
					reader.Skip();
					break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			CustomerOrder customerOrder = (CustomerOrder)Activator.CreateInstance(typeof(CustomerOrder), nonPublic: true);
			ReadObject<T>(reader, customerOrder);
			return customerOrder;
		}
	}
}
