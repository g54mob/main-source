using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_Wishlist : MonoBehaviour
	{
		[SerializeField]
		private Button _wishlistButton;

		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private URLLinkSO _wishlistURL;

		[SerializeField]
		private bool _setInactifAtferButtonClick = true;

		private void Awake()
		{
			base.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			Application.wantsToQuit -= OnApplicationQuitting;
		}

		private bool OnApplicationQuitting()
		{
			if (base.gameObject.activeSelf)
			{
				return true;
			}
			base.gameObject.SetActive(value: true);
			return false;
		}

		private void OnEnable()
		{
			_quitButton.onClick.AddListener(Quit);
			_wishlistButton.onClick.AddListener(Wishlist);
		}

		private void OnDisable()
		{
			_quitButton.onClick.RemoveListener(Quit);
			_wishlistButton.onClick.RemoveListener(Wishlist);
		}

		private void Wishlist()
		{
			_wishlistURL.OpenURL();
			MonoSingleton<MenusManager>.Instance.ExitGame();
		}

		private void Quit()
		{
			MonoSingleton<MenusManager>.Instance.ExitGame();
		}
	}
}
