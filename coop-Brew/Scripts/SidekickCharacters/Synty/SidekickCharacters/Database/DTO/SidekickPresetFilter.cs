using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_preset_filter")]
	public class SidekickPresetFilter
	{
		private List<SidekickPartPreset> _allPresets;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("filter_term")]
		public string Term { get; set; }

		public static SidekickPresetFilter GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPresetFilter> GetAll(DatabaseManager dbManager, bool excludeFiltersWithNoParts = true)
		{
			return null;
		}

		public static SidekickPresetFilter GetByTerm(DatabaseManager dbManager, string filterTerm)
		{
			return null;
		}

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public List<SidekickPartPreset> GetAllPresetsForFilter(DatabaseManager dbManager, bool excludeMissingParts = true, bool refreshList = false)
		{
			return null;
		}

		protected bool Equals(SidekickPresetFilter other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
