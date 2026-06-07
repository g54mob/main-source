public class Mad : Card
{
	public override void CardSetUp()
	{
		cost = "aabb";
		card_txt = "Academy\nCost: two pairs in a row\nEnd of turn: Draw a card";
		card_txt_cn = "学院\n费用：二连对\n回合结束 : 抓一张牌";
		cardType = CardType.Building;
	}

	public override void EndOfTurn()
	{
		gm.AddBlueprint();
		Shine();
	}
}
