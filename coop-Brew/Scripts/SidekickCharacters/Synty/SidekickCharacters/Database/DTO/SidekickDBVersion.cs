using System;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_vdata")]
	public class SidekickDBVersion
	{
		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("semantic_version")]
		public string SemanticVersion { get; set; }

		[Column("update_time")]
		public DateTime LastUpdated { get; set; }

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}
	}
}
