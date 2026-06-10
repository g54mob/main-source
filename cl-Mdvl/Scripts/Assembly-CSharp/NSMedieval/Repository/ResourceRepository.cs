using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.Repository
{
	public class ResourceRepository : DynamicJsonRepository<ResourceRepository, Resource>
	{
		private static readonly object Padlock = new object();

		private Resource[] protoItems;

		private Resource[] regularItems;

		private Resource[] generateTaintedFromThese;

		private readonly Dictionary<string, Resource> resourceDictionary = new Dictionary<string, Resource>();

		private readonly List<Resource> qualityItems = new List<Resource>();

		private readonly List<Resource> structurePilesCache = new List<Resource>();

		private readonly Dictionary<string, HashSet<Resource>> resourcesListBySortingGroup = new Dictionary<string, HashSet<Resource>>();

		private Dictionary<string, Resource> resourcesByProtoId = new Dictionary<string, Resource>();

		private Dictionary<string, Resource> resourcesByGroupId;

		private Dictionary<ItemMaterialCategory, List<Resource>> resourcesByMaterialCategory;

		private Dictionary<ResourceCategory, List<Resource>> resourcesByResourceCategory;

		private Dictionary<string, List<Resource>> resourceListsByProtoId;

		private Dictionary<string, List<Resource>> resourceListsByGroupIdentifier;

		private List<Resource> uniqueResources = new List<Resource>();

		private bool uniqueResourcesInit;

		private static readonly HashSet<string> ResourcesInRoomTypes = new HashSet<string>();

		private Dictionary<IngredientFlags, Resource> resourcesByIngredientFlags = new Dictionary<IngredientFlags, Resource>();

		private HashSet<Resource> uniqueResourcesWithIngredients = new HashSet<Resource>();

		public Resource[] ProtoItems => protoItems;

		public Resource[] GenerateTaintedFromThese => generateTaintedFromThese;

		public Dictionary<IngredientFlags, Resource> ResourcesByIngredientFlags => resourcesByIngredientFlags;

		public HashSet<Resource> UniqueResourcesWithIngredients => uniqueResourcesWithIngredients;

		private Dictionary<string, Resource> ResourcesByProtoId
		{
			get
			{
				if (resourcesByProtoId == null)
				{
					resourcesByProtoId = new Dictionary<string, Resource>();
				}
				foreach (Resource allItem in GetAllItems())
				{
					if (!(allItem == null) && !string.IsNullOrEmpty(allItem.ProtoId) && !resourcesByProtoId.ContainsKey(allItem.ProtoId))
					{
						resourcesByProtoId.Add(allItem.ProtoId, allItem);
					}
				}
				return resourcesByProtoId;
			}
		}

		private Dictionary<string, Resource> ResourcesByGroupId
		{
			get
			{
				if (resourcesByGroupId == null)
				{
					resourcesByGroupId = new Dictionary<string, Resource>();
					foreach (Resource allItem in GetAllItems())
					{
						if (!(allItem == null) && !string.IsNullOrEmpty(allItem.GroupIdentifier) && !resourcesByGroupId.ContainsKey(allItem.GroupIdentifier))
						{
							resourcesByGroupId.Add(allItem.GroupIdentifier, allItem);
						}
					}
				}
				return resourcesByGroupId;
			}
		}

		private Dictionary<string, List<Resource>> ResourceListsByProtoId
		{
			get
			{
				if (resourceListsByProtoId == null)
				{
					resourceListsByProtoId = new Dictionary<string, List<Resource>>();
					foreach (Resource allItem in GetAllItems())
					{
						if (!(allItem == null) && !string.IsNullOrEmpty(allItem.ProtoId))
						{
							if (!resourceListsByProtoId.ContainsKey(allItem.ProtoId))
							{
								resourceListsByProtoId.Add(allItem.ProtoId, new List<Resource>());
							}
							resourceListsByProtoId[allItem.ProtoId].Add(allItem);
						}
					}
				}
				return resourceListsByProtoId;
			}
		}

		public List<Resource> StructurePilesCache => structurePilesCache;

		public List<Resource> UniqueResources
		{
			get
			{
				if (!uniqueResourcesInit)
				{
					uniqueResourcesInit = true;
					uniqueResources = new List<Resource>();
					foreach (Resource allItem in base.AllItems)
					{
						if (allItem.UniqueResource)
						{
							uniqueResources.Add(allItem);
						}
					}
				}
				return uniqueResources;
			}
		}

		public ResourceRepository()
		{
			SplitProtoItems();
			CacheAllResources();
			CacheResourcesByGroupIdentifiers();
		}

		public Resource GetByIngredientFlags(IngredientFlags flags)
		{
			return resourcesByIngredientFlags.GetValueOrDefault(flags);
		}

		public static bool IsResourceInRoomTypes(string resourceId)
		{
			return ResourcesInRoomTypes.Contains(resourceId);
		}

		public override bool TryGetValue(string id, out Resource model)
		{
			if (resourceDictionary.TryGetValue(id, out model))
			{
				return true;
			}
			return base.TryGetValue(id, out model);
		}

		public override Resource GetByID(string id)
		{
			if (resourceDictionary.TryGetValue(id, out var value))
			{
				return value;
			}
			return base.GetByID(id);
		}

		public override IEnumerable<Resource> GetAllItems()
		{
			return regularItems.Union(qualityItems).Union(structurePilesCache);
		}

		public Resource GetByGroupIdentifier(string groupIdentifier)
		{
			resourceListsByGroupIdentifier.TryGetValue(groupIdentifier, out var value);
			if (value == null)
			{
				return null;
			}
			foreach (Resource item in value)
			{
				if (item.GroupIdentifier.Equals(groupIdentifier))
				{
					return item;
				}
			}
			return null;
		}

		public string GetByIDWithoutQuality(string resourceId)
		{
			return ResourceUtils.GetTruncatedQualityID(GetByID(resourceId));
		}

		public bool ContainsProtoId(string protoId)
		{
			return ResourcesByProtoId.ContainsKey(protoId);
		}

		public Resource GetProtoItemById(string id)
		{
			Resource resource = protoItems.FirstOrDefault((Resource res) => res.GetID().Equals(id));
			if (resource == null)
			{
				Resource resource2 = GetAllItems().FirstOrDefault((Resource res) => res.GetID().Equals(id));
				if (resource2 == null)
				{
					return null;
				}
				resource = protoItems.FirstOrDefault((Resource proto) => proto.GetID().Equals(resource2.ProtoId));
			}
			return resource;
		}

		public IEnumerable<Resource> GetAllResourcesByMaterial(ItemMaterialCategory materialCategory)
		{
			if (resourcesByMaterialCategory == null)
			{
				resourcesByMaterialCategory = new Dictionary<ItemMaterialCategory, List<Resource>>();
				ItemMaterialCategory[] itemMaterialCategories = EnumValues.ItemMaterialCategories;
				for (int i = 0; i < itemMaterialCategories.Length; i++)
				{
					ItemMaterialCategory itemMaterialCategory = itemMaterialCategories[i];
					if (itemMaterialCategory.Equals(ItemMaterialCategory.None))
					{
						continue;
					}
					resourcesByMaterialCategory[itemMaterialCategory] = new List<Resource>();
					foreach (Resource allItem in GetAllItems())
					{
						if (allItem.ItemMaterialCategory.Equals(itemMaterialCategory))
						{
							resourcesByMaterialCategory[itemMaterialCategory].Add(allItem);
						}
					}
				}
			}
			return resourcesByMaterialCategory[materialCategory];
		}

		public IEnumerable<Resource> GetAllResourcesByResourceCategory(ResourceCategory resourceCategory)
		{
			if (resourcesByResourceCategory == null)
			{
				resourcesByResourceCategory = new Dictionary<ResourceCategory, List<Resource>>();
				ResourceCategory[] allResourceCategories = EnumValues.AllResourceCategories;
				foreach (ResourceCategory resourceCategory2 in allResourceCategories)
				{
					resourcesByResourceCategory[resourceCategory2] = new List<Resource>();
					foreach (Resource allItem in GetAllItems())
					{
						if (allItem.Category.HasFlag(resourceCategory2))
						{
							resourcesByResourceCategory[resourceCategory2].Add(allItem);
						}
					}
				}
			}
			return resourcesByResourceCategory[resourceCategory];
		}

		public IEnumerable<Resource> GetAllResourcesByProtoId(string protoId)
		{
			if (!ResourceListsByProtoId.ContainsKey(protoId))
			{
				return null;
			}
			return ResourceListsByProtoId[protoId];
		}

		public IEnumerable<Resource> GetAllResourcesBySortingGroup(string groupId)
		{
			lock (Padlock)
			{
				if (!resourcesListBySortingGroup.ContainsKey(groupId))
				{
					HashSet<Resource> hashSet = new HashSet<Resource>();
					foreach (Resource allItem in GetAllItems())
					{
						if (groupId.Equals(allItem.SortingGroup) || Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(allItem.SortingGroup, groupId))
						{
							hashSet.Add(allItem);
						}
					}
					resourcesListBySortingGroup.Add(groupId, hashSet);
				}
				return resourcesListBySortingGroup[groupId];
			}
		}

		public List<string> GetUniqueItemsWithoutQuality()
		{
			return (from res in GetAllItems()
				where res.HasQuality
				select res).Select(ResourceUtils.GetTruncatedQualityID).Distinct().ToList();
		}

		public IEnumerable<string> GetItemGroups()
		{
			return from item in GetAllItems()
				where item.HasQuality
				group item by item.GroupIdentifier into item
				select item.Key;
		}

		public Resource GetByProtoID(string blueprintID)
		{
			if (ResourcesByProtoId.TryGetValue(blueprintID, out var value))
			{
				return value;
			}
			Resource resource = ProtoItems.FirstOrDefault((Resource res) => res.GetID().Equals(blueprintID));
			if ((object)resource != null)
			{
				return resource;
			}
			return null;
		}

		public bool ContainsGroup(string groupIdentifier)
		{
			return ResourcesByGroupId.ContainsKey(groupIdentifier);
		}

		public Resource GetByGroup(string groupIdentifier)
		{
			return ResourcesByGroupId.GetValueOrDefault(groupIdentifier);
		}

		public void CacheStructurePiles(List<Resource> structurePiles)
		{
			structurePilesCache.Clear();
			structurePilesCache.AddRange(structurePiles);
			CacheAllResources();
			CacheResourcesByGroupIdentifiers();
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\ResourceRepository.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Adding ");
				messageBuilder.AppendFormatted(structurePiles.Count());
				messageBuilder.AppendLiteral("  building items to repo");
			}
			Log.Debug(messageBuilder);
		}

		public void CacheEquipmentQualityItems()
		{
			Log.Debug("Initialize Equipment Quality Items", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\ResourceRepository.cs");
			qualityItems.Clear();
			resourcesByProtoId = new Dictionary<string, Resource>();
			Resource[] array = protoItems;
			foreach (Resource resource in array)
			{
				ItemQuality[] itemQualities = EquipmentUtils.GetItemQualities(resource.GetID());
				bool isEnabled;
				if (itemQualities == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\ResourceRepository.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(resource.GetID());
						messageBuilder.AppendLiteral(" has no Item Quality");
					}
					Log.Error(messageBuilder);
					continue;
				}
				string[] materials = resource.Materials;
				foreach (string text in materials)
				{
					MaterialSettings materialSettings = null;
					string arg = resource.GetID();
					if (!text.Equals(string.Empty))
					{
						arg = text + "_" + resource.GetID();
						materialSettings = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(text);
						if (materialSettings == null)
						{
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Resources\\ResourceRepository.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("There is no ");
								messageBuilder.AppendFormatted(text);
								messageBuilder.AppendLiteral(" material");
							}
							Log.Error(messageBuilder);
						}
					}
					ItemQuality[] array2 = itemQualities;
					foreach (ItemQuality itemQuality in array2)
					{
						string text2 = $"{itemQuality.Quality}_{arg}".ToLower(CultureInfo.InvariantCulture);
						float num = MultiplySafely(resource.Hitpoints, itemQuality.HitpointsMultiplier);
						float num2 = MultiplySafely(resource.WealthPoints, itemQuality.WealthPointsMultiplier);
						float num3 = resource.Weight;
						ItemMaterialCategory itemMaterialCategory = resource.ItemMaterialCategory;
						List<KeyIntPair> list = new List<KeyIntPair>();
						list.AddRange(resource.DismantledProduct);
						string text3 = string.Empty;
						AssetByQuality[] equippedTexturePaths = resource.EquippedTexturePaths?.Where((AssetByQuality assetByQuality) => assetByQuality.Quality.Equals(itemQuality.Quality) || assetByQuality.Quality.Equals(ProductQuality.None)).ToArray();
						if (materialSettings != null)
						{
							text3 = text;
							num = MultiplySafely(num, materialSettings.HitpointsMultiplier);
							num2 = MultiplySafely(num2, materialSettings.WealthPointsMultiplier);
							num3 = MultiplySafely(num3, materialSettings.WeightMultiplier);
							itemMaterialCategory = (materialSettings.ItemMaterialCategory.Equals(ItemMaterialCategory.None) ? itemMaterialCategory : materialSettings.ItemMaterialCategory);
							list[0] = new KeyIntPair(resource.DismantledProduct[0].GetID().Replace("<materialOverride>", materialSettings.DismantledProductsOverride), resource.DismantledProduct[0].Value);
						}
						Resource resource2 = new Resource();
						resource2.SetupResourceWithQuality(text2, resource.IconPath, resource.IconBackgroundPath, resource.LocKeys, resource.GroupIdentifier, resource.ProtoId, resource.HasQuality, itemQuality.Quality, num3, resource.StackingLimit, num, resource.DecomposeModifiersId, num2, resource.SortingGroup, resource.AlmanacTags, itemMaterialCategory, resource.Category, resource.HaulPriority, list, new string[1] { text3 }, equippedTexturePaths, itemQuality, resource);
						resourcesByProtoId.TryAdd(resource.ProtoId, resource2);
						qualityItems.Add(resource2);
						if (resource.GenerateTaintedVersion)
						{
							Resource resource3 = new Resource();
							string id = (text2 + "_tainted").ToLower(CultureInfo.InvariantCulture);
							resource3.SetupResourceWithQuality(id, resource.IconPath, resource.IconBackgroundPath, resource.LocKeys, resource.GroupIdentifier, resource.ProtoId, resource.HasQuality, itemQuality.Quality, num3, resource.StackingLimit, num, resource.DecomposeModifiersId, num2, resource.SortingGroup, resource.AlmanacTags, itemMaterialCategory, resource.Category, resource.HaulPriority, list, new string[1] { text3 }, equippedTexturePaths, itemQuality, resource, tainted: true);
							resourcesByProtoId.TryAdd(resource.ProtoId, resource3);
							qualityItems.Add(resource3);
						}
					}
				}
			}
			CacheAllResources();
			CacheResourcesByGroupIdentifiers();
		}

		private void CacheAllResources()
		{
			resourceDictionary.Clear();
			foreach (Resource allItem in GetAllItems())
			{
				resourceDictionary.TryAdd(allItem.GetID(), allItem);
				List<IngredientFlags> producedFromIngredients = allItem.ProducedFromIngredients;
				if (producedFromIngredients == null || producedFromIngredients.Count <= 0)
				{
					continue;
				}
				foreach (IngredientFlags producedFromIngredient in allItem.ProducedFromIngredients)
				{
					if (resourcesByIngredientFlags.TryAdd(producedFromIngredient, allItem))
					{
						uniqueResourcesWithIngredients.Add(allItem);
					}
				}
			}
		}

		private void CacheResourcesByGroupIdentifiers()
		{
			if (resourceListsByGroupIdentifier == null)
			{
				resourceListsByGroupIdentifier = new Dictionary<string, List<Resource>>();
			}
			foreach (Resource allItem in GetAllItems())
			{
				if (!resourceListsByGroupIdentifier.ContainsKey(allItem.GroupIdentifier))
				{
					resourceListsByGroupIdentifier.Add(allItem.GroupIdentifier, new List<Resource>());
				}
				resourceListsByGroupIdentifier[allItem.GroupIdentifier].Add(allItem);
			}
		}

		protected override string JsonFile()
		{
			return "Resources/Resources.json";
		}

		protected override void Refresh()
		{
			base.Refresh();
			SplitProtoItems();
			CacheAllResources();
			CacheResourcesByGroupIdentifiers();
			CacheResourcesInRoomTypes();
		}

		private void CacheResourcesInRoomTypes()
		{
			ResourcesInRoomTypes.Clear();
			foreach (RoomType allItem in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems())
			{
				foreach (RoomTypeMustHave item in allItem.MustHave)
				{
					ResourcesInRoomTypes.UnionWith(item.Content);
				}
				ResourcesInRoomTypes.UnionWith(allItem.CantHave);
			}
			ResourcesInRoomTypes.IntersectWith(dictionary.Keys);
		}

		private void SplitProtoItems()
		{
			protoItems = base.AllItems.Where((Resource r) => r.HasQuality).ToArray();
			regularItems = base.AllItems.Where((Resource r) => !r.HasQuality).ToArray();
			generateTaintedFromThese = base.AllItems.Where((Resource r) => r.GenerateTaintedVersion).ToArray();
			resourceDictionary.Clear();
			Resource[] array = regularItems;
			foreach (Resource resource in array)
			{
				resourceDictionary.Add(resource.GetID(), resource);
			}
		}

		private float MultiplySafely(float baseValue, float multiplier)
		{
			if (multiplier == 0f)
			{
				return baseValue;
			}
			return baseValue * multiplier;
		}
	}
}
