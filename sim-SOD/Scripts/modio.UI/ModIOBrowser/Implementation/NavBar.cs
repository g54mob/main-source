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
		}
	}
}
