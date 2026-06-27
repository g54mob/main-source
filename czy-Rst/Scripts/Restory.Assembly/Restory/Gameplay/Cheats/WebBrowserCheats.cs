using System.ComponentModel;
using Restory.Gameplay.Internet;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class WebBrowserCheats : SRDebugCheatBase
	{
		private readonly InternetStatusService internetStatusService;

		private const string COMMON_CATEGORY = "Web Browser Cheats";

		private bool isInternetOn;

		[Category("Web Browser Cheats")]
		[DisplayName("Is Internet On")]
		[SROptions.Sort(0)]
		public bool WebBrowserInternetStatusEnabled
		{
			get
			{
				return isInternetOn;
			}
			set
			{
				isInternetOn = value;
				internetStatusService.IsInternetOn = isInternetOn;
				Debug.Log("Cheat command: WebBrowserInternetStatusEnabled success");
			}
		}

		[Inject]
		public WebBrowserCheats(InternetStatusService internetStatusService)
		{
			this.internetStatusService = internetStatusService;
		}
	}
}
