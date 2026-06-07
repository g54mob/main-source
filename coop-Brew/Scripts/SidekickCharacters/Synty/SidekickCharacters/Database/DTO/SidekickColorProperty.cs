using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;
using UnityEngine;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_color_property")]
	public class SidekickColorProperty
	{
		[PrimaryKey]
		[Column("id")]
		public int ID { get; set; }

		[Column("color_group")]
		public ColorGroup Group { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("u")]
		public int U { get; set; }

		[Column("v")]
		public int V { get; set; }

		public static List<SidekickColorProperty> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickColorProperty> GetAllByGroup(DatabaseManager dbManager, ColorGroup group)
		{
			return null;
		}

		public static SidekickColorProperty GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickColorProperty> GetByUVs(DatabaseManager dbManager, List<Vector2> uVs)
		{
			return null;
		}
	}
}
