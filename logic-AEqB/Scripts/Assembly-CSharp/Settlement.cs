public class Settlement : Card
{
	public override void CardSetUp()
	{
		cost = "abcd";
		card_txt = "Settlement\nCost: four in a row\nStart of turn: Roll a Basic die";
		card_txt_cn = "定居点\n费用：四连\n回合开始：投一个基础骰";
		cardType = CardType.Building;
	}

	public override void EnterPlay()
	{
		gm.maxDice++;
	}

	public override void StartOfTurn()
	{
		Shine();
	}
}
