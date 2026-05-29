public class Vishnu : Card
{
	public override void CardSetUp()
	{
		cost = "666666";
		card_txt = "Vishnu Project\nCost: six 6s";
		card_txt_cn = "毗湿奴计划\n费用：六个6";
		cardType = CardType.Project;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
