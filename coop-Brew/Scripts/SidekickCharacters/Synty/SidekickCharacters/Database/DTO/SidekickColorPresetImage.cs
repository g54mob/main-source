using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_preset_image")]
	public class SidekickColorPresetImage
	{
		private SidekickColorPreset _colorPreset;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_color_preset")]
		public int PtrPreset { get; set; }

		[Column("color_group")]
		public ColorGroup ColorGroup { get; set; }

		[Column("img_data")]
		public byte[] ImageData { get; set; }

		[Column("img_width")]
		public int Width { get; set; }

		[Column("img_height")]
		public int Height { get; set; }

		[Ignore]
		public SidekickColorPreset ColorPreset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static SidekickColorPresetImage GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickColorPresetImage> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickColorPresetImage> GetAllByPreset(DatabaseManager dbManager, SidekickPartPreset partPreset)
		{
			return null;
		}

		public static SidekickColorPresetImage GetByPresetAndColorGroup(DatabaseManager dbManager, SidekickColorPreset partPreset, ColorGroup partGroup)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickColorPresetImage partPresetImage)
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
