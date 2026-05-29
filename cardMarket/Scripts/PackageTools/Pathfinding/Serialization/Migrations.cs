using System;

namespace Pathfinding.Serialization
{
	public struct Migrations
	{
		internal int finishedMigrations;

		internal int allMigrations;

		internal bool ignore;

		private const int MIGRATE_TO_BITFIELD = 1073741824;

		public bool IsLegacyFormat => (finishedMigrations & 0x40000000) == 0;

		public int LegacyVersion => finishedMigrations;

		public Migrations(int value)
		{
			finishedMigrations = value;
			allMigrations = 1073741824;
			ignore = false;
		}

		public bool TryMigrateFromLegacyFormat(out int legacyVersion)
		{
			legacyVersion = finishedMigrations;
			if (IsLegacyFormat)
			{
				this = new Migrations(1073741824);
				return true;
			}
			return false;
		}

		public void MarkMigrationFinished(int flag)
		{
			if (IsLegacyFormat)
			{
				throw new InvalidOperationException("Version must first be migrated to the bitfield format");
			}
			finishedMigrations |= flag;
		}

		public bool AddAndMaybeRunMigration(int flag, bool filter = true)
		{
			if ((flag & 0x40000000) != 0)
			{
				throw new ArgumentException("Cannot use the MIGRATE_TO_BITFIELD flag when adding a migration");
			}
			allMigrations |= flag;
			if (filter)
			{
				bool result = (finishedMigrations & flag) != flag;
				MarkMigrationFinished(flag);
				return result;
			}
			return false;
		}

		public void IgnoreMigrationAttempt()
		{
			ignore = true;
		}
	}
}
