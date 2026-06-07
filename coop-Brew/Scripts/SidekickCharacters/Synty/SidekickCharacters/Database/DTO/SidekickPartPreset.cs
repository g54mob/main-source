using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_preset")]
	public class SidekickPartPreset
	{
		private SidekickSpecies _species;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("part_group")]
		public PartGroup PartGroup { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

		[Column("outfit")]
		public string Outfit { get; set; }

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

		public static SidekickPartPreset GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartPreset> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartPreset> GetAllBySpecies(DatabaseManager dbManager, SidekickSpecies species)
		{
			return null;
		}

		public static SidekickPartPreset GetByName(DatabaseManager dbManager, string name)
		{
			return null;
		}

		public static List<SidekickPartPreset> GetAllByGroup(DatabaseManager dbManager, PartGroup partGroup, bool excludeMissingParts = true)
		{
			return null;
		}

		public static List<SidekickPartPreset> GetAllBySpeciesAndGroup(DatabaseManager dbManager, SidekickSpecies species, PartGroup partGroup)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartPreset partPreset)
		{
		}

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public bool HasAllPartsAvailable(DatabaseManager dbManager)
		{
			return false;
		}

		public bool HasOnlyBasePartsAndAllAvailable(DatabaseManager dbManager)
		{
			return false;
		}

		protected bool Equals(SidekickPartPreset other)
		{
			return false;
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
