using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_preset_filter_row")]
	public class SidekickPresetFilterRow
	{
		private SidekickPresetFilter _filter;

		private SidekickPartPreset _preset;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_filter")]
		public int PtrFilter { get; set; }

		[Column("ptr_preset")]
		public int PtrPreset { get; set; }

		[Ignore]
		public SidekickPresetFilter Filter
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
		public SidekickPartPreset Preset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static SidekickPresetFilterRow GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPresetFilterRow> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPresetFilterRow> GetAllForFilter(DatabaseManager dbManager, SidekickPresetFilter filter, bool excludeMissingParts = true)
		{
			return null;
		}

		public static SidekickPresetFilterRow GetForFilterAndPreset(DatabaseManager dbManager, SidekickPresetFilter filter, SidekickPartPreset preset)
		{
			return null;
		}

		public static List<SidekickPresetFilterRow> GetAllForPreset(DatabaseManager dbManager, SidekickPartPreset preset)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPresetFilterRow filterRow)
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
