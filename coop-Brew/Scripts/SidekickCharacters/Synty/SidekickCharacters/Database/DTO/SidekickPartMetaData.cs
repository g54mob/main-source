using System;
using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_pmdata")]
	public class SidekickPartMetaData
	{
		[PrimaryKey]
		[Column("id")]
		public int ID { get; set; }

		[Column("part_guid")]
		public string PartGuid { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("value")]
		public string Value { get; set; }

		[Column("type")]
		public string Type { get; set; }

		[Column("value_type")]
		public string ValueType { get; set; }

		[Column("last_updated")]
		public DateTime LastUpdated { get; set; }

		public static List<string> GetPartGuidsByMetaDataValue(DatabaseManager dbManager, string type, string value)
		{
			return null;
		}
	}
}
