using System;

namespace Restory.Data.EntityMigrations
{
	[Serializable]
	public class RenameRule
	{
		public string OldID;

		public string NewID;
	}
}
