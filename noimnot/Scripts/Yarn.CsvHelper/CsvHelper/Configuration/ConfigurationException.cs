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
		{
		}

		public ConfigurationException(string message, Exception innerException)
		{
		}
	}
}
