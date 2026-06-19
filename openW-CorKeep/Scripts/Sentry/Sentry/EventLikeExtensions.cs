using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class EventLikeExtensions
	{
		public static void AddBreadcrumb(this IEventLike eventLike, string message, string? category, string? type, (string, string)? dataPair = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			Dictionary<string, string> data = null;
			if (dataPair.HasValue)
			{
				data = new Dictionary<string, string> { 
				{
					dataPair.Value.Item1,
					dataPair.Value.Item2
				} };
			}
			eventLike.AddBreadcrumb(null, message, category, type, data, level);
		}

		public static void AddBreadcrumb(this IEventLike eventLike, string message, string? category = null, string? type = null, IReadOnlyDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			eventLike.AddBreadcrumb(null, message, category, type, data, level);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void AddBreadcrumb(this IEventLike eventLike, DateTimeOffset? timestamp, string message, string? category = null, string? type = null, IReadOnlyDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			eventLike.AddBreadcrumb(new Breadcrumb(timestamp, message, type, data, category, level));
		}

		public static bool HasUser(this IEventLike eventLike)
		{
			return eventLike.User.HasAnyData();
		}

		public static void SetFingerprint(this IEventLike eventLike, IEnumerable<string> fingerprint)
		{
			eventLike.Fingerprint = (fingerprint as IReadOnlyList<string>) ?? fingerprint.ToArray();
		}

		public static void SetFingerprint(this IEventLike eventLike, params string[] fingerprint)
		{
			eventLike.Fingerprint = fingerprint;
		}
	}
}
