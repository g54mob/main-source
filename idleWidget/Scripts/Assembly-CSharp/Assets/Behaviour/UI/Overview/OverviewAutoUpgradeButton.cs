using Assets.Source.Player;
using Assets.Source.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Overview
{
	public class OverviewAutoUpgradeButton : MonoBehaviour, ITooltipTextSource
	{
		[SerializeField]
		private Image _indicator;

		[SerializeField]
		private Sprite _spriteActive;

		[SerializeField]
		private Sprite _spriteInactive;

		private void Update()
		{
			_indicator.sprite = (GamePlayer.Current.DoAutoUpgrade ? _spriteActive : _spriteInactive);
		}

		public string GetTooltipText()
		{
			return (GamePlayer.Current.DoAutoUpgrade ? ("Automatically purchases a missing upgrade for one of your frames every " + UIHelper.HighlightText("2 seconds")) : "Auto-upgrade is currently disabled") + ".\n\n" + UIHelper.HighlightText("Click") + " to " + (GamePlayer.Current.DoAutoUpgrade ? "disable" : "enable") + " this feature.";
		}
	}
}
