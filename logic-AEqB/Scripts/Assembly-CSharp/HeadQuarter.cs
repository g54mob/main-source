public class HeadQuarter : Card
{
	public override void CardSetUp()
	{
		card_txt = "Headquarter\nStart of turn: Roll 4 Basic dice";
		card_txt_cn = "总部\n回合开始：投四个基础骰";
		cardType = CardType.Basic;
	}

	public override void StartOfTurn()
	{
		Shine();
	}
}
