public class Printer : Card
{
	public override void CardSetUp()
	{
		cost = "123";
		card_txt = "3D Printer\nCost: 1, 2, 3\nClick: 1 > A wild die";
		card_txt_cn = "3D打印机\n费用：1, 2, 3\n点击：1 > 百搭";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("1"))
		{
			gm.RemoveSelectedDice();
			gm.GenerateDice(1, DiceType.Wild, preserve: false);
			energy--;
		}
	}
}
