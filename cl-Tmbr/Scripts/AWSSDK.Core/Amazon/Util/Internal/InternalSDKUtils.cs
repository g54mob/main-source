using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal.PlatformServices;
using ThirdParty.RuntimeBackports;

namespace Amazon.Util.Internal
{
	public static class InternalSDKUtils
	{
		private static string _overrideVersionNumber;

		private static string _customData;

		private const string USER_AGENT_VERSION = "ua/2.1";

		private const string DisallowedCharactersRegexPattern = "[^ /!#$%&'*+-.^_`|~\\w\\d]";

		private static readonly Regex _disallowedCharactersRegex = new Regex("[^ /!#$%&'*+-.^_`|~\\w\\d]", RegexOptions.Compiled);

		internal static string EXECUTION_ENVIRONMENT_ENVVAR = "AWS_EXECUTION_ENV";

		internal static string INTERNAL_ENVIRONMENT_ENVVAR = "AWS_INTERNAL_ENV";

		internal const string CoreVersionNumber = "4.0.0.6";

		private const string UnknownPlaceholder = "Unknown";

		private const string UnknownPlatform = "unknown_platform";

		private static string _userAgentBaseName = "aws-sdk-dotnet-coreclr";

		private static IRuntimeInformationWrapper _runtimeInformationWrapper = new RuntimeInformationWrapper();

		private static Regex DisallowedCharactersRegex()
		{
			return _disallowedCharactersRegex;
		}

		public static void SetUserAgent(string productName, string versionNumber)
		{
			SetUserAgent(productName, versionNumber, null);
		}

		public static void SetUserAgent(string productName, string versionNumber, string customData)
		{
			_userAgentBaseName = productName;
			_overrideVersionNumber = versionNumber;
			_customData = customData;
		}

		internal static string ReplaceInvalidUserAgentCharacters(string userAgent)
		{
			return DisallowedCharactersRegex().Replace(userAgent, "-");
		}

		public static string BuildUserAgentString(string serviceSdkVersion)
		{
			return BuildUserAgentString(string.Empty, serviceSdkVersion);
		}

		public static string BuildUserAgentString(string serviceId, string serviceSdkVersion)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(_userAgentBaseName);
			if (!string.IsNullOrEmpty(_overrideVersionNumber))
			{
				stringBuilder.AppendFormat("/{0}", _overrideVersionNumber);
			}
			else if (!string.IsNullOrEmpty(serviceSdkVersion))
			{
				stringBuilder.AppendFormat("/{0}", serviceSdkVersion);
			}
			stringBuilder.AppendFormat(" {0}", "ua/2.1");
			IEnvironmentInfo service = ServiceFactory.Instance.GetService<IEnvironmentInfo>();
			stringBuilder.AppendFormat(" os/{0}", service.PlatformUserAgent);
			stringBuilder.AppendFormat(" lang/{0}", service.FrameworkUserAgent);
			string executionEnvironmentUserAgentString = GetExecutionEnvironmentUserAgentString();
			if (!string.IsNullOrEmpty(executionEnvironmentUserAgentString))
			{
				stringBuilder.AppendFormat(" {0}", executionEnvironmentUserAgentString);
			}
			stringBuilder.AppendFormat(" md/aws-sdk-dotnet-core#{0}", "4.0.0.6");
			string internalUserAgentString = GetInternalUserAgentString();
			if (!string.IsNullOrEmpty(internalUserAgentString))
			{
				stringBuilder.AppendFormat(" {0}", internalUserAgentString);
			}
			if (!string.IsNullOrEmpty(serviceId))
			{
				stringBuilder.AppendFormat(" api/{0}", serviceId);
				if (!string.IsNullOrEmpty(serviceSdkVersion))
				{
					stringBuilder.Append("#");
					stringBuilder.Append(serviceSdkVersion);
				}
			}
			if (!string.IsNullOrEmpty(_customData))
			{
				stringBuilder.AppendFormat(" {0}", _customData);
			}
			if (IsRunningNativeAot())
			{
				stringBuilder.Append(" ft/aot");
			}
			return stringBuilder.ToString();
		}

		public static void ApplyValuesV2<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T target, IDictionary<string, object> propertyValues)
		{
			if (propertyValues == null || propertyValues.Count == 0)
			{
				return;
			}
			Type typeFromHandle = typeof(T);
			foreach (KeyValuePair<string, object> propertyValue in propertyValues)
			{
				PropertyInfo property = typeFromHandle.GetProperty(propertyValue.Key);
				if (property == null)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to find property {0} on type {1}.", propertyValue.Key, typeFromHandle.FullName));
				}
				try
				{
					Type propertyType = property.PropertyType;
					if (propertyType.IsEnum)
					{
						object value = Enum.Parse(propertyType, propertyValue.Value.ToString(), ignoreCase: true);
						property.SetValue(target, value, null);
					}
					else
					{
						property.SetValue(target, propertyValue.Value, null);
					}
				}
				catch (Exception ex)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to set property {0} on type {1}: {2}", propertyValue.Key, typeFromHandle.FullName, ex.Message));
				}
			}
		}

		public static bool AreTypesEqual(Type type1, Type type2)
		{
			if (type1.Assembly != type2.Assembly)
			{
				return false;
			}
			if (type1.Namespace != type2.Namespace)
			{
				return false;
			}
			if (type1.Name != type2.Name)
			{
				return false;
			}
			return true;
		}

		public static void AddToDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (dictionary.ContainsKey(key))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Dictionary already contains item with key {0}", key));
			}
			dictionary[key] = value;
		}

		public static void FillDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator, Dictionary<TKey, TValue> targetDictionary)
		{
			foreach (T item in items)
			{
				TKey key = keyGenerator(item);
				TValue value = valueGenerator(item);
				AddToDictionary(targetDictionary, key, value);
			}
		}

		public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator)
		{
			return ToDictionary(items, keyGenerator, valueGenerator, null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator, IEqualityComparer<TKey> comparer)
		{
			Dictionary<TKey, TValue> dictionary = ((comparer != null) ? new Dictionary<TKey, TValue>(comparer) : new Dictionary<TKey, TValue>());
			FillDictionary(items, keyGenerator, valueGenerator, dictionary);
			return dictionary;
		}

		public static bool TryFindByValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> valueComparer, out TKey key)
		{
			if (dictionary != null)
			{
				foreach (KeyValuePair<TKey, TValue> item in dictionary)
				{
					TValue value2 = item.Value;
					if (valueComparer.Equals(value, value2))
					{
						key = item.Key;
						return true;
					}
				}
			}
			key = default(TKey);
			return false;
		}

		internal static string GetExecutionEnvironment()
		{
			return Environment.GetEnvironmentVariable(EXECUTION_ENVIRONMENT_ENVVAR);
		}

		internal static string GetInternalEnvironment()
		{
			return Environment.GetEnvironmentVariable(INTERNAL_ENVIRONMENT_ENVVAR);
		}

		private static string GetExecutionEnvironmentUserAgentString()
		{
			string result = "";
			string executionEnvironment = GetExecutionEnvironment();
			if (!string.IsNullOrEmpty(executionEnvironment))
			{
				result = string.Format(CultureInfo.InvariantCulture, "exec-env/{0}", executionEnvironment);
			}
			return result;
		}

		private static string GetInternalUserAgentString()
		{
			string result = "";
			string internalEnvironment = GetInternalEnvironment();
			if (!string.IsNullOrEmpty(internalEnvironment))
			{
				result = string.Format(CultureInfo.InvariantCulture, "{0}", internalEnvironment);
			}
			return result;
		}

		public static bool IsFilePathRootedWithDirectoryPath(string filePath, string directoryPath)
		{
			string text = directoryPath;
			string text2 = text;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			if (!text2.EndsWith(directorySeparatorChar.ToString()))
			{
				string text3 = text;
				directorySeparatorChar = Path.DirectorySeparatorChar;
				text = text3 + directorySeparatorChar;
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(text);
			return new FileInfo(filePath).FullName.StartsWith(directoryInfo.FullName);
		}

		public static bool IsRunningNativeAot()
		{
			return false;
		}

		internal static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			using IEnumerator<TFirst> enumerator1 = first.GetEnumerator();
			using IEnumerator<TSecond> enumerator2 = second.GetEnumerator();
			while (enumerator1.MoveNext() && enumerator2.MoveNext())
			{
				yield return resultSelector(enumerator1.Current, enumerator2.Current);
			}
		}

		public static void SetIsSet<T>(bool isSet, ref T? field) where T : struct
		{
			if (isSet)
			{
				if (!field.HasValue)
				{
					field = default(T);
				}
			}
			else
			{
				field = null;
			}
		}

		public static void SetIsSet<T>(bool isSet, ref List<T> field)
		{
			if (isSet)
			{
				field = new AlwaysSendList<T>(field);
			}
			else
			{
				field = new List<T>();
			}
		}

		public static void SetIsSet<TKey, TValue>(bool isSet, ref Dictionary<TKey, TValue> field)
		{
			if (isSet)
			{
				field = new AlwaysSendDictionary<TKey, TValue>(field);
			}
			else
			{
				field = new Dictionary<TKey, TValue>();
			}
		}

		public static bool GetIsSet<T>(T? field) where T : struct
		{
			return field.HasValue;
		}

		public static bool GetIsSet<T>(List<T> field)
		{
			if (field == null)
			{
				return false;
			}
			if (field.Count > 0 || !AWSConfigs.InitializeCollections)
			{
				return true;
			}
			if (field is AlwaysSendList<T>)
			{
				return true;
			}
			return false;
		}

		public static bool GetIsSet<TKey, TVvalue>(Dictionary<TKey, TVvalue> field)
		{
			if (field == null)
			{
				return false;
			}
			if (field.Count > 0 || !AWSConfigs.InitializeCollections)
			{
				return true;
			}
			if (field is AlwaysSendDictionary<TKey, TVvalue>)
			{
				return true;
			}
			return false;
		}

		private static string GetValidSubstringOrUnknown(string str, int start, int end)
		{
			if (start != -1 && end != -1 && 0 <= start && end <= str.Length)
			{
				string text = str.Substring(start, end - start);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return text.Trim().Replace(' ', '_');
				}
			}
			return "Unknown";
		}

		public static string DetermineFramework()
		{
			try
			{
				string text = _runtimeInformationWrapper.FrameworkDescription.Trim();
				string validSubstringOrUnknown = GetValidSubstringOrUnknown(text, text.LastIndexOf(' ') + 1, text.Length);
				if (!Version.TryParse(validSubstringOrUnknown, out var _))
				{
					return "Unknown md/framework-raw-version#" + text.Replace(' ', '_');
				}
				return string.Format(CultureInfo.InvariantCulture, ".NET_Core#{0}", validSubstringOrUnknown);
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string DetermineOS()
		{
			try
			{
				string text = RuntimeInformation.OSDescription.Trim();
				return GetValidSubstringOrUnknown(text, 0, text.LastIndexOf(' '));
			}
			catch
			{
				return "Unknown";
			}
		}

		public static string PlatformUserAgent()
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					stringBuilder.AppendFormat("linux#{0}", Environment.OSVersion.Version);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					stringBuilder.AppendFormat("windows#{0}", Environment.OSVersion.Version);
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				{
					stringBuilder.AppendFormat("macos#{0}", Environment.OSVersion.Version);
				}
				else
				{
					stringBuilder.AppendFormat("other md/{0}#{1}", RuntimeInformation.OSDescription, Environment.OSVersion.Version);
				}
				stringBuilder.AppendFormat(" md/ARCH#{0}", RuntimeInformation.OSArchitecture);
				return stringBuilder.ToString();
			}
			catch
			{
				return "Unknown";
			}
		}

		internal static void SetRuntimeInformationWrapper(IRuntimeInformationWrapper wrapper)
		{
			_runtimeInformationWrapper = wrapper;
		}

		internal static void ResetRuntimeInformationWrapper()
		{
			_runtimeInformationWrapper = new RuntimeInformationWrapper();
		}
	}
}
