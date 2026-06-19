using System.Collections.Generic;
using System.Linq;

namespace Sentry
{
	public class DefaultSentryScopeStateProcessor : ISentryScopeStateProcessor
	{
		private static readonly char[] TrimFilter = new char[2] { '{', '}' };

		public void Apply(Scope scope, object state)
		{
			if (!(state is string value))
			{
				if (!(state is IEnumerable<KeyValuePair<string, string>> source))
				{
					if (!(state is IEnumerable<KeyValuePair<string, object>> source2))
					{
						if (state is (string, string) tuple)
						{
							if (!string.IsNullOrEmpty(tuple.Item2))
							{
								scope.SetTag(tuple.Item1, tuple.Item2);
							}
						}
						else
						{
							scope.SetExtra("state", state);
						}
					}
					else
					{
						scope.SetTags(from k in source2
							where !string.IsNullOrEmpty(k.Value as string)
							select new KeyValuePair<string, string>(k.Key.Trim(TrimFilter), k.Value.ToString()));
					}
				}
				else
				{
					scope.SetTags(source.Where((KeyValuePair<string, string> kv) => !string.IsNullOrEmpty(kv.Value)));
				}
			}
			else
			{
				scope.SetTag("scope", value);
			}
		}
	}
}
