public class SpaceBar : Card
{
	public override void CardSetUp()
	{
		card_txt = "Bar\nEnd of turn: +1 M.O.D. if no card purchase in this round.";
		card_txt_cn = "酒吧\n回合结束：如果本回合未购买卡牌，+1 M.O.D.";
		cardType = CardType.Basic;
		maxenergy = 0;
	}

	public override void EndOfTurn()
	{
		if (gm.cardPurchase_cnt == 0)
		{
			gm.mod++;
		}
	}
}
