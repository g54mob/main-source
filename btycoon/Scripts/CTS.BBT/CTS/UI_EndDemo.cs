using System;
using CTS.UI;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_EndDemo : MonoBehaviour
	{
		[SerializeField]
		private Button _wishlistButton;

		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private Button _closePanel;

		[SerializeField]
		private URLLinkSO _wishlistURL;

		[SerializeField]
		private bool _setInactifAtferButtonClick = true;

		[SerializeField]
		private BackToMenuButton _backToMenuButton;

		[SerializeField]
		private CanvasGroupController _controller;

		public static event Action OnWishlistOpenURL;

		public static event Action OnQuit;

		public static event Action OpenEndScreen;

		public static event Action CloseEndScreen;

		public void ShowWishlist()
		{
			base.gameObject.SetActive(value: false);
			_backToMenuButton.ReturnToMainMenu();
		}

		private void OnEnable()
		{
			_quitButton.onClick.AddListener(Quit);
			_wishlistButton.onClick.AddListener(Wishlist);
			_closePanel.onClick.AddListener(ClosePanel);
		}

		private void OnDisable()
		{
			_quitButton.onClick.RemoveListener(Quit);
			_wishlistButton.onClick.RemoveListener(Wishlist);
			_closePanel.onClick.RemoveListener(ClosePanel);
		}

		private void Wishlist()
		{
			_wishlistURL.OpenURL();
			UI_EndDemo.OnWishlistOpenURL?.Invoke();
			if (_setInactifAtferButtonClick)
			{
				_controller.ShowCanvasGroup(show: false, 0.25f);
			}
			_backToMenuButton.ReturnToMainMenu();
			UI_EndDemo.CloseEndScreen?.Invoke();
		}

		public void ShowPanel()
		{
			Debug.Log("You are not in Demo");
		}

		public void ClosePanel()
		{
			_controller.ShowCanvasGroup(show: false, 0.25f);
			UI_EndDemo.CloseEndScreen?.Invoke();
		}

		private void Quit()
		{
			if (_setInactifAtferButtonClick)
			{
				_controller.ShowCanvasGroup(show: false, 0.25f);
			}
			UI_EndDemo.OnQuit?.Invoke();
			UI_EndDemo.CloseEndScreen?.Invoke();
			_backToMenuButton.ReturnToMainMenu();
		}
	}
}
