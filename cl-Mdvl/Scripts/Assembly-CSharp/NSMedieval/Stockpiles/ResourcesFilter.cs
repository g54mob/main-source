using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Extensions;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Stockpiles
{
	[FVSerializableKey("ResourcesFilter", "")]
	public class ResourcesFilter : ISerializationCallbackReceiver, IFVSerializable
	{
		[SerializeField]
		private IntRange hitPointsPercent;

		[SerializeField]
		private IntRange quality;

		[SerializeField]
		private IntRange freshnessPercent;

		[SerializeField]
		private List<string> allowedResourceTypesSave;

		private HashSet<Resource> allowedResourceTypes;

		[SerializeField]
		private List<string> allowedByBlueprintSave;

		private HashSet<Resource> defaultAllowedResources;

		public IntRange HitPointsPercent => hitPointsPercent;

		public IntRange FreshnessPercent => freshnessPercent;

		public IntRange Quality => quality;

		public HashSet<Resource> AllowedResourceTypes => allowedResourceTypes;

		public HashSet<Resource> DefaultAllowedResources => defaultAllowedResources;

		public event Action OnParamsChangedEvent;

		public ResourcesFilter()
		{
			hitPointsPercent = new IntRange(0, 100);
			freshnessPercent = new IntRange(0, 100);
			quality = new IntRange(ProductionUtils.DefaultQualityRange);
			allowedResourceTypes = new HashSet<Resource>();
			defaultAllowedResources = new HashSet<Resource>();
		}

		public ResourcesFilter(ResourcesFilter resourcesFilter)
		{
			hitPointsPercent = resourcesFilter.hitPointsPercent;
			freshnessPercent = resourcesFilter.freshnessPercent;
			quality = resourcesFilter.quality;
			allowedResourceTypes = resourcesFilter.allowedResourceTypes;
			defaultAllowedResources = resourcesFilter.defaultAllowedResources;
		}

		public ResourcesFilter DeepCopy()
		{
			ResourcesFilter resourcesFilter = new ResourcesFilter();
			if (hitPointsPercent != null)
			{
				resourcesFilter.hitPointsPercent = new IntRange(hitPointsPercent.Min, hitPointsPercent.Max);
			}
			if (quality != null)
			{
				resourcesFilter.quality = new IntRange(quality.Min, quality.Max);
			}
			if (freshnessPercent != null)
			{
				resourcesFilter.freshnessPercent = new IntRange(freshnessPercent.Min, freshnessPercent.Max);
			}
			if (allowedResourceTypesSave != null)
			{
				resourcesFilter.allowedResourceTypesSave = new List<string>(allowedResourceTypesSave);
			}
			if (allowedResourceTypes != null)
			{
				resourcesFilter.allowedResourceTypes = new HashSet<Resource>(allowedResourceTypes);
			}
			if (allowedByBlueprintSave != null)
			{
				resourcesFilter.allowedByBlueprintSave = new List<string>(allowedByBlueprintSave);
			}
			if (defaultAllowedResources != null)
			{
				resourcesFilter.defaultAllowedResources = new HashSet<Resource>(defaultAllowedResources ?? (defaultAllowedResources = new HashSet<Resource>()));
			}
			return resourcesFilter;
		}

		public bool IsValid(ResourceInstance resource)
		{
			if (resource == null || resource.Amount == 0 || resource.Blueprint == null)
			{
				return false;
			}
			if (!allowedResourceTypes.Contains(resource.Blueprint))
			{
				return false;
			}
			if (resource.Blueprint.HasQuality && !quality.InRange((int)resource.Blueprint.Quality))
			{
				return false;
			}
			if (!hitPointsPercent.InRange((int)resource.GetHealthInPercentage()))
			{
				return false;
			}
			StatInstance stat = resource.GetStat(StatType.Freshness);
			if (stat != null && !stat.Current.IsCloseToZero() && !freshnessPercent.InRange((int)resource.GetFreshnessInPercentage()))
			{
				return false;
			}
			return true;
		}

		public bool IsValid(Resource blueprint)
		{
			if (blueprint == null)
			{
				return false;
			}
			if (!allowedResourceTypes.Contains(blueprint))
			{
				return false;
			}
			if (blueprint.HasQuality && !quality.InRange((int)blueprint.Quality))
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", "HitPointsPercent", HitPointsPercent, "Quality", Quality, "AllowedResourceTypes", AllowedResourceTypes.ToPrettyString());
		}

		public bool IsBlueprintAllowed(Resource blueprint)
		{
			if (blueprint != null)
			{
				return allowedResourceTypes.Contains(blueprint);
			}
			return false;
		}

		public bool IsBlueprintAllowed(string id)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(id);
			if (byID != null)
			{
				return allowedResourceTypes.Contains(byID);
			}
			return false;
		}

		public bool HasGroupIdentifierEnabled(string id)
		{
			return allowedResourceTypes.Any((Resource item) => item.GroupIdentifier.Equals(id));
		}

		public void AddAllowedResource(string blueprintId)
		{
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintId);
			if (!(byID == null))
			{
				allowedResourceTypes.Add(byID);
				ParametersChanged();
			}
		}

		public void AddAllowedResource(Resource blueprint)
		{
			allowedResourceTypes.Add(blueprint);
			ParametersChanged();
		}

		public void CacheDefaultAllowedResources(Resource blueprint)
		{
			if (defaultAllowedResources == null)
			{
				defaultAllowedResources = new HashSet<Resource>();
			}
			if (allowedByBlueprintSave == null)
			{
				allowedByBlueprintSave = new List<string>();
			}
			if (defaultAllowedResources.Add(blueprint))
			{
				allowedByBlueprintSave.Add(blueprint.GetID());
			}
		}

		public void AddAllowedResource(IEnumerable<Resource> resources)
		{
			foreach (Resource resource in resources)
			{
				allowedResourceTypes.Add(resource);
			}
			ParametersChanged();
		}

		public void AddAllowedResourceByGroupId(string groupId, ItemMaterialCategory category)
		{
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (allItem.ItemMaterialCategory == category && allItem.GroupIdentifier.Equals(groupId))
				{
					allowedResourceTypes.Add(allItem);
				}
			}
			ParametersChanged();
		}

		public void RemoveAllowedResourceByGroupId(string groupId)
		{
			allowedResourceTypes.RemoveWhere((Resource item) => item.GroupIdentifier.Equals(groupId));
			ParametersChanged();
		}

		public void RemoveAllowedResource(string blueprintId)
		{
			allowedResourceTypes.RemoveWhere((Resource item) => item.GetID().Equals(blueprintId));
			ParametersChanged();
		}

		public void RemoveAllowedResource(Resource blueprint)
		{
			allowedResourceTypes.Remove(blueprint);
			ParametersChanged();
		}

		public void RemoveAllowedResource(IEnumerable<Resource> resources)
		{
			foreach (Resource resource in resources)
			{
				allowedResourceTypes.Remove(resource);
			}
			ParametersChanged();
		}

		public void SetAllowedResourceTypes(IEnumerable<Resource> allowedResourceTypes)
		{
			this.allowedResourceTypes.Clear();
			foreach (Resource allowedResourceType in allowedResourceTypes)
			{
				this.allowedResourceTypes.Add(allowedResourceType);
			}
		}

		public void ClearAllowedResourceTypes()
		{
			allowedResourceTypes.Clear();
		}

		public void SetQuality(IntRange quality)
		{
			if (this.quality != quality)
			{
				this.quality = quality;
				ParametersChanged();
			}
		}

		public void SetHitPointsPercent(IntRange hp)
		{
			if (hitPointsPercent != hp)
			{
				hitPointsPercent = hp;
				ParametersChanged();
			}
		}

		public void SetFreshnessPercent(IntRange freshness)
		{
			if (freshnessPercent != freshness)
			{
				freshnessPercent = freshness;
				ParametersChanged();
			}
		}

		public void OnBeforeSerialize()
		{
			if (allowedResourceTypesSave == null)
			{
				allowedResourceTypesSave = new List<string>();
			}
			else
			{
				allowedResourceTypesSave.Clear();
			}
			if (allowedResourceTypes == null || allowedResourceTypes.Count == 0)
			{
				return;
			}
			foreach (Resource allowedResourceType in allowedResourceTypes)
			{
				if (allowedResourceType == null)
				{
					Log.Info("Resource is null in ResourcesFilter", "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\ResourcesFilter.cs");
				}
				else
				{
					allowedResourceTypesSave.Add(allowedResourceType.GetID());
				}
			}
		}

		public void OnAfterDeserialize()
		{
			allowedResourceTypes = new HashSet<Resource>();
			if (allowedResourceTypesSave == null || allowedResourceTypesSave.Count == 0)
			{
				return;
			}
			if (!Repository<ResourceRepository, Resource>.IsInstantiated())
			{
				Log.Warning("This should never happen! ResourceRepository.IsInstantiated", "C:\\GIT\\dev\\Assets\\Scripts\\Stockpile\\ResourcesFilter.cs");
				return;
			}
			using PooledList<string> pooledList = ListPool<string>.GetJanitor();
			foreach (string item in allowedResourceTypesSave)
			{
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(item);
				if (byID != null)
				{
					allowedResourceTypes.Add(byID);
				}
				else
				{
					pooledList.Add(item);
				}
			}
			foreach (string item2 in pooledList)
			{
				allowedResourceTypesSave.Remove(item2);
				allowedByBlueprintSave?.Remove(item2);
			}
			if (allowedByBlueprintSave == null)
			{
				return;
			}
			if (defaultAllowedResources == null)
			{
				defaultAllowedResources = new HashSet<Resource>();
			}
			HashSet<string> hashSet = HashSetPool<string>.Get();
			hashSet.UnionWith(allowedByBlueprintSave);
			if (hashSet.Count < allowedByBlueprintSave.Count)
			{
				allowedByBlueprintSave.Clear();
				allowedByBlueprintSave.AddRange(hashSet);
			}
			HashSetPool<string>.Return(hashSet);
			foreach (string item3 in allowedByBlueprintSave)
			{
				defaultAllowedResources.Add(Repository<ResourceRepository, Resource>.Instance.GetByID(item3));
			}
		}

		public void ParametersChanged()
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "param_changed", delegate
			{
				this.OnParamsChangedEvent?.Invoke();
			});
		}

		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("hitPointsPercent", hitPointsPercent);
			serializer.Write("freshnessPercent", freshnessPercent);
			serializer.Write("quality", quality);
			serializer.Write("allowedResourceTypesSave", allowedResourceTypesSave);
			serializer.Write("allowedByBlueprintSave", allowedByBlueprintSave);
		}

		public ResourcesFilter(FVDeserializer deserializer)
		{
			hitPointsPercent = deserializer.ReadObject<IntRange>("hitPointsPercent");
			freshnessPercent = deserializer.ReadObject("freshnessPercent", new IntRange(0, 100));
			quality = deserializer.ReadObject<IntRange>("quality");
			allowedResourceTypesSave = deserializer.ReadStringList("allowedResourceTypesSave");
			allowedByBlueprintSave = deserializer.ReadStringList("allowedByBlueprintSave");
			OnAfterDeserialize();
		}
	}
}
