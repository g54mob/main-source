public class Pangu : Card
{
	public override void CardSetUp()
	{
		cost = "";
		sumCost = 40;
		card_txt = "Pangu Project\nCost: Sum=40";
		card_txt_cn = "盘古计划\n费用：总和=40";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
