public class Tourist : Card
{
	public override void CardSetUp()
	{
		cost = "123";
		card_txt = "Tourist Attraction\nCost: 1, 2, 3\nStart of turn: Roll one extra dice per project built";
		card_txt_cn = "旅游景点\n费用：1, 2, 3\n回合开始：每有一个完成的计划，投一个骰子";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		if (gm.project.Count < 3)
		{
			Shine();
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
			if (gm.project.Count <= 1)
			{
				gm.GenerateDice(0, DiceType.Basic, preserve: false);
			}
		}
	}
}
