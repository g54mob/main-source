using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.UI.Overview
{
	public class AbilityChargeBar : MonoBehaviour, ITooltipCustomSource
	{
		[SerializeField]
		private RectTransform _chargeProgress;

		private UITooltipText _tooltipWidgets;

		private UITooltipText _tooltipEntropy;

		private void Update()
		{
			float x = GameMath.Clamp01(GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget), GamePlayer.Current.GetInventoryCapacity(ItemType.GlitchedWidget));
			_chargeProgress.localScale = new Vector3(x, 1f, 1f);
			if ((bool)_tooltipWidgets)
			{
				UpdateTooltipText();
			}
		}

		private void UpdateTooltipText()
		{
			_tooltipWidgets.Text.text = Translation.Translate("@AbilityBarWidgets", GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget), GamePlayer.Current.GetInventoryCapacity(ItemType.GlitchedWidget));
			_tooltipEntropy.Text.text = "\n" + Translation.Translate("@AbilityBarEntropy", GameMath.FormatPercentage(GamePlayer.Current.AbilityEntropy, FormatPercentageMode.Offset));
		}

		public void AddTooltipCustomContent(UITooltip tooltip)
		{
			_tooltipWidgets = tooltip.AddItemLine(ItemType.GlitchedWidget, "");
			_tooltipWidgets.Text.alignment = TextAlignmentOptions.TopLeft;
			tooltip.AddTextLine("@AbilityBarWidgetsDesc");
			_tooltipEntropy = tooltip.AddTextLine("");
			tooltip.AddTextLine("@AbilityBarEntropyDesc");
			UpdateTooltipText();
		}
	}
}
