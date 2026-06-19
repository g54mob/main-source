using System;
using Loxodon.Framework.Binding.Registry;

namespace Loxodon.Framework.Binding.Converters
{
	public class ConverterRegistry : KeyValueRegistry<string, IConverter>, IConverterRegistry, IKeyValueRegistry<string, IConverter>
	{
		public ConverterRegistry()
		{
			Init();
		}

		protected virtual void Init()
		{
		}

		public override void Unregister(string key)
		{
			if (!lookups.ContainsKey(key))
			{
				return;
			}
			try
			{
				if (lookups[key] is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			catch (Exception)
			{
			}
			lookups.Remove(key);
		}
	}
}
