public class Vesta : Card
{
	public override void CardSetUp()
	{
		cost = "aaabbb";
		card_txt = "Vesta Project\nCost: two triples in a row\nCan't be purchased if you haven't built another card this turn";
		card_txt_cn = "维斯塔计划\n费用：相连的两个三同\n如果你本回合未购买其他卡牌，不能购买这张牌";
		cardType = CardType.Project;
	}

	public override bool SpecialCost()
	{
		if (gm.cardPurchase_cnt == 0)
		{
			return false;
		}
		return true;
	}

	public override void EnterPlay()
	{
		Shine();
	}
}
