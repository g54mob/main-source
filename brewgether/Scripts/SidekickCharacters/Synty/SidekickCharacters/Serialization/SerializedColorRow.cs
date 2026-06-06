using System;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;

namespace Synty.SidekickCharacters.Serialization
{
	[Serializable]
	public class SerializedColorRow
	{
		public int ColorProperty { get; set; }

		public string MainColor { get; set; }

		public string Metallic { get; set; }

		public string Smoothness { get; set; }

		public string Reflection { get; set; }

		public string Emission { get; set; }

		public string Opacity { get; set; }

		public SerializedColorRow()
		{
		}

		public SerializedColorRow(SidekickColorRow row)
		{
		}

		public SidekickColorRow CreateSidekickColorRow(DatabaseManager db, SidekickColorSet set)
		{
			return null;
		}
	}
}
