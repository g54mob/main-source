using System.Collections.Generic;
using SQLite;
using UnityEngine;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_preset_row")]
	public class SidekickColorPresetRow
	{
		private SidekickColorPreset _colorPreset;

		private SidekickColorProperty _colorProperty;

		private Color? _niceColor;

		private Color? _niceMetallic;

		private Color? _niceSmoothness;

		private Color? _niceReflection;

		private Color? _niceEmission;

		private Color? _niceOpacity;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_color_preset")]
		public int PtrColorPreset { get; set; }

		[Column("ptr_color_property")]
		public int PtrColorProperty { get; set; }

		[Column("color")]
		public string MainColor { get; set; }

		[Column("metallic")]
		public string Metallic { get; set; }

		[Column("smoothness")]
		public string Smoothness { get; set; }

		[Column("reflection")]
		public string Reflection { get; set; }

		[Column("emission")]
		public string Emission { get; set; }

		[Column("opacity")]
		public string Opacity { get; set; }

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

		[Ignore]
		public SidekickColorProperty ColorProperty
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
		public Color NiceColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Ignore]
		public Color NiceMetallic
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Ignore]
		public Color NiceSmoothness
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Ignore]
		public Color NiceReflection
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Ignore]
		public Color NiceEmission
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		[Ignore]
		public Color NiceOpacity
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public static List<SidekickColorPresetRow> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickColorPresetRow GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickColorPresetRow> GetAllByProperty(DatabaseManager dbManager, SidekickColorProperty property)
		{
			return null;
		}

		public static List<SidekickColorPresetRow> GetAllByPresetAndProperty(DatabaseManager dbManager, SidekickColorPreset preset, SidekickColorProperty property)
		{
			return null;
		}

		public static List<SidekickColorPresetRow> GetAllByPreset(DatabaseManager dbManager, SidekickColorPreset preset)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickColorPresetRow row)
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
