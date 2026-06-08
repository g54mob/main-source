using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class UpgradeHelper
	{
		public static void AddUpgrades(IFranchiseUpgrade upg, Entity ent, EntityContext ctx)
		{
			if (!(upg is CUpgradeExtraDish data))
			{
				if (!(upg is CUpgradeExtraLayout data2))
				{
					if (!(upg is CUpgradeHasGarage data3))
					{
						if (!(upg is CUpgradeAdvancedBuildMode data4))
						{
							if (upg is CUpgradeDishCabinet data5)
							{
								ctx.Set(ent, data5);
							}
							else
							{
								Debug.LogWarning($"Unhandled upgrade ${upg}");
							}
						}
						else
						{
							ctx.Set(ent, data4);
						}
					}
					else
					{
						ctx.Set(ent, data3);
					}
				}
				else
				{
					ctx.Set(ent, data2);
				}
			}
			else
			{
				ctx.Set(ent, data);
			}
		}
	}
}
