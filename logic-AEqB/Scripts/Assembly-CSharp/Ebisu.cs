public class Ebisu : Card
{
	public override void CardSetUp()
	{
		cost = "111111";
		card_txt = "Inari Project\nCost: six 1s";
		card_txt_cn = "稻荷神计划\n费用：六个1";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
