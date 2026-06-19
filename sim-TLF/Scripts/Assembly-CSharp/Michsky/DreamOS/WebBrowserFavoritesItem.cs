using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class WebBrowserFavoritesItem : MonoBehaviour
	{
		public Image iconObject;

		public TextMeshProUGUI titleObject;

		public TextMeshProUGUI urlObject;

		public ButtonManager button;

		[HideInInspector]
		public WebBrowserManager manager;

		[HideInInspector]
		public string url;

		public void SetFavorite(bool value)
		{
			manager.SetFavoriteState(value, url);
		}
	}
}
