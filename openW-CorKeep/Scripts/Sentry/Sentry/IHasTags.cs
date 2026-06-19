using System.Collections.Generic;

namespace Sentry
{
	public interface IHasTags
	{
		IReadOnlyDictionary<string, string> Tags { get; }

		void SetTag(string key, string value);

		void UnsetTag(string key);
	}
}
