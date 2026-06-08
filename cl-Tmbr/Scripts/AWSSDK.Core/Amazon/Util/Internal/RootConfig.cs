using System.Collections.Generic;
using System.Xml.Linq;

namespace Amazon.Util.Internal
{
	public class RootConfig
	{
		private const string _rootAwsSectionName = "aws";

		public CSMConfig CSMConfig { get; set; }

		public LoggingConfig Logging { get; private set; }

		public ProxyConfig Proxy { get; private set; }

		public string Region { get; set; }

		public string ProfileName { get; set; }

		public string ProfilesLocation { get; set; }

		public RegionEndpoint RegionEndpoint
		{
			get
			{
				if (string.IsNullOrEmpty(Region))
				{
					return null;
				}
				return RegionEndpoint.GetBySystemName(Region);
			}
			set
			{
				if (value == null)
				{
					Region = null;
				}
				else
				{
					Region = value.SystemName;
				}
			}
		}

		public bool UseSdkCache { get; set; }

		public bool InitializeCollections { get; set; }

		public bool CorrectForClockSkew { get; set; }

		public bool UseAlternateUserAgentHeader { get; set; }

		public string ApplicationName { get; set; }

		public bool? CSMEnabled { get; set; }

		public string CSMClientId { get; set; }

		public int? CSMPort { get; set; }

		public int? StreamingUtf8JsonReaderBufferSize { get; set; }

		private IDictionary<string, XElement> ServiceSections { get; set; }

		public RootConfig()
		{
			CSMConfig = new CSMConfig();
			Logging = new LoggingConfig();
			Proxy = new ProxyConfig();
			Region = AWSConfigs._awsRegion;
			ProfileName = AWSConfigs._awsProfileName;
			ProfilesLocation = AWSConfigs._awsAccountsLocation;
			UseSdkCache = AWSConfigs._useSdkCache;
			InitializeCollections = AWSConfigs._initializeCollections;
			CorrectForClockSkew = true;
		}

		private static string Choose(string a, string b)
		{
			if (!string.IsNullOrEmpty(a))
			{
				return a;
			}
			return b;
		}

		public XElement GetServiceSection(string service)
		{
			if (ServiceSections.TryGetValue(service, out var value))
			{
				return value;
			}
			return null;
		}
	}
}
