using System.Collections.Generic;
using System.ComponentModel;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class HasExtraExtensions
	{
		public static void SetExtras(this IHasExtra hasExtra, IEnumerable<KeyValuePair<string, object?>> values)
		{
			foreach (var (key, value) in values)
			{
				hasExtra.SetExtra(key, value);
			}
		}
	}
}
