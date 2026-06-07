using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
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
			if (!GamePlayer.Current.DoAutoUpgrade)
			{
				return "@ToolbarAutoUpgradeDisabled";
			}
			return Translation.TranslateOnly("@ToolbarAutoUpgradeEnabled", GamePlayer.AutoUpgradeTime);
		}
	}
}
