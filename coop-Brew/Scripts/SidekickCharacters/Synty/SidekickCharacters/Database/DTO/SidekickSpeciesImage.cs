using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_species_image")]
	public class SidekickSpeciesImage
	{
		private SidekickSpecies _species;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

		[Column("img_data")]
		public byte[] ImageData { get; set; }

		[Column("img_width")]
		public int Width { get; set; }

		[Column("img_height")]
		public int Height { get; set; }

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

		public static SidekickSpeciesImage GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickSpeciesImage> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickSpeciesImage GetBySpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickSpeciesImage bodyShapePresetImage)
		{
		}

		public void Save(DatabaseManager dbManager)
		{
		}
	}
}
