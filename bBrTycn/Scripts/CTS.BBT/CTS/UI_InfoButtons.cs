using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class UI_InfoButtons : MonoBehaviour
	{
		[SerializeField]
		private string _mailSubject;

		[SerializeField]
		private URLLinkSO _email;

		[SerializeField]
		private GameObject _buttonWishlist;

		[SerializeField]
		private GameObject _buttonDiscord;

		[SerializeField]
		private GameObject _buttonQQ;

		private void Awake()
		{
			_buttonWishlist.SetActive(value: false);
			string playerCountry = CountryManager.GetPlayerCountry();
			_buttonDiscord.SetActive(!CountryManager.DiscordRestrictedCountry.Contains(playerCountry));
			_buttonQQ.SetActive(CountryManager.QQAutorizededCountry.Contains(playerCountry));
		}

		public void OpenEmail()
		{
			Application.OpenURL("mailto:" + _email.Url + "?subject=" + _mailSubject);
		}
	}
}
