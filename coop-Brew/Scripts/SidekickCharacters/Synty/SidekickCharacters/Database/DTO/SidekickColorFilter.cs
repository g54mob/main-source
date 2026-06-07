using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_filter")]
	public class SidekickColorFilter
	{
		[PrimaryKey]
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("display_name")]
		public string DisplayName { get; set; }

		public static List<SidekickColorFilter> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickColorFilter GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}
	}
}
