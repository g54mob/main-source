public class Transporter : Card
{
	public override void CardSetUp()
	{
		cost = "246";
		card_txt = "Transporter\nCost: 2, 4, 6\nStart of turn: +1 M.O.D.";
		card_txt_cn = "传送带\n费用：2, 4, 6\n回合开始: +1 M.O.D.";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		gm.mod++;
		Shine();
	}
}
