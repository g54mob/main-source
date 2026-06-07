using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_body_shape_preset")]
	public class SidekickBodyShapePreset
	{
		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("body_type")]
		public int BodyType { get; set; }

		[Column("body_size")]
		public int BodySize { get; set; }

		[Column("musculature")]
		public int Musculature { get; set; }

		public static List<SidekickBodyShapePreset> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickBodyShapePreset GetByID(DatabaseManager dbManager, int id)
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
