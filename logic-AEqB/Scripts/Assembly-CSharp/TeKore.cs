public class TeKore : Card
{
	public override void CardSetUp()
	{
		card_txt = "Te Kore Project\nCost: two sets of four of a kind";
		card_txt_cn = "特-刻瑞计划\n费用：两组四同";
		cardType = CardType.Project;
		cost = "xxxxyyyy";
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
