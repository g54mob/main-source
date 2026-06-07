using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_PaintResultScreen : UI_CollectionPopup
	{
		[SerializeField]
		private Button m_marketHistoryButton;

		[Space(10f)]
		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private Image m_armyImage;

		[SerializeField]
		private Image m_licenseImage;

		[SerializeField]
		private Image m_rarityImage;

		[SerializeField]
		private TextMeshProUGUI m_nameText;

		[SerializeField]
		private TextMeshProUGUI m_scoreText;

		[SerializeField]
		private TextMeshProUGUI m_marketPriceText;

		[SerializeField]
		private TextMeshProUGUI m_armyText;

		public void Show(int miniatureUID, int score)
		{
		}

		private void SetContent(int miniatureUID, int score, bool bestScore)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
			m_armyImage.sprite = MiniatureSettings.GetArmySprite(miniatureData.Army);
			m_licenseImage.sprite = MiniatureSettings.GetLicenseSprite(miniatureData.License);
			m_rarityImage.enabled = miniatureData.Type != EMiniatureType.COMMON;
			m_nameText.text = miniatureData.name;
			m_scoreText.text = "Score : " + score;
			m_scoreText.color = (bestScore ? Color.yellow : Color.white);
			m_scoreText.fontStyle = (bestScore ? FontStyles.Bold : FontStyles.Normal);
			m_marketPriceText.text = miniatureData.MarketPrice.ToStringMoneyFormat();
			string text = miniatureData.Army.ToString().ToLower();
			char[] array = text.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			text = new string(array);
			m_armyText.text = text;
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			base.gameObject.SetActive(value: true);
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			base.gameObject.SetActive(value: false);
		}

		public override bool CanBeClosed()
		{
			return true;
		}
	}
}
