public class Shuttle : Card
{
	public override void CardSetUp()
	{
		cost = "aaa";
		card_txt = "Shuttle\nCost: Three of a kind\nEnter play: +2 M.O.D.\nYou may mod 6 into 1 or 1 into 6";
		card_txt_cn = "穿梭机\n费用：三同\n进场: +2 M.O.D.\n你可以将6修改成1，或者将1修改成6";
		cardType = CardType.Building;
	}

	public override void EnterPlay()
	{
		gm.mod += 2;
		gm.ability.Add("Shuttle");
	}
}
