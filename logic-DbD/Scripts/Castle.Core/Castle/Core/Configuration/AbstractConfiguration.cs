using System;
using System.Globalization;

namespace Castle.Core.Configuration
{
	public abstract class AbstractConfiguration : IConfiguration
	{
		private readonly ConfigurationAttributeCollection attributes = new ConfigurationAttributeCollection();

		private readonly ConfigurationCollection children = new ConfigurationCollection();

		public virtual ConfigurationAttributeCollection Attributes => attributes;

		public virtual ConfigurationCollection Children => children;

		public string Name { get; protected set; }

		public string Value { get; protected set; }

		public virtual object GetValue(Type type, object defaultValue)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			try
			{
				return Convert.ChangeType(Value, type, CultureInfo.CurrentCulture);
			}
			catch (InvalidCastException)
			{
				return defaultValue;
			}
		}
	}
}
