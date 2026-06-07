using System;
using Dhs5.Utility.Settings;

namespace Dhs5.Utility.Databases
{
	public abstract class DatabaseSettings : CustomSettings<DatabaseSettings>
	{
		public static bool TryGetDatabase(Type type, out BaseDataContainer db)
		{
			if (CustomSettings<DatabaseSettings>.I != null)
			{
				db = CustomSettings<DatabaseSettings>.I.GetDatabase(type);
				return db != null;
			}
			db = null;
			return false;
		}

		protected abstract BaseDataContainer GetDatabase(Type type);
	}
}
