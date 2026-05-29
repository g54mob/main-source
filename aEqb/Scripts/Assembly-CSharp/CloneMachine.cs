public class CloneMachine : Card
{
	public override void CardSetUp()
	{
		cost = "abcde";
		card_txt = "Clone Machine\nCost: five in a row\nClick: Select a die, generate a fixed copy of it";
		card_txt_cn = "克隆机\n费用：五连\n点击：选择一个骰子，生成一个点数相同的固定骰";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("x"))
		{
			int val = gm.selected_dice[0].val;
			energy--;
			gm.GenerateDice(val, DiceType.Fixed, preserve: false);
		}
	}
}
