public class Dajbog : Card
{
	public override void CardSetUp()
	{
		cost = "aaaaaaa";
		card_txt = "Dazbog Project\nCost: seven of a kind";
		card_txt_cn = "达兹伯格计划\n费用：七个相同";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
