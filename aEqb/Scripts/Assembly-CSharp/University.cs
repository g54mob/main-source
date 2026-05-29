public class University : Card
{
	public override void CardSetUp()
	{
		cost = "xy";
		card_txt = "Mars University\nCost: two wild\nWhen you draw a card, roll an extra die at the start of next round.";
		card_txt_cn = "火星大学\n费用：两个百搭\n每当你抽一张牌，在下回合开始时多投一个骰子";
		cardType = CardType.Building;
		gm.ability.Add("University");
	}

	public override bool SpecialCost()
	{
		foreach (Dice item in gm.selected_dice)
		{
			if (item.diceType != DiceType.Wild)
			{
				return false;
			}
		}
		return true;
	}

	public override void StartOfTurn()
	{
		for (int i = 0; i < special_num; i++)
		{
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
		}
		if (special_num > 0)
		{
			Shine();
		}
		special_num = 0;
	}
}
