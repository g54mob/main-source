using System;
using System.IO;
using Loxodon.Framework.Asynchronous;

namespace Loxodon.Framework.Net.Http
{
	public interface IFileDownloader
	{
		IProgressResult<ProgressInfo, FileInfo> DownloadFileAsync(Uri path, string fileName);

		IProgressResult<ProgressInfo, FileInfo> DownloadFileAsync(Uri path, FileInfo fileInfo);

		IProgressResult<ProgressInfo, ResourceInfo[]> DownloadFileAsync(ResourceInfo[] infos);
	}
}
