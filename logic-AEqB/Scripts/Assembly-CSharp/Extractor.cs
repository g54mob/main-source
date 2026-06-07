public class Extractor : Card
{
	public override void CardSetUp()
	{
		cost = "456";
		card_txt = "Extractor\nCost: 4, 5, 6\nClick: A pair > A Preserved Wild.";
		card_txt_cn = "萃取机\n费用：4, 5, 6\n点击：对子 > 一个保存的百搭";
		cardType = CardType.Building;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (Match("aa"))
		{
			gm.RemoveSelectedDice();
			gm.GenerateDice(1, DiceType.Wild, preserve: true);
			energy--;
		}
	}
}
