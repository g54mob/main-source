using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_preset")]
	public class SidekickColorPreset
	{
		private SidekickSpecies _species;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("color_group")]
		public ColorGroup ColorGroup { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

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

		public static List<SidekickColorPreset> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickColorPreset> GetAllBySpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return null;
		}

		public static SidekickColorPreset GetByName(DatabaseManager dbManager, string name)
		{
			return null;
		}

		public static List<SidekickColorPreset> GetAllByColorGroup(DatabaseManager dbManager, ColorGroup colorGroup)
		{
			return null;
		}

		public static List<SidekickColorPreset> GetAllByColorGroupAndSpecies(DatabaseManager dbManager, ColorGroup colorGroup, SidekickSpecies species)
		{
			return null;
		}

		public static SidekickColorPreset GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickColorPreset preset)
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
