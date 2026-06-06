namespace Pathfinding.Serialization
{
	public struct Migrations
	{
		internal int finishedMigrations;

		internal int allMigrations;

		internal bool ignore;

		private const int MIGRATE_TO_BITFIELD = 1073741824;

		public bool IsLegacyFormat => false;

		public int LegacyVersion => 0;

		public Migrations(int value)
		{
			finishedMigrations = 0;
			allMigrations = 0;
			ignore = false;
		}

		public bool TryMigrateFromLegacyFormat(out int legacyVersion)
		{
			legacyVersion = default(int);
			return false;
		}

		public void MarkMigrationFinished(int flag)
		{
		}

		public bool AddAndMaybeRunMigration(int flag, bool filter = true)
		{
			return false;
		}

		public void IgnoreMigrationAttempt()
		{
		}
	}
}
