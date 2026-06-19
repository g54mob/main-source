using System.Collections;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class NavBar : SelfInstancingMonoSingleton<NavBar>
	{
		[Header("Nav Bar")]
		[SerializeField]
		private TMP_Text BrowserPanelNavButton;

		[SerializeField]
		private GameObject BrowserPanelNavButtonHighlights;

		[SerializeField]
		private Image BrowserPanelHeaderBackground;

		[SerializeField]
		private TMP_Text CollectionPanelNavButton;

		[SerializeField]
		private GameObject CollectionPanelNavButtonHighlights;

		private IEnumerator browserHeaderTransition;

		internal void UpdateNavbarSelection()
		{
			if (Collection.IsOn())
			{
				Color color = CollectionPanelNavButton.color;
				color.a = 1f;
				CollectionPanelNavButton.color = color;
				CollectionPanelNavButtonHighlights.SetActive(value: true);
				color = BrowserPanelNavButton.color;
				color.a = 0.5f;
				BrowserPanelNavButton.color = color;
				BrowserPanelNavButtonHighlights.SetActive(value: false);
			}
			else
			{
				Color color2 = CollectionPanelNavButton.color;
				color2.a = 0.5f;
				CollectionPanelNavButton.color = color2;
				CollectionPanelNavButtonHighlights.SetActive(value: false);
				color2 = BrowserPanelNavButton.color;
				color2.a = 1f;
				BrowserPanelNavButton.color = color2;
				BrowserPanelNavButtonHighlights.SetActive(value: true);
			}
		}
	}
}
