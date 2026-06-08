using System.Collections.Generic;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class ConfigHashSet : Dictionary<ATNConfig, ATNConfig>
	{
		public ConfigHashSet(IEqualityComparer<ATNConfig> comparer)
			: base(comparer)
		{
		}

		public ConfigHashSet()
			: base((IEqualityComparer<ATNConfig>)new ConfigEqualityComparator())
		{
		}

		public ATNConfig GetOrAdd(ATNConfig config)
		{
			if (TryGetValue(config, out var value))
			{
				return value;
			}
			this.Put(config, config);
			return config;
		}
	}
}
