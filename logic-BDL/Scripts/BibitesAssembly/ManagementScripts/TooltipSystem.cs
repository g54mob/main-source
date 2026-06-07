using LeanTween.Framework;
using SimulationScripts;
using SteamIntegrations;
using UIScripts.UIReferences;
using UIScripts.UIReferences.LineagePanel;
using UnityEngine;

namespace ManagementScripts
{
	public class TooltipSystem : MonoBehaviour
	{
		public static TooltipSystem current;

		public CanvasGroup tooltipAlpha;

		public TooltipHandle tooltip;

		public AchievementPopupHandle achievementPopup;

		public PelletTooltipHandle pelletTooltip;

		private void Awake()
		{
			current = this;
		}

		private void Start()
		{
			if (tooltip != null)
			{
				current.tooltip.gameObject.SetActive(value: true);
				Hide();
			}
			if (pelletTooltip != null)
			{
				pelletTooltip.gameObject.SetActive(value: true);
				HidePelletTooltip();
			}
			achievementPopup.gameObject.SetActive(value: false);
		}

		public static void Show(string header = "", string content = "")
		{
			if (!(current == null))
			{
				UpdateTooltip(header, content);
				current.tooltipAlpha.alpha = 0f;
				LeanTween.Framework.LeanTween.alphaCanvas(current.tooltipAlpha, 1f, 0.25f).setIgnoreTimeScale(useUnScaledTime: true);
				current.tooltip.gameObject.SetActive(value: true);
			}
		}

		public static void ShowPelletTooltip(MatterPellet target)
		{
			if (!(current == null))
			{
				current.pelletTooltip.SetTooltip(target);
				current.tooltipAlpha.alpha = 0f;
				LeanTween.Framework.LeanTween.alphaCanvas(current.tooltipAlpha, 1f, 0.25f).setIgnoreTimeScale(useUnScaledTime: true);
				current.pelletTooltip.gameObject.SetActive(value: true);
			}
		}

		public static void UpdateTooltip(string header = null, string content = null)
		{
			if (!(current == null))
			{
				current.tooltip.SetTooltip(header, content);
			}
		}

		public static void TriggerAchievementPopup(Achievement achievement, GameObject source = null)
		{
			if (!(current == null))
			{
				current.achievementPopup.UnlockAchievement(achievement);
			}
		}

		public static void Hide()
		{
			if (!(current == null))
			{
				current.tooltip.gameObject.SetActive(value: false);
			}
		}

		public static void HidePelletTooltip()
		{
			if (!(current == null))
			{
				current.pelletTooltip.ResetTooltip();
				current.pelletTooltip.gameObject.SetActive(value: false);
			}
		}
	}
}
