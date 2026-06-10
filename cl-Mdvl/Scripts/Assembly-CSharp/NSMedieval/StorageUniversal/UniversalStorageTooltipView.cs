using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	[DisallowMultipleComponent]
	public class UniversalStorageTooltipView : TooltipViewNew
	{
		[NonSerialized]
		private ShelfComponentInstance shelfComponentInstance;

		public void Setup(ShelfComponentInstance storageHolder)
		{
			shelfComponentInstance = storageHolder;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (shelfComponentInstance == null || shelfComponentInstance.AllStorage == null)
			{
				return lines;
			}
			string localizedName = BuildingUtils.GetLocalizedName(shelfComponentInstance.OwnerBuildingID);
			AppendLine(localizedName, TooltipStyles.TooltipTitle);
			bool flag = shelfComponentInstance.IsForbidden();
			foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
			{
				StorageSlot[] storageSlots = item.StorageSlots;
				for (int i = 0; i < storageSlots.Length; i++)
				{
					ResourcePileInstance resourcePileInstance = storageSlots[i]?.Pile;
					if (resourcePileInstance != null && !resourcePileInstance.HasDisposed && !(resourcePileInstance.Blueprint == null) && resourcePileInstance.GetStoredResource() != null)
					{
						StatInstance stat = resourcePileInstance.GetStat(StatType.Health);
						ResourceInstance storedResource = resourcePileInstance.GetStoredResource();
						string text = ResourceUtils.GetLocalizedResourceName(storedResource.Blueprint);
						string localizedInheritedName = storedResource.LocalizedInheritedName;
						if (!string.IsNullOrEmpty(localizedInheritedName))
						{
							text = text + " (" + localizedInheritedName + ")";
						}
						string text2 = ((!flag) ? $"{ResourceUtils.GetTextIcon(resourcePileInstance.Blueprint)} {resourcePileInstance.GetStoredResource().Amount} {text}" : string.Format("{0} {1} {2} <style=DefaultRed>{3}</style>", ResourceUtils.GetTextIcon(resourcePileInstance.Blueprint), resourcePileInstance.GetStoredResource().Amount, text, MonoSingleton<LocalizationController>.Instance.GetText("forbidden_resource")));
						string text3 = string.Format("<#{0}>{1}/{2}</color> {3}", ColorTools.GetHexColor(Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max)), Mathf.RoundToInt(stat.Current), Mathf.RoundToInt(stat.Max), MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"));
						AppendLine(text2 + "  " + text3, TooltipStyles.TooltipDescriptionLine);
					}
				}
			}
			return base.GetLinesToShow();
		}
	}
}
