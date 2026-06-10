using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	[FVSerializableKey("TraderStockItemBase", "")]
	public class TraderStockItemBase : IFVSerializable
	{
		private readonly FVDeserializer deserializer;

		[SerializeField]
		private string type;

		[SerializeField]
		private string value;

		[SerializeField]
		private List<TraderStockExcludeItems> exclude;

		[NonSerialized]
		private TraderStockType typeCache;

		[NonSerialized]
		private HashSet<TraderStockResource> itemsCache = new HashSet<TraderStockResource>();

		[NonSerialized]
		private HashSet<Resource> resourceCache = new HashSet<Resource>();

		[NonSerialized]
		private HashSet<Animal> animalsCache = new HashSet<Animal>();

		[SerializeField]
		private IntRange qualityRange;

		public TraderStockType Type
		{
			get
			{
				if (typeCache == TraderStockType.None && !string.IsNullOrEmpty(type))
				{
					typeCache = (TraderStockType)Enum.Parse(typeof(TraderStockType), type, ignoreCase: true);
				}
				return typeCache;
			}
		}

		public string Value => value;

		public TraderStockItemBase()
		{
		}

		public bool IsResourceExcluded(Resource resource)
		{
			if (exclude == null || exclude.Count == 0)
			{
				return false;
			}
			return exclude.Any((TraderStockExcludeItems exclude) => exclude.IsResourceExcluded(resource) || MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(resource.GetID()));
		}

		public bool IsResourceExcluded(TraderStockResource resource)
		{
			if (exclude == null || exclude.Count == 0)
			{
				return false;
			}
			return exclude.Any((TraderStockExcludeItems exclude) => exclude.IsResourceExcluded(resource));
		}

		public bool IsResourceExcluded(TradeResource resource)
		{
			if (exclude == null || exclude.Count == 0)
			{
				return false;
			}
			return exclude.Any((TraderStockExcludeItems exclude) => exclude.IsResourceExcluded(resource));
		}

		public bool Contains(Resource resource)
		{
			TryInitCache();
			if (Type == TraderStockType.Resource && (value == null || string.IsNullOrEmpty(value)))
			{
				return !IsResourceExcluded(resource);
			}
			return resourceCache.Contains(resource);
		}

		public bool Contains(TradeResource resource)
		{
			TryInitCache();
			if (resource.IsCreature)
			{
				if (resource.Creature is AnimalInstance animalInstance)
				{
					if (Type == TraderStockType.Animal && (value == null || string.IsNullOrEmpty(value)))
					{
						return !IsResourceExcluded(resource);
					}
					return animalsCache.Contains(animalInstance.Blueprint);
				}
				return Type == TraderStockType.Prisoner;
			}
			if (Type == TraderStockType.Resource && (value == null || string.IsNullOrEmpty(value)))
			{
				return !IsResourceExcluded(resource.Resource);
			}
			return resourceCache.Contains(resource.Resource);
		}

		public bool Contains(TraderStockResource resource)
		{
			TryInitCache();
			return itemsCache.Contains(resource);
		}

		public HashSet<TraderStockResource> GetAllPossibleResources()
		{
			TryInitCache();
			return itemsCache;
		}

		private bool CheckResourceQuality(Resource res)
		{
			if (res.HasQuality && !qualityRange.IsZero())
			{
				if ((int)res.Quality >= qualityRange.Min)
				{
					return (int)res.Quality <= qualityRange.Max;
				}
				return false;
			}
			return true;
		}

		private void TryInitCache()
		{
			if (itemsCache.Count > 0)
			{
				return;
			}
			itemsCache.Clear();
			resourceCache.Clear();
			animalsCache.Clear();
			if (Type != TraderStockType.Prisoner && (value == null || string.IsNullOrEmpty(value)))
			{
				return;
			}
			IEnumerable<Resource> enumerable = null;
			switch (Type)
			{
			case TraderStockType.ProtoId:
				enumerable = from res in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
					where res.ProtoId != null && res.ProtoId.Equals(value) && !IsResourceExcluded(res) && CheckResourceQuality(res)
					select res;
				break;
			case TraderStockType.Group:
				enumerable = from res in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
					where Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(res.SortingGroup, value) && !IsResourceExcluded(res) && CheckResourceQuality(res)
					select res;
				break;
			case TraderStockType.Material:
				enumerable = from res in Repository<ResourceRepository, Resource>.Instance.GetAllItems()
					where Value.Equals(res.Material) && !IsResourceExcluded(res) && CheckResourceQuality(res)
					select res;
				break;
			case TraderStockType.Resource:
			{
				if (MonoSingleton<GlobalSaveController>.Instance.IsBuildingLocked(value))
				{
					break;
				}
				Resource byID2 = Repository<ResourceRepository, Resource>.Instance.GetByID(value);
				if (byID2 == null)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TraderStockItemBase.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("TraderType: no resource with id ");
						messageBuilder.AppendFormatted(value);
					}
					Log.Info(messageBuilder);
				}
				else
				{
					enumerable = new List<Resource> { byID2 };
				}
				break;
			}
			case TraderStockType.Animal:
			case TraderStockType.AnimalNoTrade:
			{
				Animal byID = Repository<AnimalBaseRepository, Animal>.Instance.GetByID(value);
				if (byID != null)
				{
					itemsCache.Add(new TraderStockResource(byID));
				}
				break;
			}
			case TraderStockType.Prisoner:
				itemsCache.Add(new TraderStockResource(value));
				break;
			}
			if (enumerable == null)
			{
				return;
			}
			foreach (Resource item in enumerable)
			{
				itemsCache.Add(new TraderStockResource(item));
			}
			foreach (TraderStockResource item2 in itemsCache)
			{
				if (item2.Animal != null)
				{
					animalsCache.Add(item2.Animal);
				}
				if (item2.Resource != null)
				{
					resourceCache.Add(item2.Resource);
				}
			}
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("type", type);
			serializer.Write("value", value);
			serializer.Write("exclude", exclude);
			serializer.Write("qualityRange", qualityRange);
		}

		public TraderStockItemBase(FVDeserializer deserializer)
		{
			this.deserializer = deserializer;
			type = deserializer.ReadString("type");
			value = deserializer.ReadString("value");
			exclude = deserializer.ReadObjectList<TraderStockExcludeItems>("exclude");
			qualityRange = deserializer.ReadObject<IntRange>("qualityRange");
		}
	}
}
