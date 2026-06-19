using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sentry.Internal.Http
{
	internal class RateLimit
	{
		public IReadOnlyList<RateLimitCategory> Categories { get; }

		public IReadOnlyList<string>? Namespaces { get; }

		internal bool IsDefaultNamespace
		{
			get
			{
				if (Namespaces != null)
				{
					if (Namespaces.Count == 1)
					{
						return string.Equals(Namespaces[0], "custom", StringComparison.OrdinalIgnoreCase);
					}
					return false;
				}
				return true;
			}
		}

		public TimeSpan RetryAfter { get; }

		public RateLimit(TimeSpan retryAfter, IReadOnlyList<RateLimitCategory> categories, IReadOnlyList<string>? namespaces = null)
		{
			RetryAfter = retryAfter;
			Categories = categories;
			Namespaces = namespaces;
		}

		public static RateLimit Parse(string rateLimitEncoded)
		{
			string[] array = rateLimitEncoded.Split(new char[1] { ':' });
			TimeSpan retryAfter = TimeSpan.FromSeconds(int.Parse(array[0], CultureInfo.InvariantCulture));
			RateLimitCategory[] array2 = (from c in array[1].Split(new char[1] { ';' })
				select new RateLimitCategory(c)).ToArray();
			string[] namespaces = null;
			RateLimitCategory[] array3 = array2;
			for (int num = 0; num < array3.Length; num++)
			{
				if (string.Equals(array3[num].Name, "metric_bucket", StringComparison.OrdinalIgnoreCase))
				{
					namespaces = ((array.Length > 4) ? array[4].Split(new char[1] { ';' }) : null);
					break;
				}
			}
			return new RateLimit(retryAfter, array2, namespaces);
		}

		public static IEnumerable<RateLimit> ParseMany(string rateLimitsEncoded)
		{
			return rateLimitsEncoded.Split(new char[1] { ',' }).Select(Parse);
		}
	}
}
