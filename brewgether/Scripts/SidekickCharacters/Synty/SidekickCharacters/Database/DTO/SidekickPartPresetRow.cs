using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_preset_row")]
	public class SidekickPartPresetRow
	{
		private SidekickPartPreset _partPreset;

		private SidekickPart _part;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("part_name")]
		public string PartName { get; set; }

		[Column("ptr_part_preset")]
		public int PtrPreset { get; set; }

		[Column("ptr_part")]
		public int PtrPart { get; set; }

		[Column("part_type")]
		public string PartType { get; set; }

		[Ignore]
		public SidekickPartPreset PartPreset
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

		public static SidekickPartPresetRow GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartPresetRow> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartPresetRow> GetAllByPreset(DatabaseManager dbManager, SidekickPartPreset partPreset)
		{
			return null;
		}

		public static List<SidekickPartPresetRow> GetAllByPart(DatabaseManager dbManager, SidekickPart part)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartPresetRow partPreset)
		{
		}

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public bool HasValidPart()
		{
			return false;
		}
	}
}
