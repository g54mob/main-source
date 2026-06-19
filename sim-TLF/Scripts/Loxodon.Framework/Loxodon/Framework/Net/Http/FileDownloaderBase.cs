using System;
using System.IO;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Net.Http
{
	public abstract class FileDownloaderBase : IFileDownloader
	{
		private Uri baseUri;

		private int maxTaskCount;

		public virtual Uri BaseUri
		{
			get
			{
				return baseUri;
			}
			set
			{
				if (value != null && !IsAllowedAbsoluteUri(value))
				{
					throw new NotSupportedException(string.Format("Invalid uri:{0}", (value == null) ? "null" : value.OriginalString));
				}
				baseUri = value;
			}
		}

		public virtual int MaxTaskCount
		{
			get
			{
				return maxTaskCount;
			}
			set
			{
				maxTaskCount = Mathf.Max((value > 0) ? value : (SystemInfo.processorCount * 2), 1);
			}
		}

		public FileDownloaderBase()
			: this(null, SystemInfo.processorCount * 2)
		{
		}

		public FileDownloaderBase(Uri baseUri, int maxTaskCount)
		{
			BaseUri = baseUri;
			MaxTaskCount = maxTaskCount;
		}

		protected virtual bool IsAllowedAbsoluteUri(Uri uri)
		{
			if (!uri.IsAbsoluteUri)
			{
				return false;
			}
			if ("http".Equals(uri.Scheme) || "https".Equals(uri.Scheme) || "ftp".Equals(uri.Scheme))
			{
				return true;
			}
			if ("file".Equals(uri.Scheme) && uri.OriginalString.IndexOf("jar:") < 0)
			{
				return true;
			}
			return false;
		}

		protected virtual Uri GetAbsoluteUri(Uri relativePath)
		{
			if (baseUri == null || IsAllowedAbsoluteUri(relativePath))
			{
				return relativePath;
			}
			return new Uri(baseUri, relativePath);
		}

		public virtual IProgressResult<ProgressInfo, FileInfo> DownloadFileAsync(Uri path, string fileName)
		{
			return DownloadFileAsync(path, new FileInfo(fileName));
		}

		public abstract IProgressResult<ProgressInfo, FileInfo> DownloadFileAsync(Uri path, FileInfo fileInfo);

		public abstract IProgressResult<ProgressInfo, ResourceInfo[]> DownloadFileAsync(ResourceInfo[] infos);
	}
}
