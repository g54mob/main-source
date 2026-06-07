using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_set")]
	public class SidekickColorSet
	{
		private SidekickSpecies _species;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("src_color")]
		public string SourceColorPath { get; set; }

		[Column("src_metallic")]
		public string SourceMetallicPath { get; set; }

		[Column("src_smoothness")]
		public string SourceSmoothnessPath { get; set; }

		[Column("src_reflection")]
		public string SourceReflectionPath { get; set; }

		[Column("src_emission")]
		public string SourceEmissionPath { get; set; }

		[Column("src_opacity")]
		public string SourceOpacityPath { get; set; }

		[Ignore]
		public SidekickSpecies Species
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static List<SidekickColorSet> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickColorSet> GetAllBySpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return null;
		}

		public static SidekickColorSet GetDefault(DatabaseManager dbManager)
		{
			return null;
		}

		public static int GetCountBySpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return 0;
		}

		public static SidekickColorSet GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static SidekickColorSet GetByName(DatabaseManager dbManager, string name)
		{
			return null;
		}

		public static bool DoesNameExist(DatabaseManager dbManager, string name)
		{
			return false;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickColorSet set)
		{
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public void Save(DatabaseManager dbManager)
		{
		}

		private void SaveToDB(DatabaseManager dbManager)
		{
		}

		private void UpdateDB(DatabaseManager dbManager)
		{
		}
	}
}
