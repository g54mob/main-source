using System;

namespace Assets.Scripts.Craft.CraftFiles.Exceptions
{
	public class CraftDatabaseException : Exception
	{
		public CraftDatabaseException()
		{
		}

		public CraftDatabaseException(string message)
			: base(message)
		{
		}

		public CraftDatabaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
