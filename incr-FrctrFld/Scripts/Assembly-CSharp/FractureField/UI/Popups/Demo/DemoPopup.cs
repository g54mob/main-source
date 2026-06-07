using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Popups.Demo
{
	public class DemoPopup : Popup
	{
		[SerializeField]
		private TMP_Text _description;

		[SerializeField]
		private Image _banner;

		[SerializeField]
		private Sprite _banner_EN;

		[SerializeField]
		private Sprite _banner_CN;

		[SerializeField]
		private Sprite _banner_TW;

		protected override void InitHandler()
		{
		}

		private void Setup()
		{
		}

		public void Open(int stage)
		{
		}

		public void ClickedSteamButton()
		{
		}
	}
}
