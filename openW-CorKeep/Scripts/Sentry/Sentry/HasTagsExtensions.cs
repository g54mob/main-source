using System.Collections.Generic;
using System.ComponentModel;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class HasTagsExtensions
	{
		public static void SetTags(this IHasTags hasTags, IEnumerable<KeyValuePair<string, string>> tags)
		{
			foreach (var (key, value) in tags)
			{
				hasTags.SetTag(key, value);
			}
		}
	}
}
