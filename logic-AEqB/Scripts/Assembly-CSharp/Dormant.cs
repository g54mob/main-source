public class Dormant : Card
{
	public override void CardSetUp()
	{
		cost = "135";
		card_txt = "Dormant Chamber\nCost: 1, 3, 5\nClick: A die > fix and preserve it";
		card_txt_cn = "休眠仓\n费用：1, 3, 5\n点击：一个骰子 > 将其固定并保存";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("x") && !gm.selected_dice[0].isPreserved)
		{
			int val = gm.selected_dice[0].val;
			gm.GenerateDice(val, DiceType.Fixed, preserve: true);
			gm.RemoveSelectedDice();
			energy--;
		}
	}
}
