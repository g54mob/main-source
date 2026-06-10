using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map
{
	public class RegionAreaManager : IGameDisposable, IDisposable
	{
		private uint uniqueIdGenerator;

		private VillageMap map;

		private bool isInitialized;

		private readonly Dictionary<uint, Area> areas = new Dictionary<uint, Area>();

		private readonly HashSet<uint> recalculationQueue = new HashSet<uint>();

		public Dictionary<uint, Area> Areas => areas;

		public bool HasDisposed { get; private set; }

		public event Action<IGameDisposable> OnDisposedEvent;

		public RegionAreaManager(VillageMap map)
		{
			this.map = map;
		}

		public void Initialize()
		{
			List<Region> regions = map.RegionManager.Regions;
			bool flag = true;
			foreach (Region item in regions)
			{
				if (item.Area == 0)
				{
					if (flag)
					{
						flag = false;
						GenerateAreaAndAddRegion(item);
					}
					else
					{
						AssignRegionToArea(item);
					}
				}
			}
		}

		public void Dispose()
		{
			if (HasDisposed)
			{
				return;
			}
			foreach (Area value in areas.Values)
			{
				value.Dispose();
			}
			areas.Clear();
			if (!LoadingController.IsLeavingMainScene)
			{
				this.OnDisposedEvent?.Invoke(this);
			}
			this.OnDisposedEvent = null;
			HasDisposed = true;
			map = null;
		}

		internal void GetAreasTouchingEdge(ISet<uint> areasTouchingEdge)
		{
			areasTouchingEdge.Clear();
			foreach (KeyValuePair<uint, Area> area in Areas)
			{
				if (area.Value != null && area.Value.IsTouchingEdge)
				{
					areasTouchingEdge.Add(area.Value.Id);
				}
			}
		}

		internal Area GetAreaById(uint id)
		{
			if (id == 0)
			{
				return null;
			}
			return areas.GetValueOrDefault(id);
		}

		internal void AssignRegionToArea(Region region)
		{
			if (region.IsBridge)
			{
				if (region.Area != 0)
				{
					throw new Exception($"Bridge region {region.UniqueId} already in area {region.Area}, but still trying to be area re-assigned somehow.");
				}
				GenerateAreaAndAddRegion(region);
				return;
			}
			foreach (Region connection in region.Connections)
			{
				if (!connection.IsBridge && connection.Area != 0)
				{
					(GetAreaById(connection.Area) ?? throw new Exception($"Area {connection.Area} object instance not found! Thous hold never happen. Region probably not removed from area, but area was disposed.")).AddRegion(region);
					return;
				}
			}
			uint num = AreaFloodFill.FindDirectAreaId(region);
			if (num == 0)
			{
				GenerateAreaAndAddRegion(region);
			}
			else
			{
				areas[num].AddRegion(region);
			}
		}

		private Area GenerateAreaAndAddRegion(Region region)
		{
			uniqueIdGenerator++;
			Area area = new Area(uniqueIdGenerator, region.Map, region.IsBridge);
			area.AddRegion(region);
			areas.Add(area.Id, area);
			area.OnDisposedEvent += delegate(IGameDisposable disposable)
			{
				areas.Remove(((Area)disposable).Id);
			};
			return area;
		}

		internal void QueueForRecalculation(uint areaId)
		{
			if (areaId != 0)
			{
				recalculationQueue.Add(areaId);
			}
		}

		internal void RecalculateAreas()
		{
			if (recalculationQueue.Count == 0)
			{
				return;
			}
			HashSet<Region> hashSet = null;
			while (recalculationQueue.Count > 0)
			{
				uint num = recalculationQueue.First();
				recalculationQueue.Remove(num);
				Area areaById = GetAreaById(num);
				if (areaById == null)
				{
					continue;
				}
				if (areaById.IsBridge)
				{
					if (!areaById.IsValidBridge())
					{
						areaById.ConnectionsSafeForEach(delegate(Region areaConnection)
						{
							QueueForRecalculation(areaConnection.Area);
						});
						areaById.Dispose();
					}
					continue;
				}
				HashSet<Region> hashSet2 = areaById.ReFloodArea();
				if (areaById.Regions.Count == 0)
				{
					areaById.Dispose();
				}
				if (hashSet == null)
				{
					hashSet = hashSet2;
					continue;
				}
				foreach (Region item in hashSet2)
				{
					hashSet.Add(item);
				}
				HashSetPool<Region>.Return(hashSet2);
			}
			if (hashSet == null)
			{
				return;
			}
			foreach (Region item2 in hashSet)
			{
				if (item2.Area == 0)
				{
					AssignRegionToArea(item2);
				}
			}
			HashSetPool<Region>.Return(hashSet);
		}
	}
}
