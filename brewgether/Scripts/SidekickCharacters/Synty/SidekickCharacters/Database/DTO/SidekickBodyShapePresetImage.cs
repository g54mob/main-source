using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_body_shape_preset_image")]
	public class SidekickBodyShapePresetImage
	{
		private SidekickBodyShapePreset _bodyShapePreset;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_body_shape_preset")]
		public int PtrPreset { get; set; }

		[Column("img_data")]
		public byte[] ImageData { get; set; }

		[Column("img_width")]
		public int Width { get; set; }

		[Column("img_height")]
		public int Height { get; set; }

		[Ignore]
		public SidekickBodyShapePreset BodyShapePreset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static SidekickBodyShapePresetImage GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickBodyShapePresetImage> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickBodyShapePresetImage GetByPreset(DatabaseManager dbManager, SidekickBodyShapePreset bodyShapePreset)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickBodyShapePresetImage bodyShapePresetImage)
		{
		}

		public void Save(DatabaseManager dbManager)
		{
		}
	}
}
