using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class EffectorRepository : DynamicJsonRepository<EffectorRepository, StatEffector>
	{
		public override StatEffector GetByID(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				Log.Warning("Effector id should never be null or empty!", "C:\\GIT\\dev\\Assets\\Scripts\\StatsSystem\\Repo\\EffectorRepository.cs");
				return null;
			}
			StatEffector byID = base.GetByID(id);
			if (!(byID != null))
			{
				return Repository<WoundsRepository, StatEffectorWound>.Instance.GetByID(id);
			}
			return byID;
		}

		public override bool TryGetValue(string id, out StatEffector model)
		{
			if (base.TryGetValue(id, out model))
			{
				return true;
			}
			if (!Repository<WoundsRepository, StatEffectorWound>.Instance.TryGetValue(id, out var model2))
			{
				return false;
			}
			model = model2;
			return true;
		}

		public StatEffector GetByLongestDuration(List<string> effectorIds)
		{
			float num = 0f;
			StatEffector result = GetByID(effectorIds.First());
			foreach (string effectorId in effectorIds)
			{
				StatEffector byID = GetByID(effectorId);
				if (byID.Duration > num)
				{
					num = byID.Duration;
					result = byID;
				}
			}
			return result;
		}

		protected override string JsonFile()
		{
			return "StatsSystem/Effectors.json";
		}
	}
}
