using System;

namespace CsvHelper.Configuration
{
	[Serializable]
	public class ConfigurationException : CsvHelperException
	{
		public ConfigurationException()
		{
		}

		public ConfigurationException(string message)
			: base(message)
		{
		}

		public ConfigurationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
