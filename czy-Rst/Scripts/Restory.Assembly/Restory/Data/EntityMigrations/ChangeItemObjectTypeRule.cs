using System;

namespace Restory.Data.EntityMigrations
{
	[Serializable]
	public class ChangeItemObjectTypeRule
	{
		public string ItemObjectID;

		public string OldType;

		public string NewType;
	}
}
