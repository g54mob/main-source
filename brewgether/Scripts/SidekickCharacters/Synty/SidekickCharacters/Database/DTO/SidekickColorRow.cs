using System.Collections.Generic;
using SQLite;
using UnityEngine;
using UnityEngine.UIElements;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_row")]
	public class SidekickColorRow
	{
		private SidekickColorSet _colorSet;

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

		[Column("ptr_color_set")]
		public int PtrColorSet { get; set; }

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
		public SidekickColorSet ColorSet
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

		[Ignore]
		public bool IsLocked { get; set; }

		[Ignore]
		public Image ButtonImage { get; set; }

		public static List<SidekickColorRow> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickColorRow GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickColorRow> GetAllByProperty(DatabaseManager dbManager, SidekickColorProperty property)
		{
			return null;
		}

		public static List<SidekickColorRow> GetAllBySetAndProperty(DatabaseManager dbManager, SidekickColorSet set, SidekickColorProperty property)
		{
			return null;
		}

		public static List<SidekickColorRow> GetAllBySet(DatabaseManager dbManager, SidekickColorSet set)
		{
			return null;
		}

		public static SidekickColorRow CreateFromPresetColorRow(SidekickColorPresetRow row)
		{
			return null;
		}

		private static void Decorate(DatabaseManager dbManager, SidekickColorRow row)
		{
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public void Save(DatabaseManager dbManager)
		{
		}

		private void SaveToDB(DatabaseManager dbManager)
		{
		}

		private void UpdateDB(DatabaseManager dbManager)
		{
		}
	}
}
