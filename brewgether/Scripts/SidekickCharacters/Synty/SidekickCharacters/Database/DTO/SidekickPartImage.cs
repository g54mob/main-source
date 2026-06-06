using System.Collections.Generic;
using SQLite;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part_image")]
	public class SidekickPartImage
	{
		private SidekickPart _part;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_part")]
		public int PtrPart { get; set; }

		[Column("img_data")]
		public byte[] ImageData { get; set; }

		[Column("img_width")]
		public int Width { get; set; }

		[Column("img_height")]
		public int Height { get; set; }

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

		public static SidekickPartImage GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static SidekickPartImage GetByPart(DatabaseManager dbManager, SidekickPart part)
		{
			return null;
		}

		public static List<SidekickPartImage> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPartImage partImage)
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
