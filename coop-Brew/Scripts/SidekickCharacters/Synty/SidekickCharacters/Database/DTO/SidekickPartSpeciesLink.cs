using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_species_link")]
	public class SidekickPartSpeciesLink
	{
		private SidekickSpecies _species;

		private SidekickPart _part;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

		[Column("ptr_part")]
		public int PtrPart { get; set; }

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

		[Ignore]
		public SidekickPart Part
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static SidekickPartSpeciesLink GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartSpeciesLink> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartSpeciesLink> GetAllForSpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return null;
		}

		public static List<SidekickPartSpeciesLink> GetAllForPart(DatabaseManager dbManager, SidekickPart part)
		{
			return null;
		}

		public static SidekickPartSpeciesLink GetForSpeciesAndPart(DatabaseManager dbManager, SidekickSpecies species, SidekickPart part)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartSpeciesLink partSpeciesLink)
		{
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
