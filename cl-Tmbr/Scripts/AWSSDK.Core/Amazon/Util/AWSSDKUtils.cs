using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Util
{
	public static class AWSSDKUtils
	{
		private class IsSetMethodsCacheKey
		{
			public readonly Type Type;

			public readonly string PropertyName;

			public IsSetMethodsCacheKey(Type type, string propertyName)
			{
				Type = type;
				PropertyName = propertyName;
			}

			public override bool Equals(object other)
			{
				if (!(other is IsSetMethodsCacheKey isSetMethodsCacheKey))
				{
					return false;
				}
				if (Type == isSetMethodsCacheKey.Type)
				{
					return PropertyName == isSetMethodsCacheKey.PropertyName;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Type.GetHashCode() ^ PropertyName.GetHashCode();
			}

			public override string ToString()
			{
				return Type.FullName + "." + PropertyName;
			}
		}

		internal const string DefaultRegion = "us-east-1";

		internal const string DefaultGovRegion = "us-gov-west-1";

		private const char WindowsDirectorySeparatorChar = '\\';

		private const char WindowsAltDirectorySeparatorChar = '/';

		private const char WindowsVolumeSeparatorChar = ':';

		private const char SlashChar = '/';

		private const string Slash = "/";

		private const string EncodedSlash = "%2F";

		internal const int DefaultMaxRetry = 3;

		private const int DefaultConnectionLimit = 50;

		private const int DefaultMaxIdleTime = 50000;

		private const int MaxIsSetMethodsCacheSize = 50;

		public static readonly DateTime EPOCH_START = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public const int DefaultBufferSize = 8192;

		public const long DefaultProgressUpdateInterval = 102400L;

		internal const string S3Accelerate = "s3-accelerate";

		internal const string S3Control = "s3-control";

		private static readonly string _userAgent = InternalSDKUtils.BuildUserAgentString(string.Empty, string.Empty);

		public const string UserAgentHeader = "User-Agent";

		public const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		public const string ValidUrlCharactersRFC1738 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.";

		private static string ValidPathCharacters = DetermineValidPathCharacters();

		public const string ValidTraceIdHeaderValueCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-=;:+&[]{}\"',";

		public const string UrlEncodedContent = "application/x-www-form-urlencoded; charset=utf-8";

		public const string GMTDateFormat = "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T";

		public const string ISO8601DateFormat = "yyyy-MM-dd\\THH:mm:ss.fff\\Z";

		public const string ISO8601DateFormatNoMS = "yyyy-MM-dd\\THH:mm:ss\\Z";

		public const string ISO8601BasicDateTimeFormat = "yyyyMMddTHHmmssZ";

		public const string ISO8601BasicDateFormat = "yyyyMMdd";

		public const string RFC822DateFormat = "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T";

		public const string ISO8601WithUTCOffset = "yyyy-MM-ddTHH:mm:ssZ";

		private static BackgroundInvoker _dispatcher;

		private static LruCache<IsSetMethodsCacheKey, MethodInfo> IsSetMethodsCache = new LruCache<IsSetMethodsCacheKey, MethodInfo>(50);

		private static ReadOnlySpan<char> DoubleSlash
		{
			get
			{
				object obj = global::_003CPrivateImplementationDetails_003E._532E97B88EF3AF89C44A55158E00FBB1F14C112124DAD03F965E44CE95414AA8_A1;
				if (obj == null)
				{
					obj = new char[2] { '/', '/' };
					global::_003CPrivateImplementationDetails_003E._532E97B88EF3AF89C44A55158E00FBB1F14C112124DAD03F965E44CE95414AA8_A1 = (char[])obj;
				}
				return new ReadOnlySpan<char>((char[])obj);
			}
		}

		private static ReadOnlySpan<char> Queue
		{
			get
			{
				object obj = global::_003CPrivateImplementationDetails_003E.E263CF6CF3DCB673DBE065F96FC9404AF11EF2CD07E01FA78504D8E9A7E205CC_A1;
				if (obj == null)
				{
					obj = new char[5] { 'q', 'u', 'e', 'u', 'e' };
					global::_003CPrivateImplementationDetails_003E.E263CF6CF3DCB673DBE065F96FC9404AF11EF2CD07E01FA78504D8E9A7E205CC_A1 = (char[])obj;
				}
				return new ReadOnlySpan<char>((char[])obj);
			}
		}

		private static BackgroundInvoker Dispatcher
		{
			get
			{
				if (_dispatcher == null)
				{
					_dispatcher = new BackgroundInvoker();
				}
				return _dispatcher;
			}
		}

		public static string FormattedCurrentTimestampGMT => CorrectedUtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);

		public static string FormattedCurrentTimestampISO8601 => GetFormattedTimestampISO8601(0);

		public static string FormattedCurrentTimestampRFC822 => GetFormattedTimestampRFC822(0);

		public static DateTime CorrectedUtcNow
		{
			get
			{
				DateTime result = AWSConfigs.utcNowSource();
				if (AWSConfigs.ManualClockCorrection.HasValue)
				{
					result += AWSConfigs.ManualClockCorrection.Value;
				}
				return result;
			}
		}

		private static string DetermineValidPathCharacters()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = "/'()!*$+,;=&";
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				string text2 = Uri.EscapeUriString(c.ToString());
				if (text2.Length == 1 && text2[0] == c)
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetExtension(string path)
		{
			if (path == null)
			{
				return null;
			}
			int length = path.Length;
			int num = length;
			while (--num >= 0)
			{
				char c = path[num];
				if (c == '.')
				{
					if (num != length - 1)
					{
						return path.Substring(num, length - num);
					}
					return string.Empty;
				}
				if (IsPathSeparator(c))
				{
					break;
				}
			}
			return string.Empty;
			static bool IsPathSeparator(char ch)
			{
				if (ch != '\\' && ch != '/')
				{
					return ch == ':';
				}
				return true;
			}
		}

		internal static string CalculateStringToSignV2(ParameterCollection parameterCollection, string serviceUrl)
		{
			StringBuilder stringBuilder = new StringBuilder("POST\n", 512);
			List<KeyValuePair<string, string>> sortedParametersList = parameterCollection.GetSortedParametersList();
			Uri uri = new Uri(serviceUrl);
			stringBuilder.Append(uri.Host);
			stringBuilder.Append("\n");
			string text = uri.AbsolutePath;
			if (text == null || text.Length == 0)
			{
				text = "/";
			}
			stringBuilder.Append(UrlEncode(text, path: true));
			stringBuilder.Append("\n");
			foreach (KeyValuePair<string, string> item in sortedParametersList)
			{
				if (item.Value != null)
				{
					stringBuilder.Append(UrlEncode(item.Key, path: false));
					stringBuilder.Append("=");
					stringBuilder.Append(UrlEncode(item.Value, path: false));
					stringBuilder.Append("&");
				}
			}
			string text2 = stringBuilder.ToString();
			return text2.Remove(text2.Length - 1);
		}

		internal static string GetParametersAsString(IRequest request)
		{
			return GetParametersAsString(request.ParameterCollection);
		}

		public static byte[] GetRequestPayloadBytes(IRequest request, bool? usesQueryString = null)
		{
			if (request.Content != null)
			{
				return request.Content;
			}
			string s = ((!usesQueryString.HasValue || !usesQueryString.Value) ? GetParametersAsString(request) : string.Empty);
			return Encoding.UTF8.GetBytes(s);
		}

		internal static string GetParametersAsString(ParameterCollection parameterCollection)
		{
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(512);
			foreach (KeyValuePair<string, string> item in parameterCollection.GetParametersEnumerable())
			{
				string value = item.Value;
				if (value != null)
				{
					valueStringBuilder.Append(item.Key);
					valueStringBuilder.Append('=');
					valueStringBuilder.Append(UrlEncode(value, path: false));
					valueStringBuilder.Append('&');
				}
			}
			int length = valueStringBuilder.Length;
			if (length != 0)
			{
				return valueStringBuilder.ToString(0, length - 1);
			}
			return string.Empty;
		}

		public static string CanonicalizeResourcePathV2(Uri endpoint, string resourcePath, bool encode, IDictionary<string, string> pathResources)
		{
			if (endpoint != null)
			{
				string text = endpoint.AbsolutePath;
				if (string.IsNullOrEmpty(text) || string.Equals(text, "/", StringComparison.Ordinal))
				{
					text = string.Empty;
				}
				if (!string.IsNullOrEmpty(resourcePath) && resourcePath.StartsWith("/", StringComparison.Ordinal))
				{
					resourcePath = resourcePath.Substring(1);
				}
				if (!string.IsNullOrEmpty(resourcePath))
				{
					text = text + "/" + resourcePath;
				}
				resourcePath = text;
			}
			if (string.IsNullOrEmpty(resourcePath))
			{
				return "/";
			}
			IEnumerable<UriComponent> enumerable = SplitResourcePathIntoSegmentsV2(resourcePath, pathResources);
			bool flag = false;
			if (encode)
			{
				if (endpoint == null)
				{
					throw new ArgumentNullException("endpoint", "A non-null endpoint is necessary to decide whether or not to pre URL encode.");
				}
				foreach (UriComponent item in enumerable)
				{
					if (item.SegmentType == SegmentType.Label)
					{
						item.Value = UrlEncode(item.Value, path: false);
					}
					else
					{
						item.Value = UrlEncode(item.Value, path: true);
					}
				}
				flag = true;
			}
			string text2 = JoinResourcePathSegmentsV2(enumerable);
			Logger.GetLogger(typeof(AWSSDKUtils)).DebugFormat("{0} encoded {1}{2} for canonicalization: {3}", flag ? "Double" : "Single", resourcePath, (endpoint == null) ? "" : (" with endpoint " + endpoint.AbsoluteUri), text2);
			return text2;
		}

		public static IEnumerable<string> SplitResourcePathIntoSegments(string resourcePath, IDictionary<string, string> pathResources)
		{
			char[] separator = new char[1] { '/' };
			string[] array = resourcePath.Split(separator, StringSplitOptions.None);
			if (pathResources == null || pathResources.Count == 0)
			{
				return array;
			}
			List<string> list = new List<string>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!pathResources.ContainsKey(text))
				{
					list.Add(text);
				}
				else if (text.EndsWith("+}", StringComparison.Ordinal))
				{
					list.AddRange(pathResources[text].Split(separator, StringSplitOptions.None));
				}
				else
				{
					list.Add(pathResources[text]);
				}
			}
			return list;
		}

		public static IEnumerable<UriComponent> SplitResourcePathIntoSegmentsV2(string resourcePath, IDictionary<string, string> pathResources)
		{
			char[] separator = new char[1] { '/' };
			string[] array = resourcePath.Split(separator, StringSplitOptions.None);
			List<UriComponent> list = new List<UriComponent>();
			string[] array2;
			if (pathResources == null || pathResources.Count == 0)
			{
				array2 = array;
				foreach (string value in array2)
				{
					list.Add(new UriComponent
					{
						SegmentType = SegmentType.Literal,
						Value = value
					});
				}
				return list;
			}
			array2 = array;
			foreach (string text in array2)
			{
				if (!pathResources.TryGetValue(text, out var value2))
				{
					list.Add(new UriComponent
					{
						SegmentType = SegmentType.Literal,
						Value = text
					});
				}
				else if (text.EndsWith("+}", StringComparison.Ordinal))
				{
					list.AddRange(from x in value2.Split(separator, StringSplitOptions.None)
						select new UriComponent
						{
							Value = x,
							SegmentType = SegmentType.Label
						});
				}
				else
				{
					list.Add(new UriComponent
					{
						SegmentType = SegmentType.Label,
						Value = value2
					});
				}
			}
			return list;
		}

		public static string JoinResourcePathSegmentsV2(IEnumerable<string> pathSegments)
		{
			pathSegments = pathSegments.Select((string segment) => UrlEncode(segment, path: false));
			return string.Join("/", pathSegments.ToArray());
		}

		public static string JoinResourcePathSegmentsV2(IEnumerable<UriComponent> pathSegments)
		{
			List<string> values = pathSegments.Select((UriComponent segment) => (segment.SegmentType == SegmentType.Label) ? UrlEncode(segment.Value, path: false) : UrlEncode(segment.Value, path: true)).ToList();
			return string.Join("/", values);
		}

		public static string ResolveResourcePathV2(string resourcePath, IDictionary<string, string> pathResources)
		{
			if (string.IsNullOrEmpty(resourcePath))
			{
				return resourcePath;
			}
			return JoinResourcePathSegmentsV2(SplitResourcePathIntoSegmentsV2(resourcePath, pathResources));
		}

		public static string Join(List<string> strings)
		{
			return string.Join(", ", strings);
		}

		public static string DetermineRegion(string url)
		{
			return RegionFinder.Instance.FindRegion(url)?.SystemName;
		}

		public static string DetermineService(string url)
		{
			ReadOnlySpan<char> span = url.AsSpan();
			int num = span.IndexOf(DoubleSlash, StringComparison.Ordinal);
			if (num >= 0)
			{
				span = span.Slice(num + 2);
			}
			int num2 = span.IndexOf('.');
			if (num2 < 0)
			{
				return string.Empty;
			}
			ReadOnlySpan<char> span2 = span.Slice(0, num2);
			int num3 = span2.IndexOf('-');
			if (num3 > 0)
			{
				span2 = span2.Slice(0, num3);
			}
			if (!span2.Equals(Queue, StringComparison.OrdinalIgnoreCase))
			{
				return span2.ToString();
			}
			return "sqs";
		}

		public static DateTime ConvertFromUnixEpochSeconds(int seconds)
		{
			long num = (long)seconds * 10000000L;
			DateTime ePOCH_START = EPOCH_START;
			return new DateTime(num + ePOCH_START.Ticks, DateTimeKind.Utc);
		}

		public static DateTime ConvertFromUnixLongEpochSeconds(long seconds)
		{
			long num = seconds * 10000000;
			DateTime ePOCH_START = EPOCH_START;
			return new DateTime(num + ePOCH_START.Ticks, DateTimeKind.Utc);
		}

		public static DateTime ConvertFromUnixEpochMilliseconds(long milliseconds)
		{
			long num = milliseconds * 10000;
			DateTime ePOCH_START = EPOCH_START;
			return new DateTime(num + ePOCH_START.Ticks, DateTimeKind.Utc);
		}

		public static int ConvertToUnixEpochSeconds(DateTime dateTime)
		{
			return Convert.ToInt32(GetTimeSpanInTicks(dateTime).TotalSeconds);
		}

		public static long ConvertToUnixEpochMilliseconds(DateTime dateTime)
		{
			return Convert.ToInt64(GetTimeSpanInTicks(dateTime).TotalMilliseconds);
		}

		public static string ConvertToUnixEpochSecondsString(DateTime dateTime)
		{
			return Convert.ToInt64(GetTimeSpanInTicks(dateTime).TotalSeconds).ToString(CultureInfo.InvariantCulture);
		}

		public static double ConvertToUnixEpochSecondsDouble(DateTime dateTime)
		{
			return Math.Round(GetTimeSpanInTicks(dateTime).TotalMilliseconds, 0) / 1000.0;
		}

		public static TimeSpan GetTimeSpanInTicks(DateTime dateTime)
		{
			long ticks = dateTime.ToUniversalTime().Ticks;
			DateTime ePOCH_START = EPOCH_START;
			return new TimeSpan(ticks - ePOCH_START.Ticks);
		}

		public static string ToHex(byte[] data, bool lowercase)
		{
			char[] array = ArrayPool<char>.Shared.Rent(data.Length * 2);
			try
			{
				ToHexString(data, array, lowercase);
				return new string(array, 0, data.Length * 2);
			}
			finally
			{
				ArrayPool<char>.Shared.Return(array);
			}
		}

		public static void InvokeInBackground<T>(EventHandler<T> handler, T args, object sender) where T : EventArgs
		{
			if (handler == null)
			{
				return;
			}
			Delegate[] invocationList = handler.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				EventHandler<T> eventHandler = (EventHandler<T>)obj;
				if (eventHandler != null)
				{
					Dispatcher.Dispatch(delegate
					{
						eventHandler(sender, args);
					});
				}
			}
		}

		public static Dictionary<string, string> ParseQueryParameters(string url)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(url))
			{
				int num = url.IndexOf('?');
				if (num >= 0)
				{
					string[] array = url.Substring(num + 1).Split(new char[1] { '&' }, StringSplitOptions.None);
					foreach (string text in array)
					{
						if (!string.IsNullOrEmpty(text))
						{
							string[] array2 = text.Split(new char[1] { '=' }, 2);
							string key = array2[0];
							string value = ((array2.Length == 1) ? null : array2[1]);
							dictionary[key] = value;
						}
					}
				}
			}
			return dictionary;
		}

		internal static bool AreEqual(object[] itemsA, object[] itemsB)
		{
			if (itemsA == null || itemsB == null)
			{
				return itemsA == itemsB;
			}
			if (itemsA.Length != itemsB.Length)
			{
				return false;
			}
			int num = itemsA.Length;
			for (int i = 0; i < num; i++)
			{
				object a = itemsA[i];
				object b = itemsB[i];
				if (!AreEqual(a, b))
				{
					return false;
				}
			}
			return true;
		}

		internal static bool AreEqual(object a, object b)
		{
			if (a == null || b == null)
			{
				return a == b;
			}
			if (a == b)
			{
				return true;
			}
			return a.Equals(b);
		}

		internal static bool DictionariesAreEqual<K, V>(Dictionary<K, V> a, Dictionary<K, V> b)
		{
			if (a == null || b == null)
			{
				return a == b;
			}
			if (a == b)
			{
				return true;
			}
			if (a.Count == b.Count)
			{
				return !a.Except(b).Any();
			}
			return false;
		}

		public static MemoryStream GenerateMemoryStreamFromString(string s)
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			streamWriter.Write(s);
			streamWriter.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		public static void CopyStream(Stream source, Stream destination)
		{
			CopyStream(source, destination, 8192);
		}

		public static void CopyStream(Stream source, Stream destination, int bufferSize)
		{
			source.CopyTo(destination, bufferSize);
		}

		public static string GetFormattedTimestampISO8601(int minutesFromNow)
		{
			return GetFormattedTimestampISO8601(CorrectedUtcNow.AddMinutes(minutesFromNow));
		}

		internal static string GetFormattedTimestampISO8601(IClientConfig config, AmazonWebServiceRequest request)
		{
			return GetFormattedTimestampISO8601(CorrectClockSkew.GetCorrectedUtcNowForEndpoint(config.DetermineServiceOperationEndpoint(new ServiceOperationEndpointParameters(request)).URL));
		}

		private static string GetFormattedTimestampISO8601(DateTime dateTime)
		{
			return dateTime.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string GetFormattedTimestampRFC822(int minutesFromNow)
		{
			return CorrectedUtcNow.AddMinutes(minutesFromNow).ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
		}

		public static bool IsAbsolutePath(string path)
		{
			if (!IsWindows())
			{
				return Path.IsPathRooted(path);
			}
			return !IsPartiallyQualifiedForWindows(path);
		}

		private static bool IsWindows()
		{
			return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
		}

		private static bool IsPartiallyQualifiedForWindows(string path)
		{
			if (path.Length < 2)
			{
				return true;
			}
			if (IsWindowsDirectorySeparator(path[0]))
			{
				if (path[1] != '?')
				{
					return !IsWindowsDirectorySeparator(path[1]);
				}
				return false;
			}
			if (path.Length >= 3 && path[1] == ':' && IsWindowsDirectorySeparator(path[2]))
			{
				return !IsValidWindowsDriveChar(path[0]);
			}
			return true;
		}

		private static bool IsWindowsDirectorySeparator(char c)
		{
			if (c != '\\')
			{
				return c == '/';
			}
			return true;
		}

		private static bool IsValidWindowsDriveChar(char value)
		{
			if (value < 'A' || value > 'Z')
			{
				if (value >= 'a')
				{
					return value <= 'z';
				}
				return false;
			}
			return true;
		}

		public static string UrlEncode(string data, bool path)
		{
			return UrlEncode(3986, data, path);
		}

		[SkipLocalsInit]
		public static string UrlEncode(int rfcNumber, string data, bool path)
		{
			byte[] array = null;
			try
			{
				if (!TryGetRFCEncodingSchemes(rfcNumber, out var encodingScheme))
				{
					encodingScheme = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
				}
				ReadOnlySpan<char> span = (encodingScheme + (path ? ValidPathCharacters : string.Empty)).AsSpan();
				ReadOnlySpan<char> src = data.AsSpan();
				Encoding uTF = Encoding.UTF8;
				int maxByteCount = uTF.GetMaxByteCount(src.Length);
				int num = 2 * maxByteCount;
				Span<byte> span2 = ((num > 256) ? ((Span<byte>)(array = ArrayPool<byte>.Shared.Rent(num))) : stackalloc byte[256]);
				Span<byte> span3 = span2;
				Span<byte> dest = span3.Slice(span3.Length - maxByteCount);
				int bytes = Extensions.GetBytes(uTF, src, dest);
				int length = 0;
				span2 = dest.Slice(0, bytes);
				for (int i = 0; i < span2.Length; i++)
				{
					byte b = span2[i];
					if (span.IndexOf((char)b) != -1)
					{
						span3[length++] = b;
						continue;
					}
					span3[length++] = 37;
					int value = b >> 4;
					int value2 = b & 0xF;
					span3[length++] = (byte)ToUpperHex(value);
					span3[length++] = (byte)ToUpperHex(value2);
				}
				return Extensions.GetString(uTF, span3.Slice(0, length));
			}
			finally
			{
				if (array != null)
				{
					ArrayPool<byte>.Shared.Return(array);
				}
			}
		}

		internal static bool TryGetRFCEncodingSchemes(int rfcNumber, out string encodingScheme)
		{
			switch (rfcNumber)
			{
			case 3986:
				encodingScheme = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
				return true;
			case 1738:
				encodingScheme = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.";
				return true;
			default:
				encodingScheme = null;
				return false;
			}
		}

		private static void ToHexString(Span<byte> source, Span<char> destination, bool lowercase)
		{
			Func<int, char> func = (lowercase ? new Func<int, char>(ToLowerHex) : new Func<int, char>(ToUpperHex));
			for (int num = source.Length - 1; num >= 0; num--)
			{
				byte num2 = source[num];
				int arg = num2 >> 4;
				int arg2 = num2 & 0xF;
				destination[num * 2] = func(arg);
				destination[num * 2 + 1] = func(arg2);
			}
		}

		private static char ToUpperHex(int value)
		{
			if (value <= 9)
			{
				return (char)(value + 48);
			}
			return (char)(value - 10 + 65);
		}

		private static char ToLowerHex(int value)
		{
			if (value <= 9)
			{
				return (char)(value + 48);
			}
			return (char)(value - 10 + 97);
		}

		internal static string UrlEncodeSlash(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return data;
			}
			return data.Replace("/", "%2F");
		}

		internal static string EncodeTraceIdHeaderValue(string value)
		{
			StringBuilder stringBuilder = new StringBuilder(value.Length * 2);
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			for (int i = 0; i < bytes.Length; i++)
			{
				char c = (char)bytes[i];
				if ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-=;:+&[]{}\"',".IndexOf(c) != -1)
				{
					stringBuilder.Append(c);
				}
				else
				{
					stringBuilder.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)c));
				}
			}
			return stringBuilder.ToString();
		}

		public static string GenerateMD5ChecksumForStream(Stream input)
		{
			if (!input.CanSeek)
			{
				throw new InvalidOperationException("Input stream must be seekable");
			}
			string result = Convert.ToBase64String(CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(input));
			input.Position = 0L;
			return result;
		}

		public static string GenerateChecksumForContent(string content, bool fBase64Encode)
		{
			return GenerateChecksumForBytes(Encoding.UTF8.GetBytes(content), fBase64Encode);
		}

		public static string GenerateChecksumForBytes(byte[] content, bool fBase64Encode)
		{
			byte[] array = ((content != null) ? CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(content) : CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(ArrayEx.Empty<byte>()));
			if (fBase64Encode)
			{
				return Convert.ToBase64String(array);
			}
			return BitConverter.ToString(array).Replace("-", string.Empty);
		}

		public static void Sleep(TimeSpan ts)
		{
			Sleep((int)ts.TotalMilliseconds);
		}

		public static byte[] HexStringToBytes(string hex)
		{
			if (string.IsNullOrEmpty(hex) || hex.Length % 2 == 1)
			{
				throw new ArgumentOutOfRangeException("hex");
			}
			int num = 0;
			byte[] array = new byte[hex.Length / 2];
			for (int i = 0; i < hex.Length; i += 2)
			{
				byte b = Convert.ToByte(hex.Substring(i, 2), 16);
				array[num] = b;
				num++;
			}
			return array;
		}

		public static bool HasBidiControlCharacters(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			for (int i = 0; i < input.Length; i++)
			{
				if (IsBidiControlChar(input[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsBidiControlChar(char c)
		{
			switch (c)
			{
			default:
				return false;
			case '‐':
			case '‑':
			case '‒':
			case '–':
			case '—':
			case '―':
			case '‖':
			case '‗':
			case '‘':
			case '’':
			case '‚':
			case '‛':
			case '“':
			case '”':
			case '„':
			case '‟':
			case '†':
			case '‡':
			case '•':
			case '‣':
			case '․':
			case '‥':
			case '…':
			case '‧':
			case '\u2028':
			case '\u2029':
			case '\u202e':
				return c == '\u202e';
			case '\u200e':
			case '\u200f':
			case '\u202a':
			case '\u202b':
			case '\u202c':
			case '\u202d':
				return true;
			}
		}

		public static string DownloadStringContent(Uri uri)
		{
			return DownloadStringContent(uri, TimeSpan.Zero, null);
		}

		public static string DownloadStringContent(Uri uri, TimeSpan timeout)
		{
			return DownloadStringContent(uri, timeout, null);
		}

		public static string DownloadStringContent(Uri uri, IWebProxy proxy)
		{
			return DownloadStringContent(uri, TimeSpan.Zero, proxy);
		}

		public static string DownloadStringContent(Uri uri, TimeSpan timeout, IWebProxy proxy)
		{
			HttpClient client = CreateClient(uri, timeout, proxy, null);
			try
			{
				return AsyncHelpers.RunSync(() => client.GetStringAsync(uri));
			}
			finally
			{
				if (client != null)
				{
					((IDisposable)client).Dispose();
				}
			}
		}

		public static string ExecuteHttpRequest(Uri uri, string requestType, string content, TimeSpan timeout, IWebProxy proxy, IDictionary<string, string> headers)
		{
			HttpClient client = CreateClient(uri, timeout, proxy, headers);
			try
			{
				HttpResponseMessage response = AsyncHelpers.RunSync(delegate
				{
					HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod(requestType), uri);
					if (!string.IsNullOrEmpty(content))
					{
						httpRequestMessage.Content = new StringContent(content);
					}
					return client.SendAsync(httpRequestMessage);
				});
				try
				{
					response.EnsureSuccessStatusCode();
				}
				catch (HttpRequestException ex)
				{
					HttpRequestException obj = new HttpRequestException(ex.Message, ex)
					{
						Data = { 
						{
							(object)"StatusCode",
							(object)response.StatusCode
						} }
					};
					response.Dispose();
					throw obj;
				}
				try
				{
					return AsyncHelpers.RunSync(() => response.Content.ReadAsStringAsync());
				}
				finally
				{
					response.Dispose();
				}
			}
			finally
			{
				if (client != null)
				{
					((IDisposable)client).Dispose();
				}
			}
		}

		public static async Task<string> ExecuteHttpRequestAsync(Uri uri, string requestType, string content, TimeSpan timeout, IWebProxy proxy, IDictionary<string, string> headers)
		{
			using HttpClient client = CreateClient(uri, timeout, proxy, headers);
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod(requestType), uri);
			if (!string.IsNullOrEmpty(content))
			{
				httpRequestMessage.Content = new StringContent(content);
			}
			HttpResponseMessage response = await client.SendAsync(httpRequestMessage).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				response.EnsureSuccessStatusCode();
			}
			catch (HttpRequestException ex)
			{
				HttpRequestException obj = new HttpRequestException(ex.Message, ex)
				{
					Data = { 
					{
						(object)"StatusCode",
						(object)response.StatusCode
					} }
				};
				response.Dispose();
				throw obj;
			}
			try
			{
				return await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				response.Dispose();
			}
		}

		private static HttpClient CreateClient(Uri uri, TimeSpan timeout, IWebProxy proxy, IDictionary<string, string> headers)
		{
			HttpClient httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy
			});
			if (timeout > TimeSpan.Zero)
			{
				httpClient.Timeout = timeout;
			}
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", _userAgent);
			if (headers != null)
			{
				foreach (KeyValuePair<string, string> header in headers)
				{
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
				}
			}
			return httpClient;
		}

		public static Stream OpenStream(Uri uri)
		{
			return OpenStream(uri, null);
		}

		public static Stream OpenStream(Uri uri, IWebProxy proxy)
		{
			using HttpClient httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy
			});
			return httpClient.GetStreamAsync(uri).Result;
		}

		public static string CompressSpaces(string data)
		{
			if (data == null)
			{
				return null;
			}
			int length = data.Length;
			if (length == 0)
			{
				return string.Empty;
			}
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(length);
			int num = 0;
			bool flag = false;
			foreach (char c in data)
			{
				if (!flag | !(flag = char.IsWhiteSpace(c)))
				{
					valueStringBuilder.Append(flag ? ' ' : c);
					num++;
				}
			}
			return valueStringBuilder.ToString(0, num);
		}

		internal static string ExtractOperationName(string requestName)
		{
			if (requestName.EndsWith("Request", StringComparison.Ordinal))
			{
				return requestName.Substring(0, requestName.Length - 7);
			}
			return requestName;
		}

		public static ProcessExecutionResult RunProcess(ProcessStartInfo processStartInfo)
		{
			Process process = new Process
			{
				StartInfo = processStartInfo
			};
			try
			{
				Logger logger = Logger.GetLogger(typeof(AWSSDKUtils));
				logger.InfoFormat("Starting a process with the following ProcessInfo: UseShellExecute - {0} RedirectStandardError - {1}, RedirectStandardOutput - {2}, CreateNoWindow - {3}", processStartInfo.UseShellExecute, processStartInfo.RedirectStandardError, processStartInfo.RedirectStandardOutput, processStartInfo.CreateNoWindow);
				process.Start();
				logger.DebugFormat("Process started");
				string standardOutput = null;
				Thread thread = new Thread((ThreadStart)delegate
				{
					standardOutput = process.StandardOutput.ReadToEnd();
				});
				thread.Start();
				string standardError = process.StandardError.ReadToEnd();
				thread.Join();
				process.WaitForExit();
				return new ProcessExecutionResult
				{
					ExitCode = process.ExitCode,
					StandardError = standardError,
					StandardOutput = standardOutput
				};
			}
			finally
			{
				if (process != null)
				{
					((IDisposable)process).Dispose();
				}
			}
		}

		public static async Task<ProcessExecutionResult> RunProcessAsync(ProcessStartInfo processStartInfo)
		{
			Logger logger = Logger.GetLogger(typeof(AWSSDKUtils));
			using Process process = new Process
			{
				StartInfo = processStartInfo,
				EnableRaisingEvents = true
			};
			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			process.Exited += delegate
			{
				tcs.SetResult(null);
			};
			logger.InfoFormat("Starting a process with the following ProcessInfo: UseShellExecute - {0} RedirectStandardError - {1}, RedirectStandardOutput - {2}, CreateNoWindow - {3}", processStartInfo.UseShellExecute, processStartInfo.RedirectStandardError, processStartInfo.RedirectStandardOutput, processStartInfo.CreateNoWindow);
			process.Start();
			logger.DebugFormat("Process started");
			Task<string> standardErrorTask = process.StandardError.ReadToEndAsync();
			Task<string> standardOutputTask = process.StandardOutput.ReadToEndAsync();
			await Task.WhenAll(tcs.Task, standardErrorTask, standardOutputTask).ConfigureAwait(continueOnCapturedContext: false);
			return new ProcessExecutionResult
			{
				ExitCode = process.ExitCode,
				StandardError = standardErrorTask.Result,
				StandardOutput = standardOutputTask.Result
			};
		}

		public static bool IsPropertySet(object awsServiceObject, string propertyName)
		{
			Type type = awsServiceObject.GetType();
			string text = type.Namespace;
			if (!text.StartsWith("Amazon.", StringComparison.Ordinal) || !text.EndsWith(".Model", StringComparison.Ordinal))
			{
				throw new ArgumentException("IsPropertySet can be used only on Amazon Model classes");
			}
			if (text == "Amazon.S3.Model")
			{
				throw new ArgumentException("IsPropertySet doesn't support S3");
			}
			IsSetMethodsCacheKey isSetMethodsCacheKey = new IsSetMethodsCacheKey(type, propertyName);
			MethodInfo orAdd = IsSetMethodsCache.GetOrAdd(isSetMethodsCacheKey, (IsSetMethodsCacheKey k) => k.Type.GetMethod("IsSet" + k.PropertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], new ParameterModifier[0]));
			if (orAdd == null)
			{
				throw new ArgumentException("Could not find an IsSet method for property " + isSetMethodsCacheKey);
			}
			object obj = orAdd.Invoke(awsServiceObject, new object[0]);
			if (!(obj is bool))
			{
				throw new ArgumentException("The IsSet method for property " + isSetMethodsCacheKey?.ToString() + " didn't return a bool");
			}
			return (bool)obj;
		}

		public static void ForceCanonicalPathAndQuery(Uri uri)
		{
		}

		public static void PreserveStackTrace(Exception exception)
		{
		}

		internal static int GetConnectionLimit(int? clientConfigValue)
		{
			if (clientConfigValue.HasValue)
			{
				return clientConfigValue.Value;
			}
			return 50;
		}

		public static void Sleep(int ms)
		{
			Thread.Sleep(ms);
		}
	}
}
