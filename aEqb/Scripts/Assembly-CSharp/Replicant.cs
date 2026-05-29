public class Replicant : Card
{
	public override void CardSetUp()
	{
		cost = "xy";
		card_txt = "Replicant Robot\nCost: two wild\nStart of turn: Gain a wild die";
		card_txt_cn = "复制机器人\n费用：两个百搭\n回合开始：获得一个百搭骰";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.GenerateDice(1, DiceType.Wild, preserve: false);
		Shine();
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
}
