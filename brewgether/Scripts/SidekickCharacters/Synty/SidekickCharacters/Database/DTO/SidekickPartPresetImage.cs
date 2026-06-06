using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_preset_image")]
	public class SidekickPartPresetImage
	{
		private SidekickPartPreset _partPreset;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_part_preset")]
		public int PtrPreset { get; set; }

		[Column("part_group")]
		public PartGroup PartGroup { get; set; }

		[Column("img_data")]
		public byte[] ImageData { get; set; }

		[Column("img_width")]
		public int Width { get; set; }

		[Column("img_height")]
		public int Height { get; set; }

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

		public static SidekickPartPresetImage GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPartPresetImage> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPartPresetImage> GetAllByPreset(DatabaseManager dbManager, SidekickPartPreset partPreset)
		{
			return null;
		}

		public static SidekickPartPresetImage GetByPresetAndPartGroup(DatabaseManager dbManager, SidekickPartPreset partPreset, PartGroup partGroup)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartPresetImage partPresetImage)
		{
		}

		public void Save(DatabaseManager dbManager)
		{
		}

		public void Delete(DatabaseManager dbManager)
		{
		}
	}
}
