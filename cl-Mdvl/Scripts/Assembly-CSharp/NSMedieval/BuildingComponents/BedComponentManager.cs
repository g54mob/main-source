using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class BedComponentManager : ComponentBaseManager<BedComponent, BedComponentInstance>
	{
		private readonly Dictionary<BedType, List<BedComponentInstance>> bedTypeComponentInstance = new Dictionary<BedType, List<BedComponentInstance>>();

		private readonly object bedTypeComponentLock = new object();

		public BedComponentManager(VillageMap map)
			: base(map)
		{
			MonoSingleton<LifeController>.Instance.WakeUpEvent += OnWakeUpEvent;
			bedTypeComponentInstance.Add(BedType.Basic, new List<BedComponentInstance>());
			bedTypeComponentInstance.Add(BedType.Medical, new List<BedComponentInstance>());
		}

		public override void Dispose()
		{
			if (MonoSingleton<LifeController>.IsInstantiated())
			{
				MonoSingleton<LifeController>.Instance.WakeUpEvent -= OnWakeUpEvent;
			}
			base.Dispose();
		}

		public List<BedComponentInstance> GetBeds(BedType bedType)
		{
			lock (bedTypeComponentLock)
			{
				bedTypeComponentInstance.TryGetValue(bedType, out var value);
				return value;
			}
		}

		public bool OwnsABed(HumanoidInstance humanoidInstance)
		{
			return InstanceComponentDictionary.Keys.Any((BedComponentInstance bed) => bed.OwnerBuilding.BuildingOwnershipInfo?.IsOwner(humanoidInstance) ?? false);
		}

		public override void AddToCache(BedComponent component, BedComponentInstance instance)
		{
			base.AddToCache(component, instance);
			BedType bedType = instance.Blueprint.BedType;
			lock (bedTypeComponentLock)
			{
				if (bedTypeComponentInstance.TryGetValue(bedType, out var value))
				{
					value.Add(instance);
				}
			}
		}

		public override void RemoveFromCache(BedComponentInstance bedComponentInstance)
		{
			base.RemoveFromCache(bedComponentInstance);
			BedType bedType = bedComponentInstance.Blueprint.BedType;
			lock (bedTypeComponentLock)
			{
				if (bedTypeComponentInstance.TryGetValue(bedType, out var value))
				{
					value.Remove(bedComponentInstance);
				}
			}
		}

		protected override void OnWorkerRemoved(HumanoidInstance humanoidInstance)
		{
			base.OnWorkerRemoved(humanoidInstance);
			if (humanoidInstance == null || (!humanoidInstance.HasDisposed && !humanoidInstance.HasDied) || !bedTypeComponentInstance.TryGetValue(BedType.Basic, out var value))
			{
				return;
			}
			foreach (BedComponentInstance item in value)
			{
				BuildingOwnershipInfo buildingOwnershipInfo = item.OwnerBuilding.BuildingOwnershipInfo;
				if (buildingOwnershipInfo != null && buildingOwnershipInfo.IsOwner(humanoidInstance))
				{
					item.OwnerBuilding.BuildingOwnershipInfo.ClearTempOwner();
					item.OwnerBuilding.BuildingOwnershipInfo.ClearOwner();
				}
			}
		}

		private void OnWakeUpEvent(StatsInstance instance)
		{
			if (!(instance.Owner is HumanoidInstance humanoidInstance))
			{
				return;
			}
			lock (bedTypeComponentLock)
			{
				foreach (BedComponentInstance bed in GetBeds(BedType.Basic))
				{
					if (bed.OwnerBuilding.BuildingOwnershipInfo != null && bed.OwnerBuilding.BuildingOwnershipInfo.TempOwner == humanoidInstance)
					{
						bed.OwnerBuilding.BuildingOwnershipInfo.ClearTempOwner();
						break;
					}
				}
			}
		}
	}
}
