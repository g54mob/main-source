using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_filter")]
	public class SidekickPartFilter
	{
		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("filter_type")]
		public FilterType Type { get; set; }

		[Column("filter_term")]
		public string Term { get; set; }

		public static SidekickPartFilter GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartFilter> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartFilter> GetAllForFilterType(DatabaseManager dbManager, FilterType filterType, bool excludeFiltersWithNoParts = true)
		{
			return null;
		}

		public static SidekickPartFilter GetByTermAndFilterType(DatabaseManager dbManager, string filterTerm, FilterType filterType)
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
	}
}
