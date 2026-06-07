public class Laboratory : Card
{
	public override void CardSetUp()
	{
		card_txt = "Laboratory\nClick: A pair > Draw a Blueprint.";
		card_txt_cn = "实验室\n点击：一个对子 > 抽一张蓝图";
		cardType = CardType.Basic;
		maxenergy = 1;
	}

	public override void Activate()
	{
		if (gm.testMode)
		{
			gm.AddBlueprint();
		}
		else if (Match("aa"))
		{
			gm.RemoveSelectedDice();
			energy--;
			gm.AddBlueprint();
		}
	}
}
