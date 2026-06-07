using System;
using System.Collections.Generic;
using FractureField.Shared.DTOs.Players;

namespace FractureField.Shared.DTOs
{
	public class PlayerDto
	{
		public int PlayerId { get; set; }

		public string Username { get; set; }

		public string Avatar { get; set; }

		public string AvatarFrame { get; set; }

		public string Platform { get; set; }

		public string Country { get; set; }

		public string Language { get; set; }

		public string AppVersion { get; set; }

		public string Status { get; set; }

		public DateTime LastActivity { get; set; }

		public DateTime CreatedDate { get; set; }

		public List<PlayerCurrencyDto> Currencies { get; set; }
	}
}
