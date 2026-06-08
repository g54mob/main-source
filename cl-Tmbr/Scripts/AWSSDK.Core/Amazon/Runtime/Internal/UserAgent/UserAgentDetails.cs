using System.Collections.Generic;
using System.Text;

namespace Amazon.Runtime.Internal.UserAgent
{
	public class UserAgentDetails
	{
		private const int MaxSizeBytes = 1024;

		private readonly HashSet<string> _trackedFeatureIds = new HashSet<string>();

		private readonly StringBuilder _userAgentBuilder = new StringBuilder();

		public IEnumerable<string> TrackedFeatureIds => _trackedFeatureIds;

		public void AddUserAgentComponent(string component)
		{
			if (!string.IsNullOrEmpty(component))
			{
				_userAgentBuilder.Append(' ').Append(component);
			}
		}

		public void AddFeature(UserAgentFeatureId featureId)
		{
			if (!(featureId == null))
			{
				_trackedFeatureIds.Add(featureId.Value);
			}
		}

		public string GetCustomUserAgentComponents()
		{
			return _userAgentBuilder.ToString().Trim();
		}

		public string GenerateUserAgentWithMetrics()
		{
			string text = GenerateMetricsUserAgent();
			if (!string.IsNullOrEmpty(text))
			{
				return _userAgentBuilder.ToString().Trim() + " " + text;
			}
			return _userAgentBuilder.ToString().Trim();
		}

		private string GenerateMetricsUserAgent()
		{
			if (_trackedFeatureIds.Count == 0)
			{
				return string.Empty;
			}
			return TruncateToSize("m/" + string.Join(",", _trackedFeatureIds));
		}

		private static string TruncateToSize(string input)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			if (bytes.Length <= 1024)
			{
				return input;
			}
			int num = 1024;
			while (num > 0 && bytes[num - 1] != 44)
			{
				num--;
			}
			return Encoding.UTF8.GetString(bytes, 0, num - 1);
		}
	}
}
