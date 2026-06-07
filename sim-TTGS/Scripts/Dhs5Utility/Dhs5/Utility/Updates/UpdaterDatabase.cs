using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Updates
{
	[Database("Update/Updater", typeof(UpdaterDatabaseElement))]
	public class UpdaterDatabase : EnumDatabase
	{
	}
}
