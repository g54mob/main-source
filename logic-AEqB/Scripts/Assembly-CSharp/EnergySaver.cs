public class EnergySaver : Card
{
	public override void CardSetUp()
	{
		cost = "aaaa";
		card_txt = "Energy Saver\nCost: four of a kind\nEnd of turn: If you have two more dice, roll two extra in the next turn";
		card_txt_cn = "节能器\n费用：四同\n回合结束：如果你有两个或者更多骰子，下回合多两个骰子";
		cardType = CardType.Building;
		special_num = 0;
	}

	public override void EndOfTurn()
	{
		if (gm.preserved_dice.Count + gm.dice.Count >= 2)
		{
			special_num = 2;
		}
	}

	public override void StartOfTurn()
	{
		if (special_num != 0)
		{
			special_num = 0;
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
			Shine();
		}
	}
}
