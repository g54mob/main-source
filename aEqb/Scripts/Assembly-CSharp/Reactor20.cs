public class Reactor20 : Card
{
	public override void CardSetUp()
	{
		sumCost = 20;
		card_txt = "Reactor\nCost: Sum=20\nClick: 1 dice>Split its value into 2 dice";
		card_txt_cn = "反应堆\n费用：总和=20\n点击：一个骰子>将其点数拆分成两个骰子";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("b"))
		{
			int val = gm.selected_dice[0].val;
			if (val != 1)
			{
				energy--;
				gm.GenerateDice(val / 2, DiceType.Fixed, preserve: false);
				gm.GenerateDice((val + 1) / 2, DiceType.Fixed, preserve: false);
				gm.RemoveSelectedDice();
			}
		}
	}
}
