using System;
using System.Collections.Generic;
using CTS;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_inventory" })]
	public class ES3UserType_BBTStock : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BBTStock()
			: base(typeof(BBTStock))
		{
			Instance = this;
			priority = 1;
		}

		public ES3UserType_BBTStock(Type type)
			: base(type)
		{
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BBTStock bBTStock = (BBTStock)obj;
			Dictionary<StringKey<StockType>, Dictionary<long, List<StockStack>>> dictionary = new Dictionary<StringKey<StockType>, Dictionary<long, List<StockStack>>>();
			foreach (StringKey<StockType> inventoryType in bBTStock.InventoryTypes)
			{
				dictionary[inventoryType] = new Dictionary<long, List<StockStack>>();
				foreach (StockItemSO itemType in bBTStock.GetItemTypes(inventoryType))
				{
					if (AssetReferences.TryGetOrCreateReferenceId(itemType, out var outId))
					{
						dictionary[inventoryType][outId] = bBTStock.GetStackList(inventoryType, itemType).Copy();
					}
				}
			}
			writer.WriteProperty("Inventory", dictionary);
			writer.WritePrivateField("_storageCapacity", bBTStock);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BBTStock bBTStock = (BBTStock)obj;
			Dictionary<StringKey<StockType>, int?> dictionary = null;
			StringKey<StockType> key;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_storageCapacity"))
				{
					if (property == "Inventory")
					{
						Dictionary<StringKey<StockType>, Dictionary<long, List<StockStack>>> dictionary2 = reader.Read<Dictionary<StringKey<StockType>, Dictionary<long, List<StockStack>>>>();
						Dictionary<StringKey<StockType>, Dictionary<StockItemSO, List<StockStack>>> dictionary3 = new Dictionary<StringKey<StockType>, Dictionary<StockItemSO, List<StockStack>>>();
						foreach (KeyValuePair<StringKey<StockType>, Dictionary<long, List<StockStack>>> item in dictionary2)
						{
							item.Deconstruct(out key, out var value);
							StringKey<StockType> key2 = key;
							Dictionary<long, List<StockStack>> dictionary4 = value;
							dictionary3[key2] = new Dictionary<StockItemSO, List<StockStack>>();
							foreach (var (id, value2) in dictionary4)
							{
								if (AssetReferences.TryGetReference(id, out StockItemSO outObject))
								{
									dictionary3[key2][outObject] = value2;
								}
							}
						}
						reader.SetPrivateField("_inventory", dictionary3, bBTStock);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					dictionary = reader.Read<Dictionary<StringKey<StockType>, int?>>();
				}
			}
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<StringKey<StockType>, int?> item2 in dictionary)
			{
				item2.Deconstruct(out key, out var value3);
				StringKey<StockType> stockType = key;
				int? maxCapacity = value3;
				bBTStock.SetStockTypeCapacity(stockType, maxCapacity);
			}
		}
	}
}
