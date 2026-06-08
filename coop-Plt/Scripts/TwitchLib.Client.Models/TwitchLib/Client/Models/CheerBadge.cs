using TwitchLib.Client.Enums;

namespace TwitchLib.Client.Models
{
	public class CheerBadge
	{
		public int CheerAmount { get; }

		public BadgeColor Color { get; }

		public CheerBadge(int cheerAmount)
		{
			CheerAmount = cheerAmount;
			Color = GetColor(cheerAmount);
		}

		private BadgeColor GetColor(int cheerAmount)
		{
			if (cheerAmount >= 10000)
			{
				return BadgeColor.Red;
			}
			if (cheerAmount >= 5000)
			{
				return BadgeColor.Blue;
			}
			if (cheerAmount >= 1000)
			{
				return BadgeColor.Green;
			}
			return (cheerAmount < 100) ? BadgeColor.Gray : BadgeColor.Purple;
		}
	}
}
