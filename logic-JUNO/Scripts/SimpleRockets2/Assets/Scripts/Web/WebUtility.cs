using System;
using Assets.Packages.SocialPlatforms;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.Web
{
	public static class WebUtility
	{
		public static ClientResponse CreateClientResponse(string xml)
		{
			ClientResponse clientResponse;
			try
			{
				clientResponse = new ClientResponse(xml);
			}
			catch (Exception ex)
			{
				clientResponse = new ClientResponse();
				((IClientResponseWriter)clientResponse).SetError("Server returned invalid response. Check your log for more details.");
				Debug.LogErrorFormat("Server returned invalid response:\n{0}\n\nException:\n{1}", xml, ex.ToString());
			}
			return clientResponse;
		}

		public static void OpenUrl(string url, bool useInGameOverlayIfAvailable = true)
		{
			if (useInGameOverlayIfAvailable && SocialExt.IsSteam && SocialExt.Steam.IsOverlayEnabled())
			{
				SocialExt.Steam.ActivateGameOverlayToWebPage(url);
			}
			else
			{
				Application.OpenURL(url);
			}
		}
	}
}
