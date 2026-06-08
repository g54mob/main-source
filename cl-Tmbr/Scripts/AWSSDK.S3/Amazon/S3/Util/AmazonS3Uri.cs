using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Amazon.Runtime;

namespace Amazon.S3.Util
{
	public class AmazonS3Uri
	{
		private const string EndpointRegexPattern = "^(.+\\.)?(?:s3|s3express)[.-]([a-z0-9-]+)\\.";

		private static readonly Regex _endpointRegexMatch = new Regex("^(.+\\.)?(?:s3|s3express)[.-]([a-z0-9-]+)\\.", RegexOptions.Compiled);

		public bool IsPathStyle { get; private set; }

		public string Bucket { get; private set; }

		public string Key { get; private set; }

		public RegionEndpoint Region { get; set; }

		private static Regex EndpointRegexMatch()
		{
			return _endpointRegexMatch;
		}

		public AmazonS3Uri(string uri)
			: this(new Uri(uri))
		{
		}

		public AmazonS3Uri(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (string.IsNullOrEmpty(uri.Host))
			{
				throw new ArgumentException("Invalid URI - no hostname present");
			}
			if (uri.Scheme == "s3")
			{
				Region = null;
				IsPathStyle = false;
				Bucket = uri.Authority;
				if (Bucket == null)
				{
					throw new ArgumentException("Invalid S3 URI - no bucket present");
				}
				Key = (uri.AbsolutePath.Equals("/") ? null : Decode(uri.AbsolutePath.Substring(1)));
				return;
			}
			Match match = EndpointRegexMatch().Match(uri.Host);
			if (!match.Success)
			{
				throw new ArgumentException("Invalid S3 URI - hostname does not appear to be a valid S3 endpoint");
			}
			Group obj = match.Groups[1];
			if (string.IsNullOrEmpty(obj.Value))
			{
				IsPathStyle = true;
				string absolutePath = uri.AbsolutePath;
				if (absolutePath.Equals("/"))
				{
					Bucket = null;
					Key = null;
				}
				else
				{
					int num = absolutePath.IndexOf('/', 1);
					if (num == -1)
					{
						Bucket = Decode(absolutePath.Substring(1));
						Key = null;
					}
					else if (num == absolutePath.Length - 1)
					{
						Bucket = Decode(absolutePath.Substring(1, num)).TrimEnd(new char[1] { '/' });
						Key = null;
					}
					else
					{
						Bucket = Decode(absolutePath.Substring(1, num)).TrimEnd(new char[1] { '/' });
						Key = Decode(absolutePath.Substring(num + 1));
					}
				}
			}
			else
			{
				IsPathStyle = false;
				Bucket = obj.Value.TrimEnd(new char[1] { '.' });
				Key = (uri.AbsolutePath.Equals("/") ? null : Decode(uri.AbsolutePath.Substring(1)));
			}
			if (match.Groups.Count <= 2)
			{
				return;
			}
			string value = match.Groups[2].Value;
			if (value.Equals("amazonaws", StringComparison.Ordinal) || value.Equals("external-1", StringComparison.Ordinal))
			{
				Region = RegionEndpoint.USEast1;
				return;
			}
			try
			{
				Region = RegionEndpoint.GetBySystemName(value);
			}
			catch (AmazonClientException)
			{
				Region = null;
			}
		}

		public AmazonS3Uri(string uri, bool decode)
			: this(decode ? EscapeSpecialControlCharacters(uri) : uri)
		{
		}

		public static bool TryParseAmazonS3Uri(string uri, out AmazonS3Uri amazonS3Uri)
		{
			try
			{
				return TryParseAmazonS3Uri(new Uri(uri), out amazonS3Uri);
			}
			catch (Exception)
			{
				amazonS3Uri = null;
				return false;
			}
		}

		public static bool TryParseAmazonS3Uri(string uri, bool decode, out AmazonS3Uri amazonS3Uri)
		{
			if (decode)
			{
				uri = EscapeSpecialControlCharacters(uri);
			}
			return TryParseAmazonS3Uri(new Uri(uri), out amazonS3Uri);
		}

		public static bool TryParseAmazonS3Uri(Uri uri, out AmazonS3Uri amazonS3Uri)
		{
			try
			{
				if (IsAmazonS3Endpoint(uri))
				{
					amazonS3Uri = new AmazonS3Uri(uri);
					return true;
				}
			}
			catch
			{
			}
			amazonS3Uri = null;
			return false;
		}

		public static bool IsAmazonS3Endpoint(string uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			return IsAmazonS3Endpoint(new Uri(uri));
		}

		public static bool IsAmazonS3Endpoint(Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (uri.IsAbsoluteUri && (uri.Host.EndsWith("amazonaws.com", StringComparison.OrdinalIgnoreCase) || uri.Host.EndsWith("amazonaws.com.cn", StringComparison.OrdinalIgnoreCase)))
			{
				return EndpointRegexMatch().Match(uri.Host).Success;
			}
			if (uri.IsAbsoluteUri && uri.Scheme == "s3")
			{
				return !string.IsNullOrEmpty(uri.Authority);
			}
			return false;
		}

		private static string Decode(string s)
		{
			if (s == null)
			{
				return null;
			}
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '%')
				{
					return Decode(s, i);
				}
			}
			return s;
		}

		private static string Decode(string s, int firstPercent)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Substring(0, firstPercent));
			AppendDecoded(stringBuilder, s, firstPercent);
			for (int i = firstPercent + 3; i < s.Length; i++)
			{
				if (s[i] == '%')
				{
					AppendDecoded(stringBuilder, s, i);
					i += 2;
				}
				else
				{
					stringBuilder.Append(s[i]);
				}
			}
			return stringBuilder.ToString();
		}

		private static void AppendDecoded(StringBuilder builder, string s, int index)
		{
			if (index > s.Length - 3)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid percent-encoded string '{0}'", s));
			}
			char c = s[index + 1];
			char c2 = s[index + 2];
			char value = (char)((FromHex(c) << 4) | FromHex(c2));
			builder.Append(value);
		}

		private static int FromHex(char c)
		{
			if (c < '0')
			{
				throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
			}
			if (c <= '9')
			{
				return c - 48;
			}
			if (c < 'A')
			{
				throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
			}
			if (c <= 'F')
			{
				return c - 65 + 10;
			}
			if (c < 'a')
			{
				throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
			}
			if (c <= 'f')
			{
				return c - 97 + 10;
			}
			throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
		}

		private static string EscapeSpecialControlCharacters(string uri)
		{
			return uri?.Replace("%3A", ":").Replace("%2F", "/").Replace("+", "%20");
		}
	}
}
