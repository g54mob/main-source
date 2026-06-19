using System.Collections.Generic;

namespace Sentry
{
	public interface IHasExtra
	{
		IReadOnlyDictionary<string, object?> Extra { get; }

		void SetExtra(string key, object? value);
	}
}
