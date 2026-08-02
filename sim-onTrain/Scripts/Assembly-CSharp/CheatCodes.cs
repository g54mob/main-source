using System.Collections.Generic;

public static class CheatCodes
{
	public static List<CheatCode> cheatCodes = new List<CheatCode>
	{
		new CheatCode
		{
			Type = CheatCodeType.CreativeMode,
			Code = "CreativeMode"
		},
		new CheatCode
		{
			Type = CheatCodeType.SurvivalMode,
			Code = "SurvivalMode"
		},
		new CheatCode
		{
			Type = CheatCodeType.HardcoreMode,
			Code = "HardcoreMode"
		},
		new CheatCode
		{
			Type = CheatCodeType.GiveItem,
			Code = "giveitem"
		},
		new CheatCode
		{
			Type = CheatCodeType.HealPlayer,
			Code = "healme"
		},
		new CheatCode
		{
			Type = CheatCodeType.FeedMe,
			Code = "feedme"
		},
		new CheatCode
		{
			Type = CheatCodeType.WaterMe,
			Code = "waterme"
		},
		new CheatCode
		{
			Type = CheatCodeType.SetTime,
			Code = "settime"
		},
		new CheatCode
		{
			Type = CheatCodeType.SkipNextTutorial,
			Code = "SkipNextTutorial"
		}
	};
}
