using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_species")]
	public class SidekickSpecies
	{
		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("code")]
		public string Code { get; set; }

		public static List<SidekickSpecies> GetAll(DatabaseManager dbManager, bool excludeSpeciesWithNoParts = true)
		{
			return null;
		}

		public static SidekickSpecies GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static SidekickSpecies GetByName(DatabaseManager dbManager, string name)
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
