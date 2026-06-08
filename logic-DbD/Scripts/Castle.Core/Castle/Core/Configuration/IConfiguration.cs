using System;

namespace Castle.Core.Configuration
{
	public interface IConfiguration
	{
		string Name { get; }

		string Value { get; }

		ConfigurationCollection Children { get; }

		ConfigurationAttributeCollection Attributes { get; }

		object GetValue(Type type, object defaultValue);
	}
}
