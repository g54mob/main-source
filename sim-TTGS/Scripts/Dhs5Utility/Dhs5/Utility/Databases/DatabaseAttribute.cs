using System;

namespace Dhs5.Utility.Databases
{
	public class DatabaseAttribute : DataContainerAttribute
	{
		public readonly string path;

		public bool showInDatabaseWindow = true;

		public DatabaseAttribute(string path)
		{
			this.path = path;
		}

		public DatabaseAttribute(string path, Type dataType)
			: base(dataType)
		{
			this.path = path;
		}
	}
}
