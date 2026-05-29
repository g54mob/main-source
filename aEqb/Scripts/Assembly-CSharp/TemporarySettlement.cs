public class TemporarySettlement : Card
{
	public override void CardSetUp()
	{
		cost = "abc";
		card_txt = "Minor Settlement\nCost: three in a row\nStart of even round: Roll a Basic die";
		card_txt_cn = "小型定居点\n费用：三连\n偶数回合开始：投一个基础骰";
		cardType = CardType.Building;
	}

	public override void StartOfTurn()
	{
		if (gm.round % 2 == 0)
		{
			Shine();
			gm.GenerateDice(0, DiceType.Basic, preserve: false);
		}
	}
}
