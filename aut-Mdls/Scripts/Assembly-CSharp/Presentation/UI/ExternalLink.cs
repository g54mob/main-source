#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using System.Web;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI
{
	public class ExternalLink : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private bool _sendMetaData;

		[SerializeField]
		private bool _forceWeblink;

		[Dropdown("GetExternalLinks")]
		[SerializeField]
		private string _link = "";

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		private DropdownList<string> GetExternalLinks()
		{
			return new DropdownList<string>
			{
				{ "ModulusDiscord", "https://discord.gg/QbTr9bFqTF" },
				{ "PlaytestTutorial", "https://youtu.be/pbXTKV3ocgo" },
				{ "PlaytestSurvey", "https://docs.google.com/forms/d/e/1FAIpQLSd1XzDgNmWnP0g47oxp29L0UpIOtFJtMC3c1sFU1-wXBx7OxA/viewform" },
				{ "SteamPlaytestSurvey", "https://docs.google.com/forms/d/e/1FAIpQLSd1XzDgNmWnP0g47oxp29L0UpIOtFJtMC3c1sFU1-wXBx7OxA/viewform" },
				{ "Feedback", "https://www.modulusgame.com/support?usp=pp_url&entry.1294754154=versionNumber&entry.232424973=platformUserId&entry.586940898=platformUserName&entry.1564469655=cloudServiceUserId&entry.917468564=deviceModel&entry.1322843767=processorType&entry.1956483813=systemMemorySize&entry.804926352=graphicsDeviceName&entry.2060459390=gameAnalyticsUserId" },
				{ "Wishlist", "https://store.steampowered.com/app/2779120/Modulus/?utm_source=demo&utm_medium=cta&utm_campaign=demo1" },
				{ "Academy", "https://www.youtube.com/playlist?list=PLkYe2etXoXzt5oXl6TZb2tn3VnJZF3ZJe" }
			};
		}

		private void Awake()
		{
			_button?.onClick.AddListener(OnButtonClicked);
		}

		private void OnDestroy()
		{
			_button?.onClick.RemoveListener(OnButtonClicked);
		}

		private string EnrichLinkWithMetaData()
		{
			string text = _link;
			if (!_sendMetaData)
			{
				return text;
			}
			foreach (KeyValuePair<string, string> item in _integrationManagerLocator.Integration.GatherFeedbackMetaData())
			{
				text = text.Replace(item.Key, HttpUtility.UrlEncode(item.Value));
			}
			this.Log("Opening link " + text, "EnrichLinkWithMetaData", 56);
			return text;
		}

		public void OnButtonClicked()
		{
			_integrationManagerLocator.Integration.Platform.OpenWebPage(EnrichLinkWithMetaData(), _forceWeblink);
		}
	}
}
