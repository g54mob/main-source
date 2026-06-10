using System.Linq;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class ChairComponentManager : ComponentBaseManager<ChairComponent, ChairComponentInstance>
	{
		public ChairComponentManager(VillageMap map)
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
				ChairComponentInstance[] array = InstanceComponentDictionary.Keys.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].FindNearbyTables();
				}
			}
		}
	}
}
