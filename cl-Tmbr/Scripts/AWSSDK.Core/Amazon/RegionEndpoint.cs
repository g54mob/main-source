using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Amazon
{
	public class RegionEndpoint
	{
		private static Dictionary<string, RegionEndpoint> _hashBySystemName = new Dictionary<string, RegionEndpoint>(StringComparer.OrdinalIgnoreCase);

		private static ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();

		private static HashSet<string> _allPartitionRegionRegex = new HashSet<string>();

		public static readonly RegionEndpoint AFSouth1 = GetRegionEndpoint("af-south-1", "Africa (Cape Town)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APEast1 = GetRegionEndpoint("ap-east-1", "Asia Pacific (Hong Kong)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APNortheast1 = GetRegionEndpoint("ap-northeast-1", "Asia Pacific (Tokyo)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APNortheast2 = GetRegionEndpoint("ap-northeast-2", "Asia Pacific (Seoul)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APNortheast3 = GetRegionEndpoint("ap-northeast-3", "Asia Pacific (Osaka)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSouth1 = GetRegionEndpoint("ap-south-1", "Asia Pacific (Mumbai)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSouth2 = GetRegionEndpoint("ap-south-2", "Asia Pacific (Hyderabad)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast1 = GetRegionEndpoint("ap-southeast-1", "Asia Pacific (Singapore)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast2 = GetRegionEndpoint("ap-southeast-2", "Asia Pacific (Sydney)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast3 = GetRegionEndpoint("ap-southeast-3", "Asia Pacific (Jakarta)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast4 = GetRegionEndpoint("ap-southeast-4", "Asia Pacific (Melbourne)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast5 = GetRegionEndpoint("ap-southeast-5", "Asia Pacific (Malaysia)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint APSoutheast7 = GetRegionEndpoint("ap-southeast-7", "Asia Pacific (Thailand)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint CACentral1 = GetRegionEndpoint("ca-central-1", "Canada (Central)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint CAWest1 = GetRegionEndpoint("ca-west-1", "Canada West (Calgary)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUCentral1 = GetRegionEndpoint("eu-central-1", "Europe (Frankfurt)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUCentral2 = GetRegionEndpoint("eu-central-2", "Europe (Zurich)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUNorth1 = GetRegionEndpoint("eu-north-1", "Europe (Stockholm)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUSouth1 = GetRegionEndpoint("eu-south-1", "Europe (Milan)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUSouth2 = GetRegionEndpoint("eu-south-2", "Europe (Spain)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUWest1 = GetRegionEndpoint("eu-west-1", "Europe (Ireland)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUWest2 = GetRegionEndpoint("eu-west-2", "Europe (London)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUWest3 = GetRegionEndpoint("eu-west-3", "Europe (Paris)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint ILCentral1 = GetRegionEndpoint("il-central-1", "Israel (Tel Aviv)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint MECentral1 = GetRegionEndpoint("me-central-1", "Middle East (UAE)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint MESouth1 = GetRegionEndpoint("me-south-1", "Middle East (Bahrain)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint MXCentral1 = GetRegionEndpoint("mx-central-1", "Mexico (Central)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint SAEast1 = GetRegionEndpoint("sa-east-1", "South America (Sao Paulo)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		private static readonly RegionEndpoint USEast1Regional = GetRegionEndpoint("us-east-1-regional", "US East (Virginia) regional", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USEast1 = GetRegionEndpoint("us-east-1", "US East (N. Virginia)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USEast2 = GetRegionEndpoint("us-east-2", "US East (Ohio)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USWest1 = GetRegionEndpoint("us-west-1", "US West (N. California)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USWest2 = GetRegionEndpoint("us-west-2", "US West (Oregon)", "aws", "amazonaws.com", "^(us|eu|ap|sa|ca|me|af|il|mx)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint CNNorth1 = GetRegionEndpoint("cn-north-1", "China (Beijing)", "aws-cn", "amazonaws.com.cn", "^cn\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint CNNorthWest1 = GetRegionEndpoint("cn-northwest-1", "China (Ningxia)", "aws-cn", "amazonaws.com.cn", "^cn\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USGovCloudEast1 = GetRegionEndpoint("us-gov-east-1", "AWS GovCloud (US-East)", "aws-us-gov", "amazonaws.com", "^us\\-gov\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USGovCloudWest1 = GetRegionEndpoint("us-gov-west-1", "AWS GovCloud (US-West)", "aws-us-gov", "amazonaws.com", "^us\\-gov\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USIsoEast1 = GetRegionEndpoint("us-iso-east-1", "US ISO East", "aws-iso", "c2s.ic.gov", "^us\\-iso\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USIsoWest1 = GetRegionEndpoint("us-iso-west-1", "US ISO WEST", "aws-iso", "c2s.ic.gov", "^us\\-iso\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USIsobEast1 = GetRegionEndpoint("us-isob-east-1", "US ISOB East (Ohio)", "aws-iso-b", "sc2s.sgov.gov", "^us\\-isob\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUIsoeWest1 = GetRegionEndpoint("eu-isoe-west-1", "EU ISOE West", "aws-iso-e", "cloud.adc-e.uk", "^eu\\-isoe\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USIsofEast1 = GetRegionEndpoint("us-isof-east-1", "US ISOF EAST", "aws-iso-f", "csp.hci.ic.gov", "^us\\-isof\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint USIsofSouth1 = GetRegionEndpoint("us-isof-south-1", "US ISOF SOUTH", "aws-iso-f", "csp.hci.ic.gov", "^us\\-isof\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static readonly RegionEndpoint EUSCDeEast1 = GetRegionEndpoint("eusc-de-east-1", "EU (Germany)", "aws-eusc", "amazonaws.eu", "^eusc\\-(de)\\-\\w+\\-\\d+$", "{service}.{region}.{dnsSuffix}");

		public static IEnumerable<RegionEndpoint> EnumerableAllRegions
		{
			get
			{
				try
				{
					_readerWriterLock.EnterReadLock();
					return _hashBySystemName.Values.ToList();
				}
				finally
				{
					_readerWriterLock.ExitReadLock();
				}
			}
		}

		public static IEnumerable<string> AllPartitionRegionRegex
		{
			get
			{
				try
				{
					_readerWriterLock.EnterReadLock();
					return _allPartitionRegionRegex.ToList();
				}
				finally
				{
					_readerWriterLock.ExitReadLock();
				}
			}
		}

		public string SystemName { get; private set; }

		public string DisplayName { get; private set; }

		public string PartitionName { get; private set; }

		public string PartitionDnsSuffix { get; private set; }

		public string PartitionRegionRegex { get; private set; }

		public string HostnameTemplate { get; private set; }

		private static RegionEndpoint GetRegionEndpoint(string systemName, string displayName, string partitionName, string partitionDnsSuffix, string partitionRegionRegex, string hostnameTemplate)
		{
			try
			{
				_readerWriterLock.EnterReadLock();
				if (_hashBySystemName.TryGetValue(systemName, out var value))
				{
					return value;
				}
			}
			finally
			{
				_readerWriterLock.ExitReadLock();
			}
			try
			{
				_readerWriterLock.EnterWriteLock();
				if (_hashBySystemName.TryGetValue(systemName, out var value2))
				{
					return value2;
				}
				value2 = new RegionEndpoint(systemName, displayName, partitionName, partitionDnsSuffix, partitionRegionRegex, hostnameTemplate);
				_hashBySystemName.Add(systemName, value2);
				_allPartitionRegionRegex.Add(partitionRegionRegex);
				return value2;
			}
			finally
			{
				_readerWriterLock.ExitWriteLock();
			}
		}

		public static RegionEndpoint GetBySystemName(string systemName)
		{
			RegionEndpoint regionEndpoint = null;
			string regionDescription = null;
			try
			{
				_readerWriterLock.EnterReadLock();
				if (_hashBySystemName.TryGetValue(systemName, out var value))
				{
					return value;
				}
				regionEndpoint = _hashBySystemName.Values.FirstOrDefault((RegionEndpoint r) => IsRegionInPartition(systemName, r.PartitionName, r.PartitionRegionRegex, out regionDescription));
				if (regionEndpoint == null)
				{
					regionEndpoint = _hashBySystemName.Values.First((RegionEndpoint r) => r.PartitionName == "aws");
				}
			}
			finally
			{
				_readerWriterLock.ExitReadLock();
			}
			return GetRegionEndpoint(systemName, regionDescription ?? GetUnknownRegionDescription(systemName), regionEndpoint.PartitionName, regionEndpoint.PartitionDnsSuffix, regionEndpoint.PartitionRegionRegex, regionEndpoint.HostnameTemplate);
		}

		private static bool IsRegionInPartition(string regionName, string partitionName, string partitionRegionPattern, out string description)
		{
			if (regionName.Equals(partitionName + "-global", StringComparison.OrdinalIgnoreCase))
			{
				description = "Global";
				return true;
			}
			if (new Regex(partitionRegionPattern).Match(regionName).Success)
			{
				description = GetUnknownRegionDescription(regionName);
				return true;
			}
			description = GetUnknownRegionDescription(regionName);
			return false;
		}

		private static string GetUnknownRegionDescription(string regionName)
		{
			if (regionName.StartsWith("cn-", StringComparison.OrdinalIgnoreCase) || regionName.EndsWith("cn-global", StringComparison.OrdinalIgnoreCase))
			{
				return "China (Unknown)";
			}
			return "Unknown";
		}

		private RegionEndpoint(string systemName, string displayName, string partitionName, string partitionDnsSuffix, string partitionRegionRegex, string hostnameTemplate)
		{
			SystemName = systemName;
			DisplayName = displayName;
			PartitionName = partitionName;
			PartitionDnsSuffix = partitionDnsSuffix;
			PartitionRegionRegex = partitionRegionRegex;
			HostnameTemplate = hostnameTemplate;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", DisplayName, SystemName);
		}
	}
}
