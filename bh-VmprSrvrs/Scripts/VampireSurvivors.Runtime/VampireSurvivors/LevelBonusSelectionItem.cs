using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class LevelBonusSelectionItem : SelectableUI
	{
		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private Image _Icon;

		private PowerUpType _type;

		private PowerUpData _data;

		private LevelBonusSelectionPage _page;

		private Button _button;

		public void SetData(LevelBonusSelectionPage page, PowerUpType t, PowerUpData d)
		{
		}

		private string UppercaseFirst(string s)
		{
			return null;
		}

		public void DisableButton()
		{
		}

		protected override void OnSelected()
		{
		}

		public PowerUpType GetPowerUpType()
		{
			return default(PowerUpType);
		}

		private void ClickButton()
		{
		}

		private void SetIconSize()
		{
		}
	}
}
