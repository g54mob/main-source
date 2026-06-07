using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public class ItemDefinitionObject : ScriptableObject
	{
		[Serializable]
		public class LanguageVariant
		{
			public LanguageCodes language;

			public string value;

			public bool Valid
			{
				get
				{
					if (!string.IsNullOrEmpty(language.ToString()))
					{
						return !string.IsNullOrEmpty(value.Trim());
					}
					return false;
				}
			}
		}

		[Serializable]
		public class LanguageVariantNode
		{
			[HideInInspector]
			public string node;

			public string value;

			public List<LanguageVariant> variants = new List<LanguageVariant>();

			public string GetSimpleValue()
			{
				if (!string.IsNullOrEmpty(value))
				{
					return value;
				}
				if (variants.Count > 0)
				{
					return variants[0].value;
				}
				return string.Empty;
			}

			public override string ToString()
			{
				if (variants.Count == 0)
				{
					return "\t\t\"" + node.Trim() + "\": \"" + value + "\"";
				}
				StringBuilder stringBuilder = new StringBuilder();
				foreach (LanguageVariant variant in variants)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",\n");
					}
					stringBuilder.Append("\t\t\"" + node.Trim() + "_" + variant.language.ToString() + "\": \"" + variant?.ToString() + "\"");
				}
				return stringBuilder.ToString();
			}

			public void Populate(SteamItemDef_t itemDefId)
			{
				value = Inventory.Client.GetItemDefinitionProperty(itemDefId, node);
				if (variants == null)
				{
					variants = new List<LanguageVariant>();
				}
				else
				{
					variants.Clear();
				}
				string[] names = Enum.GetNames(typeof(LanguageCodes));
				for (int i = 0; i < names.Length; i++)
				{
					string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, node + "_" + names[i]);
					if (!string.IsNullOrEmpty(itemDefinitionProperty))
					{
						variants.Add(new LanguageVariant
						{
							language = (LanguageCodes)i,
							value = itemDefinitionProperty
						});
					}
				}
			}
		}

		[Serializable]
		public class Bundle
		{
			[Serializable]
			public struct Entry
			{
				public ItemDefinitionObject item;

				public int count;

				public bool Valid
				{
					get
					{
						if (count < 0)
						{
							return false;
						}
						if (item == null)
						{
							return false;
						}
						if (item.item_type == InventoryItemType.tag_generator)
						{
							return false;
						}
						return true;
					}
				}

				public override string ToString()
				{
					if (!Valid)
					{
						return string.Empty;
					}
					if (count > 0)
					{
						return item.id + "x" + count;
					}
					return item.id.ToString();
				}
			}

			public List<Entry> entries = new List<Entry>();

			public bool Valid
			{
				get
				{
					if (entries.Count < 1)
					{
						return false;
					}
					return !entries.Any((Entry p) => !p.Valid);
				}
			}

			public override string ToString()
			{
				if (!Valid)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < entries.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(entries[i].ToString());
				}
				return stringBuilder.ToString();
			}
		}

		[Serializable]
		public class PromoRule
		{
			[Serializable]
			public struct PlayedEntry
			{
				public AppId_t app;

				public uint minutes;
			}

			public List<AppId_t> owns = new List<AppId_t>();

			public List<string> achievements = new List<string>();

			public List<PlayedEntry> played = new List<PlayedEntry>();

			public bool manual;

			public bool Valid
			{
				get
				{
					if (owns.Count < 1 && achievements.Count < 1 && played.Count < 1 && !manual)
					{
						return false;
					}
					return true;
				}
			}

			public override string ToString()
			{
				if (!Valid)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < owns.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append("owns:" + owns[i].m_AppId);
				}
				for (int j = 0; j < achievements.Count; j++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append("ach:" + achievements[j]);
				}
				for (int k = 0; k < played.Count; k++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append("played:" + played[k].app.ToString() + "/" + ((played[k].minutes < 1) ? "1" : played[k].minutes.ToString()));
				}
				if (manual)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append("manual");
				}
				return stringBuilder.ToString();
			}

			public void Populate(SteamItemDef_t itemDefId)
			{
				owns = new List<AppId_t>();
				achievements = new List<string>();
				played = new List<PlayedEntry>();
				manual = false;
				string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "promo");
				if (string.IsNullOrEmpty(itemDefinitionProperty))
				{
					return;
				}
				string[] array = itemDefinitionProperty.Split(';');
				foreach (string text in array)
				{
					if (text.StartsWith("owns:"))
					{
						owns.Add(new AppId_t(uint.Parse(text.Replace("owns:", string.Empty))));
					}
					else if (text.StartsWith("ach:"))
					{
						achievements.Add(text.Replace("ach:", string.Empty));
					}
					else if (text.StartsWith("played:"))
					{
						string[] array2 = text.Replace("played:", string.Empty).Split('/');
						if (array2.Length > 1)
						{
							played.Add(new PlayedEntry
							{
								app = new AppId_t(uint.Parse(array2[0])),
								minutes = uint.Parse(array2[1])
							});
						}
						else
						{
							played.Add(new PlayedEntry
							{
								app = new AppId_t(uint.Parse(array2[0]))
							});
						}
					}
				}
			}
		}

		[Serializable]
		public struct ExchangeRecipe
		{
			[Serializable]
			public struct Material
			{
				[Serializable]
				public struct Item_Def_Descriptor
				{
					public ItemDefinitionObject item;

					public uint count;

					public override string ToString()
					{
						if (count > 1)
						{
							return item.id + "x" + count;
						}
						return item.id.ToString();
					}
				}

				[Serializable]
				public struct Item_Tag_Descriptor
				{
					public string name;

					public string value;

					public uint count;

					public override string ToString()
					{
						if (count > 1)
						{
							return name + ":" + value + "*" + count;
						}
						return name + ":" + value;
					}
				}

				public Item_Def_Descriptor item;

				public Item_Tag_Descriptor tag;

				public bool Valid
				{
					get
					{
						if (item.item != null)
						{
							if (!string.IsNullOrEmpty(tag.name) || !string.IsNullOrEmpty(tag.value) || tag.count != 0)
							{
								return false;
							}
							if (item.item.item_type != InventoryItemType.item)
							{
								return false;
							}
							if (item.count == 0)
							{
								return false;
							}
							return true;
						}
						if (string.IsNullOrEmpty(tag.name) || string.IsNullOrEmpty(tag.value) || tag.count == 0)
						{
							return false;
						}
						return true;
					}
				}

				public override string ToString()
				{
					if (!Valid)
					{
						return string.Empty;
					}
					if (item.item != null && !string.IsNullOrEmpty(tag.name))
					{
						return item.ToString() + "," + tag.ToString();
					}
					if (item.item != null)
					{
						return item.ToString();
					}
					if (!string.IsNullOrEmpty(tag.name))
					{
						return tag.ToString();
					}
					return string.Empty;
				}
			}

			public List<Material> materials;

			public bool Valid
			{
				get
				{
					if (materials != null)
					{
						return !materials.Any((Material p) => !p.Valid);
					}
					return false;
				}
			}

			public string GetSchema()
			{
				if (materials.Count > 1)
				{
					StringBuilder stringBuilder = new StringBuilder(materials[0].ToString());
					for (int i = 1; i < materials.Count; i++)
					{
						stringBuilder.Append("," + materials[i].ToString());
					}
					return stringBuilder.ToString();
				}
				if (materials.Count == 1)
				{
					return materials[0].ToString();
				}
				return string.Empty;
			}
		}

		[Serializable]
		public class ExchangeCollection
		{
			public List<ExchangeRecipe> recipe = new List<ExchangeRecipe>();

			public override string ToString()
			{
				if (recipe.Count == 0)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < recipe.Count; i++)
				{
					if (recipe[i].Valid)
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(";");
						}
						stringBuilder.Append(recipe[i].GetSchema());
					}
				}
				return stringBuilder.ToString();
			}
		}

		[Serializable]
		public class Price
		{
			[Serializable]
			public class Value
			{
				public string currency;

				public uint value;

				public bool Valid
				{
					get
					{
						if (string.IsNullOrEmpty(currency.Trim()))
						{
							return false;
						}
						if (value < 1)
						{
							return false;
						}
						return true;
					}
				}

				public override string ToString()
				{
					return currency.ToUpper().Trim() + value;
				}
			}

			[Serializable]
			public class PriceList
			{
				[Serializable]
				public class PriceCollection
				{
					public List<Value> values = new List<Value>();

					public bool Valid
					{
						get
						{
							if (values.Count < 1)
							{
								return false;
							}
							return !values.Any((Value p) => !p.Valid);
						}
					}

					public override string ToString()
					{
						if (!Valid)
						{
							return string.Empty;
						}
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < values.Count; i++)
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(",");
							}
							stringBuilder.Append(values[i].ToString());
						}
						return stringBuilder.ToString();
					}
				}

				[Serializable]
				public class ChangeCollection
				{
					public string fromDate;

					public string untilDate;

					public PriceCollection prices;

					public bool Valid
					{
						get
						{
							if (!Valid)
							{
								return false;
							}
							if (string.IsNullOrEmpty(fromDate.Trim()) || string.IsNullOrEmpty(untilDate.Trim()))
							{
								return false;
							}
							return true;
						}
					}

					public override string ToString()
					{
						if (!Valid)
						{
							return string.Empty;
						}
						return fromDate + "-" + untilDate + prices.ToString();
					}
				}

				public PriceCollection original;

				public List<ChangeCollection> changes = new List<ChangeCollection>();

				public bool Valid
				{
					get
					{
						if (original.Valid)
						{
							return !changes.Any((ChangeCollection p) => !p.Valid);
						}
						return false;
					}
				}

				public override string ToString()
				{
					if (!Valid)
					{
						return string.Empty;
					}
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(original.ToString());
					for (int i = 0; i < changes.Count; i++)
					{
						stringBuilder.Append(";");
						stringBuilder.Append(changes[i]);
					}
					return stringBuilder.ToString();
				}
			}

			public uint version = 1u;

			public bool usePricing;

			public bool useCategory;

			public ValvePriceCategories category;

			public PriceList priceList = new PriceList();

			public string Node
			{
				get
				{
					if (!useCategory)
					{
						return "price";
					}
					return "price_category";
				}
			}

			public bool Valid
			{
				get
				{
					if (useCategory)
					{
						return true;
					}
					return priceList.Valid;
				}
			}

			public override string ToString()
			{
				if (useCategory)
				{
					return version + ";" + category;
				}
				return version + ";" + priceList.ToString();
			}

			public void Populate(SteamItemDef_t itemDefId)
			{
				string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "price_category");
				if (!string.IsNullOrEmpty(itemDefinitionProperty))
				{
					usePricing = true;
					useCategory = true;
					string[] array = itemDefinitionProperty.Split(';');
					if (array.Length > 1)
					{
						version = uint.Parse(array[0]);
						category = (ValvePriceCategories)Enum.Parse(typeof(ValvePriceCategories), array[1]);
					}
					else
					{
						version = 1u;
						category = (ValvePriceCategories)Enum.Parse(typeof(ValvePriceCategories), itemDefinitionProperty);
					}
					priceList = new PriceList();
					return;
				}
				itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "price");
				if (!string.IsNullOrEmpty(itemDefinitionProperty))
				{
					usePricing = true;
					useCategory = false;
					category = ValvePriceCategories.VLV100;
					priceList = new PriceList();
					string[] array2 = itemDefinitionProperty.Split(';');
					version = uint.Parse(array2[0]);
					priceList.original = new PriceList.PriceCollection();
					priceList.original.values = new List<Value>();
					string[] array3 = array2[1].Split(',');
					for (int i = 0; i < array3.Length; i++)
					{
						string text = array3[i].Substring(0, 3);
						uint value = uint.Parse(array3[i].Replace(text, string.Empty));
						priceList.original.values.Add(new Value
						{
							currency = text,
							value = value
						});
					}
					priceList.changes = new List<PriceList.ChangeCollection>();
					if (array2.Length <= 2)
					{
						return;
					}
					for (int j = 2; j < array2.Length; j++)
					{
						PriceList.ChangeCollection changeCollection = new PriceList.ChangeCollection();
						string[] array4 = array2[j].Split(',');
						string[] array5 = array4[0].Split('-');
						changeCollection.fromDate = array5[0];
						changeCollection.untilDate = array5[1];
						changeCollection.prices = new PriceList.PriceCollection();
						for (int k = 1; k < array4.Length; k++)
						{
							string text2 = array3[j].Substring(0, 3);
							uint value2 = uint.Parse(array3[j].Replace(text2, string.Empty));
							changeCollection.prices.values.Add(new Value
							{
								currency = text2,
								value = value2
							});
						}
						priceList.changes.Add(changeCollection);
					}
				}
				else
				{
					usePricing = false;
					useCategory = false;
					category = ValvePriceCategories.VLV100;
					priceList = new PriceList();
				}
			}
		}

		[Serializable]
		public class Color
		{
			public bool use;

			public UnityEngine.Color color = UnityEngine.Color.black;

			public override string ToString()
			{
				return ColorUtility.ToHtmlStringRGB(color);
			}
		}

		[Serializable]
		public class TagCollection
		{
			public List<ItemTag> tags = new List<ItemTag>();

			public override string ToString()
			{
				if (tags.Count == 0)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < tags.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(tags[i].category.Trim() + ":" + tags[i].tag.Trim());
				}
				return stringBuilder.ToString();
			}

			public void Populate(SteamItemDef_t itemDefId)
			{
				tags = new List<ItemTag>();
				string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tags");
				if (!string.IsNullOrEmpty(itemDefinitionProperty))
				{
					string[] array = itemDefinitionProperty.Split(';');
					for (int i = 0; i < array.Length; i++)
					{
						string[] array2 = array[i].Split(':');
						tags.Add(new ItemTag
						{
							category = array2[0],
							tag = array2[1]
						});
					}
				}
			}
		}

		[Serializable]
		public struct TagGeneratorValue
		{
			public string value;

			public uint weight;

			public bool Valid => !string.IsNullOrEmpty(value.Trim());

			public override string ToString()
			{
				return value.Trim() + ((weight != 0) ? (":" + weight) : "");
			}
		}

		[Serializable]
		public class TagGeneratorValues
		{
			public List<TagGeneratorValue> values = new List<TagGeneratorValue>();

			public bool Valid
			{
				get
				{
					if (values.Count > 0)
					{
						return !values.Any((TagGeneratorValue p) => !p.Valid);
					}
					return false;
				}
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < values.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(";");
					}
					stringBuilder.Append(values[i].ToString());
				}
				return stringBuilder.ToString();
			}

			public void Populate(SteamItemDef_t itemDefId)
			{
				values = new List<TagGeneratorValue>();
				string itemDefinitionProperty = Inventory.Client.GetItemDefinitionProperty(itemDefId, "tag_generator_values");
				if (!string.IsNullOrEmpty(itemDefinitionProperty))
				{
					string[] array = itemDefinitionProperty.Split(';');
					for (int i = 0; i < array.Length; i++)
					{
						string[] array2 = array[i].Split(':');
						values.Add(new TagGeneratorValue
						{
							value = array2[0],
							weight = uint.Parse(array2[1])
						});
					}
				}
			}
		}

		[Serializable]
		public class ExtendedSchema
		{
			[Serializable]
			public struct Entry
			{
				public string node;

				public string value;

				public override string ToString()
				{
					return "\"" + node.Trim() + "\": \"" + value.Trim() + "\"";
				}
			}

			public List<Entry> entries = new List<Entry>();

			public override string ToString()
			{
				if (entries.Count < 1)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < entries.Count; i++)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(",\n\t\t");
					}
					stringBuilder.Append(entries[i].ToString());
				}
				return stringBuilder.ToString();
			}
		}

		[SerializeField]
		internal int id;

		[SerializeField]
		internal InventoryItemType item_type;

		[SerializeField]
		internal LanguageVariantNode item_name = new LanguageVariantNode
		{
			node = "name"
		};

		[SerializeField]
		internal LanguageVariantNode item_description = new LanguageVariantNode
		{
			node = "description"
		};

		[SerializeField]
		internal LanguageVariantNode item_display_type = new LanguageVariantNode
		{
			node = "display_type"
		};

		[SerializeField]
		internal Bundle item_bundle = new Bundle();

		[SerializeField]
		internal PromoRule item_promo = new PromoRule();

		[SerializeField]
		internal string item_drop_start_time;

		[SerializeField]
		internal ExchangeCollection item_exchange = new ExchangeCollection();

		[SerializeField]
		internal Price item_price = new Price();

		[SerializeField]
		internal Color item_background_color = new Color();

		[SerializeField]
		internal Color item_name_color = new Color();

		[SerializeField]
		internal string item_icon_url;

		[SerializeField]
		internal string item_icon_url_large;

		[SerializeField]
		internal bool item_marketable;

		[SerializeField]
		internal bool item_tradable;

		[SerializeField]
		internal TagCollection item_tags = new TagCollection();

		[SerializeField]
		internal List<ItemDefinitionObject> item_tag_generators = new List<ItemDefinitionObject>();

		[SerializeField]
		internal string item_tag_generator_name;

		[SerializeField]
		internal TagGeneratorValues item_tag_generator_values = new TagGeneratorValues();

		[SerializeField]
		internal List<string> item_store_tags = new List<string>();

		[SerializeField]
		internal List<string> item_store_images = new List<string>();

		[SerializeField]
		internal bool item_hidden;

		[SerializeField]
		internal bool item_store_hidden;

		[SerializeField]
		internal bool item_use_drop_limit;

		[SerializeField]
		internal uint item_drop_limit;

		[SerializeField]
		internal uint item_drop_interval;

		[SerializeField]
		internal bool item_use_drop_window;

		[SerializeField]
		internal uint item_drop_window;

		[SerializeField]
		internal uint item_drop_max_per_window;

		[SerializeField]
		internal bool item_granted_manually;

		[SerializeField]
		internal bool item_use_bundle_price;

		[SerializeField]
		internal bool item_auto_stack;

		[SerializeField]
		internal ExtendedSchema item_extendedSchema = new ExtendedSchema();

		private ItemChangedEvent eventChanged = new ItemChangedEvent();

		public ItemData Data
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public List<ItemDetail> Details => Data.GetDetails();

		public long TotalQuantity => Data.GetTotalQuantity();

		public string DisplayName => Data.Name;

		public bool HasPrice => Data.HasPrice;

		public Currency.Code CurrencyCode => ItemData.CurrencyCode;

		public string CurrencySymbol => ItemData.CurrencySymbol;

		public ulong CurrentPrice => Data.CurrentPrice;

		public ulong BasePrice => Data.BasePrice;

		public ItemChangedEvent EventChanged
		{
			get
			{
				if (eventChanged == null)
				{
					eventChanged = new ItemChangedEvent();
				}
				return eventChanged;
			}
		}

		public InventoryItemType Type => item_type;

		public string Name
		{
			get
			{
				return item_name.GetSimpleValue();
			}
			set
			{
				item_name.value = value;
			}
		}

		public string Description => item_description.GetSimpleValue();

		public string DisplayType => item_display_type.GetSimpleValue();

		public SteamItemDef_t Id
		{
			get
			{
				return Data;
			}
			set
			{
				Data = value;
			}
		}

		public Bundle.Entry[] BundleEntries => item_bundle.entries.ToArray();

		public AppId_t[] PromoRuleOwns => item_promo.owns.ToArray();

		public string[] PromoRuleAchievements => item_promo.achievements.ToArray();

		public PromoRule.PlayedEntry[] PromoRulePlayed => item_promo.played.ToArray();

		public string DropStartTime => item_drop_start_time;

		public ExchangeRecipe[] Recipes => item_exchange?.recipe?.ToArray();

		public Color BackgroundColor => item_background_color;

		public Color NameColor => item_name_color;

		public string IconUrl => item_icon_url;

		public string IconUrlLarge => item_icon_url_large;

		public bool Marketable => item_marketable;

		public bool Tradable => item_tradable;

		public ItemTag[] Tags => item_tags.tags.ToArray();

		public ItemDefinitionObject[] TagGenerators => item_tag_generators.ToArray();

		public string TagGeneratorName => item_tag_generator_name;

		public TagGeneratorValue[] TagGeneratorValueArray => item_tag_generator_values.values.ToArray();

		public string[] StoreTags => item_store_tags.ToArray();

		public string[] StoreImages => item_store_images.ToArray();

		public bool Hidden => item_hidden;

		public bool StoreHidden => item_store_hidden;

		public bool UseDropLimit => item_use_drop_limit;

		public uint DropLimit => item_drop_limit;

		public uint DropInterval => item_drop_interval;

		public bool UseDropWindow => item_use_drop_window;

		public uint DropWindow => item_drop_window;

		public uint DropMaxPerWindow => item_drop_max_per_window;

		public bool GrantedManually => item_granted_manually;

		public bool UseBundlePrice => item_use_bundle_price;

		public bool AutoStack => item_auto_stack;

		public ExtendedSchema.Entry[] ExtendedSchemaEntries => item_extendedSchema.entries.ToArray();

		public bool Valid
		{
			get
			{
				if (string.IsNullOrEmpty(item_name.ToString().Trim()))
				{
					Debug.LogError(base.name + " ItemDefinition: Name field must be populated");
					return false;
				}
				if (id >= 1000000)
				{
					Debug.LogError(base.name + " ItemDefinition: ID field must be less than 1,000,000");
					return false;
				}
				switch (item_type)
				{
				case InventoryItemType.tag_generator:
					if (string.IsNullOrEmpty(item_tag_generator_name.Trim()))
					{
						Debug.LogError(base.name + " ItemDefinition: Tag Generators must define a tag_generator_name");
						return false;
					}
					if (!item_tag_generator_values.Valid)
					{
						Debug.LogError(base.name + " ItemDefinition: Tag Generators must have valid tag_generator_values");
						return false;
					}
					break;
				default:
					return false;
				case InventoryItemType.item:
				case InventoryItemType.bundle:
				case InventoryItemType.generator:
				case InventoryItemType.playtimegenerator:
					break;
				}
				return true;
			}
		}

		public string ToJson()
		{
			return item_type switch
			{
				InventoryItemType.item => ItemString(), 
				InventoryItemType.bundle => BundleString(), 
				InventoryItemType.generator => GeneratorString(), 
				InventoryItemType.playtimegenerator => PlaytimeGeneratorString(), 
				_ => TagGeneratorString(), 
			};
		}

		private string ItemString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\t{");
			stringBuilder.Append("\n\t\t\"itemdefid\": " + id);
			stringBuilder.Append(",\n\t\t\"type\": \"item\"");
			stringBuilder.Append(",\n" + item_name.ToString());
			stringBuilder.Append(",\n" + item_description.ToString());
			stringBuilder.Append(",\n" + item_display_type.ToString());
			string text = item_promo.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(",\n\t\t\"promo\": \"" + text + "\"");
			}
			if (!string.IsNullOrEmpty(item_drop_start_time))
			{
				stringBuilder.Append(",\n\t\t\"drop_start_time\": \"" + item_drop_start_time + "\"");
			}
			string text2 = item_exchange.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				stringBuilder.Append(",\n\t\t\"exchange\": \"" + text2 + "\"");
			}
			if (item_price.usePricing || item_price.useCategory)
			{
				string text3 = item_price.ToString();
				if (!string.IsNullOrEmpty(text3))
				{
					stringBuilder.Append(",\n\t\t\"" + item_price.Node + "\": \"" + text3 + "\"");
				}
			}
			if (item_background_color.use)
			{
				string text4 = item_background_color.ToString();
				if (!string.IsNullOrEmpty(text4))
				{
					stringBuilder.Append(",\n\t\t\"background_color\": \"" + text4 + "\"");
				}
			}
			if (item_name_color.use)
			{
				string text5 = item_name_color.ToString();
				if (!string.IsNullOrEmpty(text5))
				{
					stringBuilder.Append(",\n\t\t\"name_color\": \"" + text5 + "\"");
				}
			}
			if (!string.IsNullOrEmpty(item_icon_url))
			{
				stringBuilder.Append(",\n\t\t\"icon_url\": \"" + item_icon_url + "\"");
			}
			if (!string.IsNullOrEmpty(item_icon_url_large))
			{
				stringBuilder.Append(",\n\t\t\"icon_url_large\": \"" + item_icon_url_large + "\"");
			}
			stringBuilder.Append(",\n\t\t\"marketable\": " + item_marketable.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"tradable\": " + item_tradable.ToString().ToLower());
			string text6 = item_tags.ToString();
			if (!string.IsNullOrEmpty(text6))
			{
				stringBuilder.Append(",\n\t\t\"tags\": \"" + text6 + "\"");
			}
			if (item_tag_generators.Count > 0)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int i = 0; i < item_tag_generators.Count; i++)
				{
					if (stringBuilder2.Length > 0)
					{
						stringBuilder2.Append(";");
					}
					stringBuilder2.Append(item_tag_generators[i].id);
				}
				stringBuilder.Append(",\n\t\t\"tag_generators\": \"" + stringBuilder2.ToString() + "\"");
			}
			if (item_store_tags.Count > 0)
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				for (int j = 0; j < item_store_tags.Count; j++)
				{
					if (stringBuilder3.Length > 0)
					{
						stringBuilder3.Append(";");
					}
					stringBuilder3.Append(item_store_tags[j]);
				}
				stringBuilder.Append(",\n\t\t\"store_tags\": \"" + stringBuilder3.ToString() + "\"");
			}
			if (item_store_images.Count > 0)
			{
				StringBuilder stringBuilder4 = new StringBuilder();
				for (int k = 0; k < item_store_images.Count; k++)
				{
					if (stringBuilder4.Length > 0)
					{
						stringBuilder4.Append(";");
					}
					stringBuilder4.Append(item_store_images[k]);
				}
				stringBuilder.Append(",\n\t\t\"store_images\": \"" + stringBuilder4.ToString() + "\"");
			}
			stringBuilder.Append(",\n\t\t\"hidden\": " + item_hidden.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"store_hidden\": " + item_store_hidden.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"granted_manually\": " + item_granted_manually.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"auto_stack\": " + item_auto_stack.ToString().ToLower());
			string text7 = item_extendedSchema.ToString();
			if (!string.IsNullOrEmpty(text7))
			{
				stringBuilder.Append(",\n\t\t" + text7);
			}
			stringBuilder.Append("\n\t}");
			return stringBuilder.ToString();
		}

		private string BundleString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\t{");
			stringBuilder.Append("\n\t\t\"itemdefid\": " + id);
			stringBuilder.Append(",\n\t\t\"type\": \"bundle\"");
			string text = item_bundle.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(",\n\t\t\"bundle\": \"" + text + "\"");
			}
			stringBuilder.Append(",\n" + item_name.ToString());
			stringBuilder.Append(",\n" + item_description.ToString());
			stringBuilder.Append(",\n" + item_display_type.ToString());
			string text2 = item_promo.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				stringBuilder.Append(",\n\t\t\"promo\": \"" + text2 + "\"");
			}
			if (!string.IsNullOrEmpty(item_drop_start_time))
			{
				stringBuilder.Append(",\n\t\t\"drop_start_time\": \"" + item_drop_start_time + "\"");
			}
			string text3 = item_exchange.ToString();
			if (!string.IsNullOrEmpty(text3))
			{
				stringBuilder.Append(",\n\t\t\"exchange\": \"" + text3 + "\"");
			}
			if (item_price.usePricing)
			{
				string text4 = item_price.ToString();
				if (!string.IsNullOrEmpty(text4))
				{
					stringBuilder.Append(",\n\t\t\"" + item_price.Node + "\": \"" + text4 + "\"");
				}
			}
			if (item_background_color.use)
			{
				string text5 = item_background_color.ToString();
				if (!string.IsNullOrEmpty(text5))
				{
					stringBuilder.Append(",\n\t\t\"background_color\": \"" + text5 + "\"");
				}
			}
			if (item_name_color.use)
			{
				string text6 = item_name_color.ToString();
				if (!string.IsNullOrEmpty(text6))
				{
					stringBuilder.Append(",\n\t\t\"name_color\": \"" + text6 + "\"");
				}
			}
			if (!string.IsNullOrEmpty(item_icon_url))
			{
				stringBuilder.Append(",\n\t\t\"icon_url\": \"" + item_icon_url + "\"");
			}
			if (!string.IsNullOrEmpty(item_icon_url_large))
			{
				stringBuilder.Append(",\n\t\t\"icon_url_large\": \"" + item_icon_url_large + "\"");
			}
			if (item_store_tags.Count > 0)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int i = 0; i < item_store_tags.Count; i++)
				{
					if (stringBuilder2.Length > 0)
					{
						stringBuilder2.Append(";");
					}
					stringBuilder2.Append(item_store_tags[i]);
				}
				stringBuilder.Append(",\n\t\t\"store_tags\": \"" + stringBuilder2.ToString() + "\"");
			}
			if (item_store_images.Count > 0)
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				for (int j = 0; j < item_store_images.Count; j++)
				{
					if (stringBuilder3.Length > 0)
					{
						stringBuilder3.Append(";");
					}
					stringBuilder3.Append(item_store_images[j]);
				}
				stringBuilder.Append(",\n\t\t\"store_images\": \"" + stringBuilder3.ToString() + "\"");
			}
			stringBuilder.Append(",\n\t\t\"hidden\": " + item_hidden.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"store_hidden\": " + item_store_hidden.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"granted_manually\": " + item_granted_manually.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"use_bundle_price\": " + item_use_bundle_price.ToString().ToLower());
			string text7 = item_extendedSchema.ToString();
			if (!string.IsNullOrEmpty(text7))
			{
				stringBuilder.Append(",\n\t\t" + text7);
			}
			stringBuilder.Append("\n\t}");
			return stringBuilder.ToString();
		}

		private string GeneratorString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\t{");
			stringBuilder.Append("\n\t\t\"itemdefid\": " + id);
			stringBuilder.Append(",\n\t\t\"type\": \"generator\"");
			string text = item_bundle.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(",\n\t\t\"bundle\": \"" + text + "\"");
			}
			Debug.LogWarning("The Bundle node is empty for generator '" + base.name + "'; Valve deliberately omits this content when importing items from the Steam API. As such the bundle node is erased every time you import item definitions meaning you will need to manually update this field for every Item Generator every time you Copy the JSON data for upload to Steam.");
			stringBuilder.Append(",\n" + item_name.ToString());
			string text2 = item_promo.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				stringBuilder.Append(",\n\t\t\"promo\": \"" + text2 + "\"");
			}
			if (!string.IsNullOrEmpty(item_drop_start_time))
			{
				stringBuilder.Append(",\n\t\t\"drop_start_time\": \"" + item_drop_start_time + "\"");
			}
			string text3 = item_exchange.ToString();
			if (!string.IsNullOrEmpty(text3))
			{
				stringBuilder.Append(",\n\t\t\"exchange\": \"" + text3 + "\"");
			}
			stringBuilder.Append(",\n\t\t\"granted_manually\": " + item_granted_manually.ToString().ToLower());
			string text4 = item_extendedSchema.ToString();
			if (!string.IsNullOrEmpty(text4))
			{
				stringBuilder.Append(",\n\t\t" + text4);
			}
			stringBuilder.Append("\n\t}");
			return stringBuilder.ToString();
		}

		private string PlaytimeGeneratorString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\t{");
			stringBuilder.Append("\n\t\t\"itemdefid\": " + id);
			stringBuilder.Append(",\n\t\t\"type\": \"playtimegenerator\"");
			string text = item_bundle.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(",\n\t\t\"bundle\": \"" + text + "\"");
			}
			stringBuilder.Append(",\n" + item_name.ToString());
			string text2 = item_promo.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				stringBuilder.Append(",\n\t\t\"promo\": \"" + text2 + "\"");
			}
			if (!string.IsNullOrEmpty(item_drop_start_time))
			{
				stringBuilder.Append(",\n\t\t\"drop_start_time\": \"" + item_drop_start_time + "\"");
			}
			stringBuilder.Append(",\n\t\t\"use_drop_limit\": " + item_use_drop_limit.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"drop_limit\": " + item_use_drop_limit.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"drop_interval\": " + item_use_drop_limit.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"use_drop_window\": " + item_use_drop_limit.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"drop_max_per_window\": " + item_use_drop_limit.ToString().ToLower());
			stringBuilder.Append(",\n\t\t\"granted_manually\": " + item_granted_manually.ToString().ToLower());
			string text3 = item_extendedSchema.ToString();
			if (!string.IsNullOrEmpty(text3))
			{
				stringBuilder.Append(",\n\t\t" + text3);
			}
			stringBuilder.Append("\n\t}");
			return stringBuilder.ToString();
		}

		private string TagGeneratorString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("\t{");
			stringBuilder.Append("\n\t\t\"itemdefid\": " + id);
			stringBuilder.Append(",\n\t\t\"type\": \"tag_generator\"");
			stringBuilder.Append(",\n" + item_name.ToString());
			if (!string.IsNullOrEmpty(item_tag_generator_name))
			{
				stringBuilder.Append(",\n\t\t\"tag_generator_name\": \"" + item_tag_generator_name + "\"");
			}
			string text = item_tag_generator_values.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(",\n\t\t\"tag_generator_values\": \"" + text + "\"");
			}
			stringBuilder.Append(",\n\t\t\"granted_manually\": " + item_granted_manually.ToString().ToLower());
			string text2 = item_extendedSchema.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				stringBuilder.Append(",\n\t\t" + text2);
			}
			stringBuilder.Append("\n\t}");
			return stringBuilder.ToString();
		}

		public bool AddPromoItem(Action<InventoryResult> callback)
		{
			return Data.AddPromoItem(callback);
		}

		public ConsumeOrder[] GetConsumeOrders(uint quantity)
		{
			return Data.GetConsumeOrders(quantity);
		}

		public bool Consume(Action<InventoryResult> callback)
		{
			return Data.Consume(callback);
		}

		public void Consume(ConsumeOrder order, Action<InventoryResult> callback)
		{
			Data.Consume(order, callback);
		}

		public bool GetExchangeEntry(uint quantity, out ExchangeEntry[] entries)
		{
			return Data.GetExchangeEntry(quantity, out entries);
		}

		public void Exchange(IEnumerable<ExchangeEntry> recipeEntries, Action<InventoryResult> callback)
		{
			Data.Exchange(recipeEntries, callback);
		}

		public void GenerateItem(Action<InventoryResult> callback)
		{
			Data.GenerateItem(callback);
		}

		public void GenerateItem(uint quantity, Action<InventoryResult> callback)
		{
			Data.GenerateItem(quantity, callback);
		}

		public void StartPurchase(Action<SteamInventoryStartPurchaseResult_t, bool> callback)
		{
			Data.StartPurchase(callback);
		}

		public void StartPurchase(uint count, Action<SteamInventoryStartPurchaseResult_t, bool> callback)
		{
			Data.StartPurchase(count, callback);
		}

		public bool GetPrice(out ulong currentPrice, out ulong basePrice)
		{
			return Data.GetPrice(out currentPrice, out basePrice);
		}

		public void TriggerDrop(Action<InventoryResult> callback)
		{
			Data.TriggerDrop(callback);
		}

		public bool CanExchange(ExchangeRecipe recipe, out List<ExchangeEntry> entries)
		{
			if (!recipe.Valid)
			{
				entries = null;
				Debug.LogWarning("The indicated recipe appears to be invalid and cannot automatically be resolved to an ExchangeEntry list.");
				return false;
			}
			entries = new List<ExchangeEntry>();
			foreach (ExchangeRecipe.Material material in recipe.materials)
			{
				if (material.item.item == null)
				{
					Debug.LogWarning("We can only build recipies that take specific items. This recipe uses tag types");
					entries = null;
					return false;
				}
				if (material.item.item.GetExchangeEntry(material.item.count, out var entries2))
				{
					entries.AddRange(entries2);
					continue;
				}
				Debug.LogWarning("Insufficient quantity of item " + material.item.item.name);
				entries = null;
				return false;
			}
			return true;
		}

		public string CurrentPriceString()
		{
			return Data.CurrentPriceString();
		}

		public string BasePriceString()
		{
			return Data.BasePriceString();
		}
	}
}
