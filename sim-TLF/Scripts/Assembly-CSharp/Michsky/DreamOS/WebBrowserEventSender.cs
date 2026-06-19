using UnityEngine;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Web Browser/Web Browser Event Sender")]
	public class WebBrowserEventSender : MonoBehaviour
	{
		private WebBrowserManager wbm;

		private void Start()
		{
			wbm = base.gameObject.GetComponentInParent<WebBrowserManager>();
		}

		public void GoBack()
		{
			wbm.GoBack();
		}

		public void GoForward()
		{
			wbm.GoForward();
		}

		public void Refresh()
		{
			wbm.Refresh();
		}

		public void OpenHome()
		{
			wbm.OpenHomePage();
		}

		public void OpenPage(string pageUrl)
		{
			wbm.OpenPage(pageUrl);
		}

		public void DownloadFile(string fileName)
		{
			wbm.DownloadFile(fileName);
		}
	}
}
