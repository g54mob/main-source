public class Reactor25 : Card
{
	public override void CardSetUp()
	{
		sumCost = 25;
		card_txt = "Reactor\nCost: Sum=25\nClick: 1 die > a die of its value + 1 and a die of its value - 1";
		card_txt_cn = "反应堆\n费用：总和=25\n点击：一个骰子 > 一个点数+1的骰子和一个点数-1的骰子";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("b"))
		{
			int val = gm.selected_dice[0].val;
			if (val != 1 && val != 6)
			{
				energy--;
				gm.GenerateDice(val - 1, DiceType.Fixed, preserve: false);
				gm.GenerateDice(val + 1, DiceType.Fixed, preserve: false);
				gm.RemoveSelectedDice();
			}
		}
	}
}
