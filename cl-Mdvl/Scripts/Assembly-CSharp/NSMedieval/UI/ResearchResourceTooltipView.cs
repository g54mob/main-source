using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ResearchResourceTooltipView : TooltipViewNew
	{
		[SerializeField]
		private string textKey;

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			int allocatedResources = MonoSingleton<ResearchManager>.Instance.GetAllocatedResources(textKey);
			Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(textKey);
			ResourcePileCount count = MonoSingleton<ResourcePileTracker>.Instance.GetCount(byID);
			AppendLine(ResourceUtils.GetLocalizedResourceName(byID), TooltipStyles.TooltipTitle);
			AppendLine(ResourceUtils.GetLocalizedResourceInfo(textKey), TooltipStyles.TooltipDescriptionLine);
			AppendLine(string.Format("<style=AltColor>{0}</style>: {1}", MonoSingleton<LocalizationController>.Instance.GetText("research_available"), Mathf.Clamp(count.TotalCount - allocatedResources, 0, int.MaxValue)));
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText("research_available_info"), TooltipStyles.TooltipDescriptionLine);
			string line = string.Format("<style=DefaultGrey>{0}: {1}</style>", MonoSingleton<LocalizationController>.Instance.GetText("research_allocated"), allocatedResources);
			string line2 = MonoSingleton<LocalizationController>.Instance.GetText("research_allocated_info");
			if (count.TotalCount < allocatedResources)
			{
				line = string.Format("<style=DefaultRed>{0}: {1}/{2}</style>", MonoSingleton<LocalizationController>.Instance.GetText("research_allocated"), count.TotalCount, allocatedResources);
				line2 = "<style=DefaultRed>" + MonoSingleton<LocalizationController>.Instance.GetText("research_allocated_info_negative") + "</style>";
			}
			AppendLine(line);
			AppendLine(line2, TooltipStyles.TooltipDescriptionLine);
			return base.Lines;
		}
	}
}
