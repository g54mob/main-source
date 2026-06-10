using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Managers
{
	public class WebLinkManager : MonoSingleton<WebLinkManager>
	{
		[SerializeField]
		private List<WebLink> links;

		private Dictionary<string, string> linkDictionary;

		private void Start()
		{
			InitLinks();
		}

		public void OpenLinkInBrowser(string link)
		{
			if (!linkDictionary.ContainsKey(link))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WebLinkManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Missing web link for key ");
					messageBuilder.AppendFormatted(link);
				}
				Log.Info(messageBuilder);
			}
			else
			{
				Application.OpenURL(linkDictionary[link]);
			}
		}

		private void InitLinks()
		{
			if (linkDictionary != null)
			{
				return;
			}
			linkDictionary = new Dictionary<string, string>();
			foreach (WebLink link in links)
			{
				linkDictionary.Add(link.linkKey, link.linkURL);
			}
		}
	}
}
