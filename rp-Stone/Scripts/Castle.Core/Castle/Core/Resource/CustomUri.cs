using System;
using System.Text;

namespace Castle.Core.Resource
{
	[Serializable]
	public sealed class CustomUri
	{
		public static readonly string SchemeDelimiter = "://";

		public static readonly string UriSchemeFile = "file";

		public static readonly string UriSchemeAssembly = "assembly";

		private string scheme;

		private string host;

		private string path;

		private bool isUnc;

		private bool isFile;

		private bool isAssembly;

		public bool IsUnc => isUnc;

		public bool IsFile => isFile;

		public bool IsAssembly => isAssembly;

		public string Scheme => scheme;

		public string Host => host;

		public string Path => path;

		public CustomUri(string resourceIdentifier)
		{
			if (resourceIdentifier == null)
			{
				throw new ArgumentNullException("resourceIdentifier");
			}
			if (resourceIdentifier == string.Empty)
			{
				throw new ArgumentException("Empty resource identifier is not allowed", "resourceIdentifier");
			}
			ParseIdentifier(resourceIdentifier);
		}

		private void ParseIdentifier(string identifier)
		{
			int num = identifier.IndexOf(':');
			if (num == -1 && (identifier[0] != '\\' || identifier[1] != '\\') && identifier[0] != '/')
			{
				throw new ArgumentException("Invalid Uri: no scheme delimiter found on " + identifier);
			}
			bool flag = true;
			if (identifier[0] == '\\' && identifier[1] == '\\')
			{
				isUnc = true;
				isFile = true;
				scheme = UriSchemeFile;
				flag = false;
			}
			else if (identifier[num + 1] == '/' && identifier[num + 2] == '/')
			{
				scheme = identifier.Substring(0, num);
				isFile = scheme == UriSchemeFile;
				isAssembly = scheme == UriSchemeAssembly;
				identifier = identifier.Substring(num + SchemeDelimiter.Length);
			}
			else
			{
				isFile = true;
				scheme = UriSchemeFile;
			}
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = identifier.ToCharArray();
			foreach (char c in array)
			{
				if (flag && (c == '\\' || c == '/'))
				{
					if (host == null && !IsFile)
					{
						host = stringBuilder.ToString();
						stringBuilder.Length = 0;
					}
					stringBuilder.Append('/');
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			path = Environment.ExpandEnvironmentVariables(stringBuilder.ToString());
		}
	}
}
