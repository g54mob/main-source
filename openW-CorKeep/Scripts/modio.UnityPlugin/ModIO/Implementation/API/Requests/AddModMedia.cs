using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ModIO.Implementation.API.Requests
{
	internal static class AddModMedia
	{
		public static async Task<ResultAnd<WebRequestConfig>> Request(ModProfileDetails details)
		{
			WebRequestConfig request = new WebRequestConfig
			{
				Url = string.Format("{0}{1}{2}{3}{4}/media?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", details.modId?.id),
				RequestMethodType = "POST",
				ShouldRequestTimeout = false
			};
			if (details.logo != null)
			{
				request.AddField("logo", "logo.png", details.logo.EncodeToPNG());
			}
			if (details.images != null)
			{
				ResultAnd<MemoryStream> resultAnd = await new CompressOperationMultiple(details.GetGalleryImages(), null).Compress();
				if (!resultAnd.result.Succeeded())
				{
					return ResultAnd.Create<WebRequestConfig>(resultAnd.result, null);
				}
				request.AddField("images", "images.zip", resultAnd.value.ToArray());
			}
			return ResultAnd.Create(ResultBuilder.Success, request);
		}
	}
}
