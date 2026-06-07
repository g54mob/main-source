using System.Collections.Generic;
using DV.UIFramework;
using TMPro;
using UnityEngine;

namespace DV.UI
{
	public class TooltipHandler : MonoBehaviour
	{
		public TMP_Text tooltipText;

		private TooltipIconsHandler iconsHandler;

		private List<ITooltip> activeTooltips = new List<ITooltip>();

		private void Awake()
		{
			if (tooltipText == null)
			{
				Debug.LogError("Missing 'TMP_Text' reference. 'TooltipHandler' can't work properly. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				iconsHandler = GetComponent<TooltipIconsHandler>();
				ClearTooltip();
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
		}

		private void OnDisable()
		{
			ClearTooltip();
		}

		private void ClearTooltip()
		{
			activeTooltips.Clear();
			if (tooltipText != null)
			{
				tooltipText.text = string.Empty;
			}
			if (iconsHandler != null)
			{
				iconsHandler.ClearIcons();
			}
		}

		public void UpdateTooltipText()
		{
			if (tooltipText == null)
			{
				return;
			}
			string text = "";
			for (int num = activeTooltips.Count - 1; num >= 0; num--)
			{
				ITooltip tooltip = activeTooltips[num];
				if (tooltip != null && tooltip.GetGameObject().activeInHierarchy)
				{
					text = activeTooltips[num].GetText();
					if (iconsHandler != null)
					{
						iconsHandler.SetIcons(tooltip.TooltipIcons);
					}
					break;
				}
			}
			tooltipText.text = text;
		}

		public void AddTooltipAndUpdate(ITooltip tooltip)
		{
			activeTooltips.RemoveAll((ITooltip t) => !(t as Object));
			if (tooltip == null)
			{
				Debug.LogError("Cannot add null tooltip. Skipping...", this);
				return;
			}
			if (!activeTooltips.Contains(tooltip))
			{
				activeTooltips.Add(tooltip);
			}
			UpdateTooltipText();
		}

		public void RemoveTooltipAndUpdate(ITooltip tooltip)
		{
			activeTooltips.RemoveAll((ITooltip t) => !(t as Object));
			if (tooltip == null)
			{
				Debug.LogError("Cannot remove null tooltip. Skipping...", this);
				return;
			}
			activeTooltips.Remove(tooltip);
			UpdateTooltipText();
		}
	}
}
