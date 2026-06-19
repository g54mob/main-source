using System;
using Michsky.DreamOS;
using Zenject;

namespace Player.TutorialHelpers
{
	public class ComputerEnterSiteHelper : BaseTutorialHelper
	{
		[Inject]
		private WebBrowserManager _webBrowserManager;

		private void OnEnable()
		{
			WebBrowserManager webBrowserManager = _webBrowserManager;
			webBrowserManager.OnWebPageOpen = (Action<string>)Delegate.Combine(webBrowserManager.OnWebPageOpen, new Action<string>(TutorialWebPageOpen));
		}

		private void TutorialWebPageOpen(string url)
		{
			if (url == "sell.com")
			{
				EmitStep("openSellCom");
			}
			if (url == "sky.com")
			{
				EmitStep("openDeliverySite");
			}
		}
	}
}
