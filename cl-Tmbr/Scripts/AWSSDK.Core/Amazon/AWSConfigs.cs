using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.Telemetry;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon
{
	public static class AWSConfigs
	{
		private static char[] validSeparators = new char[2] { ' ', ',' };

		internal static Func<DateTime> utcNowSource = GetUtcNow;

		internal static string _awsRegion = GetConfig("AWSRegion");

		internal static string _awsProfileName = GetConfig("AWSProfileName");

		internal static string _awsAccountsLocation = GetConfig("AWSProfilesLocation");

		internal static bool _useSdkCache = GetConfigBool("AWSCache", defaultValue: true);

		internal static bool _initializeCollections = GetConfigBool("AWSInitializeCollections");

		private static object _lock = new object();

		private static List<string> standardConfigs = new List<string> { "region", "logging", "correctForClockSkew" };

		private static TelemetryProvider _telemetryProvider = new DefaultTelemetryProvider();

		private static bool configPresent = true;

		private static RootConfig _rootConfig = new RootConfig();

		public const string AWSRegionKey = "AWSRegion";

		public const string AWSProfileNameKey = "AWSProfileName";

		public const string AWSProfilesLocationKey = "AWSProfilesLocation";

		public const string StreamingUtf8JsonReaderBufferSizeKey = "StreamingUtf8JsonReaderBufferSize";

		public const string UseSdkCacheKey = "AWSCache";

		public const string InitializeCollectionsKey = "AWSInitializeCollections";

		internal const string LoggingDestinationProperty = "LogTo";

		internal static PropertyChangedEventHandler mPropertyChanged;

		internal static readonly object propertyChangedLock = new object();

		private static Dictionary<string, List<TraceListener>> _traceListeners = new Dictionary<string, List<TraceListener>>(StringComparer.OrdinalIgnoreCase);

		public static TimeSpan? ManualClockCorrection
		{
			get
			{
				return CorrectClockSkew.GlobalClockCorrection;
			}
			set
			{
				CorrectClockSkew.GlobalClockCorrection = value;
			}
		}

		public static bool CorrectForClockSkew
		{
			get
			{
				return _rootConfig.CorrectForClockSkew;
			}
			set
			{
				_rootConfig.CorrectForClockSkew = value;
			}
		}

		public static string AWSRegion
		{
			get
			{
				return _rootConfig.Region;
			}
			set
			{
				_rootConfig.Region = value;
			}
		}

		public static string AWSProfileName
		{
			get
			{
				return _rootConfig.ProfileName;
			}
			set
			{
				_rootConfig.ProfileName = value;
			}
		}

		public static string AWSProfilesLocation
		{
			get
			{
				return _rootConfig.ProfilesLocation;
			}
			set
			{
				_rootConfig.ProfilesLocation = value;
			}
		}

		public static int? StreamingUtf8JsonReaderBufferSize
		{
			get
			{
				return _rootConfig.StreamingUtf8JsonReaderBufferSize;
			}
			set
			{
				_rootConfig.StreamingUtf8JsonReaderBufferSize = value;
			}
		}

		public static bool UseSdkCache
		{
			get
			{
				return _rootConfig.UseSdkCache;
			}
			set
			{
				_rootConfig.UseSdkCache = value;
			}
		}

		public static bool InitializeCollections
		{
			get
			{
				return _rootConfig.InitializeCollections;
			}
			set
			{
				_rootConfig.InitializeCollections = value;
			}
		}

		public static LoggingConfig LoggingConfig => _rootConfig.Logging;

		public static ProxyConfig ProxyConfig => _rootConfig.Proxy;

		public static bool UseAlternateUserAgentHeader
		{
			get
			{
				return _rootConfig.UseAlternateUserAgentHeader;
			}
			set
			{
				_rootConfig.UseAlternateUserAgentHeader = value;
			}
		}

		public static TelemetryProvider TelemetryProvider
		{
			get
			{
				return _telemetryProvider;
			}
			set
			{
				_telemetryProvider = value;
			}
		}

		public static RegionEndpoint RegionEndpoint
		{
			get
			{
				return _rootConfig.RegionEndpoint;
			}
			set
			{
				_rootConfig.RegionEndpoint = value;
			}
		}

		public static CSMConfig CSMConfig
		{
			get
			{
				return _rootConfig.CSMConfig;
			}
			set
			{
				_rootConfig.CSMConfig = value;
			}
		}

		public static HttpClientFactory HttpClientFactory { get; set; }

		internal static event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				lock (propertyChangedLock)
				{
					mPropertyChanged = (PropertyChangedEventHandler)Delegate.Combine(mPropertyChanged, value);
				}
			}
			remove
			{
				lock (propertyChangedLock)
				{
					mPropertyChanged = (PropertyChangedEventHandler)Delegate.Remove(mPropertyChanged, value);
				}
			}
		}

		internal static void OnPropertyChanged(string name)
		{
			mPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));
		}

		private static bool GetConfigBool(string name, bool defaultValue = false)
		{
			if (bool.TryParse(GetConfig(name), out var result))
			{
				return result;
			}
			return defaultValue;
		}

		private static T GetConfigEnum<T>(string name)
		{
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsEnum)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Type {0} must be enum", typeFromHandle.FullName));
			}
			string config = GetConfig(name);
			if (string.IsNullOrEmpty(config))
			{
				return default(T);
			}
			return ParseEnum<T>(config);
		}

		private static T ParseEnum<T>(string value)
		{
			if (TryParseEnum<T>(value, out var result))
			{
				return result;
			}
			Type typeFromHandle = typeof(T);
			string format = "Unable to parse value {0} as enum of type {1}. Valid values are: {2}";
			string arg = string.Join(", ", Enum.GetNames(typeFromHandle));
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, format, value, typeFromHandle.FullName, arg));
		}

		private static bool TryParseEnum<T>(string value, out T result)
		{
			result = default(T);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			try
			{
				T val = (T)Enum.Parse(typeof(T), value, ignoreCase: true);
				result = val;
				return true;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		private static DateTime GetUtcNow()
		{
			return DateTime.UtcNow;
		}

		public static string GetConfig(string name)
		{
			return null;
		}

		internal static bool XmlSectionExists(string sectionName)
		{
			return false;
		}

		public static void AddTraceListener(string source, TraceListener listener)
		{
			if (string.IsNullOrEmpty(source))
			{
				throw new ArgumentException("Source cannot be null or empty", "source");
			}
			if (listener == null)
			{
				throw new ArgumentException("Listener cannot be null", "listener");
			}
			lock (_traceListeners)
			{
				if (!_traceListeners.ContainsKey(source))
				{
					_traceListeners.Add(source, new List<TraceListener>());
				}
				_traceListeners[source].Add(listener);
			}
			Logger.ClearLoggerCache();
		}

		public static void RemoveTraceListener(string source, string name)
		{
			if (string.IsNullOrEmpty(source))
			{
				throw new ArgumentException("Source cannot be null or empty", "source");
			}
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name cannot be null or empty", "name");
			}
			lock (_traceListeners)
			{
				if (_traceListeners.ContainsKey(source))
				{
					foreach (TraceListener item in _traceListeners[source])
					{
						if (item.Name.Equals(name, StringComparison.Ordinal))
						{
							_traceListeners[source].Remove(item);
							break;
						}
					}
				}
			}
			Logger.ClearLoggerCache();
		}

		internal static TraceListener[] TraceListeners(string source)
		{
			lock (_traceListeners)
			{
				if (_traceListeners.TryGetValue(source, out var value))
				{
					return value.ToArray();
				}
				return new TraceListener[0];
			}
		}
	}
}
