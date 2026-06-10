using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Repository
{
	public abstract class BackgroundRepositoryBase<TM, TB> : DynamicJsonRepository<TM, TB> where TM : Repository<TM, TB> where TB : BackgroundBase
	{
		public BackgroundRepositoryBase()
		{
		}

		public List<TB> GetAvailableBackgrounds(List<WorkerCharacteristicType> ignoreTypes)
		{
			List<TB> list = new List<TB>();
			foreach (TB allItem in GetAllItems())
			{
				if (!allItem.IgnoreCharacteristicType.Intersect(ignoreTypes).Any())
				{
					list.Add(allItem);
				}
			}
			return list;
		}

		public TB GetBackground(List<WorkerCharacteristicType> ignoreTypes, int religionAlignment)
		{
			List<TB> availableBackgrounds = GetAvailableBackgrounds(ignoreTypes);
			if (availableBackgrounds.Count == 0)
			{
				Log.Info("Couldn't find available background or backstory, adding all to the pool", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Workers\\BackgroundRepositoryBase.cs");
				availableBackgrounds.AddRange(GetAllItems());
			}
			List<TB> list = availableBackgrounds.FindAll((TB background) => (religionAlignment == 1) ? (background.ReligiousAlignment >= 0f) : (background.ReligiousAlignment <= 0f));
			TB val;
			if (list.Count > 0)
			{
				val = list[Random.Range(0, list.Count)];
			}
			else
			{
				Log.Info("Couldn't find available Religious background or backstory choosing from whole pool " + availableBackgrounds.Count, "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Workers\\BackgroundRepositoryBase.cs");
				val = availableBackgrounds[Random.Range(0, availableBackgrounds.Count)];
			}
			ignoreTypes.AddRange(val.AddCharacteristicTypeToIgnore);
			return val;
		}
	}
}
