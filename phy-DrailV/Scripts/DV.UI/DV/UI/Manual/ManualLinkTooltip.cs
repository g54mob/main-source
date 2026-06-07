using DV.UIFramework;
using UnityEngine;

namespace DV.UI.Manual
{
	public class ManualLinkTooltip : UIElementTooltipCustomText, ITooltip
	{
		public TextMeshProLinkHandler_DV linkHandler;

		public ManualController controller;

		private TooltipHandler tooltipHandler;

		private string hoveredLinkId;

		public ITooltipIcons TooltipIcons { get; }

		private void Awake()
		{
			tooltipHandler = base.transform.GetComponentInParentIncludingInactive<TooltipHandler>();
			if (tooltipHandler == null)
			{
				base.enabled = false;
			}
			else
			{
				linkHandler.LinkHovered += OnHoveredLinkChanged;
			}
		}

		private void OnHoveredLinkChanged(string linkId)
		{
			hoveredLinkId = linkId;
			if (string.IsNullOrWhiteSpace(linkId))
			{
				tooltipHandler.RemoveTooltipAndUpdate(this);
			}
			else
			{
				tooltipHandler.AddTooltipAndUpdate(this);
			}
		}

		public override string GetText()
		{
			if (controller.KeyToPageTitle.TryGetValue(hoveredLinkId, out var value))
			{
				return value;
			}
			Debug.LogWarning("ManualLinkTooltip: Couldn't get any string for key '" + hoveredLinkId + "'");
			return "";
		}

		GameObject ITooltip.GetGameObject()
		{
			return base.gameObject;
		}
	}
}
