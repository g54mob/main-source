using System;

namespace Restory.Data.SaveLoad.DataMigration
{
	public class MigrateToAttribute : Attribute
	{
		public Type NextType;

		public MigrateToAttribute(Type nextType)
		{
			NextType = nextType;
		}
	}
}
