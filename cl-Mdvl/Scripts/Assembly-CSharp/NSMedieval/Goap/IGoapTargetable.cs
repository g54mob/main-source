using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IGoapTargetable : IGameDisposable, IDisposable
	{
		Vector3 GetPosition();

		Vec3Int GetGridPosition();

		string GetLocalizedName()
		{
			if (!(this is BaseBuildingInstance baseBuildingInstance))
			{
				if (!(this is CropfieldInstance cropfieldInstance))
				{
					if (!(this is ResourcePileInstance resourcePileInstance))
					{
						if (!(this is CreatureBase attacker))
						{
							if (!(this is MapResourceInstance mapResourceInstance))
							{
								if (!(this is StockpileInstance { StorageName: var storageName }))
								{
									return string.Empty;
								}
								return storageName;
							}
							return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(mapResourceInstance.GetBlueprint().LocKeys));
						}
						return CreatureBaseUtils.GetCreatureName(attacker);
					}
					return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(resourcePileInstance.Blueprint.LocKeys));
				}
				return MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(cropfieldInstance.Blueprint.LocKeys));
			}
			return baseBuildingInstance.GetBuildingName();
		}
	}
}
