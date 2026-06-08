using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Util.Internal
{
	public class RegionFinder
	{
		internal class EndpointSegment
		{
			public string Value { get; set; }

			public RegionEndpoint RegionEndpoint { get; set; }

			public bool UseThisValue { get; set; }

			public List<EndpointSegment> Children { get; set; }
		}

		private const string DefaultRegion = "us-east-1";

		private const string DefaultGovRegion = "us-gov-west-1";

		private readonly EndpointSegment _root;

		private readonly Logger _logger;

		private readonly Dictionary<string, RegionEndpoint> _regionEndpoints;

		private static readonly RegionFinder _instance = new RegionFinder();

		public static RegionFinder Instance => _instance;

		internal RegionFinder()
		{
			_regionEndpoints = BuildRegionEndpoints();
			_root = BuildRoot();
			_logger = Logger.GetLogger(typeof(RegionFinder));
		}

		public RegionEndpoint FindRegion(string endpoint)
		{
			if (string.IsNullOrEmpty(endpoint))
			{
				return _root.RegionEndpoint;
			}
			endpoint = GetAuthority(endpoint.ToLower());
			EndpointSegment endpointSegment = FindExactRegion(endpoint);
			if (endpointSegment != null && endpointSegment.UseThisValue)
			{
				return endpointSegment.RegionEndpoint;
			}
			_logger.InfoFormat("Unable to find exact matched region in endpoint " + endpoint);
			RegionEndpoint regionEndpoint = FindFuzzyRegion(endpoint);
			if (regionEndpoint != null)
			{
				_logger.InfoFormat(regionEndpoint.SystemName + " fuzzy region found in endpoint " + endpoint);
				return regionEndpoint;
			}
			_logger.InfoFormat("Unable to find fuzzy matched region in endpoint " + endpoint);
			return _root.RegionEndpoint;
		}

		public static string GetAuthority(string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				return null;
			}
			int num = url.IndexOf("://", StringComparison.Ordinal);
			if (num != -1)
			{
				url = url.Substring(num + 3);
			}
			int num2 = url.IndexOf("/", StringComparison.Ordinal);
			if (num2 != -1)
			{
				url = url.Substring(0, num2);
			}
			return url;
		}

		public static RegionEndpoint FindFuzzyRegion(string endpoint)
		{
			foreach (string item in RegionEndpoint.AllPartitionRegionRegex)
			{
				string pattern = item.Trim('^', '$');
				Match match = Regex.Match(endpoint, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.RightToLeft);
				if (match.Success)
				{
					return RegionEndpoint.GetBySystemName(match.Value);
				}
			}
			return null;
		}

		internal EndpointSegment FindExactRegion(string endpoint)
		{
			string[] array = endpoint.Split(new char[1] { '.' });
			return FindExactRegion(array, array.Length - 1, _root);
		}

		private Dictionary<string, RegionEndpoint> BuildRegionEndpoints()
		{
			Dictionary<string, RegionEndpoint> dictionary = new Dictionary<string, RegionEndpoint>();
			foreach (RegionEndpoint enumerableAllRegion in RegionEndpoint.EnumerableAllRegions)
			{
				dictionary[enumerableAllRegion.SystemName] = enumerableAllRegion;
			}
			return dictionary;
		}

		private EndpointSegment BuildRoot()
		{
			return new EndpointSegment
			{
				Children = new List<EndpointSegment>
				{
					new EndpointSegment
					{
						Value = "s3-accelerate",
						RegionEndpoint = null,
						UseThisValue = true
					},
					new EndpointSegment
					{
						Value = "us-gov",
						RegionEndpoint = _regionEndpoints["us-gov-west-1"],
						UseThisValue = true
					}
				},
				RegionEndpoint = _regionEndpoints["us-east-1"]
			};
		}

		private EndpointSegment FindExactRegion(IList<string> segments, int segmentIndex, EndpointSegment currentEndpointSegment)
		{
			if (segmentIndex < 0)
			{
				return null;
			}
			string segment = segments[segmentIndex];
			EndpointSegment endpointSegment = currentEndpointSegment.Children.FirstOrDefault((EndpointSegment endpointSegment2) => endpointSegment2.Value.Equals(segment));
			if (endpointSegment != null)
			{
				currentEndpointSegment = endpointSegment;
			}
			if (currentEndpointSegment.UseThisValue)
			{
				return currentEndpointSegment;
			}
			string text = string.Empty;
			string[] array = segment.Split(new char[1] { '-' });
			for (int num = array.Length - 1; num >= 0; num--)
			{
				text = (string.IsNullOrEmpty(text) ? array[num] : (array[num] + "-" + text));
				if (_regionEndpoints.ContainsKey(text))
				{
					return new EndpointSegment
					{
						RegionEndpoint = _regionEndpoints[text],
						UseThisValue = true
					};
				}
			}
			return FindExactRegion(segments, segmentIndex - 1, currentEndpointSegment);
		}
	}
}
