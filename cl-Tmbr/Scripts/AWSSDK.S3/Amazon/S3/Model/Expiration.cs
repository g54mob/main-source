using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model
{
	public class Expiration
	{
		private DateTime expiryDate;

		private string ruleId;

		private const string ExpiryRegexPattern = "expiry-date=\"(.+?)\"";

		private const string RuleRegexPattern = "rule-id=\"(.+?)\"";

		private static readonly Regex _expiryRegex = new Regex("expiry-date=\"(.+?)\"");

		private static readonly Regex _ruleRegex = new Regex("rule-id=\"(.+?)\"");

		public DateTime ExpiryDate
		{
			get
			{
				return expiryDate;
			}
			set
			{
				expiryDate = value;
			}
		}

		public string RuleId
		{
			get
			{
				return ruleId;
			}
			set
			{
				ruleId = value;
			}
		}

		public Expiration()
		{
			expiryDate = DateTime.MinValue;
			ruleId = string.Empty;
		}

		private static Regex ExpiryRegex()
		{
			return _expiryRegex;
		}

		private static Regex RuleRegex()
		{
			return _ruleRegex;
		}

		internal Expiration(string headerValue)
		{
			if (string.IsNullOrEmpty(headerValue))
			{
				throw new ArgumentNullException("headerValue");
			}
			if (headerValue.Equals("NotImplemented", StringComparison.OrdinalIgnoreCase))
			{
				return;
			}
			Match match = ExpiryRegex().Match(headerValue);
			if (match.Success && match.Groups[1].Success)
			{
				string value = match.Groups[1].Value;
				try
				{
					expiryDate = DateTime.ParseExact(value, "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
				}
				catch (FormatException)
				{
					Logger.GetLogger(typeof(Expiration)).DebugFormat("Unable to parse expiry-date from: {0}", headerValue);
				}
			}
			Match match2 = RuleRegex().Match(headerValue);
			if (match2.Success && match2.Groups[1].Success)
			{
				string value2 = match2.Groups[1].Value;
				ruleId = UrlDecode(value2);
			}
		}

		private static string UrlDecode(string url)
		{
			return Uri.UnescapeDataString(url).Replace("+", " ");
		}
	}
}
