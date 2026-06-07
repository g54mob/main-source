using System;
using UnityEngine;

namespace Integrations
{
	public class DefaultPlatformHandler : MonoBehaviour, IPlatformHandler
	{
		public bool Ready { get; set; }

		public Action OnPlatformReady { get; set; }

		private void Start()
		{
			if (OnPlatformReady != null)
			{
				OnPlatformReady();
			}
		}

		public void OpenWebPage(string url, bool forceWebLink = false)
		{
			if (!string.IsNullOrWhiteSpace(url))
			{
				Application.OpenURL(url);
			}
		}

		public string GetUserId()
		{
			return "";
		}

		public string GetUserName()
		{
			return "";
		}

		public void GetAuthToken(Action<string> authComplete, Action<string> authError)
		{
		}

		public void SetSupportersEditionAppId(string value)
		{
		}

		public bool HasSupportersEdition()
		{
			return false;
		}

		public void CancelAuthToken()
		{
		}
	}
}
