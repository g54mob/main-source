public class Reactor12 : Card
{
	public override void CardSetUp()
	{
		sumCost = 12;
		card_txt = "Reactor\nCost: Sum=12\nClick: 2 dice>1 die of their sum";
		card_txt_cn = "反应堆\n费用：总和=12\n点击：两个骰子>点数为二者总和的骰子";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("xy"))
		{
			int num = gm.selected_dice[0].val + gm.selected_dice[1].val;
			if (num > 6)
			{
				num = 6;
			}
			gm.GenerateDice(num, DiceType.Fixed, preserve: false);
			gm.RemoveSelectedDice();
			energy--;
		}
	}
}
