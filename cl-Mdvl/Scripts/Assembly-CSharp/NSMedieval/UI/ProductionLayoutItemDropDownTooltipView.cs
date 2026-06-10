using System.Collections.Generic;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ProductionLayoutItemDropDownTooltipView : TooltipViewNew
	{
		[SerializeField]
		private ProductionLayoutItemView productionLayoutItemView;

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			if (productionLayoutItemView == null || productionLayoutItemView.Production == null)
			{
				return lines;
			}
			ProductionInstance production = productionLayoutItemView.Production;
			production.Blueprint.GenerateProductionModeTooltipData(production, base.AppendLine);
			return lines;
		}

		private void Start()
		{
			if (productionLayoutItemView == null)
			{
				productionLayoutItemView = base.gameObject.GetComponent<ProductionLayoutItemView>();
			}
		}
	}
}
