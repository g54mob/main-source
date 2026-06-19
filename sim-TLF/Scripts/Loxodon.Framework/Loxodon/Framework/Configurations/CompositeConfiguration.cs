using System;
using System.Collections.Generic;

namespace Loxodon.Framework.Configurations
{
	public class CompositeConfiguration : ConfigurationBase
	{
		private readonly List<IConfiguration> configurations = new List<IConfiguration>();

		private readonly IConfiguration memoryConfiguration;

		public override bool IsEmpty
		{
			get
			{
				for (int i = 0; i < configurations.Count; i++)
				{
					IConfiguration configuration = configurations[i];
					if (configuration != null && !configuration.IsEmpty)
					{
						return false;
					}
				}
				return true;
			}
		}

		public CompositeConfiguration()
			: this(null)
		{
		}

		public CompositeConfiguration(List<IConfiguration> configurations)
		{
			memoryConfiguration = new MemoryConfiguration();
			this.configurations.Add(memoryConfiguration);
			if (configurations == null || configurations.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < configurations.Count; i++)
			{
				IConfiguration configuration = configurations[i];
				if (configuration != null)
				{
					AddConfiguration(configuration);
				}
			}
		}

		public IConfiguration GetFirstConfiguration(string key)
		{
			if (key == null)
			{
				throw new ArgumentException("Key must not be null!");
			}
			for (int i = 0; i < configurations.Count; i++)
			{
				IConfiguration configuration = configurations[i];
				if (configuration != null && configuration.ContainsKey(key))
				{
					return configuration;
				}
			}
			return null;
		}

		public IConfiguration GetConfiguration(int index)
		{
			if (index < 0 || index >= configurations.Count)
			{
				return null;
			}
			return configurations[index];
		}

		public IConfiguration GetMemoryConfiguration()
		{
			return memoryConfiguration;
		}

		public void AddConfiguration(IConfiguration configuration)
		{
			if (!configurations.Contains(configuration))
			{
				configurations.Insert(1, configuration);
			}
		}

		public void RemoveConfiguration(IConfiguration configuration)
		{
			if (!configuration.Equals(memoryConfiguration))
			{
				configurations.Remove(configuration);
			}
		}

		public int GetNumberOfConfigurations()
		{
			return configurations.Count;
		}

		public override bool ContainsKey(string key)
		{
			for (int i = 0; i < configurations.Count; i++)
			{
				IConfiguration configuration = configurations[i];
				if (configuration != null && configuration.ContainsKey(key))
				{
					return true;
				}
			}
			return false;
		}

		public override IEnumerator<string> GetKeys()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < configurations.Count; i++)
			{
				IConfiguration configuration = configurations[i];
				if (configuration == null)
				{
					continue;
				}
				IEnumerator<string> keys = configuration.GetKeys();
				while (keys.MoveNext())
				{
					string current = keys.Current;
					if (!list.Contains(current))
					{
						list.Add(current);
					}
				}
			}
			return list.GetEnumerator();
		}

		public override object GetProperty(string key)
		{
			for (int i = 0; i < configurations.Count; i++)
			{
				IConfiguration configuration = configurations[i];
				if (configuration != null && configuration.ContainsKey(key))
				{
					return configuration.GetProperty(key);
				}
			}
			return null;
		}

		public override void AddProperty(string key, object value)
		{
			memoryConfiguration.AddProperty(key, value);
		}

		public override void SetProperty(string key, object value)
		{
			memoryConfiguration.SetProperty(key, value);
		}

		public override void RemoveProperty(string key)
		{
			memoryConfiguration.RemoveProperty(key);
		}

		public override void Clear()
		{
			memoryConfiguration.Clear();
			for (int num = configurations.Count - 1; num > 0; num--)
			{
				configurations.RemoveAt(num);
			}
		}
	}
}
