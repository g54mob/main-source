using System.Collections.Generic;

namespace ModIO.Implementation.API.Requests
{
	internal static class DeleteDependency
	{
		public static WebRequestConfig Request(long modId, ICollection<ModId> mods)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}{5}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", modId, "/dependencies");
			webRequestConfig.RequestMethodType = "Delete";
			WebRequestConfig webRequestConfig2 = webRequestConfig;
			int num = 0;
			foreach (ModId mod in mods)
			{
				webRequestConfig2.AddField($"dependencies[{num}]", (long)mod);
				num++;
				if (num > 4)
				{
					break;
				}
			}
			return webRequestConfig2;
		}
	}
}
