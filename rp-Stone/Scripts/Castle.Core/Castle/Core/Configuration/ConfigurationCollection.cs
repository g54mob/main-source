using System;
using System.Collections.Generic;

namespace Castle.Core.Configuration
{
	[Serializable]
	public class ConfigurationCollection : List<IConfiguration>
	{
		public IConfiguration this[string name]
		{
			get
			{
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						IConfiguration current = enumerator.Current;
						if (name.Equals(current.Name))
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		public ConfigurationCollection()
		{
		}

		public ConfigurationCollection(IEnumerable<IConfiguration> value)
			: base(value)
		{
		}
	}
}
