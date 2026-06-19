using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ModIO.Implementation.API.Requests
{
	internal static class AddModFile
	{
		public static async Task<WebRequestConfig> Request(ModfileDetails details, MemoryStream stream)
		{
			long id = details?.modId?.id ?? ((long)new ModId(0L));
			WebRequestConfig request = new WebRequestConfig
			{
				Url = Url(id),
				RequestMethodType = "POST",
				ShouldRequestTimeout = false
			};
			stream.Position = 0L;
			byte[] result = new byte[stream.Length];
			await stream.ReadAsync(result, 0, (int)stream.Length, default(CancellationToken));
			request.AddField("version", details.version);
			request.AddField("changelog", details.changelog);
			request.AddField("filehash", IOUtil.GenerateMD5(result));
			request.AddField("metadata_blob", details.metadata);
			request.AddField("filedata", $"{id}_modfile.zip", result);
			return request;
		}

		public static string Url(long id)
		{
			return string.Format("{0}{1}{2}{3}{4}{5}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", id, "/files");
		}
	}
}
