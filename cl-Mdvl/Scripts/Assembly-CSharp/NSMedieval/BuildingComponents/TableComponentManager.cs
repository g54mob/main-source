using System.Linq;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class TableComponentManager : ComponentBaseManager<TableComponent, TableComponentInstance>
	{
		public TableComponentManager(VillageMap map)
			: base(map)
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
		}

		private void OnMapLoaded(bool loadedFromSave)
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (loadedFromSave)
			{
				TableComponentInstance[] array = InstanceComponentDictionary.Keys.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].FindNearbyChairs();
				}
			}
		}
	}
}
