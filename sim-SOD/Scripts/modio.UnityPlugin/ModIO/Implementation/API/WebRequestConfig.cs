using System.Collections.Generic;
using System.IO;

namespace ModIO.Implementation.API
{
	internal class WebRequestConfig
	{
		public string Url;

		public string RequestMethodType;

		public bool ShouldRequestTimeout;

		public bool DontUseAuthToken;

		public List<KeyValuePair<string, string>> StringKvpData;

		public Stream DownloadStream;

		public List<BinaryDataContainer> BinaryData;

		public Dictionary<string, string> HeaderData;

		public bool HasBinaryData => false;

		public bool HasStringData => false;

		public bool IsUpload => false;

		public void AddField<TInput>(string key, TInput data)
		{
		}

		public void AddField(string fieldName, string fileName, byte[] data)
		{
		}

		public void AddHeader(string key, string data)
		{
		}
	}
}
