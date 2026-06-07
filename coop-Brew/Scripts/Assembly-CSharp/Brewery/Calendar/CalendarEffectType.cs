using System;

namespace Brewery.Calendar
{
	[Flags]
	public enum CalendarEffectType
	{
		None = 0,
		TagPriceMult = 1,
		BaseTypePriceMult = 2,
		FactionPriceMult = 4,
		CatalystPriceMult = 8,
		CatalystTradeCostMult = 0x10,
		CatalystDailyLimitMult = 0x20,
		FactionBarAccess = 0x40,
		TradeOfferAvailability = 0x80
	}
}
