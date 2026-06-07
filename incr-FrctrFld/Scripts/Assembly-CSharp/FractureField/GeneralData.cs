using System;

namespace FractureField
{
	public class GeneralData
	{
		public string PlayerId { get; set; }

		public string GameId { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime LastSavedDate { get; set; }

		public string AppVersion { get; set; }

		public static GeneralData Save()
		{
			return null;
		}
	}
}
