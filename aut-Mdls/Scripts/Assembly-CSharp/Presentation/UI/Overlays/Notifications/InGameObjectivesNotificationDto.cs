using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	public struct InGameObjectivesNotificationDto
	{
		public Color Color;

		public int Tier;

		public uint XpAmount;

		public Sprite CurrencyIcon;

		public uint CurrencyAmount;

		private bool _isEmpty;

		public static InGameObjectivesNotificationDto Empty => new InGameObjectivesNotificationDto(isEmpty: true);

		public InGameObjectivesNotificationDto(bool isEmpty)
		{
			_isEmpty = isEmpty;
			Color = Color.white;
			Tier = 1;
			XpAmount = 0u;
			CurrencyIcon = null;
			CurrencyAmount = 0u;
		}

		public InGameObjectivesNotificationDto(Color color, int tier, uint xpAmount)
		{
			_isEmpty = false;
			Color = color;
			Tier = tier;
			XpAmount = xpAmount;
			CurrencyIcon = null;
			CurrencyAmount = 0u;
		}

		public InGameObjectivesNotificationDto(Color color, int tier, uint xpAmount, Sprite currencyIcon, uint currencyAmount)
		{
			_isEmpty = false;
			Color = color;
			Tier = tier;
			XpAmount = xpAmount;
			CurrencyIcon = currencyIcon;
			CurrencyAmount = currencyAmount;
		}
	}
}
