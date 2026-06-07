using FractureField.Shared.Enums;

namespace FractureField.Shared.DTOs.Players
{
	public class PlayerCurrencyDto
	{
		public CurrencyType Type { get; set; }

		public long Available { get; set; }

		public long Spent { get; set; }

		public long AllTime { get; set; }
	}
}
