public class Observatory : Card
{
	public override void CardSetUp()
	{
		cost = "456";
		card_txt = "Observatory\nCost: 4, 5, 6\nEnter play: draw a card\nGain 1 more M.O.D. when you discard a card";
		card_txt_cn = "天文台\n费用：4, 5, 6\n进场：抽一张牌\n弃牌时获得额外1点M.O.D.";
		cardType = CardType.Building;
	}

	public override void EnterPlay()
	{
		gm.AddBlueprint();
		gm.ability.Add("Observatory");
	}
}
