using System;
using System.Collections.Generic;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public class CommonTooltipCustomPool : IDisposable
	{
		private readonly DiContainer diContainer;

		private readonly TooltipContainer tooltipContainer;

		private readonly Dictionary<GameObject, GUI_CommonTooltip> instantiatedTooltips = new Dictionary<GameObject, GUI_CommonTooltip>();

		[Inject]
		public CommonTooltipCustomPool(DiContainer diContainer, TooltipContainer tooltipContainer)
		{
			this.diContainer = diContainer;
			this.tooltipContainer = tooltipContainer;
		}

		public void Dispose()
		{
			instantiatedTooltips.Clear();
		}

		public GUI_CommonTooltip GetTooltip(GUI_CommonTooltip tooltipPrefab)
		{
			if (!instantiatedTooltips.TryGetValue(tooltipPrefab.gameObject, out var value))
			{
				value = diContainer.InstantiatePrefabForComponent<GUI_CommonTooltip>(tooltipPrefab.gameObject);
				instantiatedTooltips[tooltipPrefab.gameObject] = value;
			}
			value.gameObject.SetActive(value: true);
			tooltipContainer.AddTooltip(value);
			return value;
		}

		public void ReleaseTooltip(GUI_CommonTooltip tooltipInstance)
		{
			tooltipContainer.RemoveTooltip(tooltipInstance);
			tooltipInstance.gameObject.SetActive(value: false);
			tooltipInstance.transform.localScale = Vector3.one;
		}
	}
}
