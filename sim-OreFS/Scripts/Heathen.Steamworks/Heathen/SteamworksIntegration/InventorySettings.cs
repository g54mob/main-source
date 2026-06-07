using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public class InventorySettings
	{
		public List<ItemDefinitionObject> items = new List<ItemDefinitionObject>();

		public bool runTimeUpdateItemDefinitions;

		private InventoryChangedEvent eventChanged = new InventoryChangedEvent();

		public Currency.Code LocalCurrencyCode => Inventory.Client.LocalCurrencyCode;

		public string LocalCurrencySymbol => Inventory.Client.LocalCurrencySymbol;

		public InventoryChangedEvent EventChanged
		{
			get
			{
				if (eventChanged == null)
				{
					eventChanged = new InventoryChangedEvent();
				}
				return eventChanged;
			}
		}

		public void Load()
		{
			Inventory.Client.EventSteamInventoryDefinitionUpdate.AddListener(HandleDefinitionLoad);
			Inventory.Client.EventSteamInventoryResultReady.AddListener(HandleItemResults);
			if (items.Count > 0)
			{
				Inventory.Client.GetAllItems();
				Inventory.Client.RequestPrices(null);
			}
		}

		private void HandleDefinitionLoad()
		{
			SteamSettings.behaviour.StartCoroutine(AsyncDefinitionLoad());
		}

		private IEnumerator AsyncDefinitionLoad()
		{
			if (!runTimeUpdateItemDefinitions)
			{
				yield break;
			}
			yield return null;
			if (!Inventory.Client.GetItemDefinitionIDs(out var results))
			{
				yield break;
			}
			List<ItemDefinitionObject> bundles = new List<ItemDefinitionObject>();
			Dictionary<ItemDefinitionObject, string> craftable = new Dictionary<ItemDefinitionObject, string>();
			Dictionary<ItemDefinitionObject, string> generators = new Dictionary<ItemDefinitionObject, string>();
			int counter = 0;
			for (int i = 0; i < results.Length; i++)
			{
				counter++;
				if (counter > 100)
				{
					counter = 0;
					yield return new WaitForEndOfFrame();
				}
				try
				{
					SteamItemDef_t itemDefId = results[i];
					ItemDefinitionObject itemDefinitionObject = items.FirstOrDefault((ItemDefinitionObject p) => p.id == itemDefId.m_SteamItemDef);
					bool flag = false;
					if (itemDefinitionObject == null)
					{
						flag = true;
						itemDefinitionObject = ScriptableObject.CreateInstance<ItemDefinitionObject>();
					}
					itemDefinitionObject.id = itemDefId.m_SteamItemDef;
					itemDefinitionObject.item_name.Populate(itemDefId);
					string text = ((!string.IsNullOrEmpty(itemDefinitionObject.item_name.value)) ? (itemDefId.ToString() + " " + itemDefinitionObject.item_name.value) : ((itemDefinitionObject.item_name.variants.Count <= 0) ? (itemDefId.ToString() + " UNKNOWN") : (itemDefId.ToString() + " " + itemDefinitionObject.item_name.variants[0].value)));
					itemDefinitionObject.name = "[Inv] " + text;
					itemDefinitionObject.item_description.Populate(itemDefId);
					itemDefinitionObject.item_display_type.Populate(itemDefId);
					switch (Inventory.Client.GetItemDefinitionProperty(itemDefId, "type"))
					{
					case "item":
						itemDefinitionObject.item_type = InventoryItemType.item;
						break;
					case "bundle":
						itemDefinitionObject.item_type = InventoryItemType.bundle;
						bundles.Add(itemDefinitionObject);
						break;
					case "generator":
						itemDefinitionObject.item_type = InventoryItemType.generator;
						bundles.Add(itemDefinitionObject);
						Debug.LogWarning("Importing an Item Generator from Steam API ...\nValve deliberately omits the bundle node when importing items from the Steam API. As such the item pool (aka Items, aka Bundle) of this generator will be blank. You must manually reset this value before you export the JSON otherwise the generator will have an empty bundle.\nPlease let Valve know that this is a problem for you and that you would like to see this changed. This is a limitation from Valve and not something Heathen can effect.");
						break;
					case "playtimegenerator":
						itemDefinitionObject.item_type = InventoryItemType.playtimegenerator;
						bundles.Add(itemDefinitionObject);
						break;
					case "tag_generator":
						itemDefinitionObject.item_type = InventoryItemType.tag_generator;
						break;
					default:
						Debug.LogWarning("Unknown Item Type: " + itemDefinitionObject.name);
						break;
					}
					itemDefinitionObject.item_promo.Populate(itemDefId);
					itemDefinitionObject.item_drop_start_time = Inventory.Client.GetItemDefinitionProperty(itemDefId, "drop_start_time");
					string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "exchange");
					if (!string.IsNullOrEmpty(itemDefinitionProperty) && !craftable.ContainsKey(itemDefinitionObject))
					{
						craftable.Add(itemDefinitionObject, itemDefinitionProperty);
					}
					itemDefinitionObject.item_price.Populate(itemDefId);
					string itemDefinitionProperty2 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "background_color");
					if (!string.IsNullOrEmpty(itemDefinitionProperty2))
					{
						if (ColorUtility.TryParseHtmlString(itemDefinitionProperty2, out var color))
						{
							itemDefinitionObject.item_background_color.color = color;
						}
						else
						{
							itemDefinitionObject.item_background_color.use = false;
						}
					}
					else
					{
						itemDefinitionObject.item_background_color.use = false;
					}
					string itemDefinitionProperty3 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "name_color");
					if (!string.IsNullOrEmpty(itemDefinitionProperty3))
					{
						if (ColorUtility.TryParseHtmlString(itemDefinitionProperty3, out var color2))
						{
							itemDefinitionObject.item_name_color.color = color2;
						}
						else
						{
							itemDefinitionObject.item_name_color.use = false;
						}
					}
					else
					{
						itemDefinitionObject.item_name_color.use = false;
					}
					itemDefinitionObject.item_icon_url = Inventory.Client.GetItemDefinitionProperty(itemDefId, "icon_url");
					itemDefinitionObject.item_icon_url_large = Inventory.Client.GetItemDefinitionProperty(itemDefId, "icon_url_large");
					string itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "marketable");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result))
					{
						itemDefinitionObject.item_marketable = result;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tradable");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result2))
					{
						itemDefinitionObject.item_tradable = result2;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tag_generators");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4))
					{
						generators.Add(itemDefinitionObject, itemDefinitionProperty4);
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "store_hidden");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result3))
					{
						itemDefinitionObject.item_store_hidden = result3;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "use_drop_limit");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result4))
					{
						itemDefinitionObject.item_use_drop_limit = result4;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "use_drop_window");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result5))
					{
						itemDefinitionObject.item_tradable = result5;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "granted_manually");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result6))
					{
						itemDefinitionObject.item_tradable = result6;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "use_bundle_price");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result7))
					{
						itemDefinitionObject.item_tradable = result7;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "auto_stack");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result8))
					{
						itemDefinitionObject.item_tradable = result8;
					}
					itemDefinitionObject.item_tag_generator_name = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tag_generator_name");
					itemDefinitionObject.item_tag_generator_values.Populate(itemDefId);
					itemDefinitionObject.item_tags.Populate(itemDefId);
					itemDefinitionObject.item_store_tags = new List<string>(Inventory.Client.GetItemDefinitionProperty(itemDefId, "store_tags").Split(';'));
					itemDefinitionObject.item_store_images = new List<string>(Inventory.Client.GetItemDefinitionProperty(itemDefId, "store_images").Split(';'));
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tradabitem_drop_limitle");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && uint.TryParse(itemDefinitionProperty4, out var result9))
					{
						itemDefinitionObject.item_drop_limit = result9;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "item_drop_interval");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result10))
					{
						itemDefinitionObject.item_tradable = result10;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "item_drop_window");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result11))
					{
						itemDefinitionObject.item_tradable = result11;
					}
					itemDefinitionProperty4 = Inventory.Client.GetItemDefinitionProperty(itemDefId, "item_drop_max_per_window");
					if (!string.IsNullOrEmpty(itemDefinitionProperty4) && bool.TryParse(itemDefinitionProperty4, out var result12))
					{
						itemDefinitionObject.item_tradable = result12;
					}
					if (flag)
					{
						items.Add(itemDefinitionObject);
					}
				}
				catch (Exception ex)
				{
					Debug.LogError("Failed to parse item definition load from Valve: " + ex.Message);
				}
			}
			counter = 0;
			for (int i = 0; i < bundles.Count; i++)
			{
				counter++;
				if (counter > 100)
				{
					counter = 0;
					yield return new WaitForEndOfFrame();
				}
				try
				{
					ItemDefinitionObject itemDefinitionObject2 = bundles[i];
					itemDefinitionObject2.item_bundle.entries = new List<ItemDefinitionObject.Bundle.Entry>();
					string itemDefinitionProperty5 = Inventory.Client.GetItemDefinitionProperty(itemDefinitionObject2.Id, "bundle");
					if (string.IsNullOrEmpty(itemDefinitionProperty5))
					{
						continue;
					}
					string[] array = itemDefinitionProperty5.Split(';');
					foreach (string text2 in array)
					{
						if (text2.Contains("x"))
						{
							string[] array2 = text2.Split('x');
							int id = int.Parse(array2[0]);
							int count = int.Parse(array2[1]);
							itemDefinitionObject2.item_bundle.entries.Add(new ItemDefinitionObject.Bundle.Entry
							{
								count = count,
								item = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == id)
							});
						}
						else
						{
							int id2 = int.Parse(text2);
							itemDefinitionObject2.item_bundle.entries.Add(new ItemDefinitionObject.Bundle.Entry
							{
								count = 1,
								item = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == id2)
							});
						}
					}
				}
				catch (Exception ex2)
				{
					Debug.LogError("Failed to process bundle information for " + bundles[i]?.ToString() + "\nException: " + ex2.Message);
				}
			}
			foreach (KeyValuePair<ItemDefinitionObject, string> item4 in craftable)
			{
				ItemDefinitionObject key = item4.Key;
				string value = item4.Value;
				try
				{
					key.item_exchange = new ItemDefinitionObject.ExchangeCollection();
					key.item_exchange.recipe = new List<ItemDefinitionObject.ExchangeRecipe>();
					string[] array3 = value.Split(';');
					foreach (string obj in array3)
					{
						ItemDefinitionObject.ExchangeRecipe item = default(ItemDefinitionObject.ExchangeRecipe);
						string[] array4 = obj.Split(',');
						foreach (string text3 in array4)
						{
							if (text3.Contains(":"))
							{
								string[] array5 = text3.Split(':');
								string name = array5[0];
								_ = string.Empty;
								uint count2 = 1u;
								string value2;
								if (array5[1].Contains("*"))
								{
									string[] array6 = array5[1].Split('*');
									value2 = array6[0];
									count2 = uint.Parse(array6[1]);
								}
								else
								{
									value2 = array5[1];
								}
								if (item.materials == null)
								{
									item.materials = new List<ItemDefinitionObject.ExchangeRecipe.Material>();
								}
								item.materials.Add(new ItemDefinitionObject.ExchangeRecipe.Material
								{
									item = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Def_Descriptor
									{
										item = null,
										count = 0u
									},
									tag = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Tag_Descriptor
									{
										name = name,
										value = value2,
										count = count2
									}
								});
							}
							else if (text3.Contains("x"))
							{
								string[] array7 = text3.Split('x');
								int itemID = int.Parse(array7[0]);
								uint count3 = uint.Parse(array7[1]);
								ItemDefinitionObject item2 = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == itemID);
								if (item.materials == null)
								{
									item.materials = new List<ItemDefinitionObject.ExchangeRecipe.Material>();
								}
								item.materials.Add(new ItemDefinitionObject.ExchangeRecipe.Material
								{
									item = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Def_Descriptor
									{
										item = item2,
										count = count3
									},
									tag = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Tag_Descriptor
									{
										name = string.Empty,
										value = string.Empty,
										count = 0u
									}
								});
							}
							else
							{
								int itemID2 = int.Parse(text3);
								ItemDefinitionObject item3 = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == itemID2);
								if (item.materials == null)
								{
									item.materials = new List<ItemDefinitionObject.ExchangeRecipe.Material>();
								}
								item.materials.Add(new ItemDefinitionObject.ExchangeRecipe.Material
								{
									item = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Def_Descriptor
									{
										item = item3,
										count = 1u
									},
									tag = new ItemDefinitionObject.ExchangeRecipe.Material.Item_Tag_Descriptor
									{
										name = string.Empty,
										value = string.Empty,
										count = 0u
									}
								});
							}
						}
						key.item_exchange.recipe.Add(item);
					}
				}
				catch (Exception ex3)
				{
					Debug.LogError("Failed to parse excahnge schema for " + key?.ToString() + "; schema = " + value + "; \n Exception = " + ex3.Message);
				}
			}
			foreach (KeyValuePair<ItemDefinitionObject, string> item5 in generators)
			{
				ItemDefinitionObject key2 = item5.Key;
				string value3 = item5.Value;
				if (value3.Contains(";"))
				{
					key2.item_tag_generators = new List<ItemDefinitionObject>();
					string[] array3 = value3.Split(';');
					foreach (string s in array3)
					{
						int id3 = int.Parse(s);
						ItemDefinitionObject itemDefinitionObject3 = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == id3);
						if (itemDefinitionObject3 != null)
						{
							key2.item_tag_generators.Add(itemDefinitionObject3);
						}
					}
				}
				else
				{
					int id4 = int.Parse(value3);
					key2.item_tag_generators = new List<ItemDefinitionObject>();
					ItemDefinitionObject itemDefinitionObject4 = items.FirstOrDefault((ItemDefinitionObject p) => p.Id.m_SteamItemDef == id4);
					if (itemDefinitionObject4 != null)
					{
						key2.item_tag_generators.Add(itemDefinitionObject4);
					}
				}
			}
			Inventory.Client.GetAllItems(HandleItemResults);
		}

		private void HandleItemResults(InventoryResult results)
		{
			Dictionary<ItemDefinitionObject, List<ItemDetail>> dictionary = new Dictionary<ItemDefinitionObject, List<ItemDetail>>();
			Dictionary<ItemDefinitionObject, List<ItemDetail>> dictionary2 = new Dictionary<ItemDefinitionObject, List<ItemDetail>>();
			foreach (ItemDefinitionObject item in items)
			{
				dictionary.Add(item, new List<ItemDetail>(item.Details.ToArray()));
			}
			ItemDetail[] array = results.items;
			for (int i = 0; i < array.Length; i++)
			{
				ItemDetail detail = array[i];
				ItemDefinitionObject itemDefinitionObject = items.FirstOrDefault((ItemDefinitionObject p) => p.id == detail.Definition.id);
				if (itemDefinitionObject != null)
				{
					List<ItemDetail> details = itemDefinitionObject.Details;
					details.RemoveAll((ItemDetail p) => p.ItemId == detail.ItemId);
					details.Add(detail);
				}
			}
			foreach (ItemDefinitionObject item2 in items)
			{
				dictionary2.Add(item2, new List<ItemDetail>(item2.Details.ToArray()));
			}
			List<ItemChangeRecord> list = new List<ItemChangeRecord>();
			foreach (KeyValuePair<ItemDefinitionObject, List<ItemDetail>> item3 in dictionary)
			{
				ItemDefinitionObject key = item3.Key;
				List<ItemDetail> before = item3.Value;
				List<ItemDetail> after = dictionary2[key];
				IEnumerable<ItemDetail> enumerable = before.Where((ItemDetail b) => !after.Any((ItemDetail a) => a.ItemId == b.ItemId));
				IEnumerable<ItemDetail> enumerable2 = after.Where((ItemDetail a) => !before.Any((ItemDetail b) => b.ItemId == a.ItemId));
				IEnumerable<ItemDetail> enumerable3 = before.Where((ItemDetail b) => after.Any((ItemDetail a) => a.ItemId == b.ItemId) && after.FirstOrDefault((ItemDetail a) => a.ItemId == b.ItemId).Quantity != b.Quantity);
				IEnumerable<ItemDetail> source = after.Where((ItemDetail a) => before.Any((ItemDetail b) => b.ItemId == a.ItemId) && before.FirstOrDefault((ItemDetail b) => b.ItemId == a.ItemId).Quantity != a.Quantity);
				if (enumerable.Count() <= 0 && enumerable2.Count() <= 0 && enumerable3.Count() <= 0)
				{
					continue;
				}
				List<ItemInstanceChangeRecord> list2 = new List<ItemInstanceChangeRecord>();
				foreach (ItemDetail item4 in enumerable)
				{
					list2.Add(new ItemInstanceChangeRecord
					{
						added = false,
						changed = false,
						removed = true,
						quantityBefore = item4.Quantity,
						quantityAfter = 0,
						instance = item4.ItemId
					});
				}
				foreach (ItemDetail item5 in enumerable2)
				{
					list2.Add(new ItemInstanceChangeRecord
					{
						added = true,
						changed = false,
						removed = false,
						quantityBefore = 0,
						quantityAfter = item5.Quantity,
						instance = item5.ItemId
					});
				}
				foreach (ItemDetail r in enumerable3)
				{
					ItemDetail itemDetail = source.FirstOrDefault((ItemDetail a) => a.ItemId == r.ItemId);
					list2.Add(new ItemInstanceChangeRecord
					{
						added = false,
						changed = true,
						removed = false,
						quantityBefore = r.Quantity,
						quantityAfter = itemDetail.Quantity,
						instance = itemDetail.ItemId
					});
				}
				ItemChangeRecord itemChangeRecord = new ItemChangeRecord
				{
					item = key,
					changes = list2.ToArray()
				};
				list.Add(itemChangeRecord);
				try
				{
					itemChangeRecord.item.EventChanged.Invoke(itemChangeRecord);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			if (list.Count > 0)
			{
				EventChanged.Invoke(new InventoryChangeRecord
				{
					changes = list.ToArray()
				});
			}
		}
	}
}
