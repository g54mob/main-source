using System;

namespace Castle.Core.Configuration
{
	[Serializable]
	public class MutableConfiguration : AbstractConfiguration
	{
		public new string Value
		{
			get
			{
				return base.Value;
			}
			set
			{
				base.Value = value;
			}
		}

		public MutableConfiguration(string name)
			: this(name, null)
		{
		}

		public MutableConfiguration(string name, string value)
		{
			base.Name = name;
			Value = value;
		}

		public static MutableConfiguration Create(string name)
		{
			return new MutableConfiguration(name);
		}

		public MutableConfiguration Attribute(string name, string value)
		{
			Attributes[name] = value;
			return this;
		}

		public MutableConfiguration CreateChild(string name)
		{
			MutableConfiguration mutableConfiguration = new MutableConfiguration(name);
			Children.Add(mutableConfiguration);
			return mutableConfiguration;
		}

		public MutableConfiguration CreateChild(string name, string value)
		{
			MutableConfiguration mutableConfiguration = new MutableConfiguration(name, value);
			Children.Add(mutableConfiguration);
			return mutableConfiguration;
		}
	}
}
