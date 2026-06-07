using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_filter_row")]
	public class SidekickPartFilterRow
	{
		private SidekickPartFilter _filter;

		private SidekickPart _part;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_filter")]
		public int PtrFilter { get; set; }

		[Column("ptr_part")]
		public int PtrPart { get; set; }

		[Ignore]
		public SidekickPartFilter Filter
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

		public static SidekickPartFilterRow GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartFilterRow> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartFilterRow> GetAllForFilter(DatabaseManager dbManager, SidekickPartFilter filter, bool excludeMissingParts = true)
		{
			return null;
		}

		public static List<string> GetAllPartNamesForFilterSpeciesAndType(DatabaseManager dbManager, SidekickPartFilter filter, SidekickSpecies species, CharacterPartType type)
		{
			return null;
		}

		public static SidekickPartFilterRow GetForFilterAndPart(DatabaseManager dbManager, SidekickPartFilter filter, SidekickPart part)
		{
			return null;
		}

		public static List<SidekickPartFilterRow> GetAllForPart(DatabaseManager dbManager, SidekickPart part)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartFilterRow filterRow)
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
